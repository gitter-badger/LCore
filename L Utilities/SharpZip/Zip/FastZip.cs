// FastZip.cs
//
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
using ICSharpCode.SharpZipLib.Core;
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace ICSharpCode.SharpZipLib.Zip
    {
    /// <summary>
    /// FastZipEvents supports all events applicable to <see cref="FastZip">FastZip</see> operations.
    /// </summary>
    public class FastZipEvents
        {
        /// <summary>
        /// Delegate to invoke when processing directories.
        /// </summary>
        public ProcessDirectoryHandler ProcessDirectory;

        /// <summary>
        /// Delegate to invoke when processing files.
        /// </summary>
        public ProcessFileHandler ProcessFile;

        /// <summary>
        /// Delegate to invoke during processing of files.
        /// </summary>
        public ProgressHandler Progress;

        /// <summary>
        /// Delegate to invoke when processing for a file has been completed.
        /// </summary>
        public CompletedFileHandler CompletedFile;

        /// <summary>
        /// Delegate to invoke when processing directory failures.
        /// </summary>
        public DirectoryFailureHandler DirectoryFailure;

        /// <summary>
        /// Delegate to invoke when processing file failures.
        /// </summary>
        public FileFailureHandler FileFailure;

        public FastZipEvents()
            {
            try
                {
                this.ProgressInterval = TimeSpan.FromSeconds(3);
                }
            catch (OverflowException) { }
            }

        /// <summary>
        /// Raise the <see cref="DirectoryFailure">directory failure</see> event.
        /// </summary>
        /// <param name="directory">The directory causing the failure.</param>
        /// <param name="e">The exception for this event.</param>
        /// <returns>A boolean indicating if execution should continue or not.</returns>
        public bool OnDirectoryFailure(string directory, Exception e)
            {
            bool result = false;
            var handler = this.DirectoryFailure;

            if (handler != null)
                {
                var args = new ScanFailureEventArgs(directory, e);
                handler(this, args);
                result = args.ContinueRunning;
                }
            return result;
            }

        /// <summary>
        /// Raises the <see cref="FileFailure">file failure delegate</see>.
        /// </summary>
        /// <param name="file">The file causing the failure.</param>
        /// <param name="e">The exception for this failure.</param>
        /// <returns>A boolean indicating if execution should continue or not.</returns>
        public bool OnFileFailure(string file, Exception e)
            {
            var handler = this.FileFailure;
            bool result = handler != null;

            if (result)
                {
                var args = new ScanFailureEventArgs(file, e);
                handler(this, args);
                result = args.ContinueRunning;
                }
            return result;
            }

        /// <summary>
        /// Fires the <see cref="ProcessFile">Process File delegate</see>.
        /// </summary>
        /// <param name="file">The file being processed.</param>
        /// <returns>A boolean indicating if execution should continue or not.</returns>
        public bool OnProcessFile(string file)
            {
            bool result = true;
            var handler = this.ProcessFile;

            if (handler != null)
                {
                var args = new ScanEventArgs(file);
                this.ProcessFile(this, args);
                result = args.ContinueRunning;
                }
            return result;
            }

        /// <summary>
        /// Fires the CompletedFile delegate
        /// </summary>
        /// <param name="file">The file whose processing has been completed.</param>
        /// <returns>A boolean indicating if execution should continue or not.</returns>
        public bool OnCompletedFile(string file)
            {
            bool result = true;
            var handler = this.CompletedFile;
            if (handler != null)
                {
                var args = new ScanEventArgs(file);
                handler(this, args);
                result = args.ContinueRunning;
                }
            return result;
            }

        /// <summary>
        /// Fires the <see cref="ProcessDirectory">process directory</see> delegate.
        /// </summary>
        /// <param name="directory">The directory being processed.</param>
        /// <param name="hasMatchingFiles">Flag indicating if the directory has matching files as determined by the current filter.</param>
        /// <returns>A <see cref="bool"/> of true if the operation should continue; false otherwise.</returns>
        public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
            {
            bool result = true;
            var handler = this.ProcessDirectory;
            if (handler != null)
                {
                var args = new DirectoryEventArgs(directory, hasMatchingFiles);
                handler(this, args);
                result = args.ContinueRunning;
                }
            return result;
            }

        /// <summary>
        /// The minimum timespan between <see cref="Progress"/> events.
        /// </summary>
        /// <value>The minimum period of time between <see cref="Progress"/> events.</value>
        /// <seealso cref="Progress"/>
        public TimeSpan ProgressInterval { get; }

        #region Instance Fields

        #endregion
        }

    /// <summary>
    /// FastZip provides facilities for creating and extracting zip files.
    /// </summary>
    public class FastZip
        {
        #region Enumerations
        /// <summary>
        /// Defines the desired handling when overwriting files during extraction.
        /// </summary>
        public enum Overwrite
            {
            /// <summary>
            /// Prompt the user to confirm overwriting
            /// </summary>
            Prompt,
            /// <summary>
            /// Never overwrite files.
            /// </summary>
            Never,
            /// <summary>
            /// Always overwrite files.
            /// </summary>
            Always
            }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise a default instance of <see cref="FastZip"/>.
        /// </summary>
        public FastZip()
            {
            }

        /// <summary>
        /// Initialise a new instance of <see cref="FastZip"/>
        /// </summary>
        /// <param name="events">The <see cref="FastZipEvents">events</see> to use during operations.</param>
        public FastZip(FastZipEvents events)
            {
            this.events_ = events;
            }
        #endregion

        #region Properties
        /// <summary>
        /// Get/set a value indicating wether empty directories should be created.
        /// </summary>
        public bool CreateEmptyDirectories { get; set; }

#if !NETCF_1_0
        /// <summary>
        /// Get / set the password value.
        /// </summary>
        public string Password
            {
            get { return this.password_; }
            set { this.password_ = value; }
            }
#endif

        /// <summary>
        /// Get or set the <see cref="INameTransform"></see> active when creating Zip files.
        /// </summary>
        /// <seealso cref="EntryFactory"></seealso>
        public INameTransform NameTransform
            {
            get { return this.entryFactory_.NameTransform; }
            set
                {
                this.entryFactory_.NameTransform = value;
                }
            }

        /// <summary>
        /// Get or set the <see cref="IEntryFactory"></see> active when creating Zip files.
        /// </summary>
        public IEntryFactory EntryFactory
            {
            get { return this.entryFactory_; }
            set
                {
                this.entryFactory_ = value ?? new ZipEntryFactory();
                }
            }

        /// <summary>
        /// Gets or sets the setting for <see cref="UseZip64">Zip64 handling when writing.</see>
        /// </summary>
        /// <remarks>
        /// The default value is dynamic which is not backwards compatible with old
        /// programs and can cause problems with XP's built in compression which cant
        /// read Zip64 archives. However it does avoid the situation were a large file
        /// is added and cannot be completed correctly.
        /// NOTE: Setting the size for entries before they are added is the best solution!
        /// By default the EntryFactory used by FastZip will set fhe file size.
        /// </remarks>
        public UseZip64 UseZip64 { get; } = UseZip64.Dynamic;

        /// <summary>
        /// Get/set a value indicating wether file dates and times should 
        /// be restored when extracting files from an archive.
        /// </summary>
        /// <remarks>The default value is false.</remarks>
        public bool RestoreDateTimeOnExtract
            {
            get
                {
                return this.restoreDateTimeOnExtract_;
                }
            set
                {
                this.restoreDateTimeOnExtract_ = value;
                }
            }

        /// <summary>
        /// Get/set a value indicating wether file attributes should
        /// be restored during extract operations
        /// </summary>
        public bool RestoreAttributesOnExtract { get; set; }

        #endregion

        #region Delegates
        /// <summary>
        /// Delegate called when confirming overwriting of files.
        /// </summary>
        public delegate bool ConfirmOverwriteDelegate(string fileName);
        #endregion

        #region CreateZip

        /// <summary>
        /// Create a zip file.
        /// </summary>
        /// <param name="zipFileName">The name of the zip file to create.</param>
        /// <param name="sourceDirectory">The directory to source files from.</param>
        /// <param name="recurse">True to recurse directories, false for no recursion.</param>
        /// <param name="fileFilter">The <see cref="PathFilter">file filter</see> to apply.</param>
        /// <param name="directoryFilter">The <see cref="PathFilter">directory filter</see> to apply.</param>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     specified a file that is read-only. </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="IOException">An I/O error occurred while creating the file. </exception>
        public void CreateZip(string zipFileName, string sourceDirectory,
            bool recurse, string fileFilter, string directoryFilter)
            {
            this.CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
            }

        /// <summary>
        /// Create a zip file/archive.
        /// </summary>
        /// <param name="zipFileName">The name of the zip file to create.</param>
        /// <param name="sourceDirectory">The directory to obtain files and directories from.</param>
        /// <param name="recurse">True to recurse directories, false for no recursion.</param>
        /// <param name="fileFilter">The file filter to apply.</param>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     specified a file that is read-only. </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="IOException">An I/O error occurred while creating the file. </exception>
        public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
            {
            this.CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, null);
            }

        /// <summary>
        /// Create a zip archive sending output to the <paramref name="outputStream"/> passed.
        /// </summary>
        /// <param name="outputStream">The stream to write archive data to.</param>
        /// <param name="sourceDirectory">The directory to source files from.</param>
        /// <param name="recurse">True to recurse directories, false for no recursion.</param>
        /// <param name="fileFilter">The <see cref="PathFilter">file filter</see> to apply.</param>
        /// <param name="directoryFilter">The <see cref="PathFilter">directory filter</see> to apply.</param>
        public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
            {
            this.NameTransform = new ZipNameTransform(sourceDirectory);
            this.sourceDirectory_ = sourceDirectory;

            using (this.outputStream_ = new ZipOutputStream(outputStream))
                {

#if !NETCF_1_0
                if (this.password_ != null)
                    {
                    this.outputStream_.Password = this.password_;
                    }
#endif

                this.outputStream_.UseZip64 = this.UseZip64;
                var scanner = new FileSystemScanner(fileFilter, directoryFilter);
                scanner.ProcessFile += this.ProcessFile;
                if (this.CreateEmptyDirectories)
                    {
                    scanner.ProcessDirectory += this.ProcessDirectory;
                    }

                if (this.events_ != null)
                    {
                    if (this.events_.FileFailure != null)
                        {
                        scanner.FileFailure += this.events_.FileFailure;
                        }

                    if (this.events_.DirectoryFailure != null)
                        {
                        scanner.DirectoryFailure += this.events_.DirectoryFailure;
                        }
                    }

                scanner.Scan(sourceDirectory, recurse);
                }
            }

        #endregion

        #region ExtractZip

        /// <summary>
        /// Extract the contents of a zip file.
        /// </summary>
        /// <param name="zipFileName">The zip file to extract from.</param>
        /// <param name="targetDirectory">The directory to save extracted information in.</param>
        /// <param name="fileFilter">A filter to apply to files.</param>
        /// <exception cref="ArgumentNullException">confirmDelegate is <see langword="null" />.</exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type <paramref>
        ///         <name>TResult</name>
        ///     </paramref>
        ///     .</exception>
        /// <exception cref="ZipException">
        /// The file doesn't contain a valid zip archive.
        /// </exception>
        /// <exception cref="IOException">
        /// An i/o error occurs
        /// </exception>
        public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter)
            {
            this.ExtractZip(zipFileName, targetDirectory, Overwrite.Always, null, fileFilter, null, this.restoreDateTimeOnExtract_);
            }

        /// <summary>
        /// Extract the contents of a zip file.
        /// </summary>
        /// <param name="zipFileName">The zip file to extract from.</param>
        /// <param name="targetDirectory">The directory to save extracted information in.</param>
        /// <param name="overwrite">The style of <see cref="Overwrite">overwriting</see> to apply.</param>
        /// <param name="confirmDelegate">A delegate to invoke when confirming overwriting.</param>
        /// <param name="fileFilter">A filter to apply to files.</param>
        /// <param name="directoryFilter">A filter to apply to directories.</param>
        /// <param name="restoreDateTime">Flag indicating wether to restore the date and time for extracted files.</param>
        /// <exception cref="ArgumentNullException"><paramref name="confirmDelegate"/> is <see langword="null" />.</exception>
        /// <exception cref="IOException">
        /// An i/o error occurs
        /// </exception>
        /// <exception cref="ZipException">
        /// The file doesn't contain a valid zip archive.
        /// </exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type <paramref>
        ///         <name>TResult</name>
        ///     </paramref>
        ///     .</exception>
        public void ExtractZip(string zipFileName, string targetDirectory,
                               Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate,
                               string fileFilter, string directoryFilter, bool restoreDateTime)
            {
            if ((overwrite == Overwrite.Prompt) && (confirmDelegate == null))
                {
                throw new ArgumentNullException(nameof(confirmDelegate));
                }

            this.continueRunning_ = true;
            this.overwrite_ = overwrite;
            this.confirmDelegate_ = confirmDelegate;

            this.extractNameTransform_ = new WindowsNameTransform(targetDirectory);

            this.fileFilter_ = new NameFilter(fileFilter);
            this.directoryFilter_ = new NameFilter(directoryFilter);
            this.restoreDateTimeOnExtract_ = restoreDateTime;

            using (this.zipFile_ = new ZipFile(zipFileName))
                {

#if !NETCF_1_0
                if (this.password_ != null)
                    {
                    this.zipFile_.Password = this.password_;
                    }
#endif

                var enumerator = this.zipFile_.GetEnumerator();
                while (this.continueRunning_ && enumerator.MoveNext())
                    {
                    var entry = (ZipEntry)enumerator.Current;
                    if (entry.IsFile)
                        {
                        if (this.directoryFilter_.IsMatch(Path.GetDirectoryName(entry.Name)) && this.fileFilter_.IsMatch(entry.Name))
                            {
                            this.ExtractEntry(entry);
                            }
                        }
                    else if (entry.IsDirectory)
                        {
                        if (this.directoryFilter_.IsMatch(entry.Name) && this.CreateEmptyDirectories)
                            {
                            this.ExtractEntry(entry);
                            }
                        }
                    }
                }
            }
        #endregion

        #region Internal Processing

        private void ProcessDirectory(object sender, DirectoryEventArgs e)
            {
            if (!e.HasMatchingFiles && this.CreateEmptyDirectories)
                {
                this.events_?.OnProcessDirectory(e.Name, e.HasMatchingFiles);

                if (e.ContinueRunning)
                    {
                    if (e.Name != this.sourceDirectory_)
                        {
                        var entry = this.entryFactory_.MakeDirectoryEntry(e.Name);
                        this.outputStream_.PutNextEntry(entry);
                        }
                    }
                }
            }

        private void ProcessFile(object sender, ScanEventArgs e)
            {
            this.events_?.ProcessFile?.Invoke(sender, e);

            if (e.ContinueRunning)
                {
                using (var stream = File.OpenRead(e.Name))
                    {
                    var entry = this.entryFactory_.MakeFileEntry(e.Name);
                    this.outputStream_.PutNextEntry(entry);
                    this.AddFileContents(e.Name, stream);
                    }
                }
            }

        private void AddFileContents(string name, Stream stream)
            {
            if (stream == null)
                {
                throw new ArgumentNullException(nameof(stream));
                }

            if (this.buffer_ == null)
                {
                this.buffer_ = new byte[4096];
                }

            if (this.events_?.Progress != null)
                {
                StreamUtils.Copy(stream, this.outputStream_, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, this, name);
                }
            else
                {
                StreamUtils.Copy(stream, this.outputStream_, this.buffer_);
                }

            if (this.events_ != null)
                {
                this.continueRunning_ = this.events_.OnCompletedFile(name);
                }
            }

        private void ExtractFileEntry(ZipEntry entry, string targetName)
            {
            bool proceed = true;
            if (this.overwrite_ != Overwrite.Always)
                {
                if (File.Exists(targetName))
                    {
                    if ((this.overwrite_ == Overwrite.Prompt) && (this.confirmDelegate_ != null))
                        {
                        proceed = this.confirmDelegate_(targetName);
                        }
                    else
                        {
                        proceed = false;
                        }
                    }
                }

            if (proceed)
                {
                if (this.events_ != null)
                    {
                    this.continueRunning_ = this.events_.OnProcessFile(entry.Name);
                    }

                if (this.continueRunning_)
                    {
                    try
                        {
                        Stream outputStream;
                        using (outputStream = File.Create(targetName))
                            {
                            if (this.buffer_ == null)
                                {
                                this.buffer_ = new byte[4096];
                                }
                            if (this.events_?.Progress != null)
                                {
                                StreamUtils.Copy(this.zipFile_.GetInputStream(entry), outputStream, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, this, entry.Name, entry.Size);
                                }
                            else
                                {
                                StreamUtils.Copy(this.zipFile_.GetInputStream(entry), outputStream, this.buffer_);
                                }

                            if (this.events_ != null)
                                {
                                this.continueRunning_ = this.events_.OnCompletedFile(entry.Name);
                                }

                            }

#if !NETCF_1_0 && !NETCF_2_0
                        if (this.restoreDateTimeOnExtract_)
                            {
                            File.SetLastWriteTime(targetName, entry.DateTime);
                            }

                        if (this.RestoreAttributesOnExtract && entry.IsDOSEntry && (entry.ExternalFileAttributes != -1))
                            {
                            var fileAttributes = (FileAttributes)entry.ExternalFileAttributes;
                            fileAttributes &= FileAttributes.Archive | FileAttributes.Normal | FileAttributes.ReadOnly | FileAttributes.Hidden;
                            File.SetAttributes(targetName, fileAttributes);
                            }
#endif
                        }
                    catch (Exception ex)
                        {
                        if (this.events_ != null)
                            {
                            this.continueRunning_ = this.events_.OnFileFailure(targetName, ex);
                            }
                        else
                            {
                            this.continueRunning_ = false;
                            throw;
                            }
                        }
                    }
                }
            }

        private void ExtractEntry(ZipEntry entry)
            {
            bool doExtraction = entry.IsCompressionMethodSupported();
            string targetName = entry.Name;

            if (doExtraction)
                {
                if (entry.IsFile)
                    {
                    targetName = this.extractNameTransform_.TransformFile(targetName);
                    }
                else if (entry.IsDirectory)
                    {
                    targetName = this.extractNameTransform_.TransformDirectory(targetName);
                    }

                doExtraction = !((targetName == null) || (targetName.Length == 0));
                }

            string dirName = null;

            if (doExtraction)
                {
                dirName = entry.IsDirectory ?
                    targetName :
                    Path.GetDirectoryName(Path.GetFullPath(targetName));
                }

            if (doExtraction && !Directory.Exists(dirName))
                {
                if (!entry.IsDirectory || this.CreateEmptyDirectories)
                    {
                    try
                        {
                        Directory.CreateDirectory(dirName);
                        }
                    catch (Exception ex)
                        {
                        doExtraction = false;
                        if (this.events_ != null)
                            {
                            this.continueRunning_ = entry.IsDirectory ?
                                this.events_.OnDirectoryFailure(targetName, ex) :
                                this.events_.OnFileFailure(targetName, ex);
                            }
                        else
                            {
                            this.continueRunning_ = false;
                            throw;
                            }
                        }
                    }
                }

            if (doExtraction && entry.IsFile)
                {
                this.ExtractFileEntry(entry, targetName);
                }
            }

        private static int MakeExternalAttributes(FileInfo info)
            {
            return (int)info.Attributes;
            }

#if NET_1_0 || NET_1_1 || NETCF_1_0
		static bool NameIsValid(string name)
		{
			return (name != null) &&
				(name.Length > 0) &&
				(name.IndexOfAny(Path.InvalidPathChars) < 0);
		}
#else
        private static bool NameIsValid(string name)
            {
            return !string.IsNullOrEmpty(name) &&
                (name.IndexOfAny(Path.GetInvalidPathChars()) < 0);
            }
#endif
        #endregion

        #region Instance Fields

        private bool continueRunning_;
        private byte[] buffer_;
        private ZipOutputStream outputStream_;
        private ZipFile zipFile_;
        private string sourceDirectory_;
        private NameFilter fileFilter_;
        private NameFilter directoryFilter_;
        private Overwrite overwrite_;
        private ConfirmOverwriteDelegate confirmDelegate_;

        private bool restoreDateTimeOnExtract_;
        private FastZipEvents events_;
        private IEntryFactory entryFactory_ = new ZipEntryFactory();
        private INameTransform extractNameTransform_;

#if !NETCF_1_0
        private string password_;
#endif

        #endregion
        }
    }