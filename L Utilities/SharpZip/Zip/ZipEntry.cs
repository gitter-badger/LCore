// ZipEntry.cs
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
using JetBrains.Annotations;

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnassignedField.Global

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace ICSharpCode.SharpZipLib.Zip
    {

    /// <summary>
    /// Defines known values for the <see cref="HostSystemID"/> property.
    /// </summary>
    public enum HostSystemID
        {
        /// <summary>
        /// Host system = MSDOS
        /// </summary>
        Msdos = 0,
        /// <summary>
        /// Host system = Amiga
        /// </summary>
        Amiga = 1,
        /// <summary>
        /// Host system = Open VMS
        /// </summary>
        OpenVms = 2,
        /// <summary>
        /// Host system = Unix
        /// </summary>
        Unix = 3,
        /// <summary>
        /// Host system = VMCms
        /// </summary>
        VMCms = 4,
        /// <summary>
        /// Host system = Atari ST
        /// </summary>
        AtariST = 5,
        /// <summary>
        /// Host system = OS2
        /// </summary>
        OS2 = 6,
        /// <summary>
        /// Host system = Macintosh
        /// </summary>
        Macintosh = 7,
        /// <summary>
        /// Host system = ZSystem
        /// </summary>
        ZSystem = 8,
        /// <summary>
        /// Host system = Cpm
        /// </summary>
        Cpm = 9,
        /// <summary>
        /// Host system = Windows NT
        /// </summary>
        WindowsNT = 10,
        /// <summary>
        /// Host system = MVS
        /// </summary>
        MVS = 11,
        /// <summary>
        /// Host system = VSE
        /// </summary>
        Vse = 12,
        /// <summary>
        /// Host system = Acorn RISC
        /// </summary>
        AcornRisc = 13,
        /// <summary>
        /// Host system = VFAT
        /// </summary>
        Vfat = 14,
        /// <summary>
        /// Host system = Alternate MVS
        /// </summary>
        AlternateMvs = 15,
        /// <summary>
        /// Host system = BEOS
        /// </summary>
        BeOS = 16,
        /// <summary>
        /// Host system = Tandem
        /// </summary>
        Tandem = 17,
        /// <summary>
        /// Host system = OS400
        /// </summary>
        OS400 = 18,
        /// <summary>
        /// Host system = OSX
        /// </summary>
        OSX = 19,
        /// <summary>
        /// Host system = WinZIP AES
        /// </summary>
        WinZipAES = 99
        }

    /// <summary>
    /// This class represents an entry in a zip archive.  This can be a file
    /// or a directory
    /// ZipFile and ZipInputStream will give you instances of this class as 
    /// information about the members in an archive.  ZipOutputStream
    /// uses an instance of this class when creating an entry in a Zip file.
    /// <br/>
    /// <br/>Author of the original java version : Jochen Hoenicke
    /// </summary>
    public class ZipEntry : ICloneable
        {
        [Flags]
        private enum Known : byte
            {
            None = 0,
            Size = 0x01,
            CompressedSize = 0x02,
            Crc = 0x04,
            Time = 0x08,
            ExternalAttributes = 0x10
            }

        #region Constructors

        /// <summary>
        /// Initializes an entry with the given name and made by information
        /// </summary>
        /// <param name="name">Name for this entry</param>
        /// <param name="madeByInfo">Version and HostSystem Information</param>
        /// <param name="versionRequiredToExtract">Minimum required zip feature version required to extract this entry</param>
        /// <param name="method">Compression method for this entry.</param>
        /// <exception cref="ArgumentNullException">
        /// The name passed is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// versionRequiredToExtract should be 0 (auto-calculate) or > 10
        /// </exception>
        /// <remarks>
        /// This constructor is used by the ZipFile class when reading from the central header
        /// It is not generally useful, use the constructor specifying the name only.
        /// </remarks>
        public ZipEntry(string name, int versionRequiredToExtract = 0, int madeByInfo = ZipConstants.VersionMadeBy,
            CompressionMethod method = CompressionMethod.Deflated)
            {
            if (name == null)
                {
                throw new ArgumentNullException(nameof(name));
                }

            if (name.Length > 0xffff)
                {
                throw new ArgumentException("Name is too long", nameof(name));
                }

            if ((versionRequiredToExtract != 0) && (versionRequiredToExtract < 10))
                {
                throw new ArgumentOutOfRangeException(nameof(versionRequiredToExtract));
                }

            this.DateTime = DateTime.Now;
            this.name = name;
            this.versionMadeBy = (ushort)madeByInfo;
            this.versionToExtract = (ushort)versionRequiredToExtract;
            this.method = method;
            }

        /// <summary>
        /// Creates a deep copy of the given zip entry.
        /// </summary>
        /// <param name="entry">
        /// The entry to copy.
        /// </param>
        [Obsolete("Use Clone instead")]
        public ZipEntry(ZipEntry entry)
            {
            if (entry == null)
                { 
                throw new ArgumentNullException(nameof(entry));
                }

            this.known = entry.known;
            this.name = entry.name;
            this.size = entry.size;
            this.compressedSize = entry.compressedSize;
            this.crc = entry.crc;
            this.dosTime = entry.dosTime;
            this.method = entry.method;
            this.comment = entry.comment;
            this.versionToExtract = entry.versionToExtract;
            this.versionMadeBy = entry.versionMadeBy;
            this.externalFileAttributes = entry.externalFileAttributes;
            this.flags = entry.flags;

            this.zipFileIndex = entry.zipFileIndex;
            this.offset = entry.offset;

            this.forceZip64_ = entry.forceZip64_;

            if (entry.extra != null)
                {
                this.extra = new byte[entry.extra.Length];
                Array.Copy(entry.extra, sourceIndex: 0, destinationArray: this.extra, destinationIndex: 0, length: entry.extra.Length);
                }
            }

        #endregion

        /// <summary>
        /// Get a value indicating wether the entry has a CRC value available.
        /// </summary>
        public bool HasCrc => (this.known & Known.Crc) != 0;

        /// <summary>
        /// Get/Set flag indicating if entry is encrypted.
        /// A simple helper routine to aid interpretation of <see cref="Flags">flags</see>
        /// </summary>
        /// <remarks>This is an assistant that interprets the <see cref="Flags">flags</see> property.</remarks>
        public bool IsCrypted
            {
            get
                {
                return (this.flags & 1) != 0;
                }
            set
                {
                if (value)
                    {
                    this.flags |= 1;
                    }
                else
                    {
                    this.flags &= ~1;
                    }
                }
            }

        /// <summary>
        /// Get / set a flag indicating wether entry name and comment text are
        /// encoded in <a href="http://www.unicode.org">unicode UTF8</a>.
        /// </summary>
        /// <remarks>This is an assistant that interprets the <see cref="Flags">flags</see> property.</remarks>
        public bool IsUnicodeText
            {
            get
                {
                return (this.flags & (int)GeneralBitFlags.UnicodeText) != 0;
                }
            set
                {
                if (value)
                    {
                    this.flags |= (int)GeneralBitFlags.UnicodeText;
                    }
                else
                    {
                    this.flags &= ~(int)GeneralBitFlags.UnicodeText;
                    }
                }
            }

        /// <summary>
        /// Value used during password checking for PKZIP 2.0 / 'classic' encryption.
        /// </summary>
        internal byte CryptoCheckValue { get; set; }

        /// <summary>
        /// Get/Set general purpose bit flag for entry
        /// </summary>
        /// <remarks>
        /// General purpose bit flag<br/>
        /// <br/>
        /// Bit 0: If set, indicates the file is encrypted<br/>
        /// Bit 1-2 Only used for compression type 6 Imploding, and 8, 9 deflating<br/>
        /// Imploding:<br/>
        /// Bit 1 if set indicates an 8K sliding dictionary was used.  If clear a 4k dictionary was used<br/>
        /// Bit 2 if set indicates 3 Shannon-Fanno trees were used to encode the sliding dictionary, 2 otherwise<br/>
        /// <br/>
        /// Deflating:<br/>
        ///   Bit 2    Bit 1<br/>
        ///     0        0       Normal compression was used<br/>
        ///     0        1       Maximum compression was used<br/>
        ///     1        0       Fast compression was used<br/>
        ///     1        1       Super fast compression was used<br/>
        /// <br/>
        /// Bit 3: If set, the fields crc-32, compressed size
        /// and uncompressed size are were not able to be written during zip file creation
        /// The correct values are held in a data descriptor immediately following the compressed data. <br/>
        /// Bit 4: Reserved for use by PKZIP for enhanced deflating<br/>
        /// Bit 5: If set indicates the file contains compressed patch data<br/>
        /// Bit 6: If set indicates strong encryption was used.<br/>
        /// Bit 7-10: Unused or reserved<br/>
        /// Bit 11: If set the name and comments for this entry are in <a href="http://www.unicode.org">unicode</a>.<br/>
        /// Bit 12-15: Unused or reserved<br/>
        /// </remarks>
        /// <seealso cref="IsUnicodeText"></seealso>
        /// <seealso cref="IsCrypted"></seealso>
        public int Flags
            {
            get
                {
                return this.flags;
                }
            set
                {
                this.flags = value;
                }
            }

        /// <summary>
        /// Get/Set index of this entry in Zip file
        /// </summary>
        /// <remarks>This is only valid when the entry is part of a <see cref="ZipFile"></see></remarks>
        public long ZipFileIndex
            {
            get
                {
                return this.zipFileIndex;
                }
            set
                {
                this.zipFileIndex = value;
                }
            }

        /// <summary>
        /// Get/set offset for use in central header
        /// </summary>
        public long Offset
            {
            get
                {
                return this.offset;
                }
            set
                {
                this.offset = value;
                }
            }

        /// <summary>
        /// Get/Set external file attributes as an integer.
        /// The values of this are operating system dependant see
        /// <see cref="HostSystem">HostSystem</see> for details
        /// </summary>
        public int ExternalFileAttributes
            {
            get
                {
                if ((this.known & Known.ExternalAttributes) == 0)
                    {
                    return -1;
                    }
                return this.externalFileAttributes;
                }

            set
                {
                this.externalFileAttributes = value;
                this.known |= Known.ExternalAttributes;
                }
            }

        /// <summary>
        /// Get the version made by for this entry or zero if unknown.
        /// The value / 10 indicates the major version number, and 
        /// the value mod 10 is the minor version number
        /// </summary>
        public int VersionMadeBy => this.versionMadeBy & 0xff;

        /// <summary>
        /// Get a value indicating this entry is for a DOS/Windows system.
        /// </summary>
        public bool IsDOSEntry => (this.HostSystem == (int)HostSystemID.Msdos) ||
                                  (this.HostSystem == (int)HostSystemID.WindowsNT);

        /// <summary>
        /// Test the external attributes for this <see cref="ZipEntry"/> to
        /// see if the external attributes are Dos based (including WINNT and variants)
        /// and match the values
        /// </summary>
        /// <param name="attributes">The attributes to test.</param>
        /// <returns>Returns true if the external attributes are known to be DOS/Windows 
        /// based and have the same attributes set as the value passed.</returns>
        private bool HasDosAttributes(int attributes)
            {
            bool result = false;
            if ((this.known & Known.ExternalAttributes) != 0)
                {
                if (((this.HostSystem == (int)HostSystemID.Msdos) ||
                    (this.HostSystem == (int)HostSystemID.WindowsNT)) &&
                    (this.ExternalFileAttributes & attributes) == attributes)
                    {
                    result = true;
                    }
                }
            return result;
            }

        /// <summary>
        /// Gets the compatability information for the <see cref="ExternalFileAttributes">external file attribute</see>
        /// If the external file attributes are compatible with MS-DOS and can be read
        /// by PKZIP for DOS version 2.04g then this value will be zero.  Otherwise the value
        /// will be non-zero and identify the host system on which the attributes are compatible.
        /// </summary>
        /// 		
        /// <remarks>
        /// The values for this as defined in the Zip File format and by others are shown below.  The values are somewhat
        /// misleading in some cases as they are not all used as shown.  You should consult the relevant documentation
        /// to obtain up to date and correct information.  The modified appnote by the infozip group is
        /// particularly helpful as it documents a lot of peculiarities.  The document is however a little dated.
        /// <list type="table">
        /// <item>0 - MS-DOS and OS/2 (FAT / VFAT / FAT32 file systems)</item>
        /// <item>1 - Amiga</item>
        /// <item>2 - OpenVMS</item>
        /// <item>3 - Unix</item>
        /// <item>4 - VM/CMS</item>
        /// <item>5 - Atari ST</item>
        /// <item>6 - OS/2 HPFS</item>
        /// <item>7 - Macintosh</item>
        /// <item>8 - Z-System</item>
        /// <item>9 - CP/M</item>
        /// <item>10 - Windows NTFS</item>
        /// <item>11 - MVS (OS/390 - Z/OS)</item>
        /// <item>12 - VSE</item>
        /// <item>13 - Acorn Risc</item>
        /// <item>14 - VFAT</item>
        /// <item>15 - Alternate MVS</item>
        /// <item>16 - BeOS</item>
        /// <item>17 - Tandem</item>
        /// <item>18 - OS/400</item>
        /// <item>19 - OS/X (Darwin)</item>
        /// <item>99 - WinZip AES</item>
        /// <item>remainder - unused</item>
        /// </list>
        /// </remarks>
        public int HostSystem
            {
            get
                {
                return (this.versionMadeBy >> 8) & 0xff;
                }

            set
                {
                this.versionMadeBy &= 0xff;
                this.versionMadeBy |= (ushort)((value & 0xff) << 8);
                }
            }

        /// <summary>
        /// Get minimum Zip feature version required to extract this entry
        /// </summary>		
        /// <remarks>
        /// Minimum features are defined as:<br/>
        /// 1.0 - Default value<br/>
        /// 1.1 - File is a volume label<br/>
        /// 2.0 - File is a folder/directory<br/>
        /// 2.0 - File is compressed using Deflate compression<br/>
        /// 2.0 - File is encrypted using traditional encryption<br/>
        /// 2.1 - File is compressed using Deflate64<br/>
        /// 2.5 - File is compressed using PKWARE DCL Implode<br/>
        /// 2.7 - File is a patch data set<br/>
        /// 4.5 - File uses Zip64 format extensions<br/>
        /// 4.6 - File is compressed using BZIP2 compression<br/>
        /// 5.0 - File is encrypted using DES<br/>
        /// 5.0 - File is encrypted using 3DES<br/>
        /// 5.0 - File is encrypted using original RC2 encryption<br/>
        /// 5.0 - File is encrypted using RC4 encryption<br/>
        /// 5.1 - File is encrypted using AES encryption<br/>
        /// 5.1 - File is encrypted using corrected RC2 encryption<br/>
        /// 5.1 - File is encrypted using corrected RC2-64 encryption<br/>
        /// 6.1 - File is encrypted using non-OAEP key wrapping<br/>
        /// 6.2 - Central directory encryption (not confirmed yet)<br/>
        /// 6.3 - File is compressed using LZMA<br/>
        /// 6.3 - File is compressed using PPMD+<br/>
        /// 6.3 - File is encrypted using Blowfish<br/>
        /// 6.3 - File is encrypted using Twofish<br/>
        /// </remarks>
        /// <seealso cref="CanDecompress"></seealso>
        public int Version
            {
            get
                {
                // Return recorded version if known.
                if (this.versionToExtract != 0)
                    {
                    return this.versionToExtract;
                    }
                int result = 10;
                if (this.CentralHeaderRequiresZip64)
                    {
                    result = ZipConstants.VersionZip64;
                    }
                else if (CompressionMethod.Deflated == this.method)
                    {
                    result = 20;
                    }
                else if (this.IsDirectory)
                    {
                    result = 20;
                    }
                else if (this.IsCrypted)
                    {
                    result = 20;
                    }
                else if (this.HasDosAttributes(attributes: 0x08))
                    {
                    result = 11;
                    }
                return result;
                }
            }

        /// <summary>
        /// Get a value indicating wether this entry can be decompressed by the library.
        /// </summary>
        /// <remarks>This is based on the <see cref="Version"></see> and 
        /// wether the <see cref="IsCompressionMethodSupported()">compression method</see> is supported.</remarks>
        public bool CanDecompress => (this.Version <= ZipConstants.VersionMadeBy) &&
                                     ((this.Version == 10) ||
                                      (this.Version == 11) ||
                                      (this.Version == 20) ||
                                      (this.Version == 45)) && this.IsCompressionMethodSupported();

        /// <summary>
        /// Force this entry to be recorded using Zip64 extensions.
        /// </summary>
        public void ForceZip64()
            {
            this.forceZip64_ = true;
            }

        /// <summary>
        /// Get a value indicating wether Zip64 extensions were forced.
        /// </summary>
        /// <returns>A <see cref="bool"/> value of true if Zip64 extensions have been forced on; false if not.</returns>
        public bool IsZip64Forced()
            {
            return this.forceZip64_;
            }

        /// <summary>
        /// Gets a value indicating if the entry requires Zip64 extensions 
        /// to store the full entry values.
        /// </summary>
        /// <value>A <see cref="bool"/> value of true if a local header requires Zip64 extensions; false if not.</value>
        public bool LocalHeaderRequiresZip64
            {
            get
                {
                bool result = this.forceZip64_;

                if (!result)
                    {
                    ulong trueCompressedSize = this.compressedSize;

                    if ((this.versionToExtract == 0) && this.IsCrypted)
                        {
                        trueCompressedSize += ZipConstants.CryptoHeaderSize;
                        }

                    result =
                        ((this.size >= uint.MaxValue) || (trueCompressedSize >= uint.MaxValue)) &&
                        ((this.versionToExtract == 0) || (this.versionToExtract >= ZipConstants.VersionZip64));
                    }

                return result;
                }
            }

        /// <summary>
        /// Get a value indicating wether the central directory entry requires Zip64 extensions to be stored.
        /// </summary>
        public bool CentralHeaderRequiresZip64 =>
            this.LocalHeaderRequiresZip64 || (this.offset >= uint.MaxValue);

        /// <summary>
        /// Get/Set DosTime value.
        /// </summary>
        /// <remarks>
        /// The MS-DOS date format can only represent dates between 1/1/1980 and 12/31/2107.
        /// </remarks>
        public long DosTime
            {
            get
                {
                return (this.known & Known.Time) == 0 ? 0 : this.dosTime;
                }

            set
                {
                unchecked
                    {
                    this.dosTime = (uint)value;
                    }

                this.known |= Known.Time;
                }
            }

        /// <summary>
        /// Gets/Sets the time of last modification of the entry.
        /// </summary>
        /// <remarks>
        /// The <see cref="DosTime"></see> property is updated to match this as far as possible.
        /// </remarks>
        public DateTime DateTime
            {
            get
                {
                uint sec = Math.Min(val1: 59, val2: 2 * (this.dosTime & 0x1f));
                uint min = Math.Min(val1: 59, val2: (this.dosTime >> 5) & 0x3f);
                uint hrs = Math.Min(val1: 23, val2: (this.dosTime >> 11) & 0x1f);
                uint mon = Math.Max(val1: 1, val2: Math.Min(val1: 12, val2: (this.dosTime >> 21) & 0xf));
                uint year = ((this.dosTime >> 25) & 0x7f) + 1980;
                int day = Math.Max(val1: 1, val2: Math.Min(DateTime.DaysInMonth((int)year, (int)mon), (int)((this.dosTime >> 16) & 0x1f)));
                return new DateTime((int)year, (int)mon, day, (int)hrs, (int)min, (int)sec);
                }

            set
                {
                uint year = (uint)value.Year;
                uint month = (uint)value.Month;
                uint day = (uint)value.Day;
                uint hour = (uint)value.Hour;
                uint minute = (uint)value.Minute;
                uint second = (uint)value.Second;

                if (year < 1980)
                    {
                    year = 1980;
                    month = 1;
                    day = 1;
                    hour = 0;
                    minute = 0;
                    second = 0;
                    }
                else if (year > 2107)
                    {
                    year = 2107;
                    month = 12;
                    day = 31;
                    hour = 23;
                    minute = 59;
                    second = 59;
                    }

                this.DosTime = ((year - 1980) & 0x7f) << 25 |
                    (month << 21) |
                    (day << 16) |
                    (hour << 11) |
                    (minute << 5) |
                    (second >> 1);
                }
            }

        /// <summary>
        /// Returns the entry name.
        /// </summary>
        /// <remarks>
        /// The unix naming convention is followed.
        /// Path components in the entry should always separated by forward slashes ('/').
        /// Dos device names like C: should also be removed.
        /// See the <see cref="ZipNameTransform"/> class, or <see cref="CleanName(string)"/>
        ///</remarks>
        public string Name => this.name;

        /// <summary>
        /// Gets/Sets the size of the uncompressed data.
        /// </summary>
        /// <returns>
        /// The size or -1 if unknown.
        /// </returns>
        /// <remarks>Setting the size before adding an entry to an archive can help
        /// avoid compatability problems with some archivers which dont understand Zip64 extensions.</remarks>
        public long Size
            {
            get
                {
                return (this.known & Known.Size) != 0 ? (long)this.size : -1L;
                }
            set
                {
                this.size = (ulong)value;
                this.known |= Known.Size;
                }
            }

        /// <summary>
        /// Gets/Sets the size of the compressed data.
        /// </summary>
        /// <returns>
        /// The compressed entry size or -1 if unknown.
        /// </returns>
        public long CompressedSize
            {
            get
                {
                return (this.known & Known.CompressedSize) != 0 ? (long)this.compressedSize : -1L;
                }
            set
                {
                this.compressedSize = (ulong)value;
                this.known |= Known.CompressedSize;
                }
            }

        /// <summary>
        /// Gets/Sets the crc of the uncompressed data.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Crc is not in the range 0..0xffffffffL
        /// </exception>
        /// <returns>
        /// The crc value or -1 if unknown.
        /// </returns>
        public long Crc
            {
            get
                {
                return (this.known & Known.Crc) != 0 ? this.crc & 0xffffffffL : -1L;
                }
            set
                {
                if ((this.crc & 0xffffffff00000000L) != 0)
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }
                this.crc = (uint)value;
                this.known |= Known.Crc;
                }
            }

        /// <summary>
        /// Gets/Sets the compression method. Only Deflated and Stored are supported.
        /// </summary>
        /// <returns>
        /// The compression method for this entry
        /// </returns>
        /// <see cref="ICSharpCode.SharpZipLib.Zip.CompressionMethod.Deflated"/>
        /// <see cref="ICSharpCode.SharpZipLib.Zip.CompressionMethod.Stored"/>
        public CompressionMethod CompressionMethod
            {
            get
                {
                return this.method;
                }

            set
                {
                if (!IsCompressionMethodSupported(value))
                    {
                    throw new NotSupportedException("Compression method not supported");
                    }
                this.method = value;
                }
            }

        /// <summary>
        /// Gets/Sets the extra data.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Extra data is longer than 64KB (0xffff) bytes.
        /// </exception>
        /// <returns>
        /// Extra data or null if not set.
        /// </returns>
        public byte[] ExtraData
            {
            get
                {
                //				return (byte[]) extra.Clone();
                return this.extra;
                }

            set
                {
                if (value == null)
                    {
                    this.extra = null;
                    }
                else
                    {
                    if (value.Length > 0xffff)
                        {
                        throw new ArgumentOutOfRangeException(nameof(value));
                        }

                    this.extra = new byte[value.Length];
                    Array.Copy(value, sourceIndex: 0, destinationArray: this.extra, destinationIndex: 0, length: value.Length);
                    }
                }
            }

        /// <summary>
        /// Process extra data fields updating the entry based on the contents.
        /// </summary>
        /// <param name="localHeader">True if the extra data fields should be handled
        /// for a local header, rather than for a central header.
        /// </param>
        internal void ProcessExtraData(bool localHeader)
            {
            var extraData = new ZipExtraData(this.extra);

            if (extraData.Find(headerID: 0x0001))
                {
                if ((this.versionToExtract & 0xff) < ZipConstants.VersionZip64)
                    {
                    throw new ZipException("Zip64 Extended information found but version is not valid");
                    }

                // The recorded size will change but remember that this is zip64.
                this.forceZip64_ = true;

                if (extraData.ValueLength < 4)
                    {
                    throw new ZipException("Extra data extended Zip64 information length is invalid");
                    }

                if (localHeader || (this.size == uint.MaxValue))
                    {
                    this.size = (ulong)extraData.ReadLong();
                    }

                if (localHeader || (this.compressedSize == uint.MaxValue))
                    {
                    this.compressedSize = (ulong)extraData.ReadLong();
                    }

                if (!localHeader && (this.offset == uint.MaxValue))
                    {
                    this.offset = extraData.ReadLong();
                    }
                }
            else
                {
                if (
                    ((this.versionToExtract & 0xff) >= ZipConstants.VersionZip64) &&
                    ((this.size == uint.MaxValue) || (this.compressedSize == uint.MaxValue))
                )
                    {
                    throw new ZipException("Zip64 Extended information required but is missing.");
                    }
                }

            if (extraData.Find(headerID: 10))
                {
                // No room for any tags.
                if (extraData.ValueLength < 8)
                    {
                    throw new ZipException("NTFS Extra data invalid");
                    }

                extraData.ReadInt(); // Reserved

                while (extraData.UnreadCount >= 4)
                    {
                    int ntfsTag = extraData.ReadShort();
                    int ntfsLength = extraData.ReadShort();
                    if (ntfsTag == 1)
                        {
                        if (ntfsLength >= 24)
                            {
                            long lastModification = extraData.ReadLong();
                            extraData.ReadLong();
                            extraData.ReadLong();

                            this.DateTime = DateTime.FromFileTime(lastModification);
                            }
                        break;
                        }
                    // An unknown NTFS tag so simply skip it.
                    extraData.Skip(ntfsLength);
                    }
                }
            else if (extraData.Find(headerID: 0x5455))
                {
                int length = extraData.ValueLength;
                int flags = extraData.ReadByte();

                // Can include other times but these are ignored.  Length of data should
                // actually be 1 + 4 * no of bits in flags.
                if (((flags & 1) != 0) && (length >= 5))
                    {
                    int iTime = extraData.ReadInt();

                    this.DateTime = (new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0).ToUniversalTime() +
                        new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: iTime, milliseconds: 0)).ToLocalTime();
                    }
                }
            }

        /// <summary>
        /// Gets/Sets the entry comment.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If comment is longer than 0xffff.
        /// </exception>
        /// <returns>
        /// The comment or null if not set.
        /// </returns>
        /// <remarks>
        /// A comment is only available for entries when read via the <see cref="ZipFile"/> class.
        /// The <see cref="ZipInputStream"/> class doesnt have the comment data available.
        /// </remarks>
        public string Comment
            {
            get
                {
                return this.comment;
                }
            set
                {
                // This test is strictly incorrect as the length is in characters
                // while the storage limit is in bytes.
                // While the test is partially correct in that a comment of this length or greater 
                // is definitely invalid, shorter comments may also have an invalid length
                // where there are multi-byte characters
                // The full test is not possible here however as the code page to apply conversions with
                // isnt available.
                if ((value != null) && (value.Length > 0xffff))
                    {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot exceed 65535");
#endif
                    }

                this.comment = value;
                }
            }

        /// <summary>
        /// Gets a value indicating if the entry is a directory.
        /// however.
        /// </summary>
        /// <remarks>
        /// A directory is determined by an entry name with a trailing slash '/'.
        /// The external file attributes can also indicate an entry is for a directory.
        /// Currently only dos/windows attributes are tested in this manner.
        /// The trailing slash convention should always be followed.
        /// </remarks>
        public bool IsDirectory
            {
            get
                {
                int nameLength = this.name.Length;
                bool result =
                    ((nameLength > 0) &&
                    ((this.name[nameLength - 1] == '/') || (this.name[nameLength - 1] == '\\'))) || this.HasDosAttributes(attributes: 16)
                    ;
                return result;
                }
            }

        /// <summary>
        /// Get a value of true if the entry appears to be a file; false otherwise
        /// </summary>
        /// <remarks>
        /// This only takes account of DOS/Windows attributes.  Other operating systems are ignored.
        /// For linux and others the result may be incorrect.
        /// </remarks>
        public bool IsFile => !this.IsDirectory && !this.HasDosAttributes(attributes: 8);

        /// <summary>
        /// Test entry to see if data can be extracted.
        /// </summary>
        /// <returns>Returns true if data can be extracted for this entry; false otherwise.</returns>
        public bool IsCompressionMethodSupported()
            {
            return IsCompressionMethodSupported(this.CompressionMethod);
            }

        #region ICloneable Members
        /// <summary>
        /// Creates a copy of this zip entry.
        /// </summary>
        /// <returns>An <see cref="Object"/> that is a copy of the current instance.</returns>
        public object Clone()
            {
            var result = (ZipEntry)this.MemberwiseClone();

            // Ensure extra data is unique if it exists.
            if (this.extra != null)
                {
                result.extra = new byte[this.extra.Length];
                Array.Copy(this.extra, sourceIndex: 0, destinationArray: result.extra, destinationIndex: 0, length: this.extra.Length);
                }

            return result;
            }

        #endregion

        /// <summary>
        /// Gets a string representation of this ZipEntry.
        /// </summary>
        /// <returns>A readable textual representation of this <see cref="ZipEntry"/></returns>
        public override string ToString()
            {
            return this.name;
            }

        /// <summary>
        /// Test a <see cref="CompressionMethod">compression method</see> to see if this library
        /// supports extracting data compressed with that method
        /// </summary>
        /// <param name="method">The compression method to test.</param>
        /// <returns>Returns true if the compression method is supported; false otherwise</returns>
        public static bool IsCompressionMethodSupported(CompressionMethod method)
            {
            return
                (method == CompressionMethod.Deflated) ||
                (method == CompressionMethod.Stored);
            }

        /// <summary>
        /// Cleans a name making it conform to Zip file conventions.
        /// Devices names ('c:\') and UNC share names ('\\server\share') are removed
        /// and forward slashes ('\') are converted to back slashes ('/').
        /// Names are made relative by trimming leading slashes which is compatible
        /// with the ZIP naming convention.
        /// </summary>
        /// <param name="name">The name to clean</param>
        /// <returns>The 'cleaned' name.</returns>
        /// <remarks>
        /// The <seealso cref="ZipNameTransform">Zip name transform</seealso> class is more flexible.
        /// </remarks>
        public static string CleanName([CanBeNull]string name)
            {
            if (name == null)
                {
                return string.Empty;
                }

            if (Path.IsPathRooted(name))
                {
                // NOTE:
                // for UNC names...  \\machine\share\zoom\beet.txt gives \zoom\beet.txt
                name = name.Substring(Path.GetPathRoot(name).Length);
                }

            name = name.Replace(@"\", "/");

            while ((name.Length > 0) && (name[index: 0] == '/'))
                {
                name = name.Remove(startIndex: 0, count: 1);
                }
            return name;
            }

        #region Instance Fields

        private Known known;
        private int externalFileAttributes = -1;     // contains external attributes (O/S dependant)

        private ushort versionMadeBy;                   // Contains host system and version information
                                                        // only relevant for central header entries

        private string name;
        private ulong size;
        private ulong compressedSize;
        private ushort versionToExtract;                // Version required to extract (library handles <= 2.0)
        private uint crc;
        private uint dosTime;

        private CompressionMethod method;
        private byte[] extra;
        private string comment;

        private int flags;                             // general purpose bit flags

        private long zipFileIndex = -1;                // used by ZipFile
        private long offset;                           // used by ZipFile and ZipOutputStream

        private bool forceZip64_;

        #endregion
        }
    }
