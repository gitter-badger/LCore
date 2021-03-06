// Deflater.cs
//
// Copyright (C) 2001 Mike Krueger
// Copyright (C) 2004 John Reilly
//
// This file was translated from java, it was part of the GNU Classpath
// Copyright (C) 2001 Free Software Foundation, Inc.
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
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace ICSharpCode.SharpZipLib.Zip.Compression
    {

    /// <summary>
    /// This is the Deflater class.  The deflater class compresses input
    /// with the deflate algorithm described in RFC 1951.  It has several
    /// compression levels and three different strategies described below.
    ///
    /// This class is <i>not</i> thread safe.  This is inherent in the API, due
    /// to the split of deflate and setInput.
    /// 
    /// author of the original java version : Jochen Hoenicke
    /// </summary>
    public class Deflater
        {
        #region Deflater Documentation
        /*
		* The Deflater can do the following state transitions:
		*
		* (1) -> INIT_STATE   ----> INIT_FINISHING_STATE ---.
		*        /  | (2)      (5)                          |
		*       /   v          (5)                          |
		*   (3)| SETDICT_STATE ---> SETDICT_FINISHING_STATE |(3)
		*       \   | (3)                 |        ,--------'
		*        |  |                     | (3)   /
		*        v  v          (5)        v      v
		* (1) -> BUSY_STATE   ----> FINISHING_STATE
		*                                | (6)
		*                                v
		*                           FINISHED_STATE
		*    \_____________________________________/
		*                    | (7)
		*                    v
		*               CLOSED_STATE
		*
		* (1) If we should produce a header we start in INIT_STATE, otherwise
		*     we start in BUSY_STATE.
		* (2) A dictionary may be set only when we are in INIT_STATE, then
		*     we change the state as indicated.
		* (3) Whether a dictionary is set or not, on the first call of deflate
		*     we change to BUSY_STATE.
		* (4) -- intentionally left blank -- :)
		* (5) FINISHING_STATE is entered, when flush() is called to indicate that
		*     there is no more INPUT.  There are also states indicating, that
		*     the header wasn't written yet.
		* (6) FINISHED_STATE is entered, when everything has been flushed to the
		*     internal pending output buffer.
		* (7) At any time (7)
		*
		*/
        #endregion
        #region Public Constants
        /// <summary>
        /// The best and slowest compression level.  This tries to find very
        /// long and distant string repetitions.
        /// </summary>
        public const int BEST_COMPRESSION = 9;

        /// <summary>
        /// The worst but fastest compression level.
        /// </summary>
        public const int BEST_SPEED = 1;

        /// <summary>
        /// The default compression level.
        /// </summary>
        public const int DEFAULT_COMPRESSION = -1;

        /// <summary>
        /// This level won't compress at all but output uncompressed blocks.
        /// </summary>
        public const int NO_COMPRESSION = 0;

        /// <summary>
        /// The compression method.  This is the only method supported so far.
        /// There is no need to use this constant at all.
        /// </summary>
        public const int DEFLATED = 8;
        #endregion
        #region Local Constants
        private const int IS_SETDICT = 0x01;
        private const int IS_FLUSHING = 0x04;
        private const int IS_FINISHING = 0x08;

        private const int INIT_STATE = 0x00;
        private const int SETDICT_STATE = 0x01;
        //		private static  int INIT_FINISHING_STATE    = 0x08;
        //		private static  int SETDICT_FINISHING_STATE = 0x09;
        private const int BUSY_STATE = 0x10;
        private const int FLUSHING_STATE = 0x14;
        private const int FINISHING_STATE = 0x1c;
        private const int FINISHED_STATE = 0x1e;
        private const int CLOSED_STATE = 0x7f;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new deflater with given compression level.
        /// </summary>
        /// <param name="level">
        /// the compression level, a value between NO_COMPRESSION
        /// and BEST_COMPRESSION.
        /// </param>
        /// <param name="noZlibHeaderOrFooter">
        /// true, if we should suppress the Zlib/RFC1950 header at the
        /// beginning and the adler checksum at the end of the output.  This is
        /// useful for the GZIP/PKZIP formats.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">if lvl is out of range.</exception>
        public Deflater(int level = DEFAULT_COMPRESSION, bool noZlibHeaderOrFooter = false)
            {
            if (level == DEFAULT_COMPRESSION)
                {
                level = 6;
                }
            else if (level < NO_COMPRESSION || level > BEST_COMPRESSION)
                {
                throw new ArgumentOutOfRangeException(nameof(level));
                }

            this.pending = new DeflaterPending();
            this.engine = new DeflaterEngine(this.pending);
            this.noZlibHeaderOrFooter = noZlibHeaderOrFooter;
            this.SetStrategy(DeflateStrategy.Default);
            this.SetLevel(level);
            this.Reset();
            }
        #endregion

        /// <summary>
        /// Resets the deflater.  The deflater acts afterwards as if it was
        /// just created with the same compression level and strategy as it
        /// had before.
        /// </summary>
        public void Reset()
            {
            this.state = this.noZlibHeaderOrFooter ? BUSY_STATE : INIT_STATE;
            this.totalOut = 0;
            this.pending.Reset();
            this.engine.Reset();
            }

        /// <summary>
        /// Gets the current adler checksum of the data that was processed so far.
        /// </summary>
        public int Adler => this.engine.Adler;

        /// <summary>
        /// Gets the number of input bytes processed so far.
        /// </summary>
        public long TotalIn => this.engine.TotalIn;

        /// <summary>
        /// Gets the number of output bytes so far.
        /// </summary>
        public long TotalOut => this.totalOut;

        /// <summary>
        /// Flushes the current input block.  Further calls to deflate() will
        /// produce enough output to inflate everything in the current input
        /// block.  This is not part of Sun's JDK so I have made it package
        /// private.  It is used by DeflaterOutputStream to implement
        /// flush().
        /// </summary>
        public void Flush()
            {
            this.state |= IS_FLUSHING;
            }

        /// <summary>
        /// Finishes the deflater with the current input block.  It is an error
        /// to give more input after this method was called.  This method must
        /// be called to force all bytes to be flushed.
        /// </summary>
        public void Finish()
            {
            this.state |= IS_FLUSHING | IS_FINISHING;
            }

        /// <summary>
        /// Returns true if the stream was finished and no more output bytes
        /// are available.
        /// </summary>
        public bool IsFinished => (this.state == FINISHED_STATE) && this.pending.IsFlushed;

        /// <summary>
        /// Returns true, if the input buffer is empty.
        /// You should then call setInput(). 
        /// NOTE: This method can also return true when the stream
        /// was finished.
        /// </summary>
        public bool IsNeedingInput => this.engine.NeedsInput();

        /// <summary>
        /// Sets the data which should be compressed next.  This should be only
        /// called when needsInput indicates that more input is needed.
        /// If you call setInput when needsInput() returns false, the
        /// previous input that is still pending will be thrown away.
        /// The given byte array should not be changed, before needsInput() returns
        /// true again.
        /// This call is equivalent to <code>setInput(input, 0, input.length)</code>.
        /// </summary>
        /// <param name="input">
        /// the buffer containing the input data.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// if the buffer was finished() or ended().
        /// </exception>
        public void SetInput(byte[] input)
            {
            this.SetInput(input, offset: 0, count: input.Length);
            }

        /// <summary>
        /// Sets the data which should be compressed next.  This should be
        /// only called when needsInput indicates that more input is needed.
        /// The given byte array should not be changed, before needsInput() returns
        /// true again.
        /// </summary>
        /// <param name="input">
        /// the buffer containing the input data.
        /// </param>
        /// <param name="offset">
        /// the start of the data.
        /// </param>
        /// <param name="count">
        /// the number of data bytes of input.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// if the buffer was Finish()ed or if previous input is still pending.
        /// </exception>
        public void SetInput(byte[] input, int offset, int count)
            {
            if ((this.state & IS_FINISHING) != 0)
                {
                throw new InvalidOperationException("Finish() already called");
                }
            this.engine.SetInput(input, offset, count);
            }

        /// <summary>
        /// Sets the compression level.  There is no guarantee of the exact
        /// position of the change, but if you call this when needsInput is
        /// true the change of compression level will occur somewhere near
        /// before the end of the so far given input.
        /// </summary>
        /// <param name="Level">
        /// the new compression level.
        /// </param>
        public void SetLevel(int Level)
            {
            if (Level == DEFAULT_COMPRESSION)
                {
                Level = 6;
                }
            else if (Level < NO_COMPRESSION || Level > BEST_COMPRESSION)
                {
                throw new ArgumentOutOfRangeException(nameof(Level));
                }

            if (this.level != Level)
                {
                this.level = Level;
                this.engine.SetLevel(Level);
                }
            }

        /// <summary>
        /// Get current compression level
        /// </summary>
        /// <returns>Returns the current compression level</returns>
        public int GetLevel()
            {
            return this.level;
            }

        /// <summary>
        /// Sets the compression strategy. Strategy is one of
        /// DEFAULT_STRATEGY, HUFFMAN_ONLY and FILTERED.  For the exact
        /// position where the strategy is changed, the same as for
        /// SetLevel() applies.
        /// </summary>
        /// <param name="strategy">
        /// The new compression strategy.
        /// </param>
        public void SetStrategy(DeflateStrategy strategy)
            {
            this.engine.Strategy = strategy;
            }

        /// <summary>
        /// Deflates the current input block with to the given array.
        /// </summary>
        /// <param name="output">
        /// The buffer where compressed data is stored
        /// </param>
        /// <returns>
        /// The number of compressed bytes added to the output, or 0 if either
        /// IsNeedingInput() or IsFinished returns true or length is zero.
        /// </returns>
        public int Deflate(byte[] output)
            {
            return this.Deflate(output, offset: 0, length: output.Length);
            }

        /// <summary>
        /// Deflates the current input block to the given array.
        /// </summary>
        /// <param name="output">
        /// Buffer to store the compressed data.
        /// </param>
        /// <param name="offset">
        /// Offset into the output array.
        /// </param>
        /// <param name="length">
        /// The maximum number of bytes that may be stored.
        /// </param>
        /// <returns>
        /// The number of compressed bytes added to the output, or 0 if either
        /// needsInput() or finished() returns true or length is zero.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// If Finish() was previously called.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If offset or length don't match the array length.
        /// </exception>
        public int Deflate(byte[] output, int offset, int length)
            {
            int origLength = length;

            if (this.state == CLOSED_STATE)
                {
                throw new InvalidOperationException("Deflater closed");
                }

            if (this.state < BUSY_STATE)
                {
                // output header
                int header = (DEFLATED +
                    ((DeflaterConstants.MAX_WBITS - 8) << 4)) << 8;
                int level_flags = (this.level - 1) >> 1;
                if (level_flags < 0 || level_flags > 3)
                    {
                    level_flags = 3;
                    }
                header |= level_flags << 6;
                if ((this.state & IS_SETDICT) != 0)
                    {
                    // Dictionary was set
                    header |= DeflaterConstants.PRESET_DICT;
                    }
                header += 31 - header % 31;

                this.pending.WriteShortMSB(header);
                if ((this.state & IS_SETDICT) != 0)
                    {
                    int chksum = this.engine.Adler;
                    this.engine.ResetAdler();
                    this.pending.WriteShortMSB(chksum >> 16);
                    this.pending.WriteShortMSB(chksum & 0xffff);
                    }

                this.state = BUSY_STATE | (this.state & (IS_FLUSHING | IS_FINISHING));
                }

            for (;;)
                {
                int count = this.pending.Flush(output, offset, length);
                offset += count;
                this.totalOut += count;
                length -= count;

                if (length == 0 || this.state == FINISHED_STATE)
                    {
                    break;
                    }

                if (!this.engine.Deflate((this.state & IS_FLUSHING) != 0, (this.state & IS_FINISHING) != 0))
                    {
                    switch (this.state)
                        {
                        case BUSY_STATE:
                            // We need more input now
                            return origLength - length;
                        case FLUSHING_STATE:
                            if (this.level != NO_COMPRESSION)
                                {
                                /* We have to supply some lookahead.  8 bit lookahead
							 * is needed by the zlib inflater, and we must fill
							 * the next byte, so that all bits are flushed.
							 */
                                int neededbits = 8 + (-this.pending.BitCount & 7);
                                while (neededbits > 0)
                                    {
                                    /* write a static tree block consisting solely of
								 * an EOF:
								 */
                                    this.pending.WriteBits(b: 2, count: 10);
                                    neededbits -= 10;
                                    }
                                }
                            this.state = BUSY_STATE;
                            break;
                        case FINISHING_STATE:
                            this.pending.AlignToByte();

                            // Compressed data is complete.  Write footer information if required.
                            if (!this.noZlibHeaderOrFooter)
                                {
                                int adler = this.engine.Adler;
                                this.pending.WriteShortMSB(adler >> 16);
                                this.pending.WriteShortMSB(adler & 0xffff);
                                }
                            this.state = FINISHED_STATE;
                            break;
                        }
                    }
                }
            return origLength - length;
            }

        /// <summary>
        /// Sets the dictionary which should be used in the deflate process.
        /// This call is equivalent to <code>setDictionary(dict, 0, dict.Length)</code>.
        /// </summary>
        /// <param name="dictionary">
        /// the dictionary.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// if SetInput () or Deflate () were already called or another dictionary was already set.
        /// </exception>
        public void SetDictionary(byte[] dictionary)
            {
            this.SetDictionary(dictionary, index: 0, count: dictionary.Length);
            }

        /// <summary>
        /// Sets the dictionary which should be used in the deflate process.
        /// The dictionary is a byte array containing strings that are
        /// likely to occur in the data which should be compressed.  The
        /// dictionary is not stored in the compressed output, only a
        /// checksum.  To decompress the output you need to supply the same
        /// dictionary again.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary data
        /// </param>
        /// <param name="index">
        /// The index where dictionary information commences.
        /// </param>
        /// <param name="count">
        /// The number of bytes in the dictionary.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// If SetInput () or Deflate() were already called or another dictionary was already set.
        /// </exception>
        public void SetDictionary(byte[] dictionary, int index, int count)
            {
            if (this.state != INIT_STATE)
                {
                throw new InvalidOperationException();
                }

            this.state = SETDICT_STATE;
            this.engine.SetDictionary(dictionary, index, count);
            }

        #region Instance Fields
        /// <summary>
        /// Compression level.
        /// </summary>
        private int level;

        /// <summary>
        /// If true no Zlib/RFC1950 headers or footers are generated
        /// </summary>
        private bool noZlibHeaderOrFooter;

        /// <summary>
        /// The current state.
        /// </summary>
        private int state;

        /// <summary>
        /// The total bytes of output written.
        /// </summary>
        private long totalOut;

        /// <summary>
        /// The pending output.
        /// </summary>
        private DeflaterPending pending;

        /// <summary>
        /// The deflater engine.
        /// </summary>
        private DeflaterEngine engine;
        #endregion
        }
    }
