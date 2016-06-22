//
// ZipExtraData.cs
//
// Copyright 2004-2007 John Reilly
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

namespace ICSharpCode.SharpZipLib.Zip
    {

    /// <summary>
    /// ExtraData tagged value interface.
    /// </summary>
    public interface ITaggedData
        {
        /// <summary>
        /// Get the ID for this tagged data value.
        /// </summary>
        short TagID { get; }

        /// <summary>
        /// Set the contents of this instance from the data passed.
        /// </summary>
        /// <param name="data">The data to extract contents from.</param>
        /// <param name="offset">The offset to begin extracting data from.</param>
        /// <param name="count">The number of bytes to extract.</param>
        void SetData(byte[] data, int offset, int count);

        /// <summary>
        /// Get the data representing this instance.
        /// </summary>
        /// <returns>Returns the data for this instance.</returns>
        byte[] GetData();
        }

    /// <summary>
    /// A raw binary tagged value
    /// </summary>
    public class RawTaggedData : ITaggedData
        {
        /// <summary>
        /// Initialise a new instance.
        /// </summary>
        /// <param name="tag">The tag ID.</param>
        public RawTaggedData(short tag)
            {
            this.tag_ = tag;
            }

        #region ITaggedData Members

        /// <summary>
        /// Get the ID for this tagged data value.
        /// </summary>
        public short TagID
            {
            get { return this.tag_; }
            set { this.tag_ = value; }
            }

        /// <summary>
        /// Set the data from the raw values provided.
        /// </summary>
        /// <param name="data">The raw data to extract values from.</param>
        /// <param name="offset">The index to start extracting values from.</param>
        /// <param name="count">The number of bytes available.</param>
        public void SetData(byte[] data, int offset, int count)
            {
            if (data == null)
                {
                throw new ArgumentNullException(nameof(data));
                }

            this.data_ = new byte[count];
            Array.Copy(data, offset, this.data_, 0, count);
            }

        /// <summary>
        /// Get the binary data representing this instance.
        /// </summary>
        /// <returns>The raw binary data representing this instance.</returns>
        public byte[] GetData()
            {
            return this.data_;
            }

        #endregion

        /// <summary>
        /// Get /set the binary data representing this instance.
        /// </summary>
        /// <returns>The raw binary data representing this instance.</returns>
        public byte[] Data
            {
            get { return this.data_; }
            set { this.data_ = value; }
            }

        #region Instance Fields
        /// <summary>
        /// The tag ID for this instance.
        /// </summary>
        protected short tag_;

        private byte[] data_;
        #endregion
        }

    /// <summary>
    /// Class representing extended unix date time values.
    /// </summary>
    public class ExtendedUnixData : ITaggedData
        {
        /// <summary>
        /// Flags indicate which values are included in this instance.
        /// </summary>
        [Flags]
        public enum Flags : byte
            {
            /// <summary>
            /// The modification time is included
            /// </summary>
            ModificationTime = 0x01,

            /// <summary>
            /// The access time is included
            /// </summary>
            AccessTime = 0x02,

            /// <summary>
            /// The create time is included.
            /// </summary>
            CreateTime = 0x04
            }

        #region ITaggedData Members

        /// <summary>
        /// Get the ID
        /// </summary>
        public short TagID => 0x5455;

        /// <summary>
        /// Set the data from the raw values provided.
        /// </summary>
        /// <param name="data">The raw data to extract values from.</param>
        /// <param name="index">The index to start extracting values from.</param>
        /// <param name="count">The number of bytes available.</param>
        public void SetData(byte[] data, int index, int count)
            {
            using (MemoryStream ms = new MemoryStream(data, index, count, false))
            using (ZipHelperStream helperStream = new ZipHelperStream(ms))
                {
                // bit 0           if set, modification time is present
                // bit 1           if set, access time is present
                // bit 2           if set, creation time is present

                this.flags_ = (Flags)helperStream.ReadByte();
                if (((this.flags_ & Flags.ModificationTime) != 0) && (count >= 5))
                    {
                    int iTime = helperStream.ReadLEInt();

                    this.modificationTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
                        new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
                    }

                if ((this.flags_ & Flags.AccessTime) != 0)
                    {
                    int iTime = helperStream.ReadLEInt();

                    this.lastAccessTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
                        new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
                    }

                if ((this.flags_ & Flags.CreateTime) != 0)
                    {
                    int iTime = helperStream.ReadLEInt();

                    this.createTime_ = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
                        new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
                    }
                }
            }

        /// <summary>
        /// Get the binary data representing this instance.
        /// </summary>
        /// <returns>The raw binary data representing this instance.</returns>
        public byte[] GetData()
            {
            using (MemoryStream ms = new MemoryStream())
            using (ZipHelperStream helperStream = new ZipHelperStream(ms))
                {
                helperStream.IsStreamOwner = false;
                helperStream.WriteByte((byte)this.flags_);     // Flags
                if ((this.flags_ & Flags.ModificationTime) != 0)
                    {
                    TimeSpan span = this.modificationTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
                    int seconds = (int)span.TotalSeconds;
                    helperStream.WriteLEInt(seconds);
                    }
                if ((this.flags_ & Flags.AccessTime) != 0)
                    {
                    TimeSpan span = this.lastAccessTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
                    int seconds = (int)span.TotalSeconds;
                    helperStream.WriteLEInt(seconds);
                    }
                if ((this.flags_ & Flags.CreateTime) != 0)
                    {
                    TimeSpan span = this.createTime_.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
                    int seconds = (int)span.TotalSeconds;
                    helperStream.WriteLEInt(seconds);
                    }
                return ms.ToArray();
                }
            }

        #endregion

        /// <summary>
        /// Test a <see cref="DateTime"> value to see if is valid and can be represented here.</see>
        /// </summary>
        /// <param name="value">The <see cref="DateTime">value</see> to test.</param>
        /// <returns>Returns true if the value is valid and can be represented; false if not.</returns>
        /// <remarks>The standard Unix time is a signed integer data type, directly encoding the Unix time number,
        /// which is the number of seconds since 1970-01-01.
        /// Being 32 bits means the values here cover a range of about 136 years.
        /// The minimum representable time is 1901-12-13 20:45:52,
        /// and the maximum representable time is 2038-01-19 03:14:07.
        /// </remarks>
        public static bool IsValidValue(DateTime value)
            {
            return (value >= new DateTime(1901, 12, 13, 20, 45, 52)) ||
                   (value <= new DateTime(2038, 1, 19, 03, 14, 07));
            }

        /// <summary>
        /// Get /set the Modification Time
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <seealso cref="IsValidValue"></seealso>
        public DateTime ModificationTime
            {
            get { return this.modificationTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.flags_ |= Flags.ModificationTime;
                this.modificationTime_ = value;
                }
            }

        /// <summary>
        /// Get / set the Access Time
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <seealso cref="IsValidValue"></seealso>
        public DateTime AccessTime
            {
            get { return this.lastAccessTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.flags_ |= Flags.AccessTime;
                this.lastAccessTime_ = value;
                }
            }

        /// <summary>
        /// Get / Set the Create Time
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <seealso cref="IsValidValue"></seealso>
        public DateTime CreateTime
            {
            get { return this.createTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.flags_ |= Flags.CreateTime;
                this.createTime_ = value;
                }
            }

        /// <summary>
        /// Get/set the <see cref="Flags">values</see> to include.
        /// </summary>
        private Flags Include
            {
            get { return this.flags_; }
            set { this.flags_ = value; }
            }

        #region Instance Fields

        private Flags flags_;
        private DateTime modificationTime_ = new DateTime(1970, 1, 1);
        private DateTime lastAccessTime_ = new DateTime(1970, 1, 1);
        private DateTime createTime_ = new DateTime(1970, 1, 1);
        #endregion
        }

    /// <summary>
    /// Class handling NT date time values.
    /// </summary>
    public class NTTaggedData : ITaggedData
        {
        /// <summary>
        /// Get the ID for this tagged data value.
        /// </summary>
        public short TagID => 10;

        /// <summary>
        /// Set the data from the raw values provided.
        /// </summary>
        /// <param name="data">The raw data to extract values from.</param>
        /// <param name="index">The index to start extracting values from.</param>
        /// <param name="count">The number of bytes available.</param>
        public void SetData(byte[] data, int index, int count)
            {
            using (MemoryStream ms = new MemoryStream(data, index, count, false))
            using (ZipHelperStream helperStream = new ZipHelperStream(ms))
                {
                helperStream.ReadLEInt(); // Reserved
                while (helperStream.Position < helperStream.Length)
                    {
                    int ntfsTag = helperStream.ReadLEShort();
                    int ntfsLength = helperStream.ReadLEShort();
                    if (ntfsTag == 1)
                        {
                        if (ntfsLength >= 24)
                            {
                            long lastModificationTicks = helperStream.ReadLELong();
                            this.lastModificationTime_ = DateTime.FromFileTime(lastModificationTicks);

                            long lastAccessTicks = helperStream.ReadLELong();
                            this.lastAccessTime_ = DateTime.FromFileTime(lastAccessTicks);

                            long createTimeTicks = helperStream.ReadLELong();
                            this.createTime_ = DateTime.FromFileTime(createTimeTicks);
                            }
                        break;
                        }
                    // An unknown NTFS tag so simply skip it.
                    helperStream.Seek(ntfsLength, SeekOrigin.Current);
                    }
                }
            }

        /// <summary>
        /// Get the binary data representing this instance.
        /// </summary>
        /// <returns>The raw binary data representing this instance.</returns>
        public byte[] GetData()
            {
            using (MemoryStream ms = new MemoryStream())
            using (ZipHelperStream helperStream = new ZipHelperStream(ms))
                {
                helperStream.IsStreamOwner = false;
                helperStream.WriteLEInt(0);       // Reserved
                helperStream.WriteLEShort(1);     // Tag
                helperStream.WriteLEShort(24);    // Length = 3 x 8.
                helperStream.WriteLELong(this.lastModificationTime_.ToFileTime());
                helperStream.WriteLELong(this.lastAccessTime_.ToFileTime());
                helperStream.WriteLELong(this.createTime_.ToFileTime());
                return ms.ToArray();
                }
            }

        /// <summary>
        /// Test a <see cref="DateTime"> valuie to see if is valid and can be represented here.</see>
        /// </summary>
        /// <param name="value">The <see cref="DateTime">value</see> to test.</param>
        /// <returns>Returns true if the value is valid and can be represented; false if not.</returns>
        /// <remarks>
        /// NTFS filetimes are 64-bit unsigned integers, stored in Intel
        /// (least significant byte first) byte order. They determine the
        /// number of 1.0E-07 seconds (1/10th microseconds!) past WinNT "epoch",
        /// which is "01-Jan-1601 00:00:00 UTC". 28 May 60056 is the upper limit
        /// </remarks>
        public static bool IsValidValue(DateTime value)
            {
            bool result = true;
            try
                {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                value.ToFileTimeUtc();
                }
            catch
                {
                result = false;
                }
            return result;
            }

        /// <summary>
        /// Get/set the <see cref="DateTime">last modification time</see>.
        /// </summary>
        public DateTime LastModificationTime
            {
            get { return this.lastModificationTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }
                this.lastModificationTime_ = value;
                }
            }

        /// <summary>
        /// Get /set the <see cref="DateTime">create time</see>
        /// </summary>
        public DateTime CreateTime
            {
            get { return this.createTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }
                this.createTime_ = value;
                }
            }

        /// <summary>
        /// Get /set the <see cref="DateTime">last access time</see>.
        /// </summary>
        public DateTime LastAccessTime
            {
            get { return this.lastAccessTime_; }
            set
                {
                if (!IsValidValue(value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }
                this.lastAccessTime_ = value;
                }
            }

        #region Instance Fields

        private DateTime lastAccessTime_ = DateTime.FromFileTime(0);
        private DateTime lastModificationTime_ = DateTime.FromFileTime(0);
        private DateTime createTime_ = DateTime.FromFileTime(0);
        #endregion
        }

    /// <summary>
    /// A factory that creates <see cref="ITaggedData">tagged data</see> instances.
    /// </summary>
    internal interface ITaggedDataFactory
        {
        /// <summary>
        /// Get data for a specific tag value.
        /// </summary>
        /// <param name="tag">The tag ID to find.</param>
        /// <param name="data">The data to search.</param>
        /// <param name="offset">The offset to begin extracting data from.</param>
        /// <param name="count">The number of bytes to extract.</param>
        /// <returns>The located <see cref="ITaggedData">value found</see>, or null if not found.</returns>
        ITaggedData Create(short tag, byte[] data, int offset, int count);
        }

    /// 
    /// <summary>
    /// A class to handle the extra data field for Zip entries
    /// </summary>
    /// <remarks>
    /// Extra data contains 0 or more values each prefixed by a header tag and length.
    /// They contain zero or more bytes of actual data.
    /// The data is held internally using a copy on write strategy.  This is more efficient but
    /// means that for extra data created by passing in data can have the values modified by the caller
    /// in some circumstances.
    /// </remarks>
    public sealed class ZipExtraData : IDisposable
        {
        #region Constructors
        /// <summary>
        /// Initialise a default instance.
        /// </summary>
        public ZipExtraData()
            {
            this.Clear();
            }

        /// <summary>
        /// Initialise with known extra data.
        /// </summary>
        /// <param name="data">The extra data.</param>
        public ZipExtraData(byte[] data)
            {
            this.data_ = data ?? new byte[0];
            }

        #endregion

        /// <summary>
        /// Get the raw extra data value
        /// </summary>
        /// <returns>Returns the raw byte[] extra data this instance represents.</returns>
        public byte[] GetEntryData()
            {
            if (this.Length > ushort.MaxValue)
                {
                throw new ZipException("Data exceeds maximum length");
                }

            return (byte[])this.data_.Clone();
            }

        /// <summary>
        /// Clear the stored data.
        /// </summary>
        public void Clear()
            {
            if ((this.data_ == null) || (this.data_.Length != 0))
                {
                this.data_ = new byte[0];
                }
            }

        /// <summary>
        /// Gets the current extra data length.
        /// </summary>
        public int Length => this.data_.Length;

        /// <summary>
        /// Get a read-only <see cref="Stream"/> for the associated tag.
        /// </summary>
        /// <param name="tag">The tag to locate data for.</param>
        /// <returns>Returns a <see cref="Stream"/> containing tag data or null if no tag was found.</returns>
        public Stream GetStreamForTag(int tag)
            {
            Stream result = null;
            if (this.Find(tag))
                {
                result = new MemoryStream(this.data_, this.index_, this.readValueLength_, false);
                }
            return result;
            }

        /// <summary>
        /// Get the <see cref="ITaggedData">tagged data</see> for a tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>Returns a <see cref="ITaggedData">tagged value</see> or null if none found.</returns>
        private ITaggedData GetData(short tag)
            {
            ITaggedData result = null;
            if (this.Find(tag))
                {
                result = Create(tag, this.data_, this.readValueStart_, this.readValueLength_);
                }
            return result;
            }

        private static ITaggedData Create(short tag, byte[] data, int offset, int count)
            {
            ITaggedData result;
            switch (tag)
                {
                case 0x000A:
                    result = new NTTaggedData();
                    break;
                case 0x5455:
                    result = new ExtendedUnixData();
                    break;
                default:
                    result = new RawTaggedData(tag);
                    break;
                }
            result.SetData(data, offset, count);
            return result;
            }

        /// <summary>
        /// Get the length of the last value found by <see cref="Find"/>
        /// </summary>
        /// <remarks>This is only valid if <see cref="Find"/> has previously returned true.</remarks>
        public int ValueLength => this.readValueLength_;

        /// <summary>
        /// Get the index for the current read value.
        /// </summary>
        /// <remarks>This is only valid if <see cref="Find"/> has previously returned true.
        /// Initially the result will be the index of the first byte of actual data.  The value is updated after calls to
        /// <see cref="ReadInt"/>, <see cref="ReadShort"/> and <see cref="ReadLong"/>. </remarks>
        public int CurrentReadIndex => this.index_;

        /// <summary>
        /// Get the number of bytes remaining to be read for the current value;
        /// </summary>
        public int UnreadCount
            {
            get
                {
                if ((this.readValueStart_ > this.data_.Length) ||
                    (this.readValueStart_ < 4))
                    {
                    throw new ZipException("Find must be called before calling a Read method");
                    }

                return this.readValueStart_ + this.readValueLength_ - this.index_;
                }
            }

        /// <summary>
        /// Find an extra data value
        /// </summary>
        /// <param name="headerID">The identifier for the value to find.</param>
        /// <returns>Returns true if the value was found; false otherwise.</returns>
        public bool Find(int headerID)
            {
            this.readValueStart_ = this.data_.Length;
            this.readValueLength_ = 0;
            this.index_ = 0;

            int localLength = this.readValueStart_;
            int localTag = headerID - 1;

            // Trailing bytes that cant make up an entry (as there arent enough
            // bytes for a tag and length) are ignored!
            while ((localTag != headerID) && (this.index_ < this.data_.Length - 3))
                {
                localTag = this.ReadShortInternal();
                localLength = this.ReadShortInternal();
                if (localTag != headerID)
                    {
                    this.index_ += localLength;
                    }
                }

            bool result = (localTag == headerID) && (this.index_ + localLength <= this.data_.Length);

            if (result)
                {
                this.readValueStart_ = this.index_;
                this.readValueLength_ = localLength;
                }

            return result;
            }

        /// <summary>
        /// Add a new entry to extra data.
        /// </summary>
        /// <param name="taggedData">The <see cref="ITaggedData"/> value to add.</param>
        public void AddEntry(ITaggedData taggedData)
            {
            if (taggedData == null)
                {
                throw new ArgumentNullException(nameof(taggedData));
                }
            this.AddEntry(taggedData.TagID, taggedData.GetData());
            }

        /// <summary>
        /// Add a new entry to extra data
        /// </summary>
        /// <param name="headerID">The ID for this entry.</param>
        /// <param name="fieldData">The data to add.</param>
        /// <remarks>If the ID already exists its contents are replaced.</remarks>
        public void AddEntry(int headerID, byte[] fieldData)
            {
            if ((headerID > ushort.MaxValue) || (headerID < 0))
                {
                throw new ArgumentOutOfRangeException(nameof(headerID));
                }

            int addLength = fieldData?.Length ?? 0;

            if (addLength > ushort.MaxValue)
                {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("fieldData");
#else
                throw new ArgumentOutOfRangeException(nameof(fieldData), "exceeds maximum length");
#endif
                }

            // Test for new length before adjusting data.
            int newLength = this.data_.Length + addLength + 4;

            if (this.Find(headerID))
                {
                newLength -= this.ValueLength + 4;
                }

            if (newLength > ushort.MaxValue)
                {
                throw new ZipException("Data exceeds maximum length");
                }

            this.Delete(headerID);

            byte[] newData = new byte[newLength];
            this.data_.CopyTo(newData, 0);
            int index = this.data_.Length;
            this.data_ = newData;
            this.SetShort(ref index, headerID);
            this.SetShort(ref index, addLength);
            fieldData?.CopyTo(newData, index);
            }

        /// <summary>
        /// Start adding a new entry.
        /// </summary>
        /// <remarks>Add data using <see cref="AddData(byte[])"/>, <see cref="AddLeShort"/>, <see cref="AddLeInt"/>, or <see cref="AddLeLong"/>.
        /// The new entry is completed and actually added by calling <see cref="AddNewEntry"/></remarks>
        /// <seealso cref="AddEntry(ITaggedData)"/>
        public void StartNewEntry()
            {
            this.newEntry_ = new MemoryStream();
            }

        /// <summary>
        /// Add entry data added since <see cref="StartNewEntry"/> using the ID passed.
        /// </summary>
        /// <param name="headerID">The identifier to use for this entry.</param>
        public void AddNewEntry(int headerID)
            {
            byte[] newData = this.newEntry_.ToArray();
            this.newEntry_ = null;
            this.AddEntry(headerID, newData);
            }

        /// <summary>
        /// Add a byte of data to the pending new entry.
        /// </summary>
        /// <param name="data">The byte to add.</param>
        /// <seealso cref="StartNewEntry"/>
        public void AddData(byte data)
            {
            this.newEntry_.WriteByte(data);
            }

        /// <summary>
        /// Add data to a pending new entry.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <seealso cref="StartNewEntry"/>
        public void AddData(byte[] data)
            {
            if (data == null)
                {
                throw new ArgumentNullException(nameof(data));
                }

            this.newEntry_.Write(data, 0, data.Length);
            }

        /// <summary>
        /// Add a short value in little endian order to the pending new entry.
        /// </summary>
        /// <param name="toAdd">The data to add.</param>
        /// <seealso cref="StartNewEntry"/>
        public void AddLeShort(int toAdd)
            {
            unchecked
                {
                this.newEntry_.WriteByte((byte)toAdd);
                this.newEntry_.WriteByte((byte)(toAdd >> 8));
                }
            }

        /// <summary>
        /// Add an integer value in little endian order to the pending new entry.
        /// </summary>
        /// <param name="toAdd">The data to add.</param>
        /// <seealso cref="StartNewEntry"/>
        public void AddLeInt(int toAdd)
            {
            unchecked
                {
                this.AddLeShort((short)toAdd);
                this.AddLeShort((short)(toAdd >> 16));
                }
            }

        /// <summary>
        /// Add a long value in little endian order to the pending new entry.
        /// </summary>
        /// <param name="toAdd">The data to add.</param>
        /// <seealso cref="StartNewEntry"/>
        public void AddLeLong(long toAdd)
            {
            unchecked
                {
                this.AddLeInt((int)(toAdd & 0xffffffff));
                this.AddLeInt((int)(toAdd >> 32));
                }
            }

        /// <summary>
        /// Delete an extra data field.
        /// </summary>
        /// <param name="headerID">The identifier of the field to delete.</param>
        /// <returns>Returns true if the field was found and deleted.</returns>
        public bool Delete(int headerID)
            {
            bool result = false;

            if (this.Find(headerID))
                {
                result = true;
                int trueStart = this.readValueStart_ - 4;

                byte[] newData = new byte[this.data_.Length - (this.ValueLength + 4)];
                Array.Copy(this.data_, 0, newData, 0, trueStart);

                int trueEnd = trueStart + this.ValueLength + 4;
                Array.Copy(this.data_, trueEnd, newData, trueStart, this.data_.Length - trueEnd);
                this.data_ = newData;
                }
            return result;
            }

        #region Reading Support
        /// <summary>
        /// Read a long in little endian form from the last <see cref="Find">found</see> data value
        /// </summary>
        /// <returns>Returns the long value read.</returns>
        public long ReadLong()
            {
            this.ReadCheck(8);
            return (this.ReadInt() & 0xffffffff) | ((long)this.ReadInt() << 32);
            }

        /// <summary>
        /// Read an integer in little endian form from the last <see cref="Find">found</see> data value.
        /// </summary>
        /// <returns>Returns the integer read.</returns>
        public int ReadInt()
            {
            this.ReadCheck(4);

            int result = this.data_[this.index_] + (this.data_[this.index_ + 1] << 8) +
                (this.data_[this.index_ + 2] << 16) + (this.data_[this.index_ + 3] << 24);
            this.index_ += 4;
            return result;
            }

        /// <summary>
        /// Read a short value in little endian form from the last <see cref="Find">found</see> data value.
        /// </summary>
        /// <returns>Returns the short value read.</returns>
        public int ReadShort()
            {
            this.ReadCheck(2);
            int result = this.data_[this.index_] + (this.data_[this.index_ + 1] << 8);
            this.index_ += 2;
            return result;
            }

        /// <summary>
        /// Read a byte from an extra data
        /// </summary>
        /// <returns>The byte value read or -1 if the end of data has been reached.</returns>
        public int ReadByte()
            {
            int result = -1;
            if ((this.index_ < this.data_.Length) && (this.readValueStart_ + this.readValueLength_ > this.index_))
                {
                result = this.data_[this.index_];
                this.index_ += 1;
                }
            return result;
            }

        /// <summary>
        /// Skip data during reading.
        /// </summary>
        /// <param name="amount">The number of bytes to skip.</param>
        public void Skip(int amount)
            {
            this.ReadCheck(amount);
            this.index_ += amount;
            }

        private void ReadCheck(int length)
            {
            if ((this.readValueStart_ > this.data_.Length) ||
                (this.readValueStart_ < 4))
                {
                throw new ZipException("Find must be called before calling a Read method");
                }

            if (this.index_ > this.readValueStart_ + this.readValueLength_ - length)
                {
                throw new ZipException("End of extra data");
                }
            }

        /// <summary>
        /// Internal form of <see cref="ReadShort"/> that reads data at any location.
        /// </summary>
        /// <returns>Returns the short value read.</returns>
        private int ReadShortInternal()
            {
            if (this.index_ > this.data_.Length - 2)
                {
                throw new ZipException("End of extra data");
                }

            int result = this.data_[this.index_] + (this.data_[this.index_ + 1] << 8);
            this.index_ += 2;
            return result;
            }

        private void SetShort(ref int index, int source)
            {
            this.data_[index] = (byte)source;
            this.data_[index + 1] = (byte)(source >> 8);
            index += 2;
            }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose of this instance.
        /// </summary>
        public void Dispose()
            {
            this.newEntry_?.Close();
            }

        #endregion

        #region Instance Fields

        private int index_;
        private int readValueStart_;
        private int readValueLength_;

        private MemoryStream newEntry_;
        private byte[] data_;
        #endregion
        }
    }
