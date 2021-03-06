// ZipFile.cs
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
using System.Collections;
using System.IO;
using System.Text;
using System.Globalization;
using System.Linq;
#if !NETCF_1_0
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Encryption;
#endif

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip.Compression;
using JetBrains.Annotations;
// ReSharper disable AssignNullToNotNullAttribute

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
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable StringLiteralTypo

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
    #region Keys Required Event Args
    /// <summary>
    /// Arguments used with KeysRequiredEvent
    /// </summary>
    public class KeysRequiredEventArgs : EventArgs
        {
        #region Constructors
        /// <summary>
        /// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
        /// </summary>
        /// <param name="name">The name of the file for which keys are required.</param>
        public KeysRequiredEventArgs(string name)
            {
            this.FileName = name;
            }

        /// <summary>
        /// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
        /// </summary>
        /// <param name="name">The name of the file for which keys are required.</param>
        /// <param name="keyValue">The current key value.</param>
        public KeysRequiredEventArgs(string name, byte[] keyValue)
            {
            this.FileName = name;
            this.Key = keyValue;
            }

        #endregion
        #region Properties
        /// <summary>
        /// Gets the name of the file for which keys are required.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets or sets the key value
        /// </summary>
        public byte[] Key { get; }

        #endregion

        #region Instance Fields

        #endregion
        }
    #endregion

    #region Test Definitions
    /// <summary>
    /// The strategy to apply to testing.
    /// </summary>
    public enum TestStrategy
        {
        /// <summary>
        /// Find the first error only.
        /// </summary>
        FindFirstError,
        /// <summary>
        /// Find all possible errors.
        /// </summary>
        FindAllErrors
        }

    /// <summary>
    /// The operation in progress reported by a <see cref="ZipTestResultHandler"/> during testing.
    /// </summary>
    /// <seealso cref="ZipFile.TestArchive(bool,TestStrategy,ZipTestResultHandler)">TestArchive</seealso>
    public enum TestOperation
        {
        /// <summary>
        /// Setting up testing.
        /// </summary>
        Initialising,

        /// <summary>
        /// Testing an individual entries header
        /// </summary>
        EntryHeader,

        /// <summary>
        /// Testing an individual entries data
        /// </summary>
        EntryData,

        /// <summary>
        /// Testing an individual entry has completed.
        /// </summary>
        EntryComplete,

        /// <summary>
        /// Running miscellaneous tests
        /// </summary>
        MiscellaneousTests,

        /// <summary>
        /// Testing is complete
        /// </summary>
        Complete
        }

    /// <summary>
    /// Status returned returned by <see cref="ZipTestResultHandler"/> during testing.
    /// </summary>
    /// <seealso cref="ZipFile.TestArchive(bool,TestStrategy,ZipTestResultHandler)">TestArchive</seealso>
    public class TestStatus
        {
        #region Constructors
        /// <summary>
        /// Initialise a new instance of <see cref="TestStatus"/>
        /// </summary>
        /// <param name="file">The <see cref="ZipFile"/> this status applies to.</param>
        public TestStatus(ZipFile file)
            {
            this.File = file;
            }
        #endregion

        #region Properties

        /// <summary>
        /// Get the current <see cref="TestOperation"/> in progress.
        /// </summary>
        public TestOperation Operation { get; private set; }

        /// <summary>
        /// Get the <see cref="ZipFile"/> this status is applicable to.
        /// </summary>
        public ZipFile File { get; }

        /// <summary>
        /// Get the current/last entry tested.
        /// </summary>
        public ZipEntry Entry { get; private set; }

        /// <summary>
        /// Get the number of errors detected so far.
        /// </summary>
        public int ErrorCount { get; private set; }

        /// <summary>
        /// Get the number of bytes tested so far for the current entry.
        /// </summary>
        public long BytesTested { get; private set; }

        /// <summary>
        /// Get a value indicating wether the last entry test was valid.
        /// </summary>
        public bool EntryValid { get; private set; }

        #endregion

        #region Internal API
        internal void AddError()
            {
            this.ErrorCount++;
            this.EntryValid = false;
            }

        internal void SetOperation(TestOperation operation)
            {
            this.Operation = operation;
            }

        internal void SetEntry(ZipEntry entry)
            {
            this.Entry = entry;
            this.EntryValid = true;
            this.BytesTested = 0;
            }

        internal void SetBytesTested(long value)
            {
            this.BytesTested = value;
            }
        #endregion

        #region Instance Fields

        #endregion
        }

    /// <summary>
    /// Delegate invoked during <see cref="ZipFile.TestArchive(bool, TestStrategy, ZipTestResultHandler)">testing</see> if supplied indicating current progress and status.
    /// </summary>
    /// <remarks>If the message is non-null an error has occured.  If the message is null
    /// the operation as found in <see cref="TestStatus">status</see> has started.</remarks>
    public delegate void ZipTestResultHandler(TestStatus status, string message);
    #endregion

    #region Update Definitions
    /// <summary>
    /// The possible ways of <see cref="ZipFile.CommitUpdate()">applying updates</see> to an archive.
    /// </summary>
    public enum FileUpdateMode
        {
        /// <summary>
        /// Perform all updates on temporary files ensuring that the original file is saved.
        /// </summary>
        Safe,
        /// <summary>
        /// Update the archive directly, which is faster but less safe.
        /// </summary>
        Direct
        }
    #endregion

    #region ZipFile Class
    /// <summary>
    /// This class represents a Zip archive.  You can ask for the contained
    /// entries, or get an input stream for a file entry.  The entry is
    /// automatically decompressed.
    /// 
    /// You can also update the archive adding or deleting entries.
    /// 
    /// This class is thread safe for input:  You can open input streams for arbitrary
    /// entries in different threads.
    /// <br/>
    /// <br/>Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <example>
    /// <code>
    /// using System;
    /// using System.Text;
    /// using System.Collections;
    /// using System.IO;
    /// 
    /// using ICSharpCode.SharpZipLib.Zip;
    /// 
    /// class MainClass
    /// {
    /// 	static public void Main(string[] args)
    /// 	{
    /// 		using (ZipFile zFile = new ZipFile(args[0])) {
    /// 			Console.WriteLine($"Listing of : {zFile.Name}");
    /// 			Console.WriteLine("");
    /// 			Console.WriteLine("Raw Size    Size      Date     Time     Name");
    /// 			Console.WriteLine("--------  --------  --------  ------  ---------");
    /// 			foreach (ZipEntry e in zFile) {
    /// 				if ( e.IsFile ) {
    /// 					DateTime d = e.DateTime;
    /// 					Console.WriteLine("{0, -10}{1, -10}{2}  {3}   {4}", e.Size, e.CompressedSize,
    /// 						d.ToString("dd-MM-yy"), d.ToString("HH:mm"),
    /// 						e.Name);
    /// 				}
    /// 			}
    /// 		}
    /// 	}
    /// }
    /// </code>
    /// </example>
    public class ZipFile : IEnumerable, IDisposable
        {
        #region KeyHandling

        /// <summary>
        /// Delegate for handling keys/password setting during compresion/decompression.
        /// </summary>
        public delegate void KeysRequiredEventHandler(
            object sender,
            KeysRequiredEventArgs e
        );

        /// <summary>
        /// Event handler for handling encryption keys.
        /// </summary>
        public KeysRequiredEventHandler KeysRequired;

        /// <summary>
        /// Handles getting of encryption keys when required.
        /// </summary>
        /// <param name="fileName">The file for which encryption keys are required.</param>
        private void OnKeysRequired(string fileName)
            {
            if (this.KeysRequired != null)
                {
                var krea = new KeysRequiredEventArgs(fileName, this.Key);
                this.KeysRequired(this, krea);
                this.Key = krea.Key;
                }
            }

        /// <summary>
        /// Get/set the encryption key value.
        /// </summary>
        private byte[] Key { get; set; }

#if !NETCF_1_0
        /// <summary>
        /// Password to be used for encrypting/decrypting files.
        /// </summary>
        /// <remarks>Set to null if no password is required.</remarks>
        public string Password
            {
            set
                {
                if ((value == null) || (value.Length == 0))
                    {
                    this.Key = null;
                    }
                else
                    {
                    this.Key = PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(value));
                    }
                }
            }
#endif

        /// <summary>
        /// Get a value indicating wether encryption keys are currently available.
        /// </summary>
        private bool HaveKeys => this.Key != null;

        #endregion

        #region Constructors
        /// <summary>
        /// Opens a Zip file with the given name for reading.
        /// </summary>
        /// <param name="name">The name of the file to open.</param>
        /// <exception cref="ArgumentNullException">The argument supplied is null.</exception>
        /// <exception cref="IOException">
        /// An i/o error occurs
        /// </exception>
        /// <exception cref="ZipException">
        /// The file doesn't contain a valid zip archive.
        /// </exception>
        public ZipFile(string name)
            {
            if (name == null)
                {
                throw new ArgumentNullException(nameof(name));
                }

            this.Name = name;

            this.baseStream_ = File.OpenRead(name);
            this.IsStreamOwner = true;

            try
                {
                this.ReadEntries();
                }
            catch
                {
                this.DisposeInternal(disposing: true);
                throw;
                }
            }

        /// <summary>
        /// Opens a Zip file reading the given <see cref="FileStream"/>.
        /// </summary>
        /// <param name="file">The <see cref="FileStream"/> to read archive data from.</param>
        /// <exception cref="ArgumentNullException">The supplied argument is null.</exception>
        /// <exception cref="IOException">
        /// An i/o error occurs.
        /// </exception>
        /// <exception cref="ZipException">
        /// The file doesn't contain a valid zip archive.
        /// </exception>
        public ZipFile(FileStream file)
            {
            if (file == null)
                {
                throw new ArgumentNullException(nameof(file));
                }

            if (!file.CanSeek)
                {
                throw new ArgumentException("Stream is not seekable", nameof(file));
                }

            this.baseStream_ = file;
            this.Name = file.Name;
            this.IsStreamOwner = true;

            try
                {
                this.ReadEntries();
                }
            catch
                {
                this.DisposeInternal(disposing: true);
                throw;
                }
            }

        /// <summary>
        /// Opens a Zip file reading the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to read archive data from.</param>
        /// <exception cref="IOException">
        /// An i/o error occurs
        /// </exception>
        /// <exception cref="ZipException">
        /// The stream doesn't contain a valid zip archive.<br/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The <see cref="Stream">stream</see> doesnt support seeking.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The <see cref="Stream">stream</see> argument is null.
        /// </exception>
        public ZipFile(Stream stream)
            {
            if (stream == null)
                {
                throw new ArgumentNullException(nameof(stream));
                }

            if (!stream.CanSeek)
                {
                throw new ArgumentException("Stream is not seekable", nameof(stream));
                }

            this.baseStream_ = stream;
            this.IsStreamOwner = true;

            if (this.baseStream_.Length > 0)
                {
                try
                    {
                    this.ReadEntries();
                    }
                catch
                    {
                    this.DisposeInternal(disposing: true);
                    throw;
                    }
                }
            else
                {
                this.entries_ = new ZipEntry[0];
                this.IsNewArchive = true;
                }
            }

        /// <summary>
        /// Initialises a default <see cref="ZipFile"/> instance with no entries and no file storage.
        /// </summary>
        internal ZipFile()
            {
            this.entries_ = new ZipEntry[0];
            this.IsNewArchive = true;
            }

        #endregion

        #region Destructors and Closing
        /// <summary>
        /// Finalize this instance.
        /// </summary>
        ~ZipFile()
            {
            this.Dispose(disposing: false);
            }

        /// <summary>
        /// Closes the ZipFile.  If the stream is <see cref="IsStreamOwner">owned</see> then this also closes the underlying input stream.
        /// Once closed, no further instance methods should be called.
        /// </summary>
        /// <exception cref="System.IO.IOException">
        /// An i/o error occurs.
        /// </exception>
        public void Close()
            {
            this.DisposeInternal(disposing: true);
            GC.SuppressFinalize(this);
            }

        #endregion

        #region Creators
        /// <summary>
        /// Create a new <see cref="ZipFile"/> whose data will be stored in a file.
        /// </summary>
        /// <param name="fileName">The name of the archive to create.</param>
        /// <returns>Returns the newly created <see cref="ZipFile"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="fileName"></paramref> is null</exception>
        public static ZipFile Create(string fileName)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            var fs = File.Create(fileName);

            var result = new ZipFile
                {
                Name = fileName,
                baseStream_ = fs,
                IsStreamOwner = true
                };
            return result;
            }

        /// <summary>
        /// Create a new <see cref="ZipFile"/> whose data will be stored on a stream.
        /// </summary>
        /// <param name="outStream">The stream providing data storage.</param>
        /// <returns>Returns the newly created <see cref="ZipFile"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="outStream"> is null</paramref></exception>
        /// <exception cref="ArgumentException"><paramref name="outStream"> doesnt support writing.</paramref></exception>
        public static ZipFile Create(Stream outStream)
            {
            if (outStream == null)
                {
                throw new ArgumentNullException(nameof(outStream));
                }

            if (!outStream.CanWrite)
                {
                throw new ArgumentException("Stream is not writeable", nameof(outStream));
                }

            if (!outStream.CanSeek)
                {
                throw new ArgumentException("Stream is not seekable", nameof(outStream));
                }

            var result = new ZipFile { baseStream_ = outStream };
            return result;
            }

        #endregion

        #region Properties
        /// <summary>
        /// Get/set a flag indicating if the underlying stream is owned by the ZipFile instance.
        /// If the flag is true then the stream will be closed when <see cref="Close">Close</see> is called.
        /// </summary>
        /// <remarks>
        /// The default value is true in all cases.
        /// </remarks>
        public bool IsStreamOwner { get; set; }

        /// <summary>
        /// Get a value indicating wether
        /// this archive is embedded in another file or not.
        /// </summary>
        public bool IsEmbeddedArchive => this.offsetOfFirstEntry > 0;

        /// <summary>
        /// Get a value indicating that this archive is a new one.
        /// </summary>
        public bool IsNewArchive { get; private set; }

        /// <summary>
        /// Gets the comment for the zip file.
        /// </summary>
        public string ZipFileComment { get; private set; }

        /// <summary>
        /// Gets the name of this zip file.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the number of entries in this zip file.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Zip file has been closed.
        /// </exception>
        [Obsolete("Use the Count property instead")]
        public int Size => this.entries_.Length;

        /// <summary>
        /// Get the number of entries contained in this <see cref="ZipFile"/>.
        /// </summary>
        public long Count => this.entries_.Length;

        /// <summary>
        /// Indexer property for ZipEntries
        /// </summary>
        [System.Runtime.CompilerServices.IndexerNameAttribute("EntryByIndex")]
        public ZipEntry this[int index] => (ZipEntry)this.entries_[index].Clone();

        #endregion

        #region Input Handling
        /// <summary>
        /// Gets an enumerator for the Zip entries in this Zip file.
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerator"/> for this archive.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The Zip file has been closed.
        /// </exception>
        public IEnumerator GetEnumerator()
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            return new ZipEntryEnumerator(this.entries_);
            }

        /// <summary>
        /// Return the index of the entry with a matching name
        /// </summary>
        /// <param name="name">Entry name to find</param>
        /// <param name="ignoreCase">If true the comparison is case insensitive</param>
        /// <returns>The index position of the matching entry or -1 if not found</returns>
        /// <exception cref="ObjectDisposedException">
        /// The Zip file has been closed.
        /// </exception>
        public int FindEntry(string name, bool ignoreCase)
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            for (int i = 0; i < this.entries_.Length; i++)
                {
                if (string.Compare(name, this.entries_[i].Name, ignoreCase, CultureInfo.InvariantCulture) == 0)
                    {
                    return i;
                    }
                }
            return -1;
            }

        /// <summary>
        /// Searches for a zip entry in this archive with the given name.
        /// String comparisons are case insensitive
        /// </summary>
        /// <param name="name">
        /// The name to find. May contain directory components separated by slashes ('/').
        /// </param>
        /// <returns>
        /// A clone of the zip entry, or null if no entry with that name exists.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// The Zip file has been closed.
        /// </exception>
        public ZipEntry GetEntry(string name)
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            int index = this.FindEntry(name, ignoreCase: true);
            return index >= 0 ? (ZipEntry)this.entries_[index].Clone() : null;
            }

        /// <summary>
        /// Gets an input stream for reading the given zip entry data in an uncompressed form.
        /// Normally the <see cref="ZipEntry"/> should be an entry returned by GetEntry().
        /// </summary>
        /// <param name="entry">The <see cref="ZipEntry"/> to obtain a data <see cref="Stream"/> for</param>
        /// <returns>An input <see cref="Stream"/> containing data for this <see cref="ZipEntry"/></returns>
        /// <exception cref="ObjectDisposedException">
        /// The ZipFile has already been closed
        /// </exception>
        /// <exception cref="ICSharpCode.SharpZipLib.Zip.ZipException">
        /// The compression method for the entry is unknown
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// The entry is not found in the ZipFile
        /// </exception>
        public Stream GetInputStream(ZipEntry entry)
            {
            if (entry == null)
                {
                throw new ArgumentNullException(nameof(entry));
                }

            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            long index = entry.ZipFileIndex;
            if ((index < 0) || (index >= this.entries_.Length) || (this.entries_[index].Name != entry.Name))
                {
                index = this.FindEntry(entry.Name, ignoreCase: true);
                if (index < 0)
                    {
                    throw new ZipException("Entry cannot be found");
                    }
                }
            return this.GetInputStream(index);
            }

        /// <summary>
        /// Creates an input stream reading a zip entry
        /// </summary>
        /// <param name="entryIndex">The index of the entry to obtain an input stream for.</param>
        /// <returns>
        /// An input <see cref="Stream"/> containing data for this <paramref name="entryIndex"/>
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        /// The ZipFile has already been closed
        /// </exception>
        /// <exception cref="ICSharpCode.SharpZipLib.Zip.ZipException">
        /// The compression method for the entry is unknown
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// The entry is not found in the ZipFile
        /// </exception>
        public Stream GetInputStream(long entryIndex)
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            long start = this.LocateEntry(this.entries_[entryIndex]);
            var method = this.entries_[entryIndex].CompressionMethod;
            Stream result = new PartialInputStream(this, start, this.entries_[entryIndex].CompressedSize);

            if (this.entries_[entryIndex].IsCrypted)
                {
#if NETCF_1_0
				throw new ZipException("decryption not supported for Compact Framework 1.0");
#else
                result = this.CreateAndInitDecryptionStream(result, this.entries_[entryIndex]);
                if (result == null)
                    {
                    throw new ZipException("Unable to decrypt this entry");
                    }
#endif
                }

            switch (method)
                {
                case CompressionMethod.Stored:
                    // read as is.
                    break;

                case CompressionMethod.Deflated:
                    // No need to worry about ownership and closing as underlying stream close does nothing.
                    result = new InflaterInputStream(result, new Inflater(noHeader: true));
                    break;

                default:
                    throw new ZipException($"Unsupported compression method {method}");
                }

            return result;
            }

        #endregion

        #region Archive Testing

        /// <summary>
        /// Test an archive for integrity/validity
        /// </summary>
        /// <param name="testData">Perform low level data Crc check</param>
        /// <param name="strategy">The <see cref="TestStrategy"></see> to apply.</param>
        /// <param name="resultHandler">The <see cref="ZipTestResultHandler"></see> handler to call during testing.</param>
        /// <returns>true if all tests pass, false otherwise</returns>
        /// <exception cref="ObjectDisposedException">The object has already been closed.</exception>
        public bool TestArchive(bool testData, TestStrategy strategy = TestStrategy.FindFirstError, ZipTestResultHandler resultHandler = null)
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            var status = new TestStatus(this);

            resultHandler?.Invoke(status, message: null);

            var test = testData ? HeaderTest.Header | HeaderTest.Extract : HeaderTest.Header;

            bool testing = true;

            try
                {
                int entryIndex = 0;

                while (testing && (entryIndex < this.Count))
                    {
                    if (resultHandler != null)
                        {
                        status.SetEntry(this[entryIndex]);
                        status.SetOperation(TestOperation.EntryHeader);
                        resultHandler(status, message: null);
                        }

                    try
                        {
                        this.TestLocalHeader(this[entryIndex], test);
                        }
                    catch (ZipException ex)
                        {
                        status.AddError();

                        resultHandler?.Invoke(status,
                            $"Exception during test - '{ex.Message}'");

                        if (strategy == TestStrategy.FindFirstError)
                            {
                            testing = false;
                            }
                        }

                    if (testing && testData && this[entryIndex].IsFile)
                        {
                        if (resultHandler != null)
                            {
                            status.SetOperation(TestOperation.EntryData);
                            resultHandler(status, message: null);
                            }

                        var crc = new Crc32();

                        using (var entryStream = this.GetInputStream(this[entryIndex]))
                            {

                            var buffer = new byte[4096];
                            long totalBytes = 0;
                            int bytesRead;
                            while ((bytesRead = entryStream.Read(buffer, offset: 0, count: buffer.Length)) > 0)
                                {
                                crc.Update(buffer, offset: 0, count: bytesRead);

                                if (resultHandler != null)
                                    {
                                    totalBytes += bytesRead;
                                    status.SetBytesTested(totalBytes);
                                    resultHandler(status, message: null);
                                    }
                                }
                            }

                        if (this[entryIndex].Crc != crc.Value)
                            {
                            status.AddError();

                            resultHandler?.Invoke(status, "CRC mismatch");

                            if (strategy == TestStrategy.FindFirstError)
                                {
                                testing = false;
                                }
                            }

                        if ((this[entryIndex].Flags & (int)GeneralBitFlags.Descriptor) != 0)
                            {
                            var helper = new ZipHelperStream(this.baseStream_);
                            var data = new DescriptorData();
                            helper.ReadDataDescriptor(this[entryIndex].LocalHeaderRequiresZip64, data);
                            if (this[entryIndex].Crc != data.Crc)
                                {
                                status.AddError();
                                }

                            if (this[entryIndex].CompressedSize != data.CompressedSize)
                                {
                                status.AddError();
                                }

                            if (this[entryIndex].Size != data.Size)
                                {
                                status.AddError();
                                }
                            }
                        }

                    if (resultHandler != null)
                        {
                        status.SetOperation(TestOperation.EntryComplete);
                        resultHandler(status, message: null);
                        }

                    entryIndex += 1;
                    }

                if (resultHandler != null)
                    {
                    status.SetOperation(TestOperation.MiscellaneousTests);
                    resultHandler(status, message: null);
                    }

                }
            catch (Exception ex)
                {
                status.AddError();

                resultHandler?.Invoke(status, $"Exception during test - '{ex.Message}'");
                }

            if (resultHandler != null)
                {
                status.SetOperation(TestOperation.Complete);
                status.SetEntry(entry: null);
                resultHandler(status, message: null);
                }

            return status.ErrorCount == 0;
            }

        [Flags]
        private enum HeaderTest
            {
            Extract = 0x01,     // Check that this header represents an entry whose data can be extracted
            Header = 0x02     // Check that this header contents are valid
            }

        /// <summary>
        /// Test a local header against that provided from the central directory
        /// </summary>
        /// <param name="entry">
        /// The entry to test against
        /// </param>
        /// <param name="tests">The type of <see cref="HeaderTest">tests</see> to carry out.</param>
        /// <returns>The offset of the entries data in the file</returns>
        private long TestLocalHeader(ZipEntry entry, HeaderTest tests)
            {
            lock (this.baseStream_)
                {
                bool testHeader = (tests & HeaderTest.Header) != 0;
                bool testData = (tests & HeaderTest.Extract) != 0;

                this.baseStream_.Seek(this.offsetOfFirstEntry + entry.Offset, SeekOrigin.Begin);
                if ((int)this.ReadLEUint() != ZipConstants.LocalHeaderSignature)
                    {
                    throw new ZipException($"Wrong local header signature @{this.offsetOfFirstEntry + entry.Offset:X}");
                    }

                short extractVersion = (short)this.ReadLEUshort();
                short localFlags = (short)this.ReadLEUshort();
                short compressionMethod = (short)this.ReadLEUshort();
                short fileTime = (short)this.ReadLEUshort();
                short fileDate = (short)this.ReadLEUshort();
                uint crcValue = this.ReadLEUint();
                long compressedSize = this.ReadLEUint();
                long size = this.ReadLEUint();
                int storedNameLength = this.ReadLEUshort();
                int extraDataLength = this.ReadLEUshort();

                var nameData = new byte[storedNameLength];
                StreamUtils.ReadFully(this.baseStream_, nameData);

                var extraData = new byte[extraDataLength];
                StreamUtils.ReadFully(this.baseStream_, extraData);

                var localExtraData = new ZipExtraData(extraData);

                // Extra data / zip64 checks
                if (localExtraData.Find(headerID: 1))
                    {
                    // Zip64 extra data but 'extract version' is too low
                    if (extractVersion < ZipConstants.VersionZip64)
                        {
                        throw new ZipException(
                            $"Extra data contains Zip64 information but version {extractVersion / 10}.{extractVersion % 10} is not high enough");
                        }

                    // Zip64 extra data but size fields dont indicate its required.
                    if (((uint)size != uint.MaxValue) && ((uint)compressedSize != uint.MaxValue))
                        {
                        throw new ZipException("Entry sizes not correct for Zip64");
                        }

                    size = localExtraData.ReadLong();
                    compressedSize = localExtraData.ReadLong();

                    if ((localFlags & (int)GeneralBitFlags.Descriptor) != 0)
                        {
                        // These may be valid if patched later
                        if ((size != -1) && (size != entry.Size))
                            {
                            throw new ZipException("Size invalid for descriptor");
                            }

                        if ((compressedSize != -1) && (compressedSize != entry.CompressedSize))
                            {
                            throw new ZipException("Compressed size invalid for descriptor");
                            }
                        }
                    }
                else
                    {
                    // No zip64 extra data but entry requires it.
                    if ((extractVersion >= ZipConstants.VersionZip64) &&
                        (((uint)size == uint.MaxValue) || ((uint)compressedSize == uint.MaxValue)))
                        {
                        throw new ZipException("Required Zip64 extended information missing");
                        }
                    }

                if (testData)
                    {
                    if (entry.IsFile)
                        {
                        if (!entry.IsCompressionMethodSupported())
                            {
                            throw new ZipException("Compression method not supported");
                            }

                        if ((extractVersion > ZipConstants.VersionMadeBy)
                            || ((extractVersion > 20) && (extractVersion < ZipConstants.VersionZip64)))
                            {
                            throw new ZipException(
                                $"Version required to extract this entry not supported ({extractVersion})");
                            }

                        if ((localFlags & (int)(GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked)) != 0)
                            {
                            throw new ZipException("The library does not support the zip version required to extract this entry");
                            }
                        }
                    }

                if (testHeader)
                    {
                    if ((extractVersion <= 63) &&   // Ignore later versions as we dont know about them..
                        (extractVersion != 10) &&
                        (extractVersion != 11) &&
                        (extractVersion != 20) &&
                        (extractVersion != 21) &&
                        (extractVersion != 25) &&
                        (extractVersion != 27) &&
                        (extractVersion != 45) &&
                        (extractVersion != 46) &&
                        (extractVersion != 50) &&
                        (extractVersion != 51) &&
                        (extractVersion != 52) &&
                        (extractVersion != 61) &&
                        (extractVersion != 62) &&
                        (extractVersion != 63)
                        )
                        {
                        throw new ZipException($"Version required to extract this entry is invalid ({extractVersion})");
                        }

                    // Local entry flags dont have reserved bit set on.
                    if ((localFlags & (int)(GeneralBitFlags.ReservedPKware4 | GeneralBitFlags.ReservedPkware14 | GeneralBitFlags.ReservedPkware15)) != 0)
                        {
                        throw new ZipException("Reserved bit flags cannot be set.");
                        }

                    // Encryption requires extract version >= 20
                    if (((localFlags & (int)GeneralBitFlags.Encrypted) != 0) && (extractVersion < 20))
                        {
                        throw new ZipException(
                            $"Version required to extract this entry is too low for encryption ({extractVersion})");
                        }

                    // Strong encryption requires encryption flag to be set and extract version >= 50.
                    if ((localFlags & (int)GeneralBitFlags.StrongEncryption) != 0)
                        {
                        if ((localFlags & (int)GeneralBitFlags.Encrypted) == 0)
                            {
                            throw new ZipException("Strong encryption flag set but encryption flag is not set");
                            }

                        if (extractVersion < 50)
                            {
                            throw new ZipException(
                                $"Version required to extract this entry is too low for encryption ({extractVersion})");
                            }
                        }

                    // Patched entries require extract version >= 27
                    if (((localFlags & (int)GeneralBitFlags.Patched) != 0) && (extractVersion < 27))
                        {
                        throw new ZipException($"Patched data requires higher version than ({extractVersion})");
                        }

                    // Central header flags match local entry flags.
                    if (localFlags != entry.Flags)
                        {
                        throw new ZipException("Central header/local header flags mismatch");
                        }

                    // Central header compression method matches local entry
                    if (entry.CompressionMethod != (CompressionMethod)compressionMethod)
                        {
                        throw new ZipException("Central header/local header compression method mismatch");
                        }

                    if (entry.Version != extractVersion)
                        {
                        throw new ZipException("Extract version mismatch");
                        }

                    // Strong encryption and extract version match
                    if ((localFlags & (int)GeneralBitFlags.StrongEncryption) != 0)
                        {
                        if (extractVersion < 62)
                            {
                            throw new ZipException("Strong encryption flag set but version not high enough");
                            }
                        }

                    if ((localFlags & (int)GeneralBitFlags.HeaderMasked) != 0)
                        {
                        if ((fileTime != 0) || (fileDate != 0))
                            {
                            throw new ZipException("Header masked set but date/time values non-zero");
                            }
                        }

                    if ((localFlags & (int)GeneralBitFlags.Descriptor) == 0)
                        {
                        if (crcValue != (uint)entry.Crc)
                            {
                            throw new ZipException("Central header/local header crc mismatch");
                            }
                        }

                    // Crc valid for empty entry.
                    // This will also apply to streamed entries where size isnt known and the header cant be patched
                    if ((size == 0) && (compressedSize == 0))
                        {
                        if (crcValue != 0)
                            {
                            throw new ZipException("Invalid CRC for empty entry");
                            }
                        }

                    if (entry.Name.Length > storedNameLength)
                        {
                        throw new ZipException("File name length mismatch");
                        }

                    // Name data has already been read convert it and compare.
                    string localName = ZipConstants.ConvertToStringExt(localFlags, nameData);

                    // Central directory and local entry name match
                    if (localName != entry.Name)
                        {
                        throw new ZipException("Central header and local header file name mismatch");
                        }

                    // Directories have zero actual size but can have compressed size
                    if (entry.IsDirectory)
                        {
                        if (size > 0)
                            {
                            throw new ZipException("Directory cannot have size");
                            }

                        // There may be other cases where the compressed size can be greater than this?
                        // If so until details are known we will be strict.
                        if (entry.IsCrypted)
                            {
                            if (compressedSize > ZipConstants.CryptoHeaderSize + 2)
                                {
                                throw new ZipException("Directory compressed size invalid");
                                }
                            }
                        else if (compressedSize > 2)
                            {
                            // When not compressed the directory size can validly be 2 bytes
                            // if the true size wasnt known when data was originally being written.
                            // NOTE: Versions of the library 0.85.4 and earlier always added 2 bytes
                            throw new ZipException("Directory compressed size invalid");
                            }
                        }

                    if (!ZipNameTransform.IsValidName(localName, relaxed: true))
                        {
                        throw new ZipException("Name is invalid");
                        }
                    }

                // Tests that apply to both data and header.

                // Size can be verified only if it is known in the local header.
                // it will always be known in the central header.
                if (((localFlags & (int)GeneralBitFlags.Descriptor) == 0) || (size > 0) || (compressedSize > 0))
                    {

                    if (size != entry.Size)
                        {
                        throw new ZipException(
                            $"Size mismatch between central header({entry.Size}) and local header({size})");
                        }

                    if (compressedSize != entry.CompressedSize)
                        {
                        throw new ZipException(
                            $"Compressed size mismatch between central header({entry.CompressedSize}) and local header({compressedSize})");
                        }
                    }

                int extraLength = storedNameLength + extraDataLength;
                return this.offsetOfFirstEntry + entry.Offset + ZipConstants.LocalHeaderBaseSize + extraLength;
                }
            }

        #endregion

        #region Updating

        private const int DefaultBufferSize = 4096;

        /// <summary>
        /// The kind of update to apply.
        /// </summary>
        private enum UpdateCommand
            {
            Copy,       // Copy original file contents.
            Modify,     // Change encryption, compression, attributes, name, time etc, of an existing file.
            Add        // Add a new file to the archive.
            }

        #region Properties
        /// <summary>
        /// Get / set the <see cref="INameTransform"/> to apply to names when updating.
        /// </summary>
        public INameTransform NameTransform
            {
            get
                {
                return this.updateEntryFactory_.NameTransform;
                }

            set
                {
                this.updateEntryFactory_.NameTransform = value;
                }
            }

        /// <summary>
        /// Get/set the <see cref="IEntryFactory"/> used to generate <see cref="ZipEntry"/> values
        /// during updates.
        /// </summary>
        public IEntryFactory EntryFactory
            {
            get
                {
                return this.updateEntryFactory_;
                }

            set
                {
                this.updateEntryFactory_ = value ?? new ZipEntryFactory();
                }
            }

        /// <summary>
        /// Get /set the buffer size to be used when updating this zip file.
        /// </summary>
        public int BufferSize
            {
            get { return this.bufferSize_; }
            set
                {
                if (value < 1024)
                    {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be below 1024");
#endif
                    }

                if (this.bufferSize_ != value)
                    {
                    this.bufferSize_ = value;
                    this.copyBuffer_ = null;
                    }
                }
            }

        /// <summary>
        /// Get a value indicating an update has <see cref="BeginUpdate()">been started</see>.
        /// </summary>
        public bool IsUpdating => this.updates_ != null;

        /// <summary>
        /// Get / set a value indicating how Zip64 Extension usage is determined when adding entries.
        /// </summary>
        public UseZip64 UseZip64 { get; set; } = UseZip64.Dynamic;

        #endregion

        #region Immediate updating
        //		TBD: Direct form of updating
        // 
        //		public void Update(IEntryMatcher deleteMatcher)
        //		{
        //		}
        //
        //		public void Update(IScanner addScanner)
        //		{
        //		}
        #endregion

        #region Deferred Updating
        /// <summary>
        /// Begin updating this <see cref="ZipFile"/> archive.
        /// </summary>
        /// <param name="archiveStorage">The <see cref="IArchiveStorage">archive storage</see> for use during the update.</param>
        /// <param name="dataSource">The <see cref="IDynamicDataSource">data source</see> to utilise during updating.</param>
        /// <exception cref="ObjectDisposedException">ZipFile has been closed.</exception>
        /// <exception cref="ArgumentNullException">One of the arguments provided is null</exception>
        /// <exception cref="ObjectDisposedException">ZipFile has been closed.</exception>
        public void BeginUpdate(IArchiveStorage archiveStorage, IDynamicDataSource dataSource)
            {
            if (archiveStorage == null)
                {
                throw new ArgumentNullException(nameof(archiveStorage));
                }

            if (dataSource == null)
                {
                throw new ArgumentNullException(nameof(dataSource));
                }

            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            if (this.IsEmbeddedArchive)
                {
                throw new ZipException("Cannot update embedded/SFX archives");
                }

            this.archiveStorage_ = archiveStorage;
            this.updateDataSource_ = dataSource;

            // NOTE: the baseStream_ may not currently support writing or seeking.

            this.updateIndex_ = new Hashtable();

            this.updates_ = new ArrayList(this.entries_.Length);
            foreach (var entry in this.entries_)
                {
                int index = this.updates_.Add(new ZipUpdate(entry));
                this.updateIndex_.Add(entry.Name, index);
                }

            this.updateCount_ = this.updates_.Count;

            this.contentsEdited_ = false;
            this.commentEdited_ = false;
            this.newComment_ = null;
            }

        /// <summary>
        /// Begin updating to this <see cref="ZipFile"/> archive.
        /// </summary>
        /// <param name="archiveStorage">The storage to use during the update.</param>
        public void BeginUpdate(IArchiveStorage archiveStorage)
            {
            this.BeginUpdate(archiveStorage, new DynamicDiskDataSource());
            }

        /// <summary>
        /// Begin updating this <see cref="ZipFile"/> archive.
        /// </summary>
        /// <seealso cref="BeginUpdate(IArchiveStorage)"/>
        /// <seealso cref="CommitUpdate"></seealso>
        /// <seealso cref="AbortUpdate"></seealso>
        public void BeginUpdate()
            {
            if (this.Name == null)
                {
                this.BeginUpdate(new MemoryArchiveStorage(), new DynamicDiskDataSource());
                }
            else
                {
                this.BeginUpdate(new DiskArchiveStorage(this), new DynamicDiskDataSource());
                }
            }

        /// <summary>
        /// Commit current updates, updating this archive.
        /// </summary>
        /// <seealso cref="BeginUpdate()"></seealso>
        /// <seealso cref="AbortUpdate"></seealso>
        /// <exception cref="ObjectDisposedException">ZipFile has been closed.</exception>
        public void CommitUpdate()
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            this.CheckUpdating();

            try
                {
                this.updateIndex_.Clear();
                this.updateIndex_ = null;

                if (this.contentsEdited_)
                    {
                    this.RunUpdates();
                    }
                else if (this.commentEdited_)
                    {
                    this.UpdateCommentOnly();
                    }
                else
                    {
                    // Create an empty archive if none existed originally.
                    if (this.entries_.Length == 0)
                        {
                        byte[] theComment = this.newComment_ != null ? this.newComment_.RawComment : ZipConstants.ConvertToArray(this.ZipFileComment);
                        using (var zhs = new ZipHelperStream(this.baseStream_))
                            {
                            zhs.WriteEndOfCentralDirectory(noOfEntries: 0, sizeEntries: 0, startOfCentralDirectory: 0, comment: theComment);
                            }
                        }
                    }

                }
            finally
                {
                this.PostUpdateCleanup();
                }
            }

        /// <summary>
        /// Abort updating leaving the archive unchanged.
        /// </summary>
        /// <seealso cref="BeginUpdate()"></seealso>
        /// <seealso cref="CommitUpdate"></seealso>
        public void AbortUpdate()
            {
            this.PostUpdateCleanup();
            }

        /// <summary>
        /// Set the file comment to be recorded when the current update is <see cref="CommitUpdate">commited</see>.
        /// </summary>
        /// <param name="comment">The comment to record.</param>
        /// <exception cref="ObjectDisposedException">ZipFile has been closed.</exception>
        public void SetComment(string comment)
            {
            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            this.CheckUpdating();

            this.newComment_ = new ZipString(comment);

            if (this.newComment_.RawLength > 0xffff)
                {
                this.newComment_ = null;
                throw new ZipException("Comment length exceeds maximum - 65535");
                }

            // We dont take account of the original and current comment appearing to be the same
            // as encoding may be different.
            this.commentEdited_ = true;
            }

        #endregion

        #region Adding Entries

        private void AddUpdate(ZipUpdate update)
            {
            this.contentsEdited_ = true;

            int index = this.FindExistingUpdate(update.Entry.Name);

            if (index >= 0)
                {
                if (this.updates_[index] == null)
                    {
                    this.updateCount_ += 1;
                    }

                // Direct replacement is faster than delete and add.
                this.updates_[index] = update;
                }
            else
                {
                index = this.updates_.Add(update);
                this.updateCount_ += 1;
                this.updateIndex_.Add(update.Entry.Name, index);
                }
            }

        /// <summary>
        /// Add a new entry to the archive.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        /// <param name="compressionMethod">The compression method to use.</param>
        /// <param name="useUnicodeText">Ensure Unicode text is used for name and comment for this entry.</param>
        /// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
        /// <exception cref="ObjectDisposedException">ZipFile has been closed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Compression method is not supported.</exception>
        public void Add(string fileName, CompressionMethod compressionMethod, bool useUnicodeText)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            if (this.isDisposed_)
                {
                throw new ObjectDisposedException("ZipFile");
                }

            if (!ZipEntry.IsCompressionMethodSupported(compressionMethod))
                {
                throw new ArgumentOutOfRangeException(nameof(compressionMethod));
                }

            this.CheckUpdating();
            this.contentsEdited_ = true;

            var entry = this.EntryFactory.MakeFileEntry(fileName);
            entry.IsUnicodeText = useUnicodeText;
            entry.CompressionMethod = compressionMethod;

            this.AddUpdate(new ZipUpdate(fileName, entry));
            }

        /// <summary>
        /// Add a new entry to the archive.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        /// <param name="compressionMethod">The compression method to use.</param>
        /// <exception cref="ArgumentNullException">ZipFile has been closed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The compression method is not supported.</exception>
        public void Add(string fileName, CompressionMethod compressionMethod)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            if (!ZipEntry.IsCompressionMethodSupported(compressionMethod))
                {
                throw new ArgumentOutOfRangeException(nameof(compressionMethod));
                }

            this.CheckUpdating();
            this.contentsEdited_ = true;

            var entry = this.EntryFactory.MakeFileEntry(fileName);
            entry.CompressionMethod = compressionMethod;
            this.AddUpdate(new ZipUpdate(fileName, entry));
            }

        /// <summary>
        /// Add a file to the archive.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        /// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
        public void Add(string fileName)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            this.CheckUpdating();
            this.AddUpdate(new ZipUpdate(fileName, this.EntryFactory.MakeFileEntry(fileName)));
            }

        /// <summary>
        /// Add a file to the archive.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        /// <param name="entryName">The name to use for the <see cref="ZipEntry"/> on the Zip file created.</param>
        /// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
        public void Add(string fileName, string entryName)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            if (entryName == null)
                {
                throw new ArgumentNullException(nameof(entryName));
                }

            this.CheckUpdating();
            this.AddUpdate(new ZipUpdate(fileName, this.EntryFactory.MakeFileEntry(entryName)));
            }


        /// <summary>
        /// Add a file entry with data.
        /// </summary>
        /// <param name="dataSource">The source of the data for this entry.</param>
        /// <param name="entryName">The name to give to the entry.</param>
        public void Add(IStaticDataSource dataSource, string entryName)
            {
            if (dataSource == null)
                {
                throw new ArgumentNullException(nameof(dataSource));
                }

            if (entryName == null)
                {
                throw new ArgumentNullException(nameof(entryName));
                }

            this.CheckUpdating();
            this.AddUpdate(new ZipUpdate(dataSource, this.EntryFactory.MakeFileEntry(entryName, useFileSystem: false)));
            }

        /// <summary>
        /// Add a file entry with data.
        /// </summary>
        /// <param name="dataSource">The source of the data for this entry.</param>
        /// <param name="entryName">The name to give to the entry.</param>
        /// <param name="compressionMethod">The compression method to use.</param>
        public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
            {
            if (dataSource == null)
                {
                throw new ArgumentNullException(nameof(dataSource));
                }

            if (entryName == null)
                {
                throw new ArgumentNullException(nameof(entryName));
                }

            this.CheckUpdating();

            var entry = this.EntryFactory.MakeFileEntry(entryName, useFileSystem: false);
            entry.CompressionMethod = compressionMethod;

            this.AddUpdate(new ZipUpdate(dataSource, entry));
            }

        /// <summary>
        /// Add a file entry with data.
        /// </summary>
        /// <param name="dataSource">The source of the data for this entry.</param>
        /// <param name="entryName">The name to give to the entry.</param>
        /// <param name="compressionMethod">The compression method to use.</param>
        /// <param name="useUnicodeText">Ensure Unicode text is used for name and comments for this entry.</param>
        public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText)
            {
            if (dataSource == null)
                {
                throw new ArgumentNullException(nameof(dataSource));
                }

            if (entryName == null)
                {
                throw new ArgumentNullException(nameof(entryName));
                }

            this.CheckUpdating();

            var entry = this.EntryFactory.MakeFileEntry(entryName, useFileSystem: false);
            entry.IsUnicodeText = useUnicodeText;
            entry.CompressionMethod = compressionMethod;

            this.AddUpdate(new ZipUpdate(dataSource, entry));
            }

        /// <summary>
        /// Add a <see cref="ZipEntry"/> that contains no data.
        /// </summary>
        /// <param name="entry">The entry to add.</param>
        /// <remarks>This can be used to add directories, volume labels, or empty file entries.</remarks>
        public void Add(ZipEntry entry)
            {
            if (entry == null)
                {
                throw new ArgumentNullException(nameof(entry));
                }

            this.CheckUpdating();

            if ((entry.Size != 0) || (entry.CompressedSize != 0))
                {
                throw new ZipException("Entry cannot have any data");
                }

            this.AddUpdate(new ZipUpdate(UpdateCommand.Add, entry));
            }

        /// <summary>
        /// Add a directory entry to the archive.
        /// </summary>
        /// <param name="directoryName">The directory to add.</param>
        public void AddDirectory(string directoryName)
            {
            if (directoryName == null)
                {
                throw new ArgumentNullException(nameof(directoryName));
                }

            this.CheckUpdating();

            var dirEntry = this.EntryFactory.MakeDirectoryEntry(directoryName);
            this.AddUpdate(new ZipUpdate(UpdateCommand.Add, dirEntry));
            }

        #endregion

        #region Modifying Entries
        /* Modify not yet ready for public consumption.
   Direct modification of an entry should not overwrite original data before its read.
   Safe mode is trivial in this sense.
		public void Modify(ZipEntry original, ZipEntry updated)
		{
			if ( original == null ) {
				throw new ArgumentNullException("original");
			}

			if ( updated == null ) {
				throw new ArgumentNullException("updated");
			}

			CheckUpdating();
			contentsEdited_ = true;
			updates_.Add(new ZipUpdate(original, updated));
		}
*/
        #endregion

        #region Deleting Entries
        /// <summary>
        /// Delete an entry by name
        /// </summary>
        /// <param name="fileName">The filename to delete</param>
        /// <returns>True if the entry was found and deleted; false otherwise.</returns>
        public bool Delete(string fileName)
            {
            if (fileName == null)
                {
                throw new ArgumentNullException(nameof(fileName));
                }

            this.CheckUpdating();

            int index = this.FindExistingUpdate(fileName);
            if ((index >= 0) && (this.updates_[index] != null))
                {
                this.contentsEdited_ = true;
                this.updates_[index] = null;
                this.updateCount_ -= 1;
                }
            else
                {
                throw new ZipException("Cannot find entry to delete");
                }
            return true;
            }

        /// <summary>
        /// Delete a <see cref="ZipEntry"/> from the archive.
        /// </summary>
        /// <param name="entry">The entry to delete.</param>
        public void Delete(ZipEntry entry)
            {
            if (entry == null)
                {
                throw new ArgumentNullException(nameof(entry));
                }

            this.CheckUpdating();

            int index = this.FindExistingUpdate(entry);
            if (index >= 0)
                {
                this.contentsEdited_ = true;
                this.updates_[index] = null;
                this.updateCount_ -= 1;
                }
            else
                {
                throw new ZipException("Cannot find entry to delete");
                }
            }

        #endregion

        #region Update Support
        #region Writing Values/Headers

        private void WriteLEShort(int value)
            {
            this.baseStream_.WriteByte((byte)(value & 0xff));
            this.baseStream_.WriteByte((byte)((value >> 8) & 0xff));
            }

        /// <summary>
        /// Write an unsigned short in little endian byte order.
        /// </summary>
        private void WriteLEUshort(ushort value)
            {
            this.baseStream_.WriteByte((byte)(value & 0xff));
            this.baseStream_.WriteByte((byte)(value >> 8));
            }

        /// <summary>
        /// Write an int in little endian byte order.
        /// </summary>
        private void WriteLEInt(int value)
            {
            this.WriteLEShort(value & 0xffff);
            this.WriteLEShort(value >> 16);
            }

        /// <summary>
        /// Write an unsigned int in little endian byte order.
        /// </summary>
        private void WriteLEUint(uint value)
            {
            this.WriteLEUshort((ushort)(value & 0xffff));
            this.WriteLEUshort((ushort)(value >> 16));
            }

        /// <summary>
        /// Write a long in little endian byte order.
        /// </summary>
        private void WriteLeLong(long value)
            {
            this.WriteLEInt((int)(value & 0xffffffff));
            this.WriteLEInt((int)(value >> 32));
            }

        private void WriteLEUlong(ulong value)
            {
            this.WriteLEUint((uint)(value & 0xffffffff));
            this.WriteLEUint((uint)(value >> 32));
            }

        private void WriteLocalEntryHeader(ZipUpdate update)
            {
            var entry = update.OutEntry;

            entry.Offset = this.baseStream_.Position;

            if (update.Command != UpdateCommand.Copy)
                {
                if (entry.CompressionMethod == CompressionMethod.Deflated)
                    {
                    if (entry.Size == 0)
                        {
                        // No need to compress - no data.
                        entry.CompressedSize = entry.Size;
                        entry.Crc = 0;
                        entry.CompressionMethod = CompressionMethod.Stored;
                        }
                    }
                else if (entry.CompressionMethod == CompressionMethod.Stored)
                    {
                    entry.Flags &= ~(int)GeneralBitFlags.Descriptor;
                    }

                if (this.HaveKeys)
                    {
                    entry.IsCrypted = true;
                    if (entry.Crc < 0)
                        {
                        entry.Flags |= (int)GeneralBitFlags.Descriptor;
                        }
                    }
                else
                    {
                    entry.IsCrypted = false;
                    }

                switch (this.UseZip64)
                    {
                    case UseZip64.Dynamic:
                        if (entry.Size < 0)
                            {
                            entry.ForceZip64();
                            }
                        break;

                    case UseZip64.On:
                        entry.ForceZip64();
                        break;

                    case UseZip64.Off:
                        // Do nothing.  The entry itself may be using Zip64 independantly.
                        break;
                    }
                }

            // Write the local file header
            this.WriteLEInt(ZipConstants.LocalHeaderSignature);

            this.WriteLEShort(entry.Version);
            this.WriteLEShort(entry.Flags);

            this.WriteLEShort((byte)entry.CompressionMethod);
            this.WriteLEInt((int)entry.DosTime);

            if (!entry.HasCrc)
                {
                // Note patch address for updating CRC later.
                update.CrcPatchOffset = this.baseStream_.Position;
                this.WriteLEInt(value: 0);
                }
            else
                {
                this.WriteLEInt(unchecked((int)entry.Crc));
                }

            if (entry.LocalHeaderRequiresZip64)
                {
                this.WriteLEInt(value: -1);
                this.WriteLEInt(value: -1);
                }
            else
                {
                if ((entry.CompressedSize < 0) || (entry.Size < 0))
                    {
                    update.SizePatchOffset = this.baseStream_.Position;
                    }

                this.WriteLEInt((int)entry.CompressedSize);
                this.WriteLEInt((int)entry.Size);
                }

            byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

            if (name.Length > 0xFFFF)
                {
                throw new ZipException("Entry name too long.");
                }

            var ed = new ZipExtraData(entry.ExtraData);

            if (entry.LocalHeaderRequiresZip64)
                {
                ed.StartNewEntry();

                // Local entry header always includes size and compressed size.
                // NOTE the order of these fields is reversed when compared to the normal headers!
                ed.AddLeLong(entry.Size);
                ed.AddLeLong(entry.CompressedSize);
                ed.AddNewEntry(headerID: 1);
                }
            else
                {
                ed.Delete(headerID: 1);
                }

            entry.ExtraData = ed.GetEntryData();

            this.WriteLEShort(name.Length);
            this.WriteLEShort(entry.ExtraData.Length);

            if (name.Length > 0)
                {
                this.baseStream_.Write(name, offset: 0, count: name.Length);
                }

            if (entry.LocalHeaderRequiresZip64)
                {
                if (!ed.Find(headerID: 1))
                    {
                    throw new ZipException("Internal error cannot find extra data");
                    }

                update.SizePatchOffset = this.baseStream_.Position + ed.CurrentReadIndex;
                }

            if (entry.ExtraData.Length > 0)
                {
                this.baseStream_.Write(entry.ExtraData, offset: 0, count: entry.ExtraData.Length);
                }
            }

        private int WriteCentralDirectoryHeader(ZipEntry entry)
            {
            if (entry.CompressedSize < 0)
                {
                throw new ZipException("Attempt to write central directory entry with unknown csize");
                }

            if (entry.Size < 0)
                {
                throw new ZipException("Attempt to write central directory entry with unknown size");
                }

            if (entry.Crc < 0)
                {
                throw new ZipException("Attempt to write central directory entry with unknown crc");
                }

            // Write the central file header
            this.WriteLEInt(ZipConstants.CentralHeaderSignature);

            // Version made by
            this.WriteLEShort(ZipConstants.VersionMadeBy);

            // Version required to extract
            this.WriteLEShort(entry.Version);

            this.WriteLEShort(entry.Flags);

            unchecked
                {
                this.WriteLEShort((byte)entry.CompressionMethod);
                this.WriteLEInt((int)entry.DosTime);
                this.WriteLEInt((int)entry.Crc);
                }

            if (entry.IsZip64Forced() || (entry.CompressedSize >= 0xffffffff))
                {
                this.WriteLEInt(value: -1);
                }
            else
                {
                this.WriteLEInt((int)(entry.CompressedSize & 0xffffffff));
                }

            if (entry.IsZip64Forced() || (entry.Size >= 0xffffffff))
                {
                this.WriteLEInt(value: -1);
                }
            else
                {
                this.WriteLEInt((int)entry.Size);
                }

            byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

            if (name.Length > 0xFFFF)
                {
                throw new ZipException("Entry name is too long.");
                }

            this.WriteLEShort(name.Length);

            // Central header extra data is different to local header version so regenerate.
            var ed = new ZipExtraData(entry.ExtraData);

            if (entry.CentralHeaderRequiresZip64)
                {
                ed.StartNewEntry();

                if ((entry.Size >= 0xffffffff) || (this.UseZip64 == UseZip64.On))
                    {
                    ed.AddLeLong(entry.Size);
                    }

                if ((entry.CompressedSize >= 0xffffffff) || (this.UseZip64 == UseZip64.On))
                    {
                    ed.AddLeLong(entry.CompressedSize);
                    }

                if (entry.Offset >= 0xffffffff)
                    {
                    ed.AddLeLong(entry.Offset);
                    }

                // Number of disk on which this file starts isnt supported and is never written here.
                ed.AddNewEntry(headerID: 1);
                }
            else
                {
                // Should have already be done when local header was added.
                ed.Delete(headerID: 1);
                }

            byte[] centralExtraData = ed.GetEntryData();

            this.WriteLEShort(centralExtraData.Length);
            this.WriteLEShort(entry.Comment?.Length ?? 0);

            this.WriteLEShort(value: 0);   // disk number
            this.WriteLEShort(value: 0);   // internal file attributes

            // External file attributes...
            if (entry.ExternalFileAttributes != -1)
                {
                this.WriteLEInt(entry.ExternalFileAttributes);
                }
            else
                {
                this.WriteLEUint(entry.IsDirectory ? (uint)16 : 0);
                }

            if (entry.Offset >= 0xffffffff)
                {
                this.WriteLEUint(value: 0xffffffff);
                }
            else
                {
                this.WriteLEUint((uint)(int)entry.Offset);
                }

            if (name.Length > 0)
                {
                this.baseStream_.Write(name, offset: 0, count: name.Length);
                }

            if (centralExtraData.Length > 0)
                {
                this.baseStream_.Write(centralExtraData, offset: 0, count: centralExtraData.Length);
                }

            byte[] rawComment = entry.Comment != null ? Encoding.ASCII.GetBytes(entry.Comment) : new byte[0];

            if (rawComment.Length > 0)
                {
                this.baseStream_.Write(rawComment, offset: 0, count: rawComment.Length);
                }

            return ZipConstants.CentralHeaderBaseSize + name.Length + centralExtraData.Length + rawComment.Length;
            }
        #endregion

        private void PostUpdateCleanup()
            {
            if (this.archiveStorage_ != null)
                {
                this.archiveStorage_.Dispose();
                this.archiveStorage_ = null;
                }

            this.updateDataSource_ = null;
            this.updates_ = null;
            this.updateIndex_ = null;
            }

        private string GetTransformedFileName(string name)
            {
            return this.NameTransform?.TransformFile(name) ?? name;
            }

        private string GetTransformedDirectoryName(string name)
            {
            return this.NameTransform?.TransformDirectory(name) ?? name;
            }

        /// <summary>
        /// Get a raw memory buffer.
        /// </summary>
        /// <returns>Returns a raw memory buffer.</returns>
        private byte[] GetBuffer()
            {
            return this.copyBuffer_ ?? (this.copyBuffer_ = new byte[this.bufferSize_]);
            }

        private void CopyDescriptorBytes(ZipUpdate update, Stream dest, Stream source)
            {
            int bytesToCopy = this.GetDescriptorSize(update);

            if (bytesToCopy > 0)
                {
                byte[] buffer = this.GetBuffer();

                while (bytesToCopy > 0)
                    {
                    int readSize = Math.Min(buffer.Length, bytesToCopy);

                    int bytesRead = source.Read(buffer, offset: 0, count: readSize);
                    if (bytesRead > 0)
                        {
                        dest.Write(buffer, offset: 0, count: bytesRead);
                        bytesToCopy -= bytesRead;
                        }
                    else
                        {
                        throw new ZipException("Unxpected end of stream");
                        }
                    }
                }
            }

        private void CopyBytes(ZipUpdate update, Stream destination, Stream source,
            long bytesToCopy, bool updateCrc)
            {
            if (destination == source)
                {
                throw new InvalidOperationException("Destination and source are the same");
                }

            // NOTE: Compressed size is updated elsewhere.
            var crc = new Crc32();
            byte[] buffer = this.GetBuffer();

            long targetBytes = bytesToCopy;
            long totalBytesRead = 0;

            int bytesRead;
            do
                {
                int readSize = buffer.Length;

                if (bytesToCopy < readSize)
                    {
                    readSize = (int)bytesToCopy;
                    }

                bytesRead = source.Read(buffer, offset: 0, count: readSize);
                if (bytesRead > 0)
                    {
                    if (updateCrc)
                        {
                        crc.Update(buffer, offset: 0, count: bytesRead);
                        }
                    destination.Write(buffer, offset: 0, count: bytesRead);
                    bytesToCopy -= bytesRead;
                    totalBytesRead += bytesRead;
                    }
                }
            while ((bytesRead > 0) && (bytesToCopy > 0));

            if (totalBytesRead != targetBytes)
                {
                throw new ZipException($"Failed to copy bytes expected {targetBytes} read {totalBytesRead}");
                }

            if (updateCrc)
                {
                update.OutEntry.Crc = crc.Value;
                }
            }

        /// <summary>
        /// Get the size of the source descriptor for a <see cref="ZipUpdate"/>.
        /// </summary>
        /// <param name="update">The update to get the size for.</param>
        /// <returns>The descriptor size, zero if there isnt one.</returns>
        private int GetDescriptorSize(ZipUpdate update)
            {
            int result = 0;
            if ((update.Entry.Flags & (int)GeneralBitFlags.Descriptor) != 0)
                {
                result = ZipConstants.DataDescriptorSize - 4;
                if (update.Entry.LocalHeaderRequiresZip64)
                    {
                    result = ZipConstants.Zip64DataDescriptorSize - 4;
                    }
                }
            return result;
            }

        private void CopyDescriptorBytesDirect(ZipUpdate update, Stream stream, ref long destinationPosition, long sourcePosition)
            {
            int bytesToCopy = this.GetDescriptorSize(update);

            while (bytesToCopy > 0)
                {
                int readSize = bytesToCopy;
                byte[] buffer = this.GetBuffer();

                stream.Position = sourcePosition;
                int bytesRead = stream.Read(buffer, offset: 0, count: readSize);
                if (bytesRead > 0)
                    {
                    stream.Position = destinationPosition;
                    stream.Write(buffer, offset: 0, count: bytesRead);
                    bytesToCopy -= bytesRead;
                    destinationPosition += bytesRead;
                    sourcePosition += bytesRead;
                    }
                else
                    {
                    throw new ZipException("Unxpected end of stream");
                    }
                }
            }

        private void CopyEntryDataDirect(ZipUpdate update, Stream stream, bool updateCrc, ref long destinationPosition, ref long sourcePosition)
            {
            long bytesToCopy = update.Entry.CompressedSize;

            // NOTE: Compressed size is updated elsewhere.
            var crc = new Crc32();
            byte[] buffer = this.GetBuffer();

            long targetBytes = bytesToCopy;
            long totalBytesRead = 0;

            int bytesRead;
            do
                {
                int readSize = buffer.Length;

                if (bytesToCopy < readSize)
                    {
                    readSize = (int)bytesToCopy;
                    }

                stream.Position = sourcePosition;
                bytesRead = stream.Read(buffer, offset: 0, count: readSize);
                if (bytesRead > 0)
                    {
                    if (updateCrc)
                        {
                        crc.Update(buffer, offset: 0, count: bytesRead);
                        }
                    stream.Position = destinationPosition;
                    stream.Write(buffer, offset: 0, count: bytesRead);

                    destinationPosition += bytesRead;
                    sourcePosition += bytesRead;
                    bytesToCopy -= bytesRead;
                    totalBytesRead += bytesRead;
                    }
                }
            while ((bytesRead > 0) && (bytesToCopy > 0));

            if (totalBytesRead != targetBytes)
                {
                throw new ZipException($"Failed to copy bytes expected {targetBytes} read {totalBytesRead}");
                }

            if (updateCrc)
                {
                update.OutEntry.Crc = crc.Value;
                }
            }

        private int FindExistingUpdate(ZipEntry entry)
            {
            int result = -1;
            string convertedName = this.GetTransformedFileName(entry.Name);

            if (this.updateIndex_.ContainsKey(convertedName))
                {
                result = (int)this.updateIndex_[convertedName];
                }
            /*
						// This is slow like the coming of the next ice age but takes less storage and may be useful
						// for CF?
						for (int index = 0; index < updates_.Count; ++index)
						{
							ZipUpdate zu = ( ZipUpdate )updates_[index];
							if ( (zu.Entry.ZipFileIndex == entry.ZipFileIndex) &&
								(string.Compare(convertedName, zu.Entry.Name, true, CultureInfo.InvariantCulture) == 0) ) {
								result = index;
								break;
							}
						}
			 */
            return result;
            }

        private int FindExistingUpdate(string fileName)
            {
            int result = -1;

            string convertedName = this.GetTransformedFileName(fileName);

            if (this.updateIndex_.ContainsKey(convertedName))
                {
                result = (int)this.updateIndex_[convertedName];
                }

            /*
						// This is slow like the coming of the next ice age but takes less storage and may be useful
						// for CF?
						for ( int index = 0; index < updates_.Count; ++index ) {
							if ( string.Compare(convertedName, (( ZipUpdate )updates_[index]).Entry.Name,
								true, CultureInfo.InvariantCulture) == 0 ) {
								result = index;
								break;
							}
						}
			 */

            return result;
            }

        /// <summary>
        /// Get an output stream for the specified <see cref="ZipEntry"/>
        /// </summary>
        /// <param name="entry">The entry to get an output stream for.</param>
        /// <returns>The output stream obtained for the entry.</returns>
        private Stream GetOutputStream(ZipEntry entry)
            {
            var result = this.baseStream_;

            if (entry.IsCrypted)
                {
#if NETCF_1_0
				throw new ZipException("Encryption not supported for Compact Framework 1.0");
#else
                result = this.CreateAndInitEncryptionStream(result, entry);
#endif
                }

            switch (entry.CompressionMethod)
                {
                case CompressionMethod.Stored:
                    result = new UncompressedStream(result);
                    break;

                case CompressionMethod.Deflated:
                    var dos = new DeflaterOutputStream(result, new Deflater(level: 9, noZlibHeaderOrFooter: true))
                        {
                        IsStreamOwner = false
                        };
                    result = dos;
                    break;

                default:
                    throw new ZipException($"Unknown compression method {entry.CompressionMethod}");
                }
            return result;
            }

        private void AddEntry(ZipFile workFile, ZipUpdate update)
            {
            Stream source = null;

            if (update.Entry.IsFile)
                {
                source = update.GetSource() ??
                    this.updateDataSource_.GetSource(update.Entry, update.Filename);
                }

            if (source != null)
                {
                using (source)
                    {
                    long sourceStreamLength = source.Length;
                    if (update.OutEntry.Size < 0)
                        {
                        update.OutEntry.Size = sourceStreamLength;
                        }
                    else
                        {
                        // Check for errant entries.
                        if (update.OutEntry.Size != sourceStreamLength)
                            {
                            throw new ZipException("Entry size/stream size mismatch");
                            }
                        }

                    workFile.WriteLocalEntryHeader(update);

                    long dataStart = workFile.baseStream_.Position;

                    using (var output = workFile.GetOutputStream(update.OutEntry))
                        {
                        this.CopyBytes(update, output, source, sourceStreamLength, updateCrc: true);
                        }

                    long dataEnd = workFile.baseStream_.Position;
                    update.OutEntry.CompressedSize = dataEnd - dataStart;

                    if ((update.OutEntry.Flags & (int)GeneralBitFlags.Descriptor) == (int)GeneralBitFlags.Descriptor)
                        {
                        var helper = new ZipHelperStream(workFile.baseStream_);
                        helper.WriteDataDescriptor(update.OutEntry);
                        }
                    }
                }
            else
                {
                workFile.WriteLocalEntryHeader(update);
                update.OutEntry.CompressedSize = 0;
                }

            }

        private void ModifyEntry(ZipFile workFile, ZipUpdate update)
            {
            workFile.WriteLocalEntryHeader(update);
            long dataStart = workFile.baseStream_.Position;

            if (update.Entry.IsFile && (update.Filename != null))
                {
                using (var output = workFile.GetOutputStream(update.OutEntry))
                    {
                    using (var source = this.GetInputStream(update.Entry))
                        {
                        this.CopyBytes(update, output, source, source.Length, updateCrc: true);
                        }
                    }
                }

            long dataEnd = workFile.baseStream_.Position;
            update.Entry.CompressedSize = dataEnd - dataStart;
            }

        private void CopyEntryDirect(ZipFile workFile, ZipUpdate update, ref long destinationPosition)
            {
            bool skipOver = update.Entry.Offset == destinationPosition;

            if (!skipOver)
                {
                this.baseStream_.Position = destinationPosition;
                workFile.WriteLocalEntryHeader(update);
                destinationPosition = this.baseStream_.Position;
                }

            const int NameLengthOffset = 26;

            long entryDataOffset = update.Entry.Offset + NameLengthOffset;

            this.baseStream_.Seek(entryDataOffset, SeekOrigin.Begin);

            // Clumsy way of handling retrieving the original name and extra data length for now.
            uint nameLength = this.ReadLEUshort();
            uint extraLength = this.ReadLEUshort();

            long sourcePosition = this.baseStream_.Position + nameLength + extraLength;

            if (skipOver)
                {
                destinationPosition +=
                    sourcePosition - entryDataOffset + NameLengthOffset + // Header size
                    update.Entry.CompressedSize + this.GetDescriptorSize(update);
                }
            else
                {
                if (update.Entry.CompressedSize > 0)
                    {
                    this.CopyEntryDataDirect(update, this.baseStream_, updateCrc: false, destinationPosition: ref destinationPosition, sourcePosition: ref sourcePosition);
                    }
                this.CopyDescriptorBytesDirect(update, this.baseStream_, ref destinationPosition, sourcePosition);
                }
            }

        private void CopyEntry(ZipFile workFile, ZipUpdate update)
            {
            workFile.WriteLocalEntryHeader(update);

            if (update.Entry.CompressedSize > 0)
                {
                const int NameLengthOffset = 26;

                long entryDataOffset = update.Entry.Offset + NameLengthOffset;

                this.baseStream_.Seek(entryDataOffset, SeekOrigin.Begin);

                uint nameLength = this.ReadLEUshort();
                uint extraLength = this.ReadLEUshort();

                this.baseStream_.Seek(nameLength + extraLength, SeekOrigin.Current);

                this.CopyBytes(update, workFile.baseStream_, this.baseStream_, update.Entry.CompressedSize, updateCrc: false);
                }
            this.CopyDescriptorBytes(update, workFile.baseStream_, this.baseStream_);
            }

        private void Reopen(Stream source)
            {
            if (source == null)
                {
                throw new ZipException("Failed to reopen archive - no source");
                }

            this.IsNewArchive = false;
            this.baseStream_ = source;
            this.ReadEntries();
            }

        private void Reopen()
            {
            if (this.Name == null)
                {
                throw new InvalidOperationException("Name is not known cannot Reopen");
                }

            this.Reopen(File.OpenRead(this.Name));
            }

        private void UpdateCommentOnly()
            {
            long baseLength = this.baseStream_.Length;

            ZipHelperStream updateFile;

            if (this.archiveStorage_.UpdateMode == FileUpdateMode.Safe)
                {
                var copyStream = this.archiveStorage_.MakeTemporaryCopy(this.baseStream_);
                updateFile = new ZipHelperStream(copyStream) { IsStreamOwner = true };

                this.baseStream_.Close();
                this.baseStream_ = null;
                }
            else
                {
                if (this.archiveStorage_.UpdateMode == FileUpdateMode.Direct)
                    {
                    // Need to tidy up the archive storage interface and contract basically.
                    this.baseStream_ = this.archiveStorage_.OpenForDirectUpdate(this.baseStream_);
                    updateFile = new ZipHelperStream(this.baseStream_);
                    }
                else
                    {
                    this.baseStream_.Close();
                    this.baseStream_ = null;
                    updateFile = new ZipHelperStream(this.Name);
                    }
                }

            using (updateFile)
                {
                long locatedCentralDirOffset =
                    updateFile.LocateBlockWithSignature(ZipConstants.EndOfCentralDirectorySignature,
                                                        baseLength, ZipConstants.EndOfCentralRecordBaseSize, maximumVariableData: 0xffff);
                if (locatedCentralDirOffset < 0)
                    {
                    throw new ZipException("Cannot find central directory");
                    }

                const int CentralHeaderCommentSizeOffset = 16;
                updateFile.Position += CentralHeaderCommentSizeOffset;

                byte[] rawComment = this.newComment_.RawComment;

                updateFile.WriteLEShort(rawComment.Length);
                updateFile.Write(rawComment, offset: 0, count: rawComment.Length);
                updateFile.SetLength(updateFile.Position);
                }

            if (this.archiveStorage_.UpdateMode == FileUpdateMode.Safe)
                {
                this.Reopen(this.archiveStorage_.ConvertTemporaryToFinal());
                }
            else
                {
                this.ReadEntries();
                }
            }

        /// <summary>
        /// Class used to sort updates.
        /// </summary>
        private class UpdateComparer : IComparer
            {
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is 
            /// less than, equal to or greater than the other.
            /// </summary>
            /// <param name="x">First object to compare</param>
            /// <param name="y">Second object to compare.</param>
            /// <returns>Compare result.</returns>
            public int Compare(
                [CanBeNull]object x,
                [CanBeNull]object y)
                {
                var zx = x as ZipUpdate;
                var zy = y as ZipUpdate;

                int result;

                if (zx == null)
                    {
                    if (zy == null)
                        {
                        result = 0;
                        }
                    else
                        {
                        result = -1;
                        }
                    }
                else if (zy == null)
                    {
                    result = 1;
                    }
                else
                    {
                    int xCmdValue = (zx.Command == UpdateCommand.Copy) || (zx.Command == UpdateCommand.Modify) ? 0 : 1;
                    int yCmdValue = (zy.Command == UpdateCommand.Copy) || (zy.Command == UpdateCommand.Modify) ? 0 : 1;

                    result = xCmdValue - yCmdValue;
                    if (result == 0)
                        {
                        long offsetDiff = zx.Entry.Offset - zy.Entry.Offset;
                        if (offsetDiff < 0)
                            {
                            result = -1;
                            }
                        else if (offsetDiff == 0)
                            {
                            result = 0;
                            }
                        else
                            {
                            result = 1;
                            }
                        }
                    }
                return result;
                }
            }

        private void RunUpdates()
            {
            long sizeEntries = 0;
            long endOfStream = 0;
            bool allOk = true;
            bool directUpdate = false;
            long destinationPosition = 0; // NOT SFX friendly

            ZipFile workFile;

            if (this.IsNewArchive)
                {
                workFile = this;
                workFile.baseStream_.Position = 0;
                directUpdate = true;
                }
            else if (this.archiveStorage_.UpdateMode == FileUpdateMode.Direct)
                {
                workFile = this;
                workFile.baseStream_.Position = 0;
                directUpdate = true;

                // Sort the updates by offset within copies/modifies, then adds.
                // This ensures that data required by copies will not be overwritten.
                this.updates_.Sort(new UpdateComparer());
                }
            else
                {
                workFile = Create(this.archiveStorage_.GetTemporaryOutput());
                workFile.UseZip64 = this.UseZip64;

                if (this.Key != null)
                    {
                    workFile.Key = (byte[])this.Key.Clone();
                    }
                }

            try
                {
                foreach (ZipUpdate update in this.updates_)
                    {
                    if (update != null)
                        {
                        switch (update.Command)
                            {
                            case UpdateCommand.Copy:
                                if (directUpdate)
                                    {
                                    this.CopyEntryDirect(workFile, update, ref destinationPosition);
                                    }
                                else
                                    {
                                    this.CopyEntry(workFile, update);
                                    }
                                break;

                            case UpdateCommand.Modify:
                                this.ModifyEntry(workFile, update);
                                break;

                            case UpdateCommand.Add:
                                if (!this.IsNewArchive && directUpdate)
                                    {
                                    workFile.baseStream_.Position = destinationPosition;
                                    }

                                this.AddEntry(workFile, update);

                                if (directUpdate)
                                    {
                                    destinationPosition = workFile.baseStream_.Position;
                                    }
                                break;
                            }
                        }
                    }

                if (!this.IsNewArchive && directUpdate)
                    {
                    workFile.baseStream_.Position = destinationPosition;
                    }

                long centralDirOffset = workFile.baseStream_.Position;

                sizeEntries = this.updates_.Cast<ZipUpdate>().Where(update => update != null)
                    .Aggregate(sizeEntries, (current, update) =>
                    current + workFile.WriteCentralDirectoryHeader(update.OutEntry));

                byte[] theComment = this.newComment_ != null ? this.newComment_.RawComment : ZipConstants.ConvertToArray(this.ZipFileComment);
                using (var zhs = new ZipHelperStream(workFile.baseStream_))
                    {
                    zhs.WriteEndOfCentralDirectory(this.updateCount_, sizeEntries, centralDirOffset, theComment);
                    }

                endOfStream = workFile.baseStream_.Position;

                // And now patch entries...
                foreach (ZipUpdate update in this.updates_)
                    {
                    if (update != null)
                        {

                        // If the size of the entry is zero leave the crc as 0 as well.
                        // The calculated crc will be all bits on...
                        if ((update.CrcPatchOffset > 0) && (update.OutEntry.CompressedSize > 0))
                            {
                            workFile.baseStream_.Position = update.CrcPatchOffset;
                            workFile.WriteLEInt((int)update.OutEntry.Crc);
                            }

                        if (update.SizePatchOffset > 0)
                            {
                            workFile.baseStream_.Position = update.SizePatchOffset;
                            if (update.OutEntry.LocalHeaderRequiresZip64)
                                {
                                workFile.WriteLeLong(update.OutEntry.Size);
                                workFile.WriteLeLong(update.OutEntry.CompressedSize);
                                }
                            else
                                {
                                workFile.WriteLEInt((int)update.OutEntry.CompressedSize);
                                workFile.WriteLEInt((int)update.OutEntry.Size);
                                }
                            }
                        }
                    }
                }
            catch (Exception)
                {
                allOk = false;
                }
            finally
                {
                if (directUpdate)
                    {
                    if (allOk)
                        {
                        workFile.baseStream_.Flush();
                        workFile.baseStream_.SetLength(endOfStream);
                        }
                    }
                else
                    {
                    workFile.Close();
                    }
                }

            if (allOk)
                {
                if (directUpdate)
                    {
                    this.IsNewArchive = false;
                    workFile.baseStream_.Flush();
                    this.ReadEntries();
                    }
                else
                    {
                    this.baseStream_.Close();
                    this.Reopen(this.archiveStorage_.ConvertTemporaryToFinal());
                    }
                }
            else
                {
                workFile.Close();
                if (!directUpdate && (workFile.Name != null))
                    {
                    File.Delete(workFile.Name);
                    }
                }
            }

        private void CheckUpdating()
            {
            if (this.updates_ == null)
                {
                throw new InvalidOperationException("BeginUpdate has not been called");
                }
            }

        #endregion

        #region ZipUpdate class
        /// <summary>
        /// Represents a pending update to a Zip file.
        /// </summary>
        private class ZipUpdate
            {
            #region Constructors
            public ZipUpdate(string fileName, ZipEntry entry)
                {
                this.Command = UpdateCommand.Add;
                this.Entry = entry;
                this.Filename = fileName;
                }

            [Obsolete]
            private ZipUpdate(string fileName, string entryName, CompressionMethod compressionMethod)
                {
                this.Command = UpdateCommand.Add;
                this.Entry = new ZipEntry(entryName) { CompressionMethod = compressionMethod };
                this.Filename = fileName;
                }

            [Obsolete]
            public ZipUpdate(string fileName, string entryName)
                : this(fileName, entryName, CompressionMethod.Deflated)
                {
                // Do nothing.
                }

            [Obsolete]
            public ZipUpdate(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
                {
                this.Command = UpdateCommand.Add;
                this.Entry = new ZipEntry(entryName) { CompressionMethod = compressionMethod };
                this.dataSource_ = dataSource;
                }

            public ZipUpdate(IStaticDataSource dataSource, ZipEntry entry)
                {
                this.Command = UpdateCommand.Add;
                this.Entry = entry;
                this.dataSource_ = dataSource;
                }

            public ZipUpdate(/*ZipEntry original, ZipEntry updated*/)
                {
                throw new ZipException("Modify not currently supported");
                /*
					command_ = UpdateCommand.Modify;
					entry_ = ( ZipEntry )original.Clone();
					outEntry_ = ( ZipEntry )updated.Clone();
				*/
                }

            public ZipUpdate(UpdateCommand command, ZipEntry entry)
                {
                this.Command = command;
                this.Entry = (ZipEntry)entry.Clone();
                }


            /// <summary>
            /// Copy an existing entry.
            /// </summary>
            /// <param name="entry">The existing entry to copy.</param>
            public ZipUpdate(ZipEntry entry)
                : this(UpdateCommand.Copy, entry)
                {
                // Do nothing.
                }
            #endregion

            /// <summary>
            /// Get the <see cref="ZipEntry"/> for this update.
            /// </summary>
            /// <remarks>This is the source or original entry.</remarks>
            public ZipEntry Entry { get; }

            /// <summary>
            /// Get the <see cref="ZipEntry"/> that will be written to the updated/new file.
            /// </summary>
            public ZipEntry OutEntry => this.outEntry_ ??
                (this.outEntry_ = (ZipEntry)this.Entry.Clone());

            /// <summary>
            /// Get the command for this update.
            /// </summary>
            public UpdateCommand Command { get; }

            /// <summary>
            /// Get the filename if any for this update.  Null if none exists.
            /// </summary>
            public string Filename { get; }

            /// <summary>
            /// Get/set the location of the size patch for this update.
            /// </summary>
            public long SizePatchOffset { get; set; } = -1;

            /// <summary>
            /// Get /set the location of the crc patch for this update.
            /// </summary>
            public long CrcPatchOffset { get; set; } = -1;

            [CanBeNull]
            public Stream GetSource()
                {
                Stream result = null;
                if (this.dataSource_ != null)
                    {
                    result = this.dataSource_.GetSource();
                    }

                return result;
                }

            #region Instance Fields

            private ZipEntry outEntry_;
            private IStaticDataSource dataSource_;

            #endregion
            }

        #endregion
        #endregion

        #region Disposing

        #region IDisposable Members
        void IDisposable.Dispose()
            {
            this.Close();
            }
        #endregion

        private void DisposeInternal(bool disposing)
            {
            if (!this.isDisposed_)
                {
                this.isDisposed_ = true;
                this.entries_ = new ZipEntry[0];

                if (this.IsStreamOwner && (this.baseStream_ != null))
                    {
                    lock (this.baseStream_)
                        {
                        this.baseStream_.Close();
                        }
                    }

                this.PostUpdateCleanup();
                }
            }

        /// <summary>
        /// Releases the unmanaged resources used by the this instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
            {
            this.DisposeInternal(disposing);
            }

        #endregion

        #region Internal routines
        #region Reading
        /// <summary>
        /// Read an unsigned short in little endian byte order.
        /// </summary>
        /// <returns>Returns the value read.</returns>
        /// <exception cref="EndOfStreamException">
        /// The stream ends prematurely
        /// </exception>
        private ushort ReadLEUshort()
            {
            int data1 = this.baseStream_.ReadByte();

            if (data1 < 0)
                {
                throw new EndOfStreamException("End of stream");
                }

            int data2 = this.baseStream_.ReadByte();

            if (data2 < 0)
                {
                throw new EndOfStreamException("End of stream");
                }


            return unchecked((ushort)((ushort)data1 | (ushort)(data2 << 8)));
            }

        /// <summary>
        /// Read a uint in little endian byte order.
        /// </summary>
        /// <returns>Returns the value read.</returns>
        /// <exception cref="IOException">
        /// An i/o error occurs.
        /// </exception>
        /// <exception cref="System.IO.EndOfStreamException">
        /// The file ends prematurely
        /// </exception>
        private uint ReadLEUint()
            {
            return (uint)(this.ReadLEUshort() | (this.ReadLEUshort() << 16));
            }

        private ulong ReadLEUlong()
            {
            return this.ReadLEUint() | ((ulong)this.ReadLEUint() << 32);
            }

        #endregion
        // NOTE this returns the offset of the first byte after the signature.
        private long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
            {
            using (var les = new ZipHelperStream(this.baseStream_))
                {
                return les.LocateBlockWithSignature(signature, endLocation, minimumBlockSize, maximumVariableData);
                }
            }

        /// <summary>
        /// Search for and read the central directory of a zip file filling the entries array.
        /// </summary>
        /// <exception cref="System.IO.IOException">
        /// An i/o error occurs.
        /// </exception>
        /// <exception cref="ICSharpCode.SharpZipLib.Zip.ZipException">
        /// The central directory is malformed or cannot be found
        /// </exception>
        private void ReadEntries()
            {
            // Search for the End Of Central Directory.  When a zip comment is
            // present the directory will start earlier
            // 
            // The search is limited to 64K which is the maximum size of a trailing comment field to aid speed.
            // This should be compatible with both SFX and ZIP files but has only been tested for Zip files
            // If a SFX file has the Zip data attached as a resource and there are other resources occuring later then
            // this could be invalid.
            // Could also speed this up by reading memory in larger blocks.			

            if (this.baseStream_.CanSeek == false)
                {
                throw new ZipException("ZipFile stream must be seekable");
                }

            long locatedEndOfCentralDir = this.LocateBlockWithSignature(ZipConstants.EndOfCentralDirectorySignature, this.baseStream_.Length, ZipConstants.EndOfCentralRecordBaseSize, maximumVariableData: 0xffff);

            if (locatedEndOfCentralDir < 0)
                {
                throw new ZipException("Cannot find central directory");
                }

            // Read end of central directory record
            ushort thisDiskNumber = this.ReadLEUshort();
            ushort startCentralDirDisk = this.ReadLEUshort();
            ulong entriesForThisDisk = this.ReadLEUshort();
            ulong entriesForWholeCentralDir = this.ReadLEUshort();
            ulong centralDirSize = this.ReadLEUint();
            long offsetOfCentralDir = this.ReadLEUint();
            uint commentSize = this.ReadLEUshort();

            if (commentSize > 0)
                {
                var comment = new byte[commentSize];

                StreamUtils.ReadFully(this.baseStream_, comment);
                this.ZipFileComment = ZipConstants.ConvertToString(comment);
                }
            else
                {
                this.ZipFileComment = string.Empty;
                }

            bool isZip64 = false;

            // Check if zip64 header information is required.
            if ((thisDiskNumber == 0xffff) ||
                (startCentralDirDisk == 0xffff) ||
                (entriesForThisDisk == 0xffff) ||
                (entriesForWholeCentralDir == 0xffff) ||
                (centralDirSize == 0xffffffff) ||
                (offsetOfCentralDir == 0xffffffff))
                {
                isZip64 = true;

                long offset = this.LocateBlockWithSignature(ZipConstants.Zip64CentralDirLocatorSignature, locatedEndOfCentralDir, minimumBlockSize: 0, maximumVariableData: 0x1000);
                if (offset < 0)
                    {
                    throw new ZipException("Cannot find Zip64 locator");
                    }

                // number of the disk with the start of the zip64 end of central directory 4 bytes 
                // relative offset of the zip64 end of central directory record 8 bytes 
                // total number of disks 4 bytes 
                this.ReadLEUint(); // startDisk64 is not currently used
                ulong offset64 = this.ReadLEUlong();
                this.ReadLEUint();

                this.baseStream_.Position = (long)offset64;
                long sig64 = this.ReadLEUint();

                if (sig64 != ZipConstants.Zip64CentralFileHeaderSignature)
                    {
                    throw new ZipException($"Invalid Zip64 Central directory signature at {offset64:X}");
                    }

                // NOTE: Record size = SizeOfFixedFields + SizeOfVariableData - 12.
                this.ReadLEUlong();
                this.ReadLEUshort();
                this.ReadLEUshort();
                this.ReadLEUint();
                this.ReadLEUint();
                entriesForThisDisk = this.ReadLEUlong();
                entriesForWholeCentralDir = this.ReadLEUlong();
                centralDirSize = this.ReadLEUlong();
                offsetOfCentralDir = (long)this.ReadLEUlong();

                // NOTE: zip64 extensible data sector (variable size) is ignored.
                }

            this.entries_ = new ZipEntry[entriesForThisDisk];

            // SFX/embedded support, find the offset of the first entry vis the start of the stream
            // This applies to Zip files that are appended to the end of an SFX stub.
            // Or are appended as a resource to an executable.
            // Zip files created by some archivers have the offsets altered to reflect the true offsets
            // and so dont require any adjustment here...
            if (!isZip64 && (offsetOfCentralDir < locatedEndOfCentralDir - (4 + (long)centralDirSize)))
                {
                this.offsetOfFirstEntry = locatedEndOfCentralDir - (4 + (long)centralDirSize + offsetOfCentralDir);
                if (this.offsetOfFirstEntry <= 0)
                    {
                    throw new ZipException("Invalid embedded zip archive");
                    }
                }

            this.baseStream_.Seek(this.offsetOfFirstEntry + offsetOfCentralDir, SeekOrigin.Begin);

            for (ulong i = 0; i < entriesForThisDisk; i++)
                {
                if (this.ReadLEUint() != ZipConstants.CentralHeaderSignature)
                    {
                    throw new ZipException("Wrong Central Directory signature");
                    }

                int versionMadeBy = this.ReadLEUshort();
                int versionToExtract = this.ReadLEUshort();
                int bitFlags = this.ReadLEUshort();
                int method = this.ReadLEUshort();
                uint dostime = this.ReadLEUint();
                uint crc = this.ReadLEUint();
                long csize = this.ReadLEUint();
                long size = this.ReadLEUint();
                int nameLen = this.ReadLEUshort();
                int extraLen = this.ReadLEUshort();
                int commentLen = this.ReadLEUshort();

                this.ReadLEUshort();
                this.ReadLEUshort();

                uint externalAttributes = this.ReadLEUint();
                long offset = this.ReadLEUint();

                var buffer = new byte[Math.Max(nameLen, commentLen)];

                StreamUtils.ReadFully(this.baseStream_, buffer, offset: 0, count: nameLen);
                string name = ZipConstants.ConvertToStringExt(bitFlags, buffer, nameLen);

                var entry = new ZipEntry(name, versionToExtract, versionMadeBy, (CompressionMethod)method)
                    {
                    Crc = crc & 0xffffffffL,
                    Size = size & 0xffffffffL,
                    CompressedSize = csize & 0xffffffffL,
                    Flags = bitFlags,
                    DosTime = dostime,
                    ZipFileIndex = (long)i,
                    Offset = offset,
                    ExternalFileAttributes = (int)externalAttributes
                    };

                if ((bitFlags & 8) == 0)
                    {
                    entry.CryptoCheckValue = (byte)(crc >> 24);
                    }
                else
                    {
                    entry.CryptoCheckValue = (byte)((dostime >> 8) & 0xff);
                    }

                if (extraLen > 0)
                    {
                    var extra = new byte[extraLen];
                    StreamUtils.ReadFully(this.baseStream_, extra);
                    entry.ExtraData = extra;
                    }

                entry.ProcessExtraData(localHeader: false);

                if (commentLen > 0)
                    {
                    StreamUtils.ReadFully(this.baseStream_, buffer, offset: 0, count: commentLen);
                    entry.Comment = ZipConstants.ConvertToStringExt(bitFlags, buffer, commentLen);
                    }

                this.entries_[i] = entry;
                }
            }

        /// <summary>
        /// Locate the data for a given entry.
        /// </summary>
        /// <returns>
        /// The start offset of the data.
        /// </returns>
        /// <exception cref="System.IO.EndOfStreamException">
        /// The stream ends prematurely
        /// </exception>
        /// <exception cref="ICSharpCode.SharpZipLib.Zip.ZipException">
        /// The local header signature is invalid, the entry and central header file name lengths are different
        /// or the local and entry compression methods dont match
        /// </exception>
        private long LocateEntry(ZipEntry entry)
            {
            return this.TestLocalHeader(entry, HeaderTest.Extract);
            }

#if !NETCF_1_0
        [CanBeNull]
        private Stream CreateAndInitDecryptionStream(Stream baseStream, ZipEntry entry)
            {
            CryptoStream result = null;

            if ((entry.Version < ZipConstants.VersionStrongEncryption)
                || (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0)
                {
                var classicManaged = new PkzipClassicManaged();

                this.OnKeysRequired(entry.Name);
                if (this.HaveKeys == false)
                    {
                    throw new ZipException("No password available for encrypted stream");
                    }

                result = new CryptoStream(baseStream, classicManaged.CreateDecryptor(this.Key, rgbIV: null), CryptoStreamMode.Read);
                CheckClassicPassword(result, entry);
                }
            else
                {
                throw new ZipException("Decryption method not supported");
                }

            return result;
            }

        private Stream CreateAndInitEncryptionStream(Stream baseStream, ZipEntry entry)
            {
            CryptoStream result = null;
            if ((entry.Version < ZipConstants.VersionStrongEncryption)
                || (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0)
                {
                var classicManaged = new PkzipClassicManaged();

                this.OnKeysRequired(entry.Name);
                if (this.HaveKeys == false)
                    {
                    throw new ZipException("No password available for encrypted stream");
                    }

                // Closing a CryptoStream will close the base stream as well so wrap it in an UncompressedStream
                // which doesnt do this.
                result = new CryptoStream(new UncompressedStream(baseStream),
                    classicManaged.CreateEncryptor(this.Key, rgbIV: null), CryptoStreamMode.Write);

                if ((entry.Crc < 0) || (entry.Flags & 8) != 0)
                    {
                    WriteEncryptionHeader(result, entry.DosTime << 16);
                    }
                else
                    {
                    WriteEncryptionHeader(result, entry.Crc);
                    }
                }
            return result;
            }

        private static void CheckClassicPassword(CryptoStream classicCryptoStream, ZipEntry entry)
            {
            var cryptbuffer = new byte[ZipConstants.CryptoHeaderSize];
            StreamUtils.ReadFully(classicCryptoStream, cryptbuffer);
            if (cryptbuffer[ZipConstants.CryptoHeaderSize - 1] != entry.CryptoCheckValue)
                {
                throw new ZipException("Invalid password");
                }
            }
#endif

        private static void WriteEncryptionHeader(Stream stream, long crcValue)
            {
            var cryptBuffer = new byte[ZipConstants.CryptoHeaderSize];
            var rnd = new Random();
            rnd.NextBytes(cryptBuffer);
            cryptBuffer[11] = (byte)(crcValue >> 24);
            stream.Write(cryptBuffer, offset: 0, count: cryptBuffer.Length);
            }

        #endregion

        #region Instance Fields

        private bool isDisposed_;
        private Stream baseStream_;
        private long offsetOfFirstEntry;
        private ZipEntry[] entries_;

        // Default is dynamic which is not backwards compatible and can cause problems
        // with XP's built in compression which cant read Zip64 archives.
        // However it does avoid the situation were a large file is added and cannot be completed correctly.
        // Hint: Set always ZipEntry size before they are added to an archive and this setting isnt needed.

        #region Zip Update Instance Fields

        private ArrayList updates_;
        private long updateCount_; // Count is managed manually as updates_ can contain nulls!
        private Hashtable updateIndex_;
        private IArchiveStorage archiveStorage_;
        private IDynamicDataSource updateDataSource_;
        private bool contentsEdited_;
        private int bufferSize_ = DefaultBufferSize;
        private byte[] copyBuffer_;
        private ZipString newComment_;
        private bool commentEdited_;
        private IEntryFactory updateEntryFactory_ = new ZipEntryFactory();
        #endregion
        #endregion

        #region Support Classes
        /// <summary>
        /// Represents a string from a <see cref="ZipFile"/> which is stored as an array of bytes.
        /// </summary>
        private class ZipString
            {
            #region Constructors
            /// <summary>
            /// Initialise a <see cref="ZipString"/> with a string.
            /// </summary>
            /// <param name="comment">The textual string form.</param>
            public ZipString(string comment)
                {
                this.comment_ = comment;
                this.IsSourceString = true;
                }

            /// <summary>
            /// Initialise a <see cref="ZipString"/> using a string in its binary 'raw' form.
            /// </summary>
            /// <param name="rawString"></param>
            public ZipString(byte[] rawString)
                {
                this.rawComment_ = rawString;
                }
            #endregion

            /// <summary>
            /// Get a value indicating the original source of data for this instance.
            /// True if the source was a string; false if the source was binary data.
            /// </summary>
            public bool IsSourceString { get; }

            /// <summary>
            /// Get the length of the comment when represented as raw bytes.
            /// </summary>
            public int RawLength
                {
                get
                    {
                    this.MakeBytesAvailable();
                    return this.rawComment_.Length;
                    }
                }

            /// <summary>
            /// Get the comment in its 'raw' form as plain bytes.
            /// </summary>
            public byte[] RawComment
                {
                get
                    {
                    this.MakeBytesAvailable();
                    return (byte[])this.rawComment_.Clone();
                    }
                }

            /// <summary>
            /// Reset the comment to its initial state.
            /// </summary>
            public void Reset()
                {
                if (this.IsSourceString)
                    {
                    this.rawComment_ = null;
                    }
                else
                    {
                    this.comment_ = null;
                    }
                }

            private void MakeTextAvailable()
                {
                if (this.comment_ == null)
                    {
                    this.comment_ = ZipConstants.ConvertToString(this.rawComment_);
                    }
                }

            private void MakeBytesAvailable()
                {
                if (this.rawComment_ == null)
                    {
                    this.rawComment_ = ZipConstants.ConvertToArray(this.comment_);
                    }
                }

            /// <summary>
            /// Implicit conversion of comment to a string.
            /// </summary>
            /// <param name="zipString">The <see cref="ZipString"/> to convert to a string.</param>
            /// <returns>The textual equivalent for the input value.</returns>
            public static implicit operator string(ZipString zipString)
                {
                zipString.MakeTextAvailable();
                return zipString.comment_;
                }

            #region Instance Fields

            private string comment_;
            private byte[] rawComment_;

            #endregion
            }

        /// <summary>
        /// An <see cref="IEnumerator">enumerator</see> for <see cref="ZipEntry">Zip entries</see>
        /// </summary>
        private class ZipEntryEnumerator : IEnumerator
            {
            #region Constructors
            public ZipEntryEnumerator(ZipEntry[] entries)
                {
                this.array = entries;
                }

            #endregion
            #region IEnumerator Members
            public object Current => this.array[this.index];

            public void Reset()
                {
                this.index = -1;
                }

            public bool MoveNext()
                {
                return ++this.index < this.array.Length;
                }
            #endregion
            #region Instance Fields

            private ZipEntry[] array;
            private int index = -1;
            #endregion
            }

        /// <summary>
        /// An <see cref="UncompressedStream"/> is a stream that you can write uncompressed data
        /// to and flush, but cannot read, seek or do anything else to.
        /// </summary>
        private class UncompressedStream : Stream
            {
            #region Constructors
            public UncompressedStream(Stream baseStream)
                {
                this.baseStream_ = baseStream;
                }

            #endregion

            /// <summary>
            /// Close this stream instance.
            /// </summary>
            public override void Close()
                {
                // Do nothing
                }

            /// <summary>
            /// Gets a value indicating whether the current stream supports reading.
            /// </summary>
            public override bool CanRead => false;

            /// <summary>
            /// Write any buffered data to underlying storage.
            /// </summary>
            public override void Flush()
                {
                this.baseStream_.Flush();
                }

            /// <summary>
            /// Gets a value indicating whether the current stream supports writing.
            /// </summary>
            public override bool CanWrite => this.baseStream_.CanWrite;

            /// <summary>
            /// Gets a value indicating whether the current stream supports seeking.
            /// </summary>
            public override bool CanSeek => false;

            /// <summary>
            /// Get the length in bytes of the stream.
            /// </summary>
            public override long Length => 0;

            /// <summary>
            /// Gets or sets the position within the current stream.
            /// </summary>
            public override long Position
                {
                get
                    {
                    return this.baseStream_.Position;
                    }

                set
                    {
                    }
                }

            /// <summary>
            /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
            /// </summary>
            /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
            /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
            /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
            /// <returns>
            /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
            /// </returns>
            /// <exception cref="T:System.ArgumentException">The sum of offset and count is larger than the buffer length. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
            /// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
            public override int Read(byte[] buffer, int offset, int count)
                {
                return 0;
                }

            /// <summary>
            /// Sets the position within the current stream.
            /// </summary>
            /// <param name="offset">A byte offset relative to the origin parameter.</param>
            /// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin"></see> indicating the reference point used to obtain the new position.</param>
            /// <returns>
            /// The new position within the current stream.
            /// </returns>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override long Seek(long offset, SeekOrigin origin)
                {
                return 0;
                }

            /// <summary>
            /// Sets the length of the current stream.
            /// </summary>
            /// <param name="value">The desired length of the current stream in bytes.</param>
            /// <exception cref="T:System.NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output. </exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override void SetLength(long value)
                {
                }

            /// <summary>
            /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
            /// </summary>
            /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
            /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
            /// <param name="count">The number of bytes to be written to the current stream.</param>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support writing. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            /// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
            /// <exception cref="T:System.ArgumentException">The sum of offset and count is greater than the buffer length. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
            public override void Write(byte[] buffer, int offset, int count)
                {
                this.baseStream_.Write(buffer, offset, count);
                }

            #region Instance Fields

            private Stream baseStream_;
            #endregion
            }

        /// <summary>
        /// A <see cref="PartialInputStream"/> is an <see cref="InflaterInputStream"/>
        /// whose data is only a part or subsection of a file.
        /// </summary>
        private class PartialInputStream : Stream
            {
            #region Constructors
            /// <summary>
            /// Initialise a new instance of the <see cref="PartialInputStream"/> class.
            /// </summary>
            /// <param name="zipFile">The <see cref="ZipFile"/> containing the underlying stream to use for IO.</param>
            /// <param name="start">The start of the partial data.</param>
            /// <param name="length">The length of the partial data.</param>
            public PartialInputStream(ZipFile zipFile, long start, long length)
                {
                this.start_ = start;
                this.Length = length;

                // Although this is the only time the zipfile is used
                // keeping a reference here prevents premature closure of
                // this zip file and thus the baseStream_.

                // Code like this will cause apparently random failures depending
                // on the size of the files and when garbage is collected.
                //
                // ZipFile z = new ZipFile (stream);
                // Stream reader = z.GetInputStream(0);
                // uses reader here....
                this.zipFile_ = zipFile;
                this.baseStream_ = this.zipFile_.baseStream_;
                this.readPos_ = start;
                this.end_ = start + length;
                }
            #endregion

            /// <summary>
            /// Read a byte from this stream.
            /// </summary>
            /// <returns>Returns the byte read or -1 on end of stream.</returns>
            public override int ReadByte()
                {
                if (this.readPos_ >= this.end_)
                    {
                    // -1 is the correct value at end of stream.
                    return -1;
                    }

                lock (this.baseStream_)
                    {
                    this.baseStream_.Seek(this.readPos_++, SeekOrigin.Begin);
                    return this.baseStream_.ReadByte();
                    }
                }

            /// <summary>
            /// Close this <see cref="PartialInputStream">partial input stream</see>.
            /// </summary>
            /// <remarks>
            /// The underlying stream is not closed.  Close the parent ZipFile class to do that.
            /// </remarks>
            public override void Close()
                {
                // Do nothing at all!
                }

            /// <summary>
            /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
            /// </summary>
            /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
            /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
            /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
            /// <returns>
            /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
            /// </returns>
            /// <exception cref="T:System.ArgumentException">The sum of offset and count is larger than the buffer length. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
            /// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
            public override int Read(byte[] buffer, int offset, int count)
                {
                lock (this.baseStream_)
                    {
                    if (count > this.end_ - this.readPos_)
                        {
                        count = (int)(this.end_ - this.readPos_);
                        if (count == 0)
                            {
                            return 0;
                            }
                        }

                    this.baseStream_.Seek(this.readPos_, SeekOrigin.Begin);
                    int readCount = this.baseStream_.Read(buffer, offset, count);
                    if (readCount > 0)
                        {
                        this.readPos_ += readCount;
                        }
                    return readCount;
                    }
                }

            /// <summary>
            /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
            /// </summary>
            /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
            /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
            /// <param name="count">The number of bytes to be written to the current stream.</param>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support writing. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            /// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
            /// <exception cref="T:System.ArgumentException">The sum of offset and count is greater than the buffer length. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
            public override void Write(byte[] buffer, int offset, int count)
                {
                throw new NotSupportedException();
                }

            /// <summary>
            /// When overridden in a derived class, sets the length of the current stream.
            /// </summary>
            /// <param name="value">The desired length of the current stream in bytes.</param>
            /// <exception cref="T:System.NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output. </exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override void SetLength(long value)
                {
                throw new NotSupportedException();
                }

            /// <summary>
            /// When overridden in a derived class, sets the position within the current stream.
            /// </summary>
            /// <param name="offset">A byte offset relative to the origin parameter.</param>
            /// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin"></see> indicating the reference point used to obtain the new position.</param>
            /// <returns>
            /// The new position within the current stream.
            /// </returns>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override long Seek(long offset, SeekOrigin origin)
                {
                long newPos = this.readPos_;

                switch (origin)
                    {
                    case SeekOrigin.Begin:
                        newPos = this.start_ + offset;
                        break;

                    case SeekOrigin.Current:
                        newPos = this.readPos_ + offset;
                        break;

                    case SeekOrigin.End:
                        newPos = this.end_ + offset;
                        break;
                    }

                if (newPos < this.start_)
                    {
                    throw new ArgumentException("Negative position is invalid");
                    }

                if (newPos >= this.end_)
                    {
                    throw new IOException("Cannot seek past end");
                    }
                this.readPos_ = newPos;
                return this.readPos_;
                }

            /// <summary>
            /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
            /// </summary>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            public override void Flush()
                {
                // Nothing to do.
                }

            /// <summary>
            /// Gets or sets the position within the current stream.
            /// </summary>
            /// <value></value>
            /// <returns>The current position within the stream.</returns>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <exception cref="T:System.NotSupportedException">The stream does not support seeking. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override long Position
                {
                get { return this.readPos_ - this.start_; }
                set
                    {
                    long newPos = this.start_ + value;

                    if (newPos < this.start_)
                        {
                        throw new ArgumentException("Negative position is invalid");
                        }

                    if (newPos >= this.end_)
                        {
                        throw new InvalidOperationException("Cannot seek past end");
                        }
                    this.readPos_ = newPos;
                    }
                }

            /// <summary>
            /// Gets the length in bytes of the stream.
            /// </summary>
            /// <value></value>
            /// <returns>A long value representing the length of the stream in bytes.</returns>
            /// <exception cref="T:System.NotSupportedException">A class derived from Stream does not support seeking. </exception>
            /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
            public override long Length { get; }

            /// <summary>
            /// Gets a value indicating whether the current stream supports writing.
            /// </summary>
            /// <value>false</value>
            /// <returns>true if the stream supports writing; otherwise, false.</returns>
            public override bool CanWrite => false;

            /// <summary>
            /// Gets a value indicating whether the current stream supports seeking.
            /// </summary>
            /// <value>true</value>
            /// <returns>true if the stream supports seeking; otherwise, false.</returns>
            public override bool CanSeek => true;

            /// <summary>
            /// Gets a value indicating whether the current stream supports reading.
            /// </summary>
            /// <value>true.</value>
            /// <returns>true if the stream supports reading; otherwise, false.</returns>
            public override bool CanRead => true;

#if !NET_1_0 && !NET_1_1 && !NETCF_1_0
            /// <summary>
            /// Gets a value that determines whether the current stream can time out.
            /// </summary>
            /// <value></value>
            /// <returns>A value that determines whether the current stream can time out.</returns>
            public override bool CanTimeout => this.baseStream_.CanTimeout;
#endif
            #region Instance Fields

            private readonly ZipFile zipFile_;
            private Stream baseStream_;
            private long start_;
            private long readPos_;
            private long end_;
            #endregion
            }
        #endregion
        }

    #endregion

    #region DataSources
    /// <summary>
    /// Provides a static way to obtain a source of data for an entry.
    /// </summary>
    public interface IStaticDataSource
        {
        /// <summary>
        /// Get a source of data by creating a new stream.
        /// </summary>
        /// <returns>Returns a <see cref="Stream"/> to use for compression input.</returns>
        /// <remarks>Ideally a new stream is created and opened to achieve this, to avoid locking problems.</remarks>
        Stream GetSource();
        }

    /// <summary>
    /// Represents a source of data that can dynamically provide
    /// multiple <see cref="Stream">data sources</see> based on the parameters passed.
    /// </summary>
    public interface IDynamicDataSource
        {
        /// <summary>
        /// Get a data source.
        /// </summary>
        /// <param name="entry">The <see cref="ZipEntry"/> to get a source for.</param>
        /// <param name="name">The name for data if known.</param>
        /// <returns>Returns a <see cref="Stream"/> to use for compression input.</returns>
        /// <remarks>Ideally a new stream is created and opened to achieve this, to avoid locking problems.</remarks>
        Stream GetSource(ZipEntry entry, string name);
        }

    /// <summary>
    /// Default implementation of a <see cref="IStaticDataSource"/> for use with files stored on disk.
    /// </summary>
    public class StaticDiskDataSource : IStaticDataSource
        {
        /// <summary>
        /// Initialise a new instnace of <see cref="StaticDiskDataSource"/>
        /// </summary>
        /// <param name="fileName">The name of the file to obtain data from.</param>
        public StaticDiskDataSource(string fileName)
            {
            this.fileName_ = fileName;
            }

        #region IDataSource Members

        /// <summary>
        /// Get a <see cref="Stream"/> providing data.
        /// </summary>
        /// <returns>Returns a <see cref="Stream"/> provising data.</returns>
        public Stream GetSource()
            {
            return File.OpenRead(this.fileName_);
            }

        #endregion
        #region Instance Fields

        private string fileName_;
        #endregion
        }


    /// <summary>
    /// Default implementation of <see cref="IDynamicDataSource"/> for files stored on disk.
    /// </summary>
    public class DynamicDiskDataSource : IDynamicDataSource
        {
        #region IDataSource Members
        /// <summary>
        /// Get a <see cref="Stream"/> providing data for an entry.
        /// </summary>
        /// <param name="entry">The entry to provide data for.</param>
        /// <param name="name">The file name for data if known.</param>
        /// <returns>Returns a stream providing data; or null if not available</returns>
        public Stream GetSource(ZipEntry entry, [CanBeNull]string name)
            {
            Stream result = null;

            if (name != null)
                {
                result = File.OpenRead(name);
                }

            return result;
            }

        #endregion
        }

    #endregion

    #region Archive Storage
    /// <summary>
    /// Defines facilities for data storage when updating Zip Archives.
    /// </summary>
    public interface IArchiveStorage
        {
        /// <summary>
        /// Get the <see cref="FileUpdateMode"/> to apply during updates.
        /// </summary>
        FileUpdateMode UpdateMode { get; }

        /// <summary>
        /// Get an empty <see cref="Stream"/> that can be used for temporary output.
        /// </summary>
        /// <returns>Returns a temporary output <see cref="Stream"/></returns>
        /// <seealso cref="ConvertTemporaryToFinal"></seealso>
        Stream GetTemporaryOutput();

        /// <summary>
        /// Convert a temporary output stream to a final stream.
        /// </summary>
        /// <returns>The resulting final <see cref="Stream"/></returns>
        /// <seealso cref="GetTemporaryOutput"/>
        Stream ConvertTemporaryToFinal();

        /// <summary>
        /// Make a temporary copy of the original stream.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to copy.</param>
        /// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
        Stream MakeTemporaryCopy(Stream stream);

        /// <summary>
        /// Return a stream suitable for performing direct updates on the original source.
        /// </summary>
        /// <param name="stream">The current stream.</param>
        /// <returns>Returns a stream suitable for direct updating.</returns>
        /// <remarks>This may be the current stream passed.</remarks>
        Stream OpenForDirectUpdate(Stream stream);

        /// <summary>
        /// Dispose of this instance.
        /// </summary>
        void Dispose();
        }

    /// <summary>
    /// An abstract <see cref="IArchiveStorage"/> suitable for extension by inheritance.
    /// </summary>
    public abstract class BaseArchiveStorage : IArchiveStorage
        {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseArchiveStorage"/> class.
        /// </summary>
        /// <param name="updateMode">The update mode.</param>
        protected BaseArchiveStorage(FileUpdateMode updateMode)
            {
            this.UpdateMode = updateMode;
            }
        #endregion

        #region IArchiveStorage Members

        /// <summary>
        /// Gets a temporary output <see cref="Stream"/>
        /// </summary>
        /// <returns>Returns the temporary output stream.</returns>
        /// <seealso cref="ConvertTemporaryToFinal"></seealso>
        public abstract Stream GetTemporaryOutput();

        /// <summary>
        /// Converts the temporary <see cref="Stream"/> to its final form.
        /// </summary>
        /// <returns>Returns a <see cref="Stream"/> that can be used to read
        /// the final storage for the archive.</returns>
        /// <seealso cref="GetTemporaryOutput"/>
        public abstract Stream ConvertTemporaryToFinal();

        /// <summary>
        /// Make a temporary copy of a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to make a copy of.</param>
        /// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
        public abstract Stream MakeTemporaryCopy(Stream stream);

        /// <summary>
        /// Return a stream suitable for performing direct updates on the original source.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to open for direct update.</param>
        /// <returns>Returns a stream suitable for direct updating.</returns>
        public abstract Stream OpenForDirectUpdate(Stream stream);

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Gets the update mode applicable.
        /// </summary>
        /// <value>The update mode.</value>
        public FileUpdateMode UpdateMode { get; }

        #endregion

        #region Instance Fields

        #endregion
        }

    /// <summary>
    /// An <see cref="IArchiveStorage"/> implementation suitable for hard disks.
    /// </summary>
    public class DiskArchiveStorage : BaseArchiveStorage
        {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DiskArchiveStorage"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="updateMode">The update mode.</param>
        public DiskArchiveStorage(ZipFile file, FileUpdateMode updateMode = FileUpdateMode.Safe)
            : base(updateMode)
            {
            if (file.Name == null)
                {
                throw new ZipException("Cant handle non file archives");
                }

            this.fileName_ = file.Name;
            }

        #endregion

        #region IArchiveStorage Members

        /// <summary>
        /// Gets a temporary output <see cref="Stream"/> for performing updates on.
        /// </summary>
        /// <returns>Returns the temporary output stream.</returns>
        public override Stream GetTemporaryOutput()
            {
            if (this.temporaryName_ != null)
                {
                this.temporaryName_ = GetTempFileName(this.temporaryName_, makeTempFile: true);
                this.temporaryStream_ = File.OpenWrite(this.temporaryName_);
                }
            else
                {
                // Determine where to place files based on internal strategy.
                // Currently this is always done in system temp directory.
                this.temporaryName_ = Path.GetTempFileName();
                this.temporaryStream_ = File.OpenWrite(this.temporaryName_);
                }

            return this.temporaryStream_;
            }

        /// <summary>
        /// Converts a temporary <see cref="Stream"/> to its final form.
        /// </summary>
        /// <returns>Returns a <see cref="Stream"/> that can be used to read
        /// the final storage for the archive.</returns>
        public override Stream ConvertTemporaryToFinal()
            {
            if (this.temporaryStream_ == null)
                {
                throw new ZipException("No temporary stream has been created");
                }

            Stream result = null;

            string moveTempName = GetTempFileName(this.fileName_, makeTempFile: false);
            bool newFileCreated = false;

            try
                {
                this.temporaryStream_.Close();
                File.Move(this.fileName_, moveTempName);
                File.Move(this.temporaryName_, this.fileName_);
                newFileCreated = true;
                File.Delete(moveTempName);

                result = File.OpenRead(this.fileName_);
                }
            catch (Exception)
                {
                result = null;

                // Try to roll back changes...
                if (!newFileCreated)
                    {
                    File.Move(moveTempName, this.fileName_);
                    File.Delete(this.temporaryName_);
                    }

                throw;
                }

            return result;
            }

        /// <summary>
        /// Make a temporary copy of a stream.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to copy.</param>
        /// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
        public override Stream MakeTemporaryCopy(Stream stream)
            {
            stream.Close();

            this.temporaryName_ = GetTempFileName(this.fileName_, makeTempFile: true);
            File.Copy(this.fileName_, this.temporaryName_, overwrite: true);

            this.temporaryStream_ = new FileStream(this.temporaryName_,
                FileMode.Open,
                FileAccess.ReadWrite);
            return this.temporaryStream_;
            }

        /// <summary>
        /// Return a stream suitable for performing direct updates on the original source.
        /// </summary>
        /// <param name="stream">The current stream.</param>
        /// <returns>Returns a stream suitable for direct updating.</returns>
        /// <remarks>If the <paramref name="stream"/>stream is not null this is used as is.</remarks>
        public override Stream OpenForDirectUpdate([CanBeNull]Stream stream)
            {
            Stream result;
            if ((stream == null) || !stream.CanWrite)
                {
                stream?.Close();

                result = new FileStream(this.fileName_,
                    FileMode.Open,
                    FileAccess.ReadWrite);
                }
            else
                {
                result = stream;
                }

            return result;
            }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
            {
            this.temporaryStream_?.Close();
            }

        #endregion

        #region Internal routines

        private static string GetTempFileName([CanBeNull]string original, bool makeTempFile)
            {
            string result = null;

            if (original == null)
                {
                result = Path.GetTempFileName();
                }
            else
                {
                int counter = 0;
                int suffixSeed = DateTime.Now.Second;

                while (result == null)
                    {
                    counter += 1;
                    string newName = $"{original}.{suffixSeed}{counter}.tmp";
                    if (!File.Exists(newName))
                        {
                        if (makeTempFile)
                            {
                            try
                                {
                                // Try and create the file.
                                using (File.Create(newName))
                                    {
                                    }
                                result = newName;
                                }
                            catch
                                {
                                suffixSeed = DateTime.Now.Second;
                                }
                            }
                        else
                            {
                            result = newName;
                            }
                        }
                    }
                }
            return result;
            }
        #endregion

        #region Instance Fields

        private Stream temporaryStream_;
        private string fileName_;
        private string temporaryName_;
        #endregion
        }

    /// <summary>
    /// An <see cref="IArchiveStorage"/> implementation suitable for in memory streams.
    /// </summary>
    public class MemoryArchiveStorage : BaseArchiveStorage
        {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryArchiveStorage"/> class.
        /// </summary>
        public MemoryArchiveStorage()
            : base(FileUpdateMode.Direct)
            {
            }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryArchiveStorage"/> class.
        /// </summary>
        /// <param name="updateMode">The <see cref="FileUpdateMode"/> to use</param>
        /// <remarks>This constructor is for testing as memory streams dont really require safe mode.</remarks>
        public MemoryArchiveStorage(FileUpdateMode updateMode)
            : base(updateMode)
            {
            }

        #endregion

        #region Properties
        /// <summary>
        /// Get the stream returned by <see cref="ConvertTemporaryToFinal"/> if this was in fact called.
        /// </summary>
        public MemoryStream FinalStream { get; private set; }

        #endregion

        #region IArchiveStorage Members

        /// <summary>
        /// Gets the temporary output <see cref="Stream"/>
        /// </summary>
        /// <returns>Returns the temporary output stream.</returns>
        public override Stream GetTemporaryOutput()
            {
            this.temporaryStream_ = new MemoryStream();
            return this.temporaryStream_;
            }

        /// <summary>
        /// Converts the temporary <see cref="Stream"/> to its final form.
        /// </summary>
        /// <returns>Returns a <see cref="Stream"/> that can be used to read
        /// the final storage for the archive.</returns>
        public override Stream ConvertTemporaryToFinal()
            {
            if (this.temporaryStream_ == null)
                {
                throw new ZipException("No temporary stream has been created");
                }

            this.FinalStream = new MemoryStream(this.temporaryStream_.ToArray());
            return this.FinalStream;
            }

        /// <summary>
        /// Make a temporary copy of the original stream.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to copy.</param>
        /// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
        public override Stream MakeTemporaryCopy(Stream stream)
            {
            this.temporaryStream_ = new MemoryStream();
            stream.Position = 0;
            StreamUtils.Copy(stream, this.temporaryStream_, new byte[4096]);
            return this.temporaryStream_;
            }

        /// <summary>
        /// Return a stream suitable for performing direct updates on the original source.
        /// </summary>
        /// <param name="stream">The original source stream</param>
        /// <returns>Returns a stream suitable for direct updating.</returns>
        /// <remarks>If the <paramref name="stream"/> passed is not null this is used;
        /// otherwise a new <see cref="MemoryStream"/> is returned.</remarks>
        public override Stream OpenForDirectUpdate([CanBeNull]Stream stream)
            {
            Stream result;
            if ((stream == null) || !stream.CanWrite)
                {

                result = new MemoryStream();

                if (stream != null)
                    {
                    stream.Position = 0;
                    StreamUtils.Copy(stream, result, new byte[4096]);

                    stream.Close();
                    }
                }
            else
                {
                result = stream;
                }

            return result;
            }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
            {
            this.temporaryStream_?.Close();
            }

        #endregion

        #region Instance Fields

        private MemoryStream temporaryStream_;

        #endregion
        }

    #endregion
    }
