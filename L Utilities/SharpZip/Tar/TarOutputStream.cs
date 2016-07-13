// TarOutputStream.cs
//
// Copyright (C) 2001 Mike Krueger
// Copyright 2005 John Reilly
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
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace ICSharpCode.SharpZipLib.Tar
    {

    /// <summary>
    /// The TarOutputStream writes a UNIX tar archive as an OutputStream.
    /// Methods are provided to put entries, and then write their contents
    /// by writing to this stream using write().
    /// </summary>
    /// public
    public class TarOutputStream : Stream
        {
        #region Constructors

        /// <summary>
        /// Construct TarOutputStream with user specified block factor
        /// </summary>
        /// <param name="outputStream">stream to write to</param>
        /// <param name="blockFactor">blocking factor</param>
        public TarOutputStream(Stream outputStream, int blockFactor = TarBuffer.DefaultBlockFactor)
            {
            if (outputStream == null)
                {
                throw new ArgumentNullException(nameof(outputStream));
                }

            this.outputStream = outputStream;
            this.buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);

            this.assemblyBuffer = new byte[TarBuffer.BlockSize];
            this.blockBuffer = new byte[TarBuffer.BlockSize];
            }
        #endregion

        /// <summary>
        /// true if the stream supports reading; otherwise, false.
        /// </summary>
        public override bool CanRead => this.outputStream.CanRead;

        /// <summary>
        /// true if the stream supports seeking; otherwise, false.
        /// </summary>
        public override bool CanSeek => this.outputStream.CanSeek;

        /// <summary>
        /// true if stream supports writing; otherwise, false.
        /// </summary>
        public override bool CanWrite => this.outputStream.CanWrite;

        /// <summary>
        /// length of stream in bytes
        /// </summary>
        public override long Length => this.outputStream.Length;

        /// <summary>
        /// gets or sets the position within the current stream.
        /// </summary>
        public override long Position
            {
            get
                {
                return this.outputStream.Position;
                }
            set
                {
                this.outputStream.Position = value;
                }
            }

        /// <summary>
        /// set the position within the current stream
        /// </summary>
        /// <param name="offset">The offset relative to the <paramref name="origin"/> to seek to</param>
        /// <param name="origin">The <see cref="SeekOrigin"/> to seek from.</param>
        /// <returns>The new position in the stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
            {
            return this.outputStream.Seek(offset, origin);
            }

        /// <summary>
        /// Set the length of the current stream
        /// </summary>
        /// <param name="value">The new stream length.</param>
        public override void SetLength(long value)
            {
            this.outputStream.SetLength(value);
            }

        /// <summary>
        /// Read a byte from the stream and advance the position within the stream 
        /// by one byte or returns -1 if at the end of the stream.
        /// </summary>
        /// <returns>The byte value or -1 if at end of stream</returns>
        public override int ReadByte()
            {
            return this.outputStream.ReadByte();
            }

        /// <summary>
        /// read bytes from the current stream and advance the position within the 
        /// stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">The buffer to store read bytes in.</param>
        /// <param name="offset">The index into the buffer to being storing bytes at.</param>
        /// <param name="count">The desired number of bytes to read.</param>
        /// <returns>The total number of bytes read, or zero if at the end of the stream.
        /// The number of bytes may be less than the <paramref name="count">count</paramref>
        /// requested if data is not avialable.</returns>
        public override int Read(byte[] buffer, int offset, int count)
            {
            return this.outputStream.Read(buffer, offset, count);
            }

        /// <summary>
        /// All buffered data is written to destination
        /// </summary>		
        public override void Flush()
            {
            this.outputStream.Flush();
            }

        /// <summary>
        /// Ends the TAR archive without closing the underlying OutputStream.
        /// The result is that the EOF block of nulls is written.
        /// </summary>
        public void Finish()
            {
            if (this.IsEntryOpen)
                {
                this.CloseEntry();
                }
            this.WriteEofBlock();
            }

        /// <summary>
        /// Ends the TAR archive and closes the underlying OutputStream.
        /// </summary>
        /// <remarks>This means that Finish() is called followed by calling the
        /// TarBuffer's Close().</remarks>
        public override void Close()
            {
            if (!this.isClosed)
                {
                this.isClosed = true;
                this.Finish();
                this.buffer.Close();
                }
            }

        /// <summary>
        /// Get the record size being used by this stream's TarBuffer.
        /// </summary>
        public int RecordSize => this.buffer.RecordSize;

        /// <summary>
        /// Get the record size being used by this stream's TarBuffer.
        /// </summary>
        /// <returns>
        /// The TarBuffer record size.
        /// </returns>
        [Obsolete("Use RecordSize property instead")]
        public int GetRecordSize()
            {
            return this.buffer.RecordSize;
            }

        /// <summary>
        /// Get a value indicating wether an entry is open, requiring more data to be written.
        /// </summary>
        private bool IsEntryOpen => this.currBytes < this.currSize;

        /// <summary>
        /// Put an entry on the output stream. This writes the entry's
        /// header and positions the output stream for writing
        /// the contents of the entry. Once this method is called, the
        /// stream is ready for calls to write() to write the entry's
        /// contents. Once the contents are written, closeEntry()
        /// <B>MUST</B> be called to ensure that all buffered data
        /// is completely written to the output stream.
        /// </summary>
        /// <param name="entry">
        /// The TarEntry to be written to the archive.
        /// </param>
        public void PutNextEntry(TarEntry entry)
            {
            if (entry == null)
                {
                throw new ArgumentNullException(nameof(entry));
                }

            if (entry.TarHeader.Name.Length >= TarHeader.NAMELEN)
                {
                var longHeader = new TarHeader { TypeFlag = TarHeader.LF_GNU_LONGNAME };
                longHeader.Name = $"{longHeader.Name}././@LongLink";
                longHeader.UserId = 0;
                longHeader.GroupId = 0;
                longHeader.GroupName = "";
                longHeader.UserName = "";
                longHeader.LinkName = "";
                longHeader.Size = entry.TarHeader.Name.Length;

                longHeader.WriteHeader(this.blockBuffer);
                this.buffer.WriteBlock(this.blockBuffer);  // Add special long filename header block

                int nameCharIndex = 0;

                while (nameCharIndex < entry.TarHeader.Name.Length)
                    {
                    Array.Clear(this.blockBuffer, 0, this.blockBuffer.Length);
                    TarHeader.GetAsciiBytes(entry.TarHeader.Name, nameCharIndex, this.blockBuffer, 0, TarBuffer.BlockSize);
                    nameCharIndex += TarBuffer.BlockSize;
                    this.buffer.WriteBlock(this.blockBuffer);
                    }
                }

            entry.WriteEntryHeader(this.blockBuffer);
            this.buffer.WriteBlock(this.blockBuffer);

            this.currBytes = 0;

            this.currSize = entry.IsDirectory ? 0 : entry.Size;
            }

        /// <summary>
        /// Close an entry. This method MUST be called for all file
        /// entries that contain data. The reason is that we must
        /// buffer data written to the stream in order to satisfy
        /// the buffer's block based writes. Thus, there may be
        /// data fragments still being assembled that must be written
        /// to the output stream before this entry is closed and the
        /// next entry written.
        /// </summary>
        public void CloseEntry()
            {
            if (this.assemblyBufferLength > 0)
                {
                Array.Clear(this.assemblyBuffer, this.assemblyBufferLength, this.assemblyBuffer.Length - this.assemblyBufferLength);

                this.buffer.WriteBlock(this.assemblyBuffer);

                this.currBytes += this.assemblyBufferLength;
                this.assemblyBufferLength = 0;
                }

            if (this.currBytes < this.currSize)
                {
                string errorText =
                    $"Entry closed at '{this.currBytes}' before the '{this.currSize}' bytes specified in the header were written";
                throw new TarException(errorText);
                }
            }

        /// <summary>
        /// Writes a byte to the current tar archive entry.
        /// This method simply calls Write(byte[], int, int).
        /// </summary>
        /// <param name="value">
        /// The byte to be written.
        /// </param>
        public override void WriteByte(byte value)
            {
            this.Write(new[] { value }, 0, 1);
            }

        /// <summary>
        /// Writes bytes to the current tar archive entry. This method
        /// is aware of the current entry and will throw an exception if
        /// you attempt to write bytes past the length specified for the
        /// current entry. The method is also (painfully) aware of the
        /// record buffering required by TarBuffer, and manages buffers
        /// that are not a multiple of recordsize in length, including
        /// assembling records from small buffers.
        /// </summary>
        /// <param name = "buffer">
        /// The buffer to write to the archive.
        /// </param>
        /// <param name = "offset">
        /// The offset in the buffer from which to get bytes.
        /// </param>
        /// <param name = "count">
        /// The number of bytes to write.
        /// </param>
        public override void Write(byte[] buffer, int offset, int count)
            {
            if (buffer == null)
                {
                throw new ArgumentNullException(nameof(buffer));
                }

            if (offset < 0)
                {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
                throw new ArgumentOutOfRangeException(nameof(offset), "Cannot be negative");
#endif
                }

            if (buffer.Length - offset < count)
                {
                throw new ArgumentException("offset and count combination is invalid");
                }

            if (count < 0)
                {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
                throw new ArgumentOutOfRangeException(nameof(count), "Cannot be negative");
#endif
                }

            if (this.currBytes + count > this.currSize)
                {
                string errorText = $"request to write '{count}' bytes exceeds size in header of '{this.currSize}' bytes";
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
                throw new ArgumentOutOfRangeException(nameof(count), errorText);
#endif
                }

            //
            // We have to deal with assembly!!!
            // The programmer can be writing little 32 byte chunks for all
            // we know, and we must assemble complete blocks for writing.
            //
            if (this.assemblyBufferLength > 0)
                {
                if (this.assemblyBufferLength + count >= this.blockBuffer.Length)
                    {
                    int aLen = this.blockBuffer.Length - this.assemblyBufferLength;

                    Array.Copy(this.assemblyBuffer, 0, this.blockBuffer, 0, this.assemblyBufferLength);
                    Array.Copy(buffer, offset, this.blockBuffer, this.assemblyBufferLength, aLen);

                    this.buffer.WriteBlock(this.blockBuffer);

                    this.currBytes += this.blockBuffer.Length;

                    offset += aLen;
                    count -= aLen;

                    this.assemblyBufferLength = 0;
                    }
                else
                    {
                    Array.Copy(buffer, offset, this.assemblyBuffer, this.assemblyBufferLength, count);
                    offset += count;
                    this.assemblyBufferLength += count;
                    count -= count;
                    }
                }

            //
            // When we get here we have EITHER:
            //   o An empty "assembly" buffer.
            //   o No bytes to write (count == 0)
            //
            while (count > 0)
                {
                if (count < this.blockBuffer.Length)
                    {
                    Array.Copy(buffer, offset, this.assemblyBuffer, this.assemblyBufferLength, count);
                    this.assemblyBufferLength += count;
                    break;
                    }

                this.buffer.WriteBlock(buffer, offset);

                int bufferLength = this.blockBuffer.Length;
                this.currBytes += bufferLength;
                count -= bufferLength;
                offset += bufferLength;
                }
            }

        /// <summary>
        /// Write an EOF (end of archive) block to the tar archive.
        /// An EOF block consists of all zeros.
        /// </summary>
        private void WriteEofBlock()
            {
            Array.Clear(this.blockBuffer, 0, this.blockBuffer.Length);
            this.buffer.WriteBlock(this.blockBuffer);
            }

        #region Instance Fields
        /// <summary>
        /// bytes written for this entry so far
        /// </summary>
        private long currBytes;

        /// <summary>
        /// current 'Assembly' buffer length
        /// </summary>		
        private int assemblyBufferLength;

        /// <summary>
        /// Flag indicating wether this instance has been closed or not.
        /// </summary>
        private bool isClosed;

        /// <summary>
        /// Size for the current entry
        /// </summary>
        protected long currSize;

        /// <summary>
        /// single block working buffer 
        /// </summary>
        protected byte[] blockBuffer;

        /// <summary>
        /// 'Assembly' buffer used to assemble data before writing
        /// </summary>
        protected byte[] assemblyBuffer;

        /// <summary>
        /// TarBuffer used to provide correct blocking factor
        /// </summary>
        protected TarBuffer buffer;

        /// <summary>
        /// the destination stream for the archive contents
        /// </summary>
        protected Stream outputStream;
        #endregion
        }
    }

/* The original Java file had this header:
	** Authored by Timothy Gerard Endres
	** <mailto:time@gjt.org>  <http://www.trustice.com>
	**
	** This work has been placed into the public domain.
	** You may use this work in any way and for any purpose you wish.
	**
	** THIS SOFTWARE IS PROVIDED AS-IS WITHOUT WARRANTY OF ANY KIND,
	** NOT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY. THE AUTHOR
	** OF THIS SOFTWARE, ASSUMES _NO_ RESPONSIBILITY FOR ANY
	** CONSEQUENCE RESULTING FROM THE USE, MODIFICATION, OR
	** REDISTRIBUTION OF THIS SOFTWARE.
	**
	*/
