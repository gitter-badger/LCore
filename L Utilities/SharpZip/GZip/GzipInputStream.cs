// GzipInputStream.cs
//
// Copyright (C) 2001 Mike Krueger
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
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace ICSharpCode.SharpZipLib.GZip
    {

    /// <summary>
    /// This filter stream is used to decompress a "GZIP" format stream.
    /// The "GZIP" format is described baseInputStream RFC 1952.
    /// 
    /// author of the original java version : John Leuner
    /// </summary>
    /// <example> This sample shows how to unzip a gzipped file
    /// <code>
    /// using System;
    /// using System.IO;
    /// 
    /// using ICSharpCode.SharpZipLib.Core;
    /// using ICSharpCode.SharpZipLib.GZip;
    /// 
    /// class MainClass
    /// {
    /// 	public static void Main(string[] args)
    /// 	{
    ///			using (Stream inStream = new GZipInputStream(File.OpenRead(args[0])))
    ///			using (FileStream outStream = File.Create(Path.GetFileNameWithoutExtension(args[0]))) {
    ///				byte[] buffer = new byte[4096];
    ///				StreamUtils.Copy(inStream, outStream, buffer);
    /// 		}
    /// 	}
    /// }	
    /// </code>
    /// </example>
    public class GZipInputStream : InflaterInputStream
        {
        #region Instance Fields
        /// <summary>
        /// CRC-32 value for uncompressed data
        /// </summary>
        protected Crc32 crc = new Crc32();

        /// <summary>
        /// Indicates end of stream
        /// </summary>
        protected bool eos;

        // Have we read the GZIP header yet?
        private bool readGZIPHeader;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a GZIPInputStream with the specified buffer size
        /// </summary>
        /// <param name="baseInputStream">
        /// The stream to read compressed data from (baseInputStream GZIP format)
        /// </param>
        /// <param name="size">
        /// Size of the buffer to use
        /// </param>
        public GZipInputStream(Stream baseInputStream, int size = 4096)
            : base(baseInputStream, new Inflater(true), size)
            {
            }
        #endregion

        #region Stream overrides

        /// <summary>
        /// Reads uncompressed data into an array of bytes
        /// </summary>
        /// <param name="buffer">
        /// The buffer to read uncompressed data into
        /// </param>
        /// <param name="offset">
        /// The offset indicating where the data should be placed
        /// </param>
        /// <param name="count">
        /// The number of uncompressed bytes to be read
        /// </param>
        /// <returns>Returns the number of bytes actually read.</returns>
        /// <exception cref="SharpZipBaseException">
        /// Inflater needs a dictionary
        /// </exception>
        public override int Read(byte[] buffer, int offset, int count)
            {
            // We first have to read the GZIP header, then we feed all the
            // rest of the data to the base class.
            //
            // As we do that we continually update the CRC32. Once the data is
            // finished, we check the CRC32
            //
            // This means we don't need our own buffer, as everything is done
            // in baseInputStream the superclass.
            if (!this.readGZIPHeader)
                {
                this.ReadHeader();
                }

            if (this.eos)
                {
                return 0;
                }

            // We don't have to read the header, so we just grab data from the superclass
            int BytesRead = base.Read(buffer, offset, count);
            if (BytesRead > 0)
                {
                this.crc.Update(buffer, offset, BytesRead);
                }

            if (this.inf.IsFinished)
                {
                this.ReadFooter();
                }
            return BytesRead;
            }
        #endregion

        #region Support routines

        private void ReadHeader()
            {
            // 1. Check the two magic bytes
            var headCRC = new Crc32();
            int magic = this.baseInputStream.ReadByte();

            if (magic < 0)
                {
                throw new EndOfStreamException("EOS reading GZIP header");
                }

            headCRC.Update(magic);
            if (magic != GZipConstants.GZIP_MAGIC >> 8)
                {
                throw new GZipException("Error GZIP header, first magic byte doesn't match");
                }

            magic = this.baseInputStream.ReadByte();

            if (magic < 0)
                {
                throw new EndOfStreamException("EOS reading GZIP header");
                }

            if (magic != (GZipConstants.GZIP_MAGIC & 0xFF))
                {
                throw new GZipException("Error GZIP header,  second magic byte doesn't match");
                }

            headCRC.Update(magic);

            // 2. Check the compression type (must be 8)
            int compressionType = this.baseInputStream.ReadByte();

            if (compressionType < 0)
                {
                throw new EndOfStreamException("EOS reading GZIP header");
                }

            if (compressionType != 8)
                {
                throw new GZipException("Error GZIP header, data not in deflate format");
                }
            headCRC.Update(compressionType);

            // 3. Check the flags
            int flags = this.baseInputStream.ReadByte();
            if (flags < 0)
                {
                throw new EndOfStreamException("EOS reading GZIP header");
                }
            headCRC.Update(flags);

            /*    This flag byte is divided into individual bits as follows:
				
				bit 0   FTEXT
				bit 1   FHCRC
				bit 2   FEXTRA
				bit 3   FNAME
				bit 4   FCOMMENT
				bit 5   reserved
				bit 6   reserved
				bit 7   reserved
			*/

            // 3.1 Check the reserved bits are zero

            if ((flags & 0xE0) != 0)
                {
                throw new GZipException("Reserved flag bits in GZIP header != 0");
                }

            // 4.-6. Skip the modification time, extra flags, and OS type
            for (int i = 0; i < 6; i++)
                {
                int readByte = this.baseInputStream.ReadByte();
                if (readByte < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }
                headCRC.Update(readByte);
                }

            // 7. Read extra field
            if ((flags & GZipConstants.FEXTRA) != 0)
                {
                // Skip subfield id
                for (int i = 0; i < 2; i++)
                    {
                    int readByte = this.baseInputStream.ReadByte();
                    if (readByte < 0)
                        {
                        throw new EndOfStreamException("EOS reading GZIP header");
                        }
                    headCRC.Update(readByte);
                    }

                if (this.baseInputStream.ReadByte() < 0 || this.baseInputStream.ReadByte() < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }

                int len1 = this.baseInputStream.ReadByte();
                int len2 = this.baseInputStream.ReadByte();
                if ((len1 < 0) || (len2 < 0))
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }
                headCRC.Update(len1);
                headCRC.Update(len2);

                int extraLen = (len1 << 8) | len2;
                for (int i = 0; i < extraLen; i++)
                    {
                    int readByte = this.baseInputStream.ReadByte();
                    if (readByte < 0)
                        {
                        throw new EndOfStreamException("EOS reading GZIP header");
                        }
                    headCRC.Update(readByte);
                    }
                }

            // 8. Read file name
            if ((flags & GZipConstants.FNAME) != 0)
                {
                int readByte;
                while ((readByte = this.baseInputStream.ReadByte()) > 0)
                    {
                    headCRC.Update(readByte);
                    }

                if (readByte < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }
                headCRC.Update(readByte);
                }

            // 9. Read comment
            if ((flags & GZipConstants.FCOMMENT) != 0)
                {
                int readByte;
                while ((readByte = this.baseInputStream.ReadByte()) > 0)
                    {
                    headCRC.Update(readByte);
                    }

                if (readByte < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }

                headCRC.Update(readByte);
                }

            // 10. Read header CRC
            if ((flags & GZipConstants.FHCRC) != 0)
                {
                int crcval = this.baseInputStream.ReadByte();
                if (crcval < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }

                int tempByte = this.baseInputStream.ReadByte();
                if (tempByte < 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP header");
                    }

                crcval = (crcval << 8) | tempByte;
                if (crcval != ((int)headCRC.Value & 0xffff))
                    {
                    throw new GZipException("Header CRC value mismatch");
                    }
                }

            this.readGZIPHeader = true;
            }

        private void ReadFooter()
            {
            var footer = new byte[8];
            int avail = this.inf.RemainingInput;

            if (avail > 8)
                {
                avail = 8;
                }

            Array.Copy(this.inputBuffer.RawData, this.inputBuffer.RawLength - this.inf.RemainingInput, footer, 0, avail);
            int needed = 8 - avail;

            while (needed > 0)
                {
                int count = this.baseInputStream.Read(footer, 8 - needed, needed);
                if (count <= 0)
                    {
                    throw new EndOfStreamException("EOS reading GZIP footer");
                    }
                needed -= count; // Jewel Jan 16
                }

            int crcval = (footer[0] & 0xff) | ((footer[1] & 0xff) << 8) | ((footer[2] & 0xff) << 16) | (footer[3] << 24);
            if (crcval != (int)this.crc.Value)
                {
                throw new GZipException($"GZIP crc sum mismatch, theirs \"{crcval}\" and ours \"{(int)this.crc.Value}");
                }

            // NOTE The total here is the original total modulo 2 ^ 32.
            uint total =
                (uint)footer[4] & 0xff |
                ((uint)footer[5] & 0xff) << 8 |
                ((uint)footer[6] & 0xff) << 16 |
                (uint)footer[7] << 24;

            if ((this.inf.TotalOut & 0xffffffff) != total)
                {
                throw new GZipException("Number of bytes mismatch in footer");
                }

            // Should we support multiple gzip members.
            // Difficult, since there may be some bytes still in baseInputStream dataBuffer
            this.eos = true;
            }
        #endregion
        }
    }
