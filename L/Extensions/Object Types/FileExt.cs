using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using LCore.Interfaces;
using LCore.Tests;

// ReSharper disable UnusedMember.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions to more easily access the file system.
    /// </summary>
    [ExtensionProvider]
    public static class FileExt
        {
        #region Extensions +

        #region ByteArrayToCharArray
        /// <summary>
        /// Safely converts a byte<paramref name="] to a char[" />
        /// </summary>
        public static char[] ByteArrayToCharArray(byte[] In)
            {
            if (In == null)
                {
                return new char[0];
                }
            var Out = new char[In.Length];

            for (int Index = 0; Index < In.Length; Index++)
                {
                Out[Index] = Convert.ToChar(In[Index]);
                }
            return Out;
            }
        #endregion

        #region CleanFileName
        /// <summary>
        /// Removes non-supported characters from filenames.
        /// </summary>
        public static string CleanFileName(this string In)
            {
            return L.File.CleanFileName(In);
            }
        #endregion

        #region EnsurePathExists
        /// <summary>
        /// Creates a directory path if it doesn't already exist.
        /// </summary>
        [Tested]
        public static void EnsurePathExists(this string Path)
            {
            string DirPath = Path;

            if (DirPath.Contains("\\"))
                DirPath = DirPath.Substring(0, DirPath.LastIndexOf("\\", StringComparison.Ordinal));

            if (!Directory.Exists(DirPath))
                Directory.CreateDirectory(DirPath);
            }
        #endregion

        #region EveryOtherByte
        /// <summary>
        /// Returns a byte[] with every other element skipped.
        /// Useful for reading data that has been encoded in Unicode.
        /// </summary>
        public static byte[] EveryOtherByte(this byte[] In)
            {
            var Out = new byte[In.Length / 2];
            for (int Index = 0; Index < Out.Length; Index++)
                {
                Out[Index] = In[Index * 2];
                }
            return Out;
            }
        #endregion

        #region GetFileBlock
        /// <summary>
        /// Reads a chunk of file <paramref name="F" /> using <paramref name="BlockSize" /> and <paramref name="BlockNum" /> as index.
        /// </summary>
        public static byte[] GetFileBlock(FileStream F, int BlockSize, int BlockNum)
            {
            if (F == null)
                throw new ArgumentNullException(nameof(F));

            if (!F.CanRead)
                {
                F = GetFileStream(F.Name);
                }

            if (F == null)
                throw new IOException();


            if (BlockNum < 0)
                {
                BlockNum = 0;
                }

            int StartPos = BlockSize * BlockNum;

            if (BlockSize <= 0)
                {
                BlockSize = (int)F.Length;
                }
            else if ((BlockNum + 1) * BlockSize > F.Length)
                {
                BlockSize = (int)F.Length - BlockNum * BlockSize;
                }

            if (StartPos > F.Length || BlockSize < 0)
                throw new ArgumentException($"PartNum: {BlockNum}");

            int Tries = 0;
            byte[] Contents = null;
            while (Tries < 2)
                {
                try
                    {
                    Contents = new byte[BlockSize];
                    F.Seek(StartPos, SeekOrigin.Begin);

                    if (L.File.LockFiles)
                        F.Lock(StartPos, BlockSize);

                    F.Read(Contents, 0, Contents.Length);

                    if (L.File.LockFiles)
                        F.Unlock(StartPos, BlockSize);

                    break;
                    }
                catch (Exception Ex)
                    {
                    if (Tries == 9)
                        {
                        try
                            {
                            if (L.File.LockFiles)
                                F.Unlock(StartPos, BlockSize);
                            }
                        catch { }

                        try { F.Close(); }
                        catch { }

                        throw new Exception("", Ex);
                        }
                    Thread.Sleep(200);
                    }
                Tries++;
                }

            try
                {
                F.Close();
                }
            catch
                {
                }

            return Contents;
            }
        #endregion

        #region GetFileStream
        /// <summary>
        /// Returns a new FileStream using the default FileMode, FileAccess, and FileShare settings.
        /// (Open | Read | ReadWrite, Delete)
        /// </summary>
        public static FileStream GetFileStream(this string FullPath)
            {
            try { return new FileStream(FullPath, L.File.DefaultFileMode, L.File.DefaultFileAccess, L.File.DefaultFileShare); }
            catch { return null; }
            }
        #endregion

        #region GetFileHash
        /// <summary>
        /// Returns the file's hash, determined by the file bytes and 
        /// L.HashAlgorithm (default to SHA256)
        /// </summary>
        public static byte[] GetFileHash(this string FullPath)
            {
            if (FullPath == null)
                throw new ArgumentNullException(nameof(FullPath));
            if (!File.Exists(FullPath))
                throw new FileNotFoundException(FullPath);

            return GetStreamHash(FullPath.ToStream());
            }
        #endregion

        #region GetMemoryStream
        /// <summary>
        /// Reads the entirety of a Stream and returns it as a MemoryStream.
        /// </summary>
        public static MemoryStream GetMemoryStream(this Stream In)
            {
            var MemStream = new MemoryStream();

            var RespBuffer = new byte[1024];
            try
                {
                int BytesRead = In.Read(RespBuffer, 0,
                RespBuffer.Length);
                while (BytesRead > 0)
                    {
                    MemStream.Write(RespBuffer, 0, BytesRead);
                    BytesRead = In.Read(RespBuffer, 0,
                    RespBuffer.Length);
                    }
                }
            catch { }
            return MemStream;
            }
        #endregion

        #region GetStreamHash
        /// <summary>
        /// Returns the stream's hash, determined by the stream bytes and 
        /// L.HashAlgorithm (default to SHA256)
        /// </summary>
        public static byte[] GetStreamHash(this Stream InputStream)
            {
            if (InputStream == null)
                throw new ArgumentNullException(nameof(InputStream));

            byte[] Hash = L.File.HashAlgorithm.ComputeHash(InputStream);
            try { InputStream.Close(); }
            catch { }
            return Hash;
            }
        #endregion

        #region GetStringHash
        /// <summary>
        /// Returns the string's hash, determined by the string bytes and 
        /// L.HashAlgorithm (default to SHA256)
        /// </summary>
        public static byte[] GetStringHash(this string In)
            {
            return GetStreamHash(In.ToStream());
            }
        #endregion

        #region MatchesWildCard
        /// <summary>
        /// Returns whether a string matches a wildcard 
        /// </summary>
        /// <param name="In"></param>
        /// <param name="WildCard"></param>
        /// <returns></returns>
        public static bool MatchesWildCard(string In, string WildCard)
            {
            if (In == null)
                throw new ArgumentNullException(nameof(In));
            if (WildCard == null)
                throw new ArgumentNullException(nameof(WildCard));

            if (!WildCard.StartsWith("*"))
                WildCard = $"*{WildCard}";


            WildCard = WildCard.ReplaceAll(new Dictionary<string, string>
                {
                {"**", "*"},
                {"*?", "*"},
                {"?*", "*"}
                });

            return MatchesWildCardLowerCase(In.ToLower(), WildCard.ToLower());
            }
        #endregion

        #region MatchesWildCardLowerCase
        private static bool MatchesWildCardLowerCase(string In, string WildCard)
            {
            if (WildCard == "*")
                {
                return true;
                }
            if (WildCard == "?" && In.Length == 1)
                {
                return true;
                }
            if (WildCard == In)
                {
                return true;
                }
            if (WildCard.Length == 0)
                {
                return false;
                }
            if (WildCard[0] == '*')
                {
                if (In.Length > 1 || (In.Length > 0 && WildCard.Length > 1 && In[0] == WildCard[1]))
                    {
                    if (In[0] == WildCard[1])
                        {
                        return MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(2)) ||
                               MatchesWildCardLowerCase(In.Substring(1), WildCard);
                        }
                    if (In[1] == WildCard[1])
                        {
                        return MatchesWildCardLowerCase(In.Substring(2), WildCard.Substring(2)) ||
                               MatchesWildCardLowerCase(In.Substring(2), WildCard);
                        }
                    return MatchesWildCardLowerCase(In.Substring(1), WildCard);
                    }
                return false;
                }
            if (WildCard[0] == '?')
                {
                return MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(1));
                }
            return In.Length != 0 && WildCard[0] == In[0] && MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(1));
            }

        #endregion

        #region ReadAllBytes
        /// <summary>
        /// Reads all bytes from the stream and returns a Byte[].
        /// </summary>
        public static byte[] ReadAllBytes(this Stream Input)
            {
            var Buffer = new byte[16 * 1024];

            using (var Stream = new MemoryStream())
                {
                int Read;
                while ((Read = Input.Read(Buffer, 0, Buffer.Length)) > 0)
                    {
                    Stream.Write(Buffer, 0, Read);
                    }
                return Stream.ToArray();
                }
            }
        #endregion

        #region WaitForFileUnlock
        /// <summary>
        /// Waits until a FileStream can be opened. Waits at most <paramref name="MaxWaitMS" /> milliseconds.
        /// </summary>
        public static bool WaitForFileUnlock(string FullPath, int MaxWaitMS)
            {
            const int Wait = 100;

            while (MaxWaitMS > 0)
                {
                try
                    {
                    var Stream = new FileStream(FullPath, FileMode.Open, FileAccess.ReadWrite);
                    Stream.Close();
                    return true;
                    }
                catch (Exception)
                    {
                    if (MaxWaitMS < Wait)
                        return false;

                    MaxWaitMS -= Wait;
                    Thread.Sleep(Wait);
                    }
                }
            return false;
            }

        #endregion


        #endregion
        }
    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to file operations.
        /// </summary>
        public static class File
            {
            #region Static Variables +
            // ReSharper disable ConvertToConstant.Global
            // ReSharper disable FieldCanBeMadeReadOnly.Global
            /// <summary>
            /// During file operations, L will use the default file mode Open.
            /// Change this value to manually override.
            /// </summary>
            public static FileMode DefaultFileMode = FileMode.Open;
            /// <summary>
            /// During file operations, L will use the default file access Read.
            /// Change this value to manually override.
            /// </summary>
            public static FileAccess DefaultFileAccess = FileAccess.Read;
            /// <summary>
            /// During file operations, L will use the default file share ReadWrite + Delete.
            /// Change this value to manually override.
            /// </summary>
            public static FileShare DefaultFileShare = FileShare.ReadWrite | FileShare.Delete;
            /// <summary>
            /// During file operations, L will lock files if this value is set to true. Default is false.
            /// </summary>
            public static bool LockFiles = false;

            /// <summary>
            /// The default character to use to combine paths for L.
            /// Change this value to manually override.
            /// </summary>
            public static char CombinePathsDefaultSeparator = '\\';

            /// <summary>
            /// The default hashing algorithm to use for L hashing functions.
            /// Change this value to manually override.
            /// </summary>
            public static HashAlgorithm HashAlgorithm = new SHA256CryptoServiceProvider();

            // ReSharper restore ConvertToConstant.Global
            // ReSharper restore FieldCanBeMadeReadOnly.Global
            #endregion

            #region Static Methods +

            #region BufferedMove
            /// <summary>
            /// Subscribe to this EventHandler to be notified of buffered move progress 
            /// during the 
            /// </summary>
            // ReSharper disable once EventNeverSubscribedTo.Global
            public static event EventHandler BufferedMoveProgress;

            /// <summary>
            /// Moves a file from <paramref name="From" /> to <paramref name="To" /> using a buffer.
            /// The original file is deleted.
            /// </summary>
            public static void BufferedMove(string From, string To, bool DeleteOriginal, int ChunkSize = 128 * 1024)
                {
                var Stream1 = new FileStream(From, FileMode.Open, FileAccess.Read, FileShare.Read);
                var Stream2 = new FileStream(To, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

                Stream2.Seek(0, SeekOrigin.Begin);
                Stream2.SetLength(Stream1.Length);

                int BufferSize = ChunkSize;

                long TotalSize = Stream1.Length;
                long Index = 0;

                while (Index < TotalSize)
                    {
                    long CurrentChunkSize = TotalSize - Index;

                    if (CurrentChunkSize > BufferSize)
                        CurrentChunkSize = BufferSize;
                    var Bytes = new byte[CurrentChunkSize];
                    Stream1.Read(Bytes, 0, (int)CurrentChunkSize);
                    Stream2.Write(Bytes, 0, (int)CurrentChunkSize);
                    Stream2.Flush();
                    Index += CurrentChunkSize;
                    BufferedMoveProgress?.Invoke(new[] { Index, TotalSize }, null);
                    }

                Stream2.Close();
                Stream1.Close();

                if (DeleteOriginal)
                    System.IO.File.Delete(From);
                }
            #endregion

            #region CleanFileName
            /// <summary>
            /// Removes non-supported characters from filenames.
            /// </summary>
            public static readonly Func<string, string> CleanFileName =
                F<string,char[],string>(Str.RemoveChars).Surround2(Path.GetInvalidFileNameChars);
            #endregion

            #region CombinePaths
            /// <summary>
            /// Combines sections of a file path using the default Windows file path 
            /// separator '\'
            /// </summary>
            public static string CombinePaths(params string[] Path)
                {
                if (Path == null)
                    {
                    throw new ArgumentNullException(nameof(Path));
                    }
                return CombinePaths(CombinePathsDefaultSeparator, Path);
                }

            /// <summary>
            /// Combines sections of a file path using a character separator.
            /// </summary>
            public static string CombinePaths(char Separator, params string[] Path)
                {
                if (Path == null)
                    {
                    throw new ArgumentNullException(nameof(Path));
                    }

                string Out = Path.CollectStr<string, string[]>((i, Str) =>
                {
                    if (!Str.IsEmpty())
                        {
                        string StrOut = "";
                        if (i != 0)
                            {
                            StrOut += Separator;
                            }
                        StrOut += Path[i];
                        return StrOut;
                        }
                    return null;
                });

                Out = Out.Replace($"{Separator}{Separator}", Separator.ToString());
                Out = Out.Replace("http:/", "http://");
                Out = Out.Replace("https:/", "https://");

                // Fix for UNC paths
                if (Out.StartsWith("\\") && !Out.StartsWith("\\\\"))
                    {
                    Out = $"\\{Out}";
                    }

                return Out;
                }

            #endregion

            #region GetFileContents
            /// <summary>
            /// A function that returns the bytes of a file from a string path.
            /// </summary>
            public static readonly Func<string, byte[]> GetFileContents = FileName =>
                {
                    var Str = FileName.GetFileStream();
                    return FileExt.GetFileBlock(Str, (int)Str.Length, 0);
                };

            #endregion

            #region SafeCopyFile
            /// <summary>
            /// Tries to copy a file from <paramref name="PathSource" /> to <paramref name="PathDestination" />.
            /// Optionally, retry a number of times, default 0.
            /// Optionally, overwrite the destination file if it exists. 
            /// </summary>
            public static bool SafeCopyFile(string PathSource, string PathDestination, int Tries = 0, bool OverwriteIfExists = false)
                {
                return SafeMoveFile(PathSource, PathDestination, Tries, OverwriteIfExists, false);
                }
            #endregion

            #region SafeMoveFile
            /// <summary>
            /// Tries to move a file from <paramref name="PathSource" /> to <paramref name="PathDestination" />.
            /// Optionally, retry a number of times, default 0.
            /// Optionally, overwrite the destination file if it exists.
            /// Optionally, delete the original.
            /// </summary>
            public static bool SafeMoveFile(string PathSource, string PathDestination, int Tries = 0, bool OverwriteIfExists = false, bool DeleteOriginal = true)
                {
                try
                    {
                    PathDestination.EnsurePathExists();

                    if (OverwriteIfExists && System.IO.File.Exists(PathDestination))
                        System.IO.File.Delete(PathDestination);

                    PathSource = PathSource.Replace("\\\\", "\\");
                    PathDestination = PathDestination.Replace("\\\\", "\\");

                    if (PathSource.StartsWith("\\"))
                        PathSource = $"\\{PathSource}";
                    if (PathDestination.StartsWith("\\"))
                        PathDestination = $"\\{PathDestination}";

                    string Dir = PathDestination.Substring(0, PathDestination.LastIndexOf('\\'));

                    if (!Directory.Exists(Dir))
                        Directory.CreateDirectory(Dir);

                    try
                        {
                        if (Path.GetPathRoot(PathSource) == Path.GetPathRoot(PathDestination))
                            {
                            System.IO.File.Move(PathSource, PathDestination);
                            return true;
                            }
                        throw new Exception();
                        }
                    catch
                        {
                        BufferedMove(PathSource, PathDestination, DeleteOriginal);
                        return true;
                        }
                    }
                catch (Exception Ex)
                    {
                    if (Ex.Message.Contains("The process cannot access the file because it is being used by another process."))
                        return false;

                    if (Tries <= 0)
                        {
                        throw new Exception($"Could not move file \'{PathSource}\' to destination \'{PathDestination}\'", Ex);
                        }

                    System.Threading.Thread.Sleep(1000);
                    return SafeMoveFile(PathSource, PathDestination, Tries - 1, OverwriteIfExists, DeleteOriginal);
                    }
                }
            #endregion

            #endregion
            }
        }
    }