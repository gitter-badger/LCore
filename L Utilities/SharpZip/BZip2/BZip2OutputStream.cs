// BZip2OutputStream.cs
//
// Copyright (C) 2001 Mike Krueger
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// Linking this library statically or dynamically with other modules is
// making a combined work based on this library.  Thus, the terms and
// conditions of the GNU General Public License cover the whole
// combination.
// 
// As a special exception, the copyright holders of this library give you
// permission to link this library with independent modules to produce an
// executable, regardless of the license terms of these independent
// modules, and to copy and distribute the resulting executable under
// terms of your choice, provided that you also meet, for each linked
// independent module, the terms and conditions of the license of that
// module.  An independent module is a module which is not derived from
// or based on this library.  If you modify this library, you may extend
// this exception to your version of the library, but you are not
// obligated to do so.  If you do not wish to do so, delete this
// exception statement from your version.

using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable SuggestBaseTypeForParameter

namespace ICSharpCode.SharpZipLib.BZip2
    {

    /// <summary>
    /// An output stream that compresses into the BZip2 format 
    /// including file header chars into another stream.
    /// </summary>
    public class BZip2OutputStream : Stream
        {
        #region Constants

        private const int SETMASK = 1 << 21;
        private const int CLEARMASK = ~SETMASK;
        private const int GREATER_ICOST = 15;
        private const int LESSER_ICOST = 0;
        private const int SMALL_THRESH = 20;
        private const int DEPTH_THRESH = 10;

        /*--
		If you are ever unlucky/improbable enough
		to get a stack overflow whilst sorting,
		increase the following constant and try
		again.  In practice I have never seen the
		stack go above 27 elems, so the following
		limit seems very generous.
		--*/
        private const int QSORT_STACK_SIZE = 1000;

        /*--
		Knuth's increments seem to work better
		than Incerpi-Sedgewick here.  Possibly
		because the number of elems to sort is
		usually small, typically <= 20.
		--*/

        private readonly int[] increments = {
            1, 4, 13, 40, 121, 364, 1093, 3280,
            9841, 29524, 88573, 265720,
            797161, 2391484
            };
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise a new instance of the <see cref="BZip2OutputStream"></see> 
        /// for the specified stream, using the given blocksize.
        /// </summary>
        /// <param name="stream">The stream to write compressed data to.</param>
        /// <param name="blockSize">The block size to use.</param>
        /// <remarks>
        /// Valid block sizes are in the range 1..9, with 1 giving 
        /// the lowest compression and 9 the highest.
        /// </remarks>
        public BZip2OutputStream(Stream stream, int blockSize = 9)
            {
            this.BsSetStream(stream);

            this.workFactor = 50;
            if (blockSize > 9)
                {
                blockSize = 9;
                }

            if (blockSize < 1)
                {
                blockSize = 1;
                }
            this.blockSize100k = blockSize;
            this.AllocateCompressStructures();
            this.Initialize();
            this.InitBlock();
            }
        #endregion

        #region Destructor
        /// <summary>
        /// Ensures that resources are freed and other cleanup operations 
        /// are performed when the garbage collector reclaims the BZip2OutputStream.
        /// </summary>
        ~BZip2OutputStream()
            {
            this.Dispose(false);
            }
        #endregion

        /// <summary>
        /// Get/set flag indicating ownership of underlying stream.
        /// When the flag is true <see cref="Close"></see> will close the underlying stream also.
        /// </summary>
        public bool IsStreamOwner { get; } = true;

        #region Stream overrides
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking
        /// </summary>
        public override bool CanSeek => false;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing
        /// </summary>
        public override bool CanWrite => this.baseStream.CanWrite;

        /// <summary>
        /// Gets the length in bytes of the stream
        /// </summary>
        public override long Length => this.baseStream.Length;

        /// <summary>
        /// Gets or sets the current position of this stream.
        /// </summary>
        public override long Position
            {
            get
                {
                return this.baseStream.Position;
                }
            set
                {
                throw new NotSupportedException("BZip2OutputStream position cannot be set");
                }
            }

        /// <summary>
        /// Sets the current position of this stream to the given value.
        /// </summary>
        /// <param name="offset">The point relative to the offset from which to being seeking.</param>
        /// <param name="origin">The reference point from which to begin seeking.</param>
        /// <returns>The new position in the stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
            {
            throw new NotSupportedException("BZip2OutputStream Seek not supported");
            }

        /// <summary>
        /// Sets the length of this stream to the given value.
        /// </summary>
        /// <param name="value">The new stream length.</param>
        public override void SetLength(long value)
            {
            throw new NotSupportedException("BZip2OutputStream SetLength not supported");
            }

        /// <summary>
        /// Read a byte from the stream advancing the position.
        /// </summary>
        /// <returns>The byte read cast to an int; -1 if end of stream.</returns>
        public override int ReadByte()
            {
            throw new NotSupportedException("BZip2OutputStream ReadByte not supported");
            }

        /// <summary>
        /// Read a block of bytes
        /// </summary>
        /// <param name="buffer">The buffer to read into.</param>
        /// <param name="offset">The offset in the buffer to start storing data at.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read. This might be less than the number of bytes
        /// requested if that number of bytes are not currently available, or zero 
        /// if the end of the stream is reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
            {
            throw new NotSupportedException("BZip2OutputStream Read not supported");
            }

        /// <summary>
        /// Write a block of bytes to the stream
        /// </summary>
        /// <param name="buffer">The buffer containing data to write.</param>
        /// <param name="offset">The offset of the first byte to write.</param>
        /// <param name="count">The number of bytes to write.</param>
        public override void Write(byte[] buffer, int offset, int count)
            {
            if (buffer == null)
                {
                throw new ArgumentNullException(nameof(buffer));
                }

            if (offset < 0)
                {
                throw new ArgumentOutOfRangeException(nameof(offset));
                }

            if (count < 0)
                {
                throw new ArgumentOutOfRangeException(nameof(count));
                }

            if (buffer.Length - offset < count)
                {
                throw new ArgumentException("Offset/count out of range");
                }

            for (int i = 0; i < count; ++i)
                {
                this.WriteByte(buffer[offset + i]);
                }
            }

        /// <summary>
        /// Write a byte to the stream.
        /// </summary>
        /// <param name="value">The byte to write to the stream.</param>
        public override void WriteByte(byte value)
            {
            int b = (256 + value) % 256;
            if (this.currentChar != -1)
                {
                if (this.currentChar == b)
                    {
                    this.runLength++;
                    if (this.runLength > 254)
                        {
                        this.WriteRun();
                        this.currentChar = -1;
                        this.runLength = 0;
                        }
                    }
                else
                    {
                    this.WriteRun();
                    this.runLength = 1;
                    this.currentChar = b;
                    }
                }
            else
                {
                this.currentChar = b;
                this.runLength++;
                }
            }

        /// <summary>
        /// End the current block and end compression.
        /// Close the stream and free any resources
        /// </summary>
        public override void Close()
            {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            }

        #endregion

        private void MakeMaps()
            {
            this.nInUse = 0;
            for (int i = 0; i < 256; i++)
                {
                if (this.inUse[i])
                    {
                    this.seqToUnseq[this.nInUse] = (char)i;
                    this.unseqToSeq[i] = (char)this.nInUse;
                    this.nInUse++;
                    }
                }
            }

        /// <summary>
        /// Get the number of bytes written to output.
        /// </summary>
        private void WriteRun()
            {
            if (this.last < this.allowableBlockSize)
                {
                this.inUse[this.currentChar] = true;
                for (int i = 0; i < this.runLength; i++)
                    {
                    this.mCrc.Update(this.currentChar);
                    }

                switch (this.runLength)
                    {
                    case 1:
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        break;
                    case 2:
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        break;
                    case 3:
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        break;
                    default:
                        this.inUse[this.runLength - 4] = true;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)this.currentChar;
                        this.last++;
                        this.block[this.last + 1] = (byte)(this.runLength - 4);
                        break;
                    }
                }
            else
                {
                this.EndBlock();
                this.InitBlock();
                this.WriteRun();
                }
            }

        /// <summary>
        /// Get the number of bytes written to the output.
        /// </summary>
        public int BytesWritten => this.bytesOut;

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="BZip2OutputStream"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
#if NET_1_0 || NET_1_1 || NETCF_1_0
		protected virtual void Dispose(bool disposing)
#else
        protected override void Dispose(bool disposing)
#endif
            {
            try
                {
#if !NET_1_0 && !NET_1_1 && !NETCF_1_0
                base.Dispose(disposing);
#endif
                if (!this.disposed_)
                    {
                    this.disposed_ = true;

                    if (this.runLength > 0)
                        {
                        this.WriteRun();
                        }

                    this.currentChar = -1;
                    this.EndBlock();
                    this.EndCompression();
                    this.Flush();
                    }
                }
            finally
                {
                if (disposing)
                    {
                    if (this.IsStreamOwner)
                        {
                        this.baseStream.Close();
                        }
                    }
                }
            }

        /// <summary>
        /// Flush output buffers
        /// </summary>		
        public override void Flush()
            {
            this.baseStream.Flush();
            }

        private void Initialize()
            {
            this.bytesOut = 0;
            this.nBlocksRandomised = 0;

            /*--- Write header `magic' bytes indicating file-format == huffmanised,
			followed by a digit indicating blockSize100k.
			---*/

            this.BsPutUChar('B');
            this.BsPutUChar('Z');

            this.BsPutUChar('h');
            this.BsPutUChar('0' + this.blockSize100k);

            this.combinedCRC = 0;
            }

        private void InitBlock()
            {
            this.mCrc.Reset();
            this.last = -1;

            for (int i = 0; i < 256; i++)
                {
                this.inUse[i] = false;
                }

            /*--- 20 is just a paranoia constant ---*/
            this.allowableBlockSize = BZip2Constants.BaseBlockSize * this.blockSize100k - 20;
            }

        private void EndBlock()
            {
            if (this.last < 0)
                {       // dont do anything for empty files, (makes empty files compatible with original Bzip)
                return;
                }

            this.blockCRC = unchecked((uint)this.mCrc.Value);
            this.combinedCRC = (this.combinedCRC << 1) | (this.combinedCRC >> 31);
            this.combinedCRC ^= this.blockCRC;

            /*-- sort the block and establish position of original string --*/
            this.DoReversibleTransformation();

            /*--
			A 6-byte block header, the value chosen arbitrarily
			as 0x314159265359 :-).  A 32 bit value does not really
			give a strong enough guarantee that the value will not
			appear by chance in the compressed datastream.  Worst-case
			probability of this event, for a 900k block, is about
			2.0e-3 for 32 bits, 1.0e-5 for 40 bits and 4.0e-8 for 48 bits.
			For a compressed file of size 100Gb -- about 100000 blocks --
			only a 48-bit marker will do.  NB: normal compression/
			decompression do *not* rely on these statistical properties.
			They are only important when trying to recover blocks from
			damaged files.
			--*/
            this.BsPutUChar(0x31);
            this.BsPutUChar(0x41);
            this.BsPutUChar(0x59);
            this.BsPutUChar(0x26);
            this.BsPutUChar(0x53);
            this.BsPutUChar(0x59);

            /*-- Now the block's CRC, so it is in a known place. --*/
            unchecked
                {
                this.BsPutint((int)this.blockCRC);
                }

            /*-- Now a single bit indicating randomisation. --*/
            if (this.blockRandomised)
                {
                this.BsW(1, 1);
                this.nBlocksRandomised++;
                }
            else
                {
                this.BsW(1, 0);
                }

            /*-- Finally, block's contents proper. --*/
            this.MoveToFrontCodeAndSend();
            }

        private void EndCompression()
            {
            /*--
			Now another magic 48-bit number, 0x177245385090, to
			indicate the end of the last block.  (sqrt(pi), if
			you want to know.  I did want to use e, but it contains
			too much repetition -- 27 18 28 18 28 46 -- for me
			to feel statistically comfortable.  Call me paranoid.)
			--*/
            this.BsPutUChar(0x17);
            this.BsPutUChar(0x72);
            this.BsPutUChar(0x45);
            this.BsPutUChar(0x38);
            this.BsPutUChar(0x50);
            this.BsPutUChar(0x90);

            unchecked
                {
                this.BsPutint((int)this.combinedCRC);
                }

            this.BsFinishedWithStream();
            }

        private void BsSetStream(Stream stream)
            {
            this.baseStream = stream;
            this.bsLive = 0;
            this.bsBuff = 0;
            this.bytesOut = 0;
            }

        private void BsFinishedWithStream()
            {
            while (this.bsLive > 0)
                {
                int ch = this.bsBuff >> 24;
                this.baseStream.WriteByte((byte)ch); // write 8-bit
                this.bsBuff <<= 8;
                this.bsLive -= 8;
                this.bytesOut++;
                }
            }

        private void BsW(int n, int v)
            {
            while (this.bsLive >= 8)
                {
                int ch = this.bsBuff >> 24;
                unchecked
                    {
                    this.baseStream.WriteByte((byte)ch);
                    } // write 8-bit
                this.bsBuff <<= 8;
                this.bsLive -= 8;
                ++this.bytesOut;
                }
            this.bsBuff |= v << (32 - this.bsLive - n);
            this.bsLive += n;
            }

        private void BsPutUChar(int c)
            {
            this.BsW(8, c);
            }

        private void BsPutint(int u)
            {
            this.BsW(8, (u >> 24) & 0xFF);
            this.BsW(8, (u >> 16) & 0xFF);
            this.BsW(8, (u >> 8) & 0xFF);
            this.BsW(8, u & 0xFF);
            }

        private void BsPutIntVS(int numBits, int c)
            {
            this.BsW(numBits, c);
            }

        private void SendMTFValues()
            {
            char[][] len = new char[BZip2Constants.GroupCount][];
            for (int i = 0; i < BZip2Constants.GroupCount; ++i)
                {
                len[i] = new char[BZip2Constants.MaximumAlphaSize];
                }

            int ge;
            int iter;
            int nSelectors = 0;
            int nGroups;

            int alphaSize = this.nInUse + 2;
            for (int t = 0; t < BZip2Constants.GroupCount; t++)
                {
                for (int v = 0; v < alphaSize; v++)
                    {
                    len[t][v] = (char)GREATER_ICOST;
                    }
                }

            /*--- Decide how many coding tables to use ---*/
            if (this.nMTF <= 0)
                {
                Panic();
                }

            if (this.nMTF < 200)
                {
                nGroups = 2;
                }
            else if (this.nMTF < 600)
                {
                nGroups = 3;
                }
            else if (this.nMTF < 1200)
                {
                nGroups = 4;
                }
            else if (this.nMTF < 2400)
                {
                nGroups = 5;
                }
            else
                {
                nGroups = 6;
                }

            /*--- Generate an initial set of coding tables ---*/
            int nPart = nGroups;
            int remF = this.nMTF;
            int gs = 0;
            while (nPart > 0)
                {
                int tFreq = remF / nPart;
                int aFreq = 0;
                ge = gs - 1;
                while (aFreq < tFreq && ge < alphaSize - 1)
                    {
                    ge++;
                    aFreq += this.mtfFreq[ge];
                    }

                if (ge > gs && nPart != nGroups && nPart != 1 && ((nGroups - nPart) % 2 == 1))
                    {
                    aFreq -= this.mtfFreq[ge];
                    ge--;
                    }

                for (int v = 0; v < alphaSize; v++)
                    {
                    if (v >= gs && v <= ge)
                        {
                        len[nPart - 1][v] = (char)LESSER_ICOST;
                        }
                    else
                        {
                        len[nPart - 1][v] = (char)GREATER_ICOST;
                        }
                    }

                nPart--;
                gs = ge + 1;
                remF -= aFreq;
                }

            int[][] rfreq = new int[BZip2Constants.GroupCount][];
            for (int i = 0; i < BZip2Constants.GroupCount; ++i)
                {
                rfreq[i] = new int[BZip2Constants.MaximumAlphaSize];
                }

            int[] fave = new int[BZip2Constants.GroupCount];
            short[] cost = new short[BZip2Constants.GroupCount];
            /*---
			Iterate up to N_ITERS times to improve the tables.
			---*/
            for (iter = 0; iter < BZip2Constants.NumberOfIterations; ++iter)
                {
                for (int t = 0; t < nGroups; ++t)
                    {
                    fave[t] = 0;
                    }

                for (int t = 0; t < nGroups; ++t)
                    {
                    for (int v = 0; v < alphaSize; ++v)
                        {
                        rfreq[t][v] = 0;
                        }
                    }

                nSelectors = 0;
                gs = 0;
                while (true)
                    {
                    /*--- Set group start & end marks. --*/
                    if (gs >= this.nMTF)
                        {
                        break;
                        }
                    ge = gs + BZip2Constants.GroupSize - 1;
                    if (ge >= this.nMTF)
                        {
                        ge = this.nMTF - 1;
                        }

                    /*--
					Calculate the cost of this group as coded
					by each of the coding tables.
					--*/
                    for (int t = 0; t < nGroups; t++)
                        {
                        cost[t] = 0;
                        }

                    if (nGroups == 6)
                        {
                        short cost1, cost2, cost3, cost4, cost5;
                        short cost0 = cost1 = cost2 = cost3 = cost4 = cost5 = 0;
                        for (int i = gs; i <= ge; ++i)
                            {
                            short icv = this.szptr[i];
                            cost0 += (short)len[0][icv];
                            cost1 += (short)len[1][icv];
                            cost2 += (short)len[2][icv];
                            cost3 += (short)len[3][icv];
                            cost4 += (short)len[4][icv];
                            cost5 += (short)len[5][icv];
                            }
                        cost[0] = cost0;
                        cost[1] = cost1;
                        cost[2] = cost2;
                        cost[3] = cost3;
                        cost[4] = cost4;
                        cost[5] = cost5;
                        }
                    else
                        {
                        for (int i = gs; i <= ge; ++i)
                            {
                            short icv = this.szptr[i];
                            for (int t = 0; t < nGroups; t++)
                                {
                                cost[t] += (short)len[t][icv];
                                }
                            }
                        }

                    /*--
					Find the coding table which is best for this group,
					and record its identity in the selector table.
					--*/
                    int bc = 999999999;
                    int bt = -1;
                    for (int t = 0; t < nGroups; ++t)
                        {
                        if (cost[t] < bc)
                            {
                            bc = cost[t];
                            bt = t;
                            }
                        }
                    fave[bt]++;
                    this.selector[nSelectors] = (char)bt;
                    nSelectors++;

                    /*--
					Increment the symbol frequencies for the selected table.
					--*/
                    for (int i = gs; i <= ge; ++i)
                        {
                        ++rfreq[bt][this.szptr[i]];
                        }

                    gs = ge + 1;
                    }

                /*--
				Recompute the tables based on the accumulated frequencies.
				--*/
                for (int t = 0; t < nGroups; ++t)
                    {
                    HbMakeCodeLengths(len[t], rfreq[t], alphaSize, 20);
                    }
                }

            if (!(nGroups < 8))
                {
                Panic();
                }

            if (!(nSelectors < 32768 && nSelectors <= 2 + 900000 / BZip2Constants.GroupSize))
                {
                Panic();
                }

            /*--- Compute MTF values for the selectors. ---*/
            char[] pos = new char[BZip2Constants.GroupCount];

            for (int i = 0; i < nGroups; i++)
                {
                pos[i] = (char)i;
                }

            for (int i = 0; i < nSelectors; i++)
                {
                char ll_i = this.selector[i];
                int j = 0;
                char tmp = pos[j];
                while (ll_i != tmp)
                    {
                    j++;
                    char tmp2 = tmp;
                    tmp = pos[j];
                    pos[j] = tmp2;
                    }
                pos[0] = tmp;
                this.selectorMtf[i] = (char)j;
                }

            int[][] code = new int[BZip2Constants.GroupCount][];

            for (int i = 0; i < BZip2Constants.GroupCount; ++i)
                {
                code[i] = new int[BZip2Constants.MaximumAlphaSize];
                }

            /*--- Assign actual codes for the tables. --*/
            for (int t = 0; t < nGroups; t++)
                {
                int minLen = 32;
                int maxLen = 0;
                for (int i = 0; i < alphaSize; i++)
                    {
                    if (len[t][i] > maxLen)
                        {
                        maxLen = len[t][i];
                        }
                    if (len[t][i] < minLen)
                        {
                        minLen = len[t][i];
                        }
                    }
                if (maxLen > 20)
                    {
                    Panic();
                    }
                if (minLen < 1)
                    {
                    Panic();
                    }
                HbAssignCodes(code[t], len[t], minLen, maxLen, alphaSize);
                }

            /*--- Transmit the mapping table. ---*/
            bool[] inUse16 = new bool[16];
            for (int i = 0; i < 16; ++i)
                {
                inUse16[i] = false;
                for (int j = 0; j < 16; ++j)
                    {
                    if (this.inUse[i * 16 + j])
                        {
                        inUse16[i] = true;
                        }
                    }
                }

            for (int i = 0; i < 16; ++i)
                {
                this.BsW(1, inUse16[i] ? 1 : 0);
                }

            for (int i = 0; i < 16; ++i)
                {
                if (inUse16[i])
                    {
                    for (int j = 0; j < 16; ++j)
                        {
                        this.BsW(1, this.inUse[i * 16 + j] ? 1 : 0);
                        }
                    }
                }

            /*--- Now the selectors. ---*/
            this.BsW(3, nGroups);
            this.BsW(15, nSelectors);
            for (int i = 0; i < nSelectors; ++i)
                {
                for (int j = 0; j < this.selectorMtf[i]; ++j)
                    {
                    this.BsW(1, 1);
                    }
                this.BsW(1, 0);
                }

            /*--- Now the coding tables. ---*/
            for (int t = 0; t < nGroups; ++t)
                {
                int curr = len[t][0];
                this.BsW(5, curr);
                for (int i = 0; i < alphaSize; ++i)
                    {
                    while (curr < len[t][i])
                        {
                        this.BsW(2, 2);
                        curr++; /* 10 */
                        }
                    while (curr > len[t][i])
                        {
                        this.BsW(2, 3);
                        curr--; /* 11 */
                        }
                    this.BsW(1, 0);
                    }
                }

            /*--- And finally, the block data proper ---*/
            int selCtr = 0;
            gs = 0;
            while (true)
                {
                if (gs >= this.nMTF)
                    {
                    break;
                    }
                ge = gs + BZip2Constants.GroupSize - 1;
                if (ge >= this.nMTF)
                    {
                    ge = this.nMTF - 1;
                    }

                for (int i = gs; i <= ge; i++)
                    {
                    this.BsW(len[this.selector[selCtr]][this.szptr[i]], code[this.selector[selCtr]][this.szptr[i]]);
                    }

                gs = ge + 1;
                ++selCtr;
                }
            if (selCtr != nSelectors)
                {
                Panic();
                }
            }

        private void MoveToFrontCodeAndSend()
            {
            this.BsPutIntVS(24, this.origPtr);
            this.GenerateMTFValues();
            this.SendMTFValues();
            }

        private void SimpleSort(int lo, int hi, int d)
            {
            int bigN = hi - lo + 1;
            if (bigN < 2)
                {
                return;
                }

            int hp = 0;
            while (this.increments[hp] < bigN)
                {
                hp++;
                }
            hp--;

            for (; hp >= 0; hp--)
                {
                int h = this.increments[hp];

                int i = lo + h;
                while (true)
                    {
                    /*-- copy 1 --*/
                    if (i > hi)
                        break;
                    int v = this.zptr[i];
                    int j = i;
                    while (this.FullGtU(this.zptr[j - h] + d, v + d))
                        {
                        this.zptr[j] = this.zptr[j - h];
                        j = j - h;
                        if (j <= lo + h - 1)
                            break;
                        }
                    this.zptr[j] = v;
                    i++;

                    /*-- copy 2 --*/
                    if (i > hi)
                        {
                        break;
                        }
                    v = this.zptr[i];
                    j = i;
                    while (this.FullGtU(this.zptr[j - h] + d, v + d))
                        {
                        this.zptr[j] = this.zptr[j - h];
                        j = j - h;
                        if (j <= lo + h - 1)
                            {
                            break;
                            }
                        }
                    this.zptr[j] = v;
                    i++;

                    /*-- copy 3 --*/
                    if (i > hi)
                        {
                        break;
                        }
                    v = this.zptr[i];
                    j = i;
                    while (this.FullGtU(this.zptr[j - h] + d, v + d))
                        {
                        this.zptr[j] = this.zptr[j - h];
                        j = j - h;
                        if (j <= lo + h - 1)
                            {
                            break;
                            }
                        }
                    this.zptr[j] = v;
                    i++;

                    if (this.workDone > this.workLimit && this.firstAttempt)
                        {
                        return;
                        }
                    }
                }
            }

        private void Vswap(int p1, int p2, int n)
            {
            while (n > 0)
                {
                int temp = this.zptr[p1];
                this.zptr[p1] = this.zptr[p2];
                this.zptr[p2] = temp;
                p1++;
                p2++;
                n--;
                }
            }

        private void QSort3(int loSt, int hiSt, int dSt)
            {
            StackElement[] stack = new StackElement[QSORT_STACK_SIZE];

            int sp = 0;

            stack[sp].ll = loSt;
            stack[sp].hh = hiSt;
            stack[sp].dd = dSt;
            sp++;

            while (sp > 0)
                {
                if (sp >= QSORT_STACK_SIZE)
                    {
                    Panic();
                    }

                sp--;
                int lo = stack[sp].ll;
                int hi = stack[sp].hh;
                int d = stack[sp].dd;

                if (hi - lo < SMALL_THRESH || d > DEPTH_THRESH)
                    {
                    this.SimpleSort(lo, hi, d);
                    if (this.workDone > this.workLimit && this.firstAttempt)
                        {
                        return;
                        }
                    continue;
                    }

                int med = Med3(this.block[this.zptr[lo] + d + 1], this.block[this.zptr[hi] + d + 1], this.block[this.zptr[(lo + hi) >> 1] + d + 1]);

                int ltLo;
                int unLo = ltLo = lo;
                int gtHi;
                int unHi = gtHi = hi;

                int n;
                while (true)
                    {
                    while (true)
                        {
                        if (unLo > unHi)
                            {
                            break;
                            }
                        n = this.block[this.zptr[unLo] + d + 1] - med;
                        if (n == 0)
                            {
                            int temp = this.zptr[unLo];
                            this.zptr[unLo] = this.zptr[ltLo];
                            this.zptr[ltLo] = temp;
                            ltLo++;
                            unLo++;
                            continue;
                            }
                        if (n > 0)
                            {
                            break;
                            }
                        unLo++;
                        }

                    while (true)
                        {
                        if (unLo > unHi)
                            {
                            break;
                            }
                        n = this.block[this.zptr[unHi] + d + 1] - med;
                        if (n == 0)
                            {
                            int temp = this.zptr[unHi];
                            this.zptr[unHi] = this.zptr[gtHi];
                            this.zptr[gtHi] = temp;
                            gtHi--;
                            unHi--;
                            continue;
                            }
                        if (n < 0)
                            {
                            break;
                            }
                        unHi--;
                        }

                    if (unLo > unHi)
                        {
                        break;
                        }

                        {
                        int temp = this.zptr[unLo];
                        this.zptr[unLo] = this.zptr[unHi];
                        this.zptr[unHi] = temp;
                        unLo++;
                        unHi--;
                        }
                    }

                if (gtHi < ltLo)
                    {
                    stack[sp].ll = lo;
                    stack[sp].hh = hi;
                    stack[sp].dd = d + 1;
                    sp++;
                    continue;
                    }

                n = ltLo - lo < unLo - ltLo ? ltLo - lo : unLo - ltLo;
                this.Vswap(lo, unLo - n, n);
                int m = hi - gtHi < gtHi - unHi ? hi - gtHi : gtHi - unHi;
                this.Vswap(unLo, hi - m + 1, m);

                n = lo + unLo - ltLo - 1;
                m = hi - (gtHi - unHi) + 1;

                stack[sp].ll = lo;
                stack[sp].hh = n;
                stack[sp].dd = d;
                sp++;

                stack[sp].ll = n + 1;
                stack[sp].hh = m - 1;
                stack[sp].dd = d + 1;
                sp++;

                stack[sp].ll = m;
                stack[sp].hh = hi;
                stack[sp].dd = d;
                sp++;
                }
            }

        private void MainSort()
            {
            int i;
            int[] runningOrder = new int[256];
            int[] copy = new int[256];
            bool[] bigDone = new bool[256];

            /*--
			In the various block-sized structures, live data runs
			from 0 to last+NUM_OVERSHOOT_BYTES inclusive.  First,
			set up the overshoot area for block.
			--*/

            //   if (verbosity >= 4) fprintf ( stderr, "        sort initialise ...\n" );
            for (i = 0; i < BZip2Constants.OvershootBytes; i++)
                {
                this.block[this.last + i + 2] = this.block[i % (this.last + 1) + 1];
                }
            for (i = 0; i <= this.last + BZip2Constants.OvershootBytes; i++)
                {
                this.quadrant[i] = 0;
                }

            this.block[0] = this.block[this.last + 1];

            if (this.last < 4000)
                {
                /*--
				Use simpleSort(), since the full sorting mechanism
				has quite a large constant overhead.
				--*/
                for (i = 0; i <= this.last; i++)
                    {
                    this.zptr[i] = i;
                    }
                this.firstAttempt = false;
                this.workDone = this.workLimit = 0;
                this.SimpleSort(0, this.last, 0);
                }
            else
                {
                for (i = 0; i <= 255; i++)
                    {
                    bigDone[i] = false;
                    }
                for (i = 0; i <= 65536; i++)
                    {
                    this.ftab[i] = 0;
                    }

                int c1 = this.block[0];
                int c2;
                for (i = 0; i <= this.last; i++)
                    {
                    c2 = this.block[i + 1];
                    this.ftab[(c1 << 8) + c2]++;
                    c1 = c2;
                    }

                for (i = 1; i <= 65536; i++)
                    {
                    this.ftab[i] += this.ftab[i - 1];
                    }

                c1 = this.block[1];
                int j;
                for (i = 0; i < this.last; i++)
                    {
                    c2 = this.block[i + 2];
                    j = (c1 << 8) + c2;
                    c1 = c2;
                    this.ftab[j]--;
                    this.zptr[this.ftab[j]] = i;
                    }

                j = (this.block[this.last + 1] << 8) + this.block[1];
                this.ftab[j]--;
                this.zptr[this.ftab[j]] = this.last;

                /*--
				Now ftab contains the first loc of every small bucket.
				Calculate the running order, from smallest to largest
				big bucket.
				--*/

                for (i = 0; i <= 255; i++)
                    {
                    runningOrder[i] = i;
                    }

                int h = 1;
                do
                    {
                    h = 3 * h + 1;
                    } while (h <= 256);
                do
                    {
                    h = h / 3;
                    for (i = h; i <= 255; i++)
                        {
                        int vv = runningOrder[i];
                        j = i;
                        while (this.ftab[(runningOrder[j - h] + 1) << 8] - this.ftab[runningOrder[j - h] << 8] > this.ftab[(vv + 1) << 8] - this.ftab[vv << 8])
                            {
                            runningOrder[j] = runningOrder[j - h];
                            j = j - h;
                            if (j <= h - 1)
                                {
                                break;
                                }
                            }
                        runningOrder[j] = vv;
                        }
                    } while (h != 1);

                /*--
				The main sorting loop.
				--*/
                for (i = 0; i <= 255; i++)
                    {

                    /*--
					Process big buckets, starting with the least full.
					--*/
                    int ss = runningOrder[i];

                    /*--
					Complete the big bucket [ss] by quicksorting
					any unsorted small buckets [ss, j].  Hopefully
					previous pointer-scanning phases have already
					completed many of the small buckets [ss, j], so
					we don't have to sort them at all.
					--*/
                    for (j = 0; j <= 255; j++)
                        {
                        int sb = (ss << 8) + j;
                        if ((this.ftab[sb] & SETMASK) != SETMASK)
                            {
                            int lo = this.ftab[sb] & CLEARMASK;
                            int hi = (this.ftab[sb + 1] & CLEARMASK) - 1;
                            if (hi > lo)
                                {
                                this.QSort3(lo, hi, 2);
                                if (this.workDone > this.workLimit && this.firstAttempt)
                                    {
                                    return;
                                    }
                                }
                            this.ftab[sb] |= SETMASK;
                            }
                        }

                    /*--
                The ss big bucket is now done.  Record this fact,
                and update the quadrant descriptors.  Remember to
                update quadrants in the overshoot area too, if
                necessary.  The "if (i < 255)" test merely skips
                this updating for the last bucket processed, since
                updating for the last bucket is pointless.
                --*/
                    bigDone[ss] = true;

                    if (i < 255)
                        {
                        int bbStart = this.ftab[ss << 8] & CLEARMASK;
                        int bbSize = (this.ftab[(ss + 1) << 8] & CLEARMASK) - bbStart;
                        int shifts = 0;

                        while (bbSize >> shifts > 65534)
                            {
                            shifts++;
                            }

                        for (j = 0; j < bbSize; j++)
                            {
                            int a2update = this.zptr[bbStart + j];
                            int qVal = j >> shifts;
                            this.quadrant[a2update] = qVal;
                            if (a2update < BZip2Constants.OvershootBytes)
                                {
                                this.quadrant[a2update + this.last + 1] = qVal;
                                }
                            }

                        if (!((bbSize - 1) >> shifts <= 65535))
                            {
                            Panic();
                            }
                        }

                    /*--
					Now scan this big bucket so as to synthesise the
					sorted order for small buckets [t, ss] for all t != ss.
					--*/
                    for (j = 0; j <= 255; j++)
                        {
                        copy[j] = this.ftab[(j << 8) + ss] & CLEARMASK;
                        }

                    for (j = this.ftab[ss << 8] & CLEARMASK; j < (this.ftab[(ss + 1) << 8] & CLEARMASK); j++)
                        {
                        c1 = this.block[this.zptr[j]];
                        if (!bigDone[c1])
                            {
                            this.zptr[copy[c1]] = this.zptr[j] == 0 ? this.last : this.zptr[j] - 1;
                            copy[c1]++;
                            }
                        }

                    for (j = 0; j <= 255; j++)
                        {
                        this.ftab[(j << 8) + ss] |= SETMASK;
                        }
                    }
                }
            }

        private void RandomiseBlock()
            {
            int i;
            int rNToGo = 0;
            int rTPos = 0;
            for (i = 0; i < 256; i++)
                {
                this.inUse[i] = false;
                }

            for (i = 0; i <= this.last; i++)
                {
                if (rNToGo == 0)
                    {
                    rNToGo = BZip2Constants.RandomNumbers[rTPos];
                    rTPos++;
                    if (rTPos == 512)
                        {
                        rTPos = 0;
                        }
                    }
                rNToGo--;
                this.block[i + 1] ^= (byte)(rNToGo == 1 ? 1 : 0);
                // handle 16 bit signed numbers
                this.block[i + 1] &= 0xFF;

                this.inUse[this.block[i + 1]] = true;
                }
            }

        private void DoReversibleTransformation()
            {
            this.workLimit = this.workFactor * this.last;
            this.workDone = 0;
            this.blockRandomised = false;
            this.firstAttempt = true;

            this.MainSort();

            if (this.workDone > this.workLimit && this.firstAttempt)
                {
                this.RandomiseBlock();
                this.workLimit = this.workDone = 0;
                this.blockRandomised = true;
                this.firstAttempt = false;
                this.MainSort();
                }

            this.origPtr = -1;
            for (int i = 0; i <= this.last; i++)
                {
                if (this.zptr[i] == 0)
                    {
                    this.origPtr = i;
                    break;
                    }
                }

            if (this.origPtr == -1)
                {
                Panic();
                }
            }

        private bool FullGtU(int i1, int i2)
            {
            byte c1 = this.block[i1 + 1];
            byte c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            c1 = this.block[i1 + 1];
            c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            c1 = this.block[i1 + 1];
            c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            c1 = this.block[i1 + 1];
            c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            c1 = this.block[i1 + 1];
            c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            c1 = this.block[i1 + 1];
            c2 = this.block[i2 + 1];
            if (c1 != c2)
                {
                return c1 > c2;
                }
            i1++;
            i2++;

            int k = this.last + 1;

            do
                {
                c1 = this.block[i1 + 1];
                c2 = this.block[i2 + 1];
                if (c1 != c2)
                    {
                    return c1 > c2;
                    }
                int s1 = this.quadrant[i1];
                int s2 = this.quadrant[i2];
                if (s1 != s2)
                    {
                    return s1 > s2;
                    }
                i1++;
                i2++;

                c1 = this.block[i1 + 1];
                c2 = this.block[i2 + 1];
                if (c1 != c2)
                    {
                    return c1 > c2;
                    }
                s1 = this.quadrant[i1];
                s2 = this.quadrant[i2];
                if (s1 != s2)
                    {
                    return s1 > s2;
                    }
                i1++;
                i2++;

                c1 = this.block[i1 + 1];
                c2 = this.block[i2 + 1];
                if (c1 != c2)
                    {
                    return c1 > c2;
                    }
                s1 = this.quadrant[i1];
                s2 = this.quadrant[i2];
                if (s1 != s2)
                    {
                    return s1 > s2;
                    }
                i1++;
                i2++;

                c1 = this.block[i1 + 1];
                c2 = this.block[i2 + 1];
                if (c1 != c2)
                    {
                    return c1 > c2;
                    }
                s1 = this.quadrant[i1];
                s2 = this.quadrant[i2];
                if (s1 != s2)
                    {
                    return s1 > s2;
                    }
                i1++;
                i2++;

                if (i1 > this.last)
                    {
                    i1 -= this.last;
                    i1--;
                    }
                if (i2 > this.last)
                    {
                    i2 -= this.last;
                    i2--;
                    }

                k -= 4;
                ++this.workDone;
                } while (k >= 0);

            return false;
            }

        private void AllocateCompressStructures()
            {
            int n = BZip2Constants.BaseBlockSize * this.blockSize100k;
            this.block = new byte[n + 1 + BZip2Constants.OvershootBytes];
            this.quadrant = new int[n + BZip2Constants.OvershootBytes];
            this.zptr = new int[n];
            this.ftab = new int[65537];

            if (this.block == null || this.quadrant == null || this.zptr == null || this.ftab == null)
                {
                //		int totalDraw = (n + 1 + NUM_OVERSHOOT_BYTES) + (n + NUM_OVERSHOOT_BYTES) + n + 65537;
                //		compressOutOfMemory ( totalDraw, n );
                }

            /*
			The back end needs a place to store the MTF values
			whilst it calculates the coding tables.  We could
			put them in the zptr array.  However, these values
			will fit in a short, so we overlay szptr at the
			start of zptr, in the hope of reducing the number
			of cache misses induced by the multiple traversals
			of the MTF values when calculating coding tables.
			Seems to improve compression speed by about 1%.
			*/
            //	szptr = zptr;


            this.szptr = new short[2 * n];
            }

        private void GenerateMTFValues()
            {
            char[] yy = new char[256];
            int i;

            this.MakeMaps();
            int EOB = this.nInUse + 1;

            for (i = 0; i <= EOB; i++)
                {
                this.mtfFreq[i] = 0;
                }

            int wr = 0;
            int zPend = 0;
            for (i = 0; i < this.nInUse; i++)
                {
                yy[i] = (char)i;
                }


            for (i = 0; i <= this.last; i++)
                {
                char ll_i = this.unseqToSeq[this.block[this.zptr[i]]];

                int j = 0;
                char tmp = yy[j];
                while (ll_i != tmp)
                    {
                    j++;
                    char tmp2 = tmp;
                    tmp = yy[j];
                    yy[j] = tmp2;
                    }
                yy[0] = tmp;

                if (j == 0)
                    {
                    zPend++;
                    }
                else
                    {
                    if (zPend > 0)
                        {
                        zPend--;
                        while (true)
                            {
                            switch (zPend % 2)
                                {
                                case 0:
                                    this.szptr[wr] = BZip2Constants.RunA;
                                    wr++;
                                    this.mtfFreq[BZip2Constants.RunA]++;
                                    break;
                                case 1:
                                    this.szptr[wr] = BZip2Constants.RunB;
                                    wr++;
                                    this.mtfFreq[BZip2Constants.RunB]++;
                                    break;
                                }
                            if (zPend < 2)
                                {
                                break;
                                }
                            zPend = (zPend - 2) / 2;
                            }
                        zPend = 0;
                        }
                    this.szptr[wr] = (short)(j + 1);
                    wr++;
                    this.mtfFreq[j + 1]++;
                    }
                }

            if (zPend > 0)
                {
                zPend--;
                while (true)
                    {
                    switch (zPend % 2)
                        {
                        case 0:
                            this.szptr[wr] = BZip2Constants.RunA;
                            wr++;
                            this.mtfFreq[BZip2Constants.RunA]++;
                            break;
                        case 1:
                            this.szptr[wr] = BZip2Constants.RunB;
                            wr++;
                            this.mtfFreq[BZip2Constants.RunB]++;
                            break;
                        }
                    if (zPend < 2)
                        {
                        break;
                        }
                    zPend = (zPend - 2) / 2;
                    }
                }

            this.szptr[wr] = (short)EOB;
            wr++;
            this.mtfFreq[EOB]++;

            this.nMTF = wr;
            }

        private static void Panic()
            {
            throw new BZip2Exception("BZip2 output stream panic");
            }

        private static void HbMakeCodeLengths(char[] len, int[] freq, int alphaSize, int maxLen)
            {
            /*--
			Nodes and heap entries run from 1.  Entry 0
			for both the heap and nodes is a sentinel.
			--*/

            int[] heap = new int[BZip2Constants.MaximumAlphaSize + 2];
            int[] weight = new int[BZip2Constants.MaximumAlphaSize * 2];
            int[] parent = new int[BZip2Constants.MaximumAlphaSize * 2];

            for (int i = 0; i < alphaSize; ++i)
                {
                weight[i + 1] = (freq[i] == 0 ? 1 : freq[i]) << 8;
                }

            while (true)
                {
                int nNodes = alphaSize;
                int nHeap = 0;

                heap[0] = 0;
                weight[0] = 0;
                parent[0] = -2;

                for (int i = 1; i <= alphaSize; ++i)
                    {
                    parent[i] = -1;
                    nHeap++;
                    heap[nHeap] = i;
                    int zz = nHeap;
                    int tmp = heap[zz];
                    while (weight[tmp] < weight[heap[zz >> 1]])
                        {
                        heap[zz] = heap[zz >> 1];
                        zz >>= 1;
                        }
                    heap[zz] = tmp;
                    }
                if (!(nHeap < BZip2Constants.MaximumAlphaSize + 2))
                    {
                    Panic();
                    }

                while (nHeap > 1)
                    {
                    int n1 = heap[1];
                    heap[1] = heap[nHeap];
                    nHeap--;
                    int zz = 1;
                    int yy;
                    int tmp = heap[zz];
                    while (true)
                        {
                        yy = zz << 1;
                        if (yy > nHeap)
                            {
                            break;
                            }
                        if (yy < nHeap && weight[heap[yy + 1]] < weight[heap[yy]])
                            {
                            yy++;
                            }
                        if (weight[tmp] < weight[heap[yy]])
                            {
                            break;
                            }

                        heap[zz] = heap[yy];
                        zz = yy;
                        }
                    heap[zz] = tmp;
                    int n2 = heap[1];
                    heap[1] = heap[nHeap];
                    nHeap--;

                    zz = 1;
                    tmp = heap[zz];
                    while (true)
                        {
                        yy = zz << 1;
                        if (yy > nHeap)
                            {
                            break;
                            }
                        if (yy < nHeap && weight[heap[yy + 1]] < weight[heap[yy]])
                            {
                            yy++;
                            }
                        if (weight[tmp] < weight[heap[yy]])
                            {
                            break;
                            }
                        heap[zz] = heap[yy];
                        zz = yy;
                        }
                    heap[zz] = tmp;
                    nNodes++;
                    parent[n1] = parent[n2] = nNodes;

                    weight[nNodes] = (int)((weight[n1] & 0xffffff00) + (weight[n2] & 0xffffff00)) |
                        1 + ((weight[n1] & 0x000000ff) > (weight[n2] & 0x000000ff) ? weight[n1] & 0x000000ff : weight[n2] & 0x000000ff);

                    parent[nNodes] = -1;
                    nHeap++;
                    heap[nHeap] = nNodes;

                    zz = nHeap;
                    tmp = heap[zz];
                    while (weight[tmp] < weight[heap[zz >> 1]])
                        {
                        heap[zz] = heap[zz >> 1];
                        zz >>= 1;
                        }
                    heap[zz] = tmp;
                    }
                if (!(nNodes < BZip2Constants.MaximumAlphaSize * 2))
                    {
                    Panic();
                    }

                bool tooLong = false;
                int j;
                for (int i = 1; i <= alphaSize; ++i)
                    {
                    j = 0;
                    int k = i;
                    while (parent[k] >= 0)
                        {
                        k = parent[k];
                        j++;
                        }
                    len[i - 1] = (char)j;
                    if (j > maxLen)
                        {
                        tooLong = true;
                        }
                    }

                if (!tooLong)
                    {
                    break;
                    }

                for (int i = 1; i < alphaSize; ++i)
                    {
                    j = weight[i] >> 8;
                    j = 1 + j / 2;
                    weight[i] = j << 8;
                    }
                }
            }

        private static void HbAssignCodes(int[] code, char[] length, int minLen, int maxLen, int alphaSize)
            {
            int vec = 0;
            for (int n = minLen; n <= maxLen; ++n)
                {
                for (int i = 0; i < alphaSize; ++i)
                    {
                    if (length[i] == n)
                        {
                        code[i] = vec;
                        ++vec;
                        }
                    }
                vec <<= 1;
                }
            }

        private static byte Med3(byte a, byte b, byte c)
            {
            if (a > b)
                {
                byte t = a;
                a = b;
                b = t;
                }
            if (b > c)
                {
                b = c;
                }
            if (a > b)
                {
                b = a;
                }
            return b;
            }

        private struct StackElement
            {
            public int ll;
            public int hh;
            public int dd;
            }

        #region Instance Fields

        /*--
		index of the last char in the block, so
		the block size == last + 1.
		--*/
        private int last;

        /*--
		index in zptr[] of original string after sorting.
		--*/
        private int origPtr;

        /*--
		always: in the range 0 .. 9.
		The current block size is 100000 * this number.
		--*/
        private int blockSize100k;

        private bool blockRandomised;

        private int bytesOut;
        private int bsBuff;
        private int bsLive;
        private IChecksum mCrc = new StrangeCRC();

        private bool[] inUse = new bool[256];
        private int nInUse;

        private char[] seqToUnseq = new char[256];
        private char[] unseqToSeq = new char[256];

        private char[] selector = new char[BZip2Constants.MaximumSelectors];
        private char[] selectorMtf = new char[BZip2Constants.MaximumSelectors];

        private byte[] block;
        private int[] quadrant;
        private int[] zptr;
        private short[] szptr;
        private int[] ftab;

        private int nMTF;

        private int[] mtfFreq = new int[BZip2Constants.MaximumAlphaSize];

        /*
		* Used when sorting.  If too many long comparisons
		* happen, we stop sorting, randomise the block
		* slightly, and try again.
		*/
        private int workFactor;
        private int workDone;
        private int workLimit;
        private bool firstAttempt;
        private int nBlocksRandomised;

        private int currentChar = -1;
        private int runLength;
        private uint blockCRC;
        private uint combinedCRC;
        private int allowableBlockSize;
        private Stream baseStream;
        private bool disposed_;
        #endregion
        }
    }

/* This file was derived from a file containing this license:
 * 
 * This file is a part of bzip2 and/or libbzip2, a program and
 * library for lossless, block-sorting data compression.
 * 
 * Copyright (C) 1996-1998 Julian R Seward.  All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 * 1. Redistributions of source code must retain the above copyright
 * notice, this list of conditions and the following disclaimer.
 * 
 * 2. The origin of this software must not be misrepresented; you must 
 * not claim that you wrote the original software.  If you use this 
 * software in a product, an acknowledgment in the product 
 * documentation would be appreciated but is not required.
 * 
 * 3. Altered source versions must be plainly marked as such, and must
 * not be misrepresented as being the original software.
 * 
 * 4. The name of the author may not be used to endorse or promote 
 * products derived from this software without specific prior written 
 * permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS
 * OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE
 * GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * Java version ported by Keiron Liddle, Aftex Software <keiron@aftexsw.com> 1999-2001
 */
