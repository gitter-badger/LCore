// TarArchive.cs
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
using System.Text;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace ICSharpCode.SharpZipLib.Tar
    {
    /// <summary>
    /// Used to advise clients of 'events' while processing archives
    /// </summary>
    public delegate void ProgressMessageHandler(TarArchive archive, TarEntry entry, string message);

    /// <summary>
    /// The TarArchive class implements the concept of a
    /// 'Tape Archive'. A tar archive is a series of entries, each of
    /// which represents a file system object. Each entry in
    /// the archive consists of a header block followed by 0 or more data blocks.
    /// Directory entries consist only of the header block, and are followed by entries
    /// for the directory's contents. File entries consist of a
    /// header followed by the number of blocks needed to
    /// contain the file's contents. All entries are written on
    /// block boundaries. Blocks are 512 bytes long.
    /// 
    /// TarArchives are instantiated in either read or write mode,
    /// based upon whether they are instantiated with an InputStream
    /// or an OutputStream. Once instantiated TarArchives read/write
    /// mode can not be changed.
    /// 
    /// There is currently no support for random access to tar archives.
    /// However, it seems that subclassing TarArchive, and using the
    /// TarBuffer.CurrentRecord and TarBuffer.CurrentBlock
    /// properties, this would be rather trivial.
    /// </summary>
    public class TarArchive : IDisposable
        {
        /// <summary>
        /// Client hook allowing detailed information to be reported during processing
        /// </summary>
        public event ProgressMessageHandler ProgressMessageEvent;

        /// <summary>
        /// Raises the ProgressMessage event
        /// </summary>
        /// <param name="entry">The <see cref="TarEntry">TarEntry</see> for this event</param>
        /// <param name="message">message for this event.  Null is no message</param>
        protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
            {
            this.ProgressMessageEvent?.Invoke(this, entry, message);
            }

        #region Constructors

        /// <summary>
        /// Initalise a TarArchive for input.
        /// </summary>
        /// <param name="stream">The <see cref="TarInputStream"/> to use for input.</param>
        protected TarArchive(TarInputStream stream)
            {
            if (stream == null)
                {
                throw new ArgumentNullException(nameof(stream));
                }

            this.tarIn = stream;
            }

        /// <summary>
        /// Initialise a TarArchive for output.
        /// </summary>
        /// <param name="stream">The <see cref="TarOutputStream"/> to use for output.</param> 
        protected TarArchive(TarOutputStream stream)
            {
            if (stream == null)
                {
                throw new ArgumentNullException(nameof(stream));
                }

            this.tarOut = stream;
            }
        #endregion

        #region Static factory methods
        /// <summary>
        /// The InputStream based constructors create a TarArchive for the
        /// purposes of extracting or listing a tar archive. Thus, use
        /// these constructors when you wish to extract files from or list
        /// the contents of an existing tar archive.
        /// </summary>
        /// <param name="inputStream">The stream to retrieve archive data from.</param>
        /// <returns>Returns a new <see cref="TarArchive"/> suitable for reading from.</returns>
        public static TarArchive CreateInputTarArchive(Stream inputStream)
            {
            if (inputStream == null)
                {
                throw new ArgumentNullException(nameof(inputStream));
                }

            var tarStream = inputStream as TarInputStream;

            return tarStream != null ?
                new TarArchive(tarStream) :
                CreateInputTarArchive(inputStream, TarBuffer.DefaultBlockFactor);
            }

        /// <summary>
        /// Create TarArchive for reading setting block factor
        /// </summary>
        /// <param name="inputStream">A stream containing the tar archive contents</param>
        /// <param name="blockFactor">The blocking factor to apply</param>
        /// <returns>Returns a <see cref="TarArchive"/> suitable for reading.</returns>
        public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
            {
            if (inputStream == null)
                {
                throw new ArgumentNullException(nameof(inputStream));
                }

            if (inputStream is TarInputStream)
                {
                throw new ArgumentException("TarInputStream not valid");
                }

            return new TarArchive(new TarInputStream(inputStream, blockFactor));
            }

        /// <summary>
        /// Create a TarArchive for writing to, using the default blocking factor
        /// </summary>
        /// <param name="outputStream">The <see cref="Stream"/> to write to</param>
        /// <returns>Returns a <see cref="TarArchive"/> suitable for writing.</returns>
        public static TarArchive CreateOutputTarArchive(Stream outputStream)
            {
            if (outputStream == null)
                {
                throw new ArgumentNullException(nameof(outputStream));
                }
            var tarStream = outputStream as TarOutputStream;

            return tarStream != null ? 
                new TarArchive(tarStream) : 
                CreateOutputTarArchive(outputStream, TarBuffer.DefaultBlockFactor);
            }

        /// <summary>
        /// Create a <see cref="TarArchive">tar archive</see> for writing.
        /// </summary>
        /// <param name="outputStream">The stream to write to</param>
        /// <param name="blockFactor">The blocking factor to use for buffering.</param>
        /// <returns>Returns a <see cref="TarArchive"/> suitable for writing.</returns>
        public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
            {
            if (outputStream == null)
                {
                throw new ArgumentNullException(nameof(outputStream));
                }

            if (outputStream is TarOutputStream)
                {
                throw new ArgumentException("TarOutputStream is not valid");
                }

            return new TarArchive(new TarOutputStream(outputStream, blockFactor));
            }
        #endregion

        /// <summary>
        /// Set the flag that determines whether existing files are
        /// kept, or overwritten during extraction.
        /// </summary>
        /// <param name="keepOldFiles">
        /// If true, do not overwrite existing files.
        /// </param>
        public void SetKeepOldFiles(bool keepOldFiles)
            {
            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            this.keepOldFiles = keepOldFiles;
            }

        /// <summary>
        /// Get/set the ascii file translation flag. If ascii file translation
        /// is true, then the file is checked to see if it a binary file or not. 
        /// If the flag is true and the test indicates it is ascii text 
        /// file, it will be translated. The translation converts the local
        /// operating system's concept of line ends into the UNIX line end,
        /// '\n', which is the defacto standard for a TAR archive. This makes
        /// text files compatible with UNIX.
        /// </summary>
        public bool AsciiTranslate
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.asciiTranslate;
                }

            set
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                this.asciiTranslate = value;
                }

            }

        /// <summary>
        /// Set the ascii file translation flag.
        /// </summary>
        /// <param name= "asciiTranslate">
        /// If true, translate ascii text files.
        /// </param>
        [Obsolete("Use the AsciiTranslate property")]
        public void SetAsciiTranslation(bool asciiTranslate)
            {
            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            this.asciiTranslate = asciiTranslate;
            }

        /// <summary>
        /// PathPrefix is added to entry names as they are written if the value is not null.
        /// A slash character is appended after PathPrefix 
        /// </summary>
        public string PathPrefix
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.pathPrefix;
                }

            set
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                this.pathPrefix = value;
                }

            }

        /// <summary>
        /// RootPath is removed from entry names if it is found at the
        /// beginning of the name.
        /// </summary>
        public string RootPath
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.rootPath;
                }

            set
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                this.rootPath = value;
                }
            }

        /// <summary>
        /// Set user and group information that will be used to fill in the
        /// tar archive's entry headers. This information based on that available 
        /// for the linux operating system, which is not always available on other
        /// operating systems.  TarArchive allows the programmer to specify values
        /// to be used in their place.
        /// <see cref="ApplyUserInfoOverrides"/> is set to true by this call.
        /// </summary>
        /// <param name="userId">
        /// The user id to use in the headers.
        /// </param>
        /// <param name="userName">
        /// The user name to use in the headers.
        /// </param>
        /// <param name="groupId">
        /// The group id to use in the headers.
        /// </param>
        /// <param name="groupName">
        /// The group name to use in the headers.
        /// </param>
        public void SetUserInfo(int userId, string userName, int groupId, string groupName)
            {
            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            this.userId = userId;
            this.userName = userName;
            this.groupId = groupId;
            this.groupName = groupName;
            this.applyUserInfoOverrides = true;
            }

        /// <summary>
        /// Get or set a value indicating if overrides defined by <see cref="SetUserInfo">SetUserInfo</see> should be applied.
        /// </summary>
        /// <remarks>If overrides are not applied then the values as set in each header will be used.</remarks>
        public bool ApplyUserInfoOverrides
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.applyUserInfoOverrides;
                }

            set
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                this.applyUserInfoOverrides = value;
                }
            }

        /// <summary>
        /// Get the archive user id.
        /// See <see cref="ApplyUserInfoOverrides">ApplyUserInfoOverrides</see> for detail
        /// on how to allow setting values on a per entry basis.
        /// </summary>
        /// <returns>
        /// The current user id.
        /// </returns>
        public int UserId
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.userId;
                }
            }

        /// <summary>
        /// Get the archive user name.
        /// See <see cref="ApplyUserInfoOverrides">ApplyUserInfoOverrides</see> for detail
        /// on how to allow setting values on a per entry basis.
        /// </summary>
        /// <returns>
        /// The current user name.
        /// </returns>
        public string UserName
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.userName;
                }
            }

        /// <summary>
        /// Get the archive group id.
        /// See <see cref="ApplyUserInfoOverrides">ApplyUserInfoOverrides</see> for detail
        /// on how to allow setting values on a per entry basis.
        /// </summary>
        /// <returns>
        /// The current group id.
        /// </returns>
        public int GroupId
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.groupId;
                }
            }

        /// <summary>
        /// Get the archive group name.
        /// See <see cref="ApplyUserInfoOverrides">ApplyUserInfoOverrides</see> for detail
        /// on how to allow setting values on a per entry basis.
        /// </summary>
        /// <returns>
        /// The current group name.
        /// </returns>
        public string GroupName
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                return this.groupName;
                }
            }

        /// <summary>
        /// Get the archive's record size. Tar archives are composed of
        /// a series of RECORDS each containing a number of BLOCKS.
        /// This allowed tar archives to match the IO characteristics of
        /// the physical device being used. Archives are expected
        /// to be properly "blocked".
        /// </summary>
        /// <returns>
        /// The record size this archive is using.
        /// </returns>
        public int RecordSize
            {
            get
                {
                if (this.isDisposed)
                    {
                    throw new ObjectDisposedException("TarArchive");
                    }

                if (this.tarIn != null)
                    {
                    return this.tarIn.RecordSize;
                    }
                return this.tarOut?.RecordSize ?? TarBuffer.DefaultRecordSize;
                }
            }

        /// <summary>
        /// Close the archive.
        /// </summary>
        [Obsolete("Use Close instead")]
        public void CloseArchive()
            {
            this.Close();
            }

        /// <summary>
        /// Perform the "list" command for the archive contents.
        /// 
        /// NOTE That this method uses the <see cref="ProgressMessageEvent"> progress event</see> to actually list
        /// the contents. If the progress display event is not set, nothing will be listed!
        /// </summary>
        public void ListContents()
            {
            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            while (true)
                {
                var entry = this.tarIn.GetNextEntry();

                if (entry == null)
                    {
                    break;
                    }
                this.OnProgressMessageEvent(entry, null);
                }
            }

        /// <summary>
        /// Perform the "extract" command and extract the contents of the archive.
        /// </summary>
        /// <param name="destinationDirectory">
        /// The destination directory into which to extract.
        /// </param>
        public void ExtractContents(string destinationDirectory)
            {
            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            while (true)
                {
                var entry = this.tarIn.GetNextEntry();

                if (entry == null)
                    {
                    break;
                    }

                this.ExtractEntry(destinationDirectory, entry);
                }
            }

        /// <summary>
        /// Extract an entry from the archive. This method assumes that the
        /// tarIn stream has been properly set with a call to GetNextEntry().
        /// </summary>
        /// <param name="destDir">
        /// The destination directory into which to extract.
        /// </param>
        /// <param name="entry">
        /// The TarEntry returned by tarIn.GetNextEntry().
        /// </param>
        private void ExtractEntry(string destDir, TarEntry entry)
            {
            this.OnProgressMessageEvent(entry, null);

            string name = entry.Name;

            if (Path.IsPathRooted(name))
                {
                // NOTE:
                // for UNC names...  \\machine\share\zoom\beet.txt gives \zoom\beet.txt
                name = name.Substring(Path.GetPathRoot(name).Length);
                }

            name = name.Replace('/', Path.DirectorySeparatorChar);

            string destFile = Path.Combine(destDir, name);

            if (entry.IsDirectory)
                {
                EnsureDirectoryExists(destFile);
                }
            else
                {
                string parentDirectory = Path.GetDirectoryName(destFile);
                EnsureDirectoryExists(parentDirectory);

                bool process = true;
                var fileInfo = new FileInfo(destFile);
                if (fileInfo.Exists)
                    {
                    if (this.keepOldFiles)
                        {
                        this.OnProgressMessageEvent(entry, "Destination file already exists");
                        process = false;
                        }
                    else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0)
                        {
                        this.OnProgressMessageEvent(entry, "Destination file already exists, and is read-only");
                        process = false;
                        }
                    }

                if (process)
                    {
                    bool asciiTrans = false;

                    Stream outputStream = File.Create(destFile);
                    if (this.asciiTranslate)
                        {
                        asciiTrans = !IsBinary(destFile);
                        }

                    StreamWriter outw = null;
                    if (asciiTrans)
                        {
                        outw = new StreamWriter(outputStream);
                        }

                    var rdbuf = new byte[32 * 1024];

                    while (true)
                        {
                        int numRead = this.tarIn.Read(rdbuf, 0, rdbuf.Length);

                        if (numRead <= 0)
                            {
                            break;
                            }

                        if (asciiTrans)
                            {
                            for (int off = 0, b = 0; b < numRead; ++b)
                                {
                                if (rdbuf[b] == 10)
                                    {
                                    string s = Encoding.ASCII.GetString(rdbuf, off, b - off);
                                    outw.WriteLine(s);
                                    off = b + 1;
                                    }
                                }
                            }
                        else
                            {
                            outputStream.Write(rdbuf, 0, numRead);
                            }
                        }

                    if (asciiTrans)
                        {
                        outw.Close();
                        }
                    else
                        {
                        outputStream.Close();
                        }
                    }
                }
            }

        /// <summary>
        /// Write an entry to the archive. This method will call the putNextEntry
        /// and then write the contents of the entry, and finally call closeEntry()
        /// for entries that are files. For directories, it will call putNextEntry(),
        /// and then, if the recurse flag is true, process each entry that is a
        /// child of the directory.
        /// </summary>
        /// <param name="sourceEntry">
        /// The TarEntry representing the entry to write to the archive.
        /// </param>
        /// <param name="recurse">
        /// If true, process the children of directory entries.
        /// </param>
        public void WriteEntry(TarEntry sourceEntry, bool recurse)
            {
            if (sourceEntry == null)
                {
                throw new ArgumentNullException(nameof(sourceEntry));
                }

            if (this.isDisposed)
                {
                throw new ObjectDisposedException("TarArchive");
                }

            try
                {
                if (recurse)
                    {
                    TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName,
                                               sourceEntry.GroupId, sourceEntry.GroupName);
                    }
                this.WriteEntryCore(sourceEntry, recurse);
                }
            finally
                {
                if (recurse)
                    {
                    TarHeader.RestoreSetValues();
                    }
                }
            }

        /// <summary>
        /// Write an entry to the archive. This method will call the putNextEntry
        /// and then write the contents of the entry, and finally call closeEntry()
        /// for entries that are files. For directories, it will call putNextEntry(),
        /// and then, if the recurse flag is true, process each entry that is a
        /// child of the directory.
        /// </summary>
        /// <param name="sourceEntry">
        /// The TarEntry representing the entry to write to the archive.
        /// </param>
        /// <param name="recurse">
        /// If true, process the children of directory entries.
        /// </param>
        private void WriteEntryCore(TarEntry sourceEntry, bool recurse)
            {
            string tempFileName = null;
            string entryFilename = sourceEntry.File;

            var entry = (TarEntry)sourceEntry.Clone();

            if (this.applyUserInfoOverrides)
                {
                entry.GroupId = this.groupId;
                entry.GroupName = this.groupName;
                entry.UserId = this.userId;
                entry.UserName = this.userName;
                }

            this.OnProgressMessageEvent(entry, null);

            if (this.asciiTranslate && !entry.IsDirectory)
                {
                bool asciiTrans = !IsBinary(entryFilename);

                if (asciiTrans)
                    {
                    tempFileName = Path.GetTempFileName();

                    using (var inStream = File.OpenText(entryFilename))
                        {
                        using (Stream outStream = File.Create(tempFileName))
                            {

                            while (true)
                                {
                                string line = inStream.ReadLine();
                                if (line == null)
                                    {
                                    break;
                                    }
                                byte[] data = Encoding.ASCII.GetBytes(line);
                                outStream.Write(data, 0, data.Length);
                                outStream.WriteByte((byte)'\n');
                                }

                            outStream.Flush();
                            }
                        }

                    entry.Size = new FileInfo(tempFileName).Length;
                    entryFilename = tempFileName;
                    }
                }

            string newName = null;

            if (this.rootPath != null)
                {
                if (entry.Name.StartsWith(this.rootPath))
                    {
                    newName = entry.Name.Substring(this.rootPath.Length + 1);
                    }
                }

            if (this.pathPrefix != null)
                {
                newName = newName == null ? $"{this.pathPrefix}/{entry.Name}" : $"{this.pathPrefix}/{newName}";
                }

            if (newName != null)
                {
                entry.Name = newName;
                }

            this.tarOut.PutNextEntry(entry);

            if (entry.IsDirectory)
                {
                if (recurse)
                    {
                    TarEntry[] list = entry.GetDirectoryEntries();
                    foreach (var t in list)
                        {
                        this.WriteEntryCore(t, true);
                        }
                    }
                }
            else
                {
                using (Stream inputStream = File.OpenRead(entryFilename))
                    {
                    var localBuffer = new byte[32 * 1024];
                    while (true)
                        {
                        int numRead = inputStream.Read(localBuffer, 0, localBuffer.Length);

                        if (numRead <= 0)
                            {
                            break;
                            }

                        this.tarOut.Write(localBuffer, 0, numRead);
                        }
                    }

                if (!string.IsNullOrEmpty(tempFileName))
                    {
                    File.Delete(tempFileName);
                    }

                this.tarOut.CloseEntry();
                }
            }

        /// <summary>
        /// Releases the unmanaged resources used by the FileStream and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
            {
            if (!this.isDisposed)
                {
                this.isDisposed = true;
                if (disposing)
                    {
                    if (this.tarOut != null)
                        {
                        this.tarOut.Flush();
                        this.tarOut.Close();
                        }

                    this.tarIn?.Close();
                    }
                }
            }

        /// <summary>
        /// Closes the archive and releases any associated resources.
        /// </summary>
        public virtual void Close()
            {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            }

        /// <summary>
        /// Ensures that resources are freed and other cleanup operations are performed
        /// when the garbage collector reclaims the <see cref="TarArchive"/>.
        /// </summary>
        ~TarArchive()
            {
            this.Dispose(false);
            }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
            {
            this.Close();
            }

        #endregion

        private static void EnsureDirectoryExists(string directoryName)
            {
            if (!Directory.Exists(directoryName))
                {
                try
                    {
                    Directory.CreateDirectory(directoryName);
                    }
                catch (Exception e)
                    {
                    throw new TarException($"Exception creating directory \'{directoryName}\', {e.Message}", e);
                    }
                }
            }

        private static bool IsBinary(string filename)
            {
            using (var fs = File.OpenRead(filename))
                {
                int sampleSize = Math.Min(4096, (int)fs.Length);
                var content = new byte[sampleSize];

                int bytesRead = fs.Read(content, 0, sampleSize);

                for (int i = 0; i < bytesRead; ++i)
                    {
                    byte b = content[i];
                    if ((b < 8) || ((b > 13) && (b < 32)) || (b == 255))
                        {
                        return true;
                        }
                    }
                }
            return false;
            }

        #region Instance Fields

        private bool keepOldFiles;
        private bool asciiTranslate;

        private int userId;
        private string userName = string.Empty;
        private int groupId;
        private string groupName = string.Empty;

        private string rootPath;
        private string pathPrefix;

        private bool applyUserInfoOverrides;

        private TarInputStream tarIn;
        private TarOutputStream tarOut;
        private bool isDisposed;
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

