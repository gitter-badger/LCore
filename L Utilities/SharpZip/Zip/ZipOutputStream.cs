// ZipOutputStream.cs
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
using System.IO;
using System.Collections;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnassignedField.Global
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable RedundantAssignment
// ReSharper disable MemberCanBePrivate.Local

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace ICSharpCode.SharpZipLib.Zip
    {
    /// <summary>
    /// This is a DeflaterOutputStream that writes the files into a zip
    /// archive one after another.  It has a special method to start a new
    /// zip entry.  The zip entries contains information about the file name
    /// size, compressed size, CRC, etc.
    /// 
    /// It includes support for Stored and Deflated entries.
    /// This class is not thread safe.
    /// <br/>
    /// <br/>Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <example> This sample shows how to create a zip file
    /// <code>
    /// using System;
    /// using System.IO;
    /// 
    /// using ICSharpCode.SharpZipLib.Core;
    /// using ICSharpCode.SharpZipLib.Zip;
    /// 
    /// class MainClass
    /// {
    /// 	public static void Main(string[] args)
    /// 	{
    /// 		string[] filenames = Directory.GetFiles(args[0]);
    /// 		byte[] buffer = new byte[4096];
    /// 		
    /// 		using ( ZipOutputStream s = new ZipOutputStream(File.Create(args[1])) ) {
    /// 		
    /// 			s.SetLevel(9); // 0 - store only to 9 - means best compression
    /// 		
    /// 			foreach (string file in filenames) {
    /// 				ZipEntry entry = new ZipEntry(file);
    /// 				s.PutNextEntry(entry);
    ///
    /// 				using (FileStream fs = File.OpenRead(file)) {
    ///						StreamUtils.Copy(fs, s, buffer);
    /// 				}
    /// 			}
    /// 		}
    /// 	}
    /// }	
    /// </code>
    /// </example>
    public class ZipOutputStream : DeflaterOutputStream
        {
        #region Constructors
        /// <summary>
        /// Creates a new Zip output stream, writing a zip archive.
        /// </summary>
        /// <param name="baseOutputStream">
        /// The output stream to which the archive contents are written.
        /// </param>
        public ZipOutputStream(Stream baseOutputStream)
            : base(baseOutputStream, new Deflater(Deflater.DEFAULT_COMPRESSION, true))
            {
            }
        #endregion

        /// <summary>
        /// Gets a flag value of true if the central header has been added for this archive; false if it has not been added.
        /// </summary>
        /// <remarks>No further entries can be added once this has been done.</remarks>
        public bool IsFinished => this.entries == null;

        /// <summary>
        /// Set the zip file comment.
        /// </summary>
        /// <param name="comment">
        /// The comment text for the entire archive.
        /// </param>
        /// <exception name ="ArgumentOutOfRangeException">
        /// The converted comment is longer than 0xffff bytes.
        /// </exception>
        public void SetComment(string comment)
            {
            byte[] commentBytes = ZipConstants.ConvertToArray(comment);
            if (commentBytes.Length > 0xffff)
                {
                throw new ArgumentOutOfRangeException(nameof(comment));
                }
            this.zipComment = commentBytes;
            }

        /// <summary>
        /// Sets the compression level.  The new level will be activated
        /// immediately.
        /// </summary>
        /// <param name="level">The new compression level (1 to 9).</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Level specified is not supported.
        /// </exception>
        /// <see cref="ICSharpCode.SharpZipLib.Zip.Compression.Deflater"/>
        public void SetLevel(int level)
            {
            this.deflater_.SetLevel(level);
            this.defaultCompressionLevel = level;
            }

        /// <summary>
        /// Get the current deflater compression level
        /// </summary>
        /// <returns>The current compression level</returns>
        public int GetLevel()
            {
            return this.deflater_.GetLevel();
            }

        /// <summary>
        /// Get / set a value indicating how Zip64 Extension usage is determined when adding entries.
        /// </summary>
        /// <remarks>Older archivers may not understand Zip64 extensions.
        /// If backwards compatability is an issue be careful when adding <see cref="ZipEntry.Size">entries</see> to an archive.
        /// Setting this property to off is workable but less desirable as in those circumstances adding a file
        /// larger then 4GB will fail.</remarks>
        public UseZip64 UseZip64
            {
            get { return this.useZip64_; }
            set { this.useZip64_ = value; }
            }

        /// <summary>
        /// Write an unsigned short in little endian byte order.
        /// </summary>
        private void WriteLeShort(int value)
            {
            unchecked
                {
                this.baseOutputStream_.WriteByte((byte)(value & 0xff));
                this.baseOutputStream_.WriteByte((byte)((value >> 8) & 0xff));
                }
            }

        /// <summary>
        /// Write an int in little endian byte order.
        /// </summary>
        private void WriteLeInt(int value)
            {
            this.WriteLeShort(value);
            this.WriteLeShort(value >> 16);
            }

        /// <summary>
        /// Write an int in little endian byte order.
        /// </summary>
        private void WriteLeLong(long value)
            {
            unchecked
                {
                this.WriteLeInt((int)value);
                this.WriteLeInt((int)(value >> 32));
                }
            }

        /// <summary>
        /// Starts a new Zip entry. It automatically closes the previous
        /// entry if present.
        /// All entry elements bar name are optional, but must be correct if present.
        /// If the compression method is stored and the output is not patchable
        /// the compression for that entry is automatically changed to deflate level 0
        /// </summary>
        /// <param name="entry">
        /// the entry.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// if entry passed is null.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// if an I/O error occured.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// if stream was finished
        /// </exception>
        /// <exception cref="ZipException">
        /// Too many entries in the Zip file<br/>
        /// Entry name is too long<br/>
        /// Finish has already been called<br/>
        /// </exception>
        public void PutNextEntry(ZipEntry entry)
            {
            if (entry == null)
                {
                throw new ArgumentNullException(nameof(entry));
                }

            if (this.entries == null)
                {
                throw new InvalidOperationException("ZipOutputStream was finished");
                }

            if (this.curEntry != null)
                {
                this.CloseEntry();
                }

            if (this.entries.Count == int.MaxValue)
                {
                throw new ZipException("Too many entries for Zip file");
                }

            CompressionMethod method = entry.CompressionMethod;
            int compressionLevel = this.defaultCompressionLevel;

            // Clear flags that the library manages internally
            entry.Flags &= (int)GeneralBitFlags.UnicodeText;
            this.patchEntryHeader = false;

            bool headerInfoAvailable;

            // No need to compress - definitely no data.
            if (entry.Size == 0)
                {
                entry.CompressedSize = entry.Size;
                entry.Crc = 0;
                method = CompressionMethod.Stored;
                headerInfoAvailable = true;
                }
            else
                {
                headerInfoAvailable = (entry.Size >= 0) && entry.HasCrc;

                // Switch to deflation if storing isnt possible.
                if (method == CompressionMethod.Stored)
                    {
                    if (!headerInfoAvailable)
                        {
                        if (!this.CanPatchEntries)
                            {
                            // Can't patch entries so storing is not possible.
                            method = CompressionMethod.Deflated;
                            compressionLevel = 0;
                            }
                        }
                    else // entry.size must be > 0
                        {
                        entry.CompressedSize = entry.Size;
                        headerInfoAvailable = entry.HasCrc;
                        }
                    }
                }

            if (headerInfoAvailable == false)
                {
                if (this.CanPatchEntries == false)
                    {
                    // Only way to record size and compressed size is to append a data descriptor
                    // after compressed data.

                    // Stored entries of this form have already been converted to deflating.
                    entry.Flags |= 8;
                    }
                else
                    {
                    this.patchEntryHeader = true;
                    }
                }

            if (this.Password != null)
                {
                entry.IsCrypted = true;
                if (entry.Crc < 0)
                    {
                    // Need to append a data descriptor as the crc isnt available for use
                    // with encryption, the date is used instead.  Setting the flag
                    // indicates this to the decompressor.
                    entry.Flags |= 8;
                    }
                }

            entry.Offset = this.offset;
            entry.CompressionMethod = method;

            this.curMethod = method;
            this.sizePatchPos = -1;

            if ((this.useZip64_ == UseZip64.On) || ((entry.Size < 0) && (this.useZip64_ == UseZip64.Dynamic)))
                {
                entry.ForceZip64();
                }

            // Write the local file header
            this.WriteLeInt(ZipConstants.LocalHeaderSignature);

            this.WriteLeShort(entry.Version);
            this.WriteLeShort(entry.Flags);
            this.WriteLeShort((byte)method);
            this.WriteLeInt((int)entry.DosTime);

            if (headerInfoAvailable)
                {
                this.WriteLeInt((int)entry.Crc);
                if (entry.LocalHeaderRequiresZip64)
                    {
                    this.WriteLeInt(-1);
                    this.WriteLeInt(-1);
                    }
                else
                    {
                    this.WriteLeInt(entry.IsCrypted ? (int)entry.CompressedSize + ZipConstants.CryptoHeaderSize : (int)entry.CompressedSize);
                    this.WriteLeInt((int)entry.Size);
                    }
                }
            else
                {
                if (this.patchEntryHeader)
                    {
                    this.crcPatchPos = this.baseOutputStream_.Position;
                    }
                this.WriteLeInt(0); // Crc

                if (this.patchEntryHeader)
                    {
                    this.sizePatchPos = this.baseOutputStream_.Position;
                    }

                // For local header both sizes appear in Zip64 Extended Information
                if (entry.LocalHeaderRequiresZip64 || this.patchEntryHeader)
                    {
                    this.WriteLeInt(-1);
                    this.WriteLeInt(-1);
                    }
                else
                    {
                    this.WriteLeInt(0); // Compressed size
                    this.WriteLeInt(0); // Uncompressed size
                    }
                }

            byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

            if (name.Length > 0xFFFF)
                {
                throw new ZipException("Entry name too long.");
                }

            ZipExtraData ed = new ZipExtraData(entry.ExtraData);

            if (entry.LocalHeaderRequiresZip64)
                {
                ed.StartNewEntry();
                if (headerInfoAvailable)
                    {
                    ed.AddLeLong(entry.Size);
                    ed.AddLeLong(entry.CompressedSize);
                    }
                else
                    {
                    ed.AddLeLong(-1);
                    ed.AddLeLong(-1);
                    }
                ed.AddNewEntry(1);

                if (!ed.Find(1))
                    {
                    throw new ZipException("Internal error cant find extra data");
                    }

                if (this.patchEntryHeader)
                    {
                    this.sizePatchPos = ed.CurrentReadIndex;
                    }
                }
            else
                {
                ed.Delete(1);
                }

            byte[] extra = ed.GetEntryData();

            this.WriteLeShort(name.Length);
            this.WriteLeShort(extra.Length);

            if (name.Length > 0)
                {
                this.baseOutputStream_.Write(name, 0, name.Length);
                }

            if (entry.LocalHeaderRequiresZip64 && this.patchEntryHeader)
                {
                this.sizePatchPos += this.baseOutputStream_.Position;
                }

            if (extra.Length > 0)
                {
                this.baseOutputStream_.Write(extra, 0, extra.Length);
                }

            this.offset += ZipConstants.LocalHeaderBaseSize + name.Length + extra.Length;

            // Activate the entry.
            this.curEntry = entry;
            this.crc.Reset();
            if (method == CompressionMethod.Deflated)
                {
                this.deflater_.Reset();
                this.deflater_.SetLevel(compressionLevel);
                }
            this.size = 0;

            if (entry.IsCrypted)
                {
                if (entry.Crc < 0)
                    {           // so testing Zip will says its ok
                    this.WriteEncryptionHeader(entry.DosTime << 16);
                    }
                else
                    {
                    this.WriteEncryptionHeader(entry.Crc);
                    }
                }
            }

        /// <summary>
        /// Closes the current entry, updating header and footer information as required
        /// </summary>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// No entry is active.
        /// </exception>
        public void CloseEntry()
            {
            if (this.curEntry == null)
                {
                throw new InvalidOperationException("No open entry");
                }

            long csize = this.size;

            // First finish the deflater, if appropriate
            if (this.curMethod == CompressionMethod.Deflated)
                {
                if (this.size > 0)
                    {
                    base.Finish();
                    csize = this.deflater_.TotalOut;
                    }
                else
                    {
                    this.deflater_.Reset();
                    }
                }

            if (this.curEntry.Size < 0)
                {
                this.curEntry.Size = this.size;
                }
            else if (this.curEntry.Size != this.size)
                {
                throw new ZipException($"size was {this.size}, but I expected {this.curEntry.Size}");
                }

            if (this.curEntry.CompressedSize < 0)
                {
                this.curEntry.CompressedSize = csize;
                }
            else if (this.curEntry.CompressedSize != csize)
                {
                throw new ZipException($"compressed size was {csize}, but I expected {this.curEntry.CompressedSize}");
                }

            if (this.curEntry.Crc < 0)
                {
                this.curEntry.Crc = this.crc.Value;
                }
            else if (this.curEntry.Crc != this.crc.Value)
                {
                throw new ZipException($"crc was {this.crc.Value}, but I expected {this.curEntry.Crc}");
                }

            this.offset += csize;

            if (this.curEntry.IsCrypted)
                {
                this.curEntry.CompressedSize += ZipConstants.CryptoHeaderSize;
                }

            // Patch the header if possible
            if (this.patchEntryHeader)
                {
                this.patchEntryHeader = false;

                long curPos = this.baseOutputStream_.Position;
                this.baseOutputStream_.Seek(this.crcPatchPos, SeekOrigin.Begin);
                this.WriteLeInt((int)this.curEntry.Crc);

                if (this.curEntry.LocalHeaderRequiresZip64)
                    {

                    if (this.sizePatchPos == -1)
                        {
                        throw new ZipException("Entry requires zip64 but this has been turned off");
                        }

                    this.baseOutputStream_.Seek(this.sizePatchPos, SeekOrigin.Begin);
                    this.WriteLeLong(this.curEntry.Size);
                    this.WriteLeLong(this.curEntry.CompressedSize);
                    }
                else
                    {
                    this.WriteLeInt((int)this.curEntry.CompressedSize);
                    this.WriteLeInt((int)this.curEntry.Size);
                    }
                this.baseOutputStream_.Seek(curPos, SeekOrigin.Begin);
                }

            // Add data descriptor if flagged as required
            if ((this.curEntry.Flags & 8) != 0)
                {
                this.WriteLeInt(ZipConstants.DataDescriptorSignature);
                this.WriteLeInt(unchecked((int)this.curEntry.Crc));

                if (this.curEntry.LocalHeaderRequiresZip64)
                    {
                    this.WriteLeLong(this.curEntry.CompressedSize);
                    this.WriteLeLong(this.curEntry.Size);
                    this.offset += ZipConstants.Zip64DataDescriptorSize;
                    }
                else
                    {
                    this.WriteLeInt((int)this.curEntry.CompressedSize);
                    this.WriteLeInt((int)this.curEntry.Size);
                    this.offset += ZipConstants.DataDescriptorSize;
                    }
                }

            this.entries.Add(this.curEntry);
            this.curEntry = null;
            }

        private void WriteEncryptionHeader(long crcValue)
            {
            this.offset += ZipConstants.CryptoHeaderSize;

            this.InitializePassword(this.Password);

            byte[] cryptBuffer = new byte[ZipConstants.CryptoHeaderSize];
            Random rnd = new Random();
            rnd.NextBytes(cryptBuffer);
            cryptBuffer[11] = (byte)(crcValue >> 24);

            this.EncryptBlock(cryptBuffer, 0, cryptBuffer.Length);
            this.baseOutputStream_.Write(cryptBuffer, 0, cryptBuffer.Length);
            }

        /// <summary>
        /// Writes the given buffer to the current entry.
        /// </summary>
        /// <param name="buffer">The buffer containing data to write.</param>
        /// <param name="offset">The offset of the first byte to write.</param>
        /// <param name="count">The number of bytes to write.</param>
        /// <exception cref="ZipException">Archive size is invalid</exception>
        /// <exception cref="System.InvalidOperationException">No entry is active.</exception>
        public override void Write(byte[] buffer, int offset, int count)
            {
            if (this.curEntry == null)
                {
                throw new InvalidOperationException("No open entry.");
                }

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

            if (count < 0)
                {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
                throw new ArgumentOutOfRangeException(nameof(count), "Cannot be negative");
#endif
                }

            if (buffer.Length - offset < count)
                {
                throw new ArgumentException("Invalid offset/count combination");
                }

            this.crc.Update(buffer, offset, count);
            this.size += count;

            switch (this.curMethod)
                {
                case CompressionMethod.Deflated:
                    base.Write(buffer, offset, count);
                    break;

                case CompressionMethod.Stored:
                    if (this.Password != null)
                        {
                        this.CopyAndEncrypt(buffer, offset, count);
                        }
                    else
                        {
                        this.baseOutputStream_.Write(buffer, offset, count);
                        }
                    break;
                }
            }

        private void CopyAndEncrypt(byte[] buffer, int offset, int count)
            {
            const int CopyBufferSize = 4096;
            byte[] localBuffer = new byte[CopyBufferSize];
            while (count > 0)
                {
                int bufferCount = count < CopyBufferSize ? count : CopyBufferSize;

                Array.Copy(buffer, offset, localBuffer, 0, bufferCount);
                this.EncryptBlock(localBuffer, 0, bufferCount);
                this.baseOutputStream_.Write(localBuffer, 0, bufferCount);
                count -= bufferCount;
                offset += bufferCount;
                }
            }

        /// <summary>
        /// Finishes the stream.  This will write the central directory at the
        /// end of the zip file and flush the stream.
        /// </summary>
        /// <remarks>
        /// This is automatically called when the stream is closed.
        /// </remarks>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        /// <exception cref="ZipException">
        /// Comment exceeds the maximum length<br/>
        /// Entry name exceeds the maximum length
        /// </exception>
        public override void Finish()
            {
            if (this.entries == null)
                {
                return;
                }

            if (this.curEntry != null)
                {
                this.CloseEntry();
                }

            long numEntries = this.entries.Count;
            long sizeEntries = 0;

            foreach (ZipEntry entry in this.entries)
                {
                this.WriteLeInt(ZipConstants.CentralHeaderSignature);
                this.WriteLeShort(ZipConstants.VersionMadeBy);
                this.WriteLeShort(entry.Version);
                this.WriteLeShort(entry.Flags);
                this.WriteLeShort((short)entry.CompressionMethod);
                this.WriteLeInt((int)entry.DosTime);
                this.WriteLeInt((int)entry.Crc);

                if (entry.IsZip64Forced() ||
                    (entry.CompressedSize >= uint.MaxValue))
                    {
                    this.WriteLeInt(-1);
                    }
                else
                    {
                    this.WriteLeInt((int)entry.CompressedSize);
                    }

                if (entry.IsZip64Forced() ||
                    (entry.Size >= uint.MaxValue))
                    {
                    this.WriteLeInt(-1);
                    }
                else
                    {
                    this.WriteLeInt((int)entry.Size);
                    }

                byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

                if (name.Length > 0xffff)
                    {
                    throw new ZipException("Name too long.");
                    }

                ZipExtraData ed = new ZipExtraData(entry.ExtraData);

                if (entry.CentralHeaderRequiresZip64)
                    {
                    ed.StartNewEntry();
                    if (entry.IsZip64Forced() ||
                        (entry.Size >= 0xffffffff))
                        {
                        ed.AddLeLong(entry.Size);
                        }

                    if (entry.IsZip64Forced() ||
                        (entry.CompressedSize >= 0xffffffff))
                        {
                        ed.AddLeLong(entry.CompressedSize);
                        }

                    if (entry.Offset >= 0xffffffff)
                        {
                        ed.AddLeLong(entry.Offset);
                        }

                    ed.AddNewEntry(1);
                    }
                else
                    {
                    ed.Delete(1);
                    }

                byte[] extra = ed.GetEntryData();

                byte[] entryComment =
                    entry.Comment != null ?
                    ZipConstants.ConvertToArray(entry.Flags, entry.Comment) :
                    new byte[0];

                if (entryComment.Length > 0xffff)
                    {
                    throw new ZipException("Comment too long.");
                    }

                this.WriteLeShort(name.Length);
                this.WriteLeShort(extra.Length);
                this.WriteLeShort(entryComment.Length);
                this.WriteLeShort(0);   // disk number
                this.WriteLeShort(0);   // internal file attributes
                                        // external file attributes

                if (entry.ExternalFileAttributes != -1)
                    {
                    this.WriteLeInt(entry.ExternalFileAttributes);
                    }
                else
                    {
                    this.WriteLeInt(entry.IsDirectory ? 16 : 0);
                    }

                if (entry.Offset >= uint.MaxValue)
                    {
                    this.WriteLeInt(-1);
                    }
                else
                    {
                    this.WriteLeInt((int)entry.Offset);
                    }

                if (name.Length > 0)
                    {
                    this.baseOutputStream_.Write(name, 0, name.Length);
                    }

                if (extra.Length > 0)
                    {
                    this.baseOutputStream_.Write(extra, 0, extra.Length);
                    }

                if (entryComment.Length > 0)
                    {
                    this.baseOutputStream_.Write(entryComment, 0, entryComment.Length);
                    }

                sizeEntries += ZipConstants.CentralHeaderBaseSize + name.Length + extra.Length + entryComment.Length;
                }

            using (ZipHelperStream zhs = new ZipHelperStream(this.baseOutputStream_))
                {
                zhs.WriteEndOfCentralDirectory(numEntries, sizeEntries, this.offset, this.zipComment);
                }

            this.entries = null;
            }

        #region Instance Fields
        /// <summary>
        /// The entries for the archive.
        /// </summary>
        private ArrayList entries = new ArrayList();

        /// <summary>
        /// Used to track the crc of data added to entries.
        /// </summary>
        private Crc32 crc = new Crc32();

        /// <summary>
        /// The current entry being added.
        /// </summary>
        private ZipEntry curEntry;

        private int defaultCompressionLevel = Deflater.DEFAULT_COMPRESSION;

        private CompressionMethod curMethod = CompressionMethod.Deflated;

        /// <summary>
        /// Used to track the size of data for an entry during writing.
        /// </summary>
        private long size;

        /// <summary>
        /// Offset to be recorded for each entry in the central header.
        /// </summary>
        private long offset;

        /// <summary>
        /// Comment for the entire archive recorded in central header.
        /// </summary>
        private byte[] zipComment = new byte[0];

        /// <summary>
        /// Flag indicating that header patching is required for the current entry.
        /// </summary>
        private bool patchEntryHeader;

        /// <summary>
        /// Position to patch crc
        /// </summary>
        private long crcPatchPos = -1;

        /// <summary>
        /// Position to patch size.
        /// </summary>
        private long sizePatchPos = -1;

        // Default is dynamic which is not backwards compatible and can cause problems
        // with XP's built in compression which cant read Zip64 archives.
        // However it does avoid the situation were a large file is added and cannot be completed correctly.
        // NOTE: Setting the size for entries before they are added is the best solution!
        private UseZip64 useZip64_ = UseZip64.Dynamic;
        #endregion
        }
    }
