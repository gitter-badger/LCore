using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Linq;

namespace LCore.Extensions
    {
    public static class FileExt
        {
        /* TODO: L: File: Comment All Below */

        #region Extensions

        #region BufferedMove
        public static void BufferedMove(string s1, string s2, bool DeleteOriginal)
            {
            FileStream f1 = new FileStream(s1, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream f2 = new FileStream(s2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            f2.Seek(0, SeekOrigin.Begin);
            f2.SetLength(f1.Length);

            const int BufferSize = 128 * 1024;

            long TotalSize = f1.Length;
            long Index = 0;

            while (Index < TotalSize)
                {
                long ChunkSize = TotalSize - Index;

                if (ChunkSize > BufferSize)
                    ChunkSize = BufferSize;
                byte[] Bytes = new byte[ChunkSize];
                f1.Read(Bytes, 0, (int)ChunkSize);
                f2.Write(Bytes, 0, (int)ChunkSize);
                f2.Flush();
                Index += ChunkSize;
                BufferedMove_Progress?.Invoke(new[] { Index, TotalSize }, null);
                }

            f2.Close();
            f1.Close();

            if (DeleteOriginal)
                File.Delete(s1);
            }
        #endregion
        #region ByteArrayToCharArray
        public static char[] ByteArrayToCharArray(byte[] In)
            {
            if (In == null)
                {
                return new char[0];
                }
            char[] Out = new char[In.Length];

            for (int i = 0; i < In.Length; i++)
                {
                Out[i] = Convert.ToChar(In[i]);
                }
            return Out;
            }
        #endregion
        #region CleanFileName
        public static string CleanFileName(this string In)
            {
            return File_CleanFileName(In);
            }
        #endregion
        #region EnsurePathExists
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
        public static byte[] EveryOtherByte(this byte[] In)
            {
            byte[] Out = new byte[In.Length / 2];
            for (int i = 0; i < Out.Length; i++)
                {
                Out[i] = In[i * 2];
                }
            return Out;
            }
        #endregion
        #region GetFileContents
        public static byte[] GetFileContents(FileStream F, int MaxSize, int PartNum)
            {
            if (F == null)
                throw new ArgumentNullException(nameof(F));

            if (!F.CanRead)
                {
                F = GetFileStream(F.Name);
                }

            if (F == null)
                throw new IOException();


            if (PartNum < 0)
                {
                PartNum = 0;
                }

            int StartPos = MaxSize * PartNum;

            if (MaxSize <= 0)
                {
                MaxSize = (int)F.Length;
                }
            else if ((PartNum + 1) * MaxSize > F.Length)
                {
                MaxSize = (int)F.Length - PartNum * MaxSize;
                }

            if (StartPos > F.Length || MaxSize < 0)
                throw new ArgumentException($"PartNum: {PartNum}");

            int tries = 0;
            byte[] Contents = null;
            while (tries < 2)
                {
                try
                    {
                    Contents = new byte[MaxSize];
                    F.Seek(StartPos, SeekOrigin.Begin);

                    if (LOCKFILES)
                        F.Lock(StartPos, MaxSize);

                    F.Read(Contents, 0, Contents.Length);

                    if (LOCKFILES)
                        F.Unlock(StartPos, MaxSize);

                    break;
                    }
                catch (Exception e)
                    {
                    if (tries == 9)
                        {
                        try
                            {
                            if (LOCKFILES)
                                F.Unlock(StartPos, MaxSize);
                            }
                        catch { }

                        try { F.Close(); }
                        catch { }

                        throw new Exception("", e);
                        }
                    Thread.Sleep(200);
                    }
                tries++;
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
        public static FileStream GetFileStream(this string FullPath)
            {
            try { return new FileStream(FullPath, DEFAULTFILEMODE, DEFAULTFILEACCESS, DEFAULTFILESHARE); }
            catch { return null; }
            }
        #endregion
        #region GetFileHash
        public static byte[] GetFileHash(this string FullPath)
            {
            if (FullPath == null)
                throw new ArgumentNullException(nameof(FullPath));
            if (!File.Exists(FullPath))
                throw new FileNotFoundException(FullPath);

            return GetStreamHash(GetStringStream(FullPath));
            }
        #endregion
        #region GetMemoryStream
        public static MemoryStream GetMemoryStream(this Stream In)
            {
            MemoryStream memStream = new MemoryStream();

            byte[] respBuffer = new byte[1024];
            try
                {
                int bytesRead = In.Read(respBuffer, 0,
                respBuffer.Length);
                while (bytesRead > 0)
                    {
                    memStream.Write(respBuffer, 0, bytesRead);
                    bytesRead = In.Read(respBuffer, 0,
                    respBuffer.Length);
                    }
                }
            catch { }
            return memStream;
            }
        #endregion
        #region GetStreamHash
        public static byte[] GetStreamHash(this Stream InputStream)
            {
            if (InputStream == null)
                throw new ArgumentNullException(nameof(InputStream));

            byte[] Hash = HashAlgorithm.ComputeHash(InputStream);
            try { InputStream.Close(); }
            catch { }
            return Hash;
            }
        #endregion
        #region GetStringHash
        public static byte[] GetStringHash(this string In)
            {
            return GetStreamHash(GetStringStream(In));
            }
        #endregion
        #region GetStringStream
        public static Stream GetStringStream(this string In)
            {
            return new MemoryStream(In.ToByteArray());
            }
        #endregion
        #region MatchesFileFilters
        public static bool MatchesFileFilters(string[] FileFilter, string[] FileFilterExceptions, string[] GlobalDirFilterExceptions, string FullName)
            {
            if (FullName == null)
                throw new ArgumentNullException(nameof(FullName));

            string FileName = FullName;

            if (FileName.Contains("\\"))
                FileName = FileName.Substring(FileName.LastIndexOf('\\') + 1);

            return MatchesFileFilters(FileFilter, FileFilterExceptions, GlobalDirFilterExceptions, FullName, FileName);
            }
        private static bool MatchesFileFilters(string[] FileFilter, string[] FileFilterExceptions, string[] GlobalDirFilterExceptions, string FullName, string FileName)
            {
            if (FileFilter == null || FileFilter.Length == 0)
                FileFilter = new[] { "*.*" };

            bool Found = false;

            foreach (string s in FileFilter)
                {
                string Test = s;
                if (Test.IsEmpty())
                    Test = "*.*";
                if (MatchesWildCard(FileName, Test))
                    {
                    Found = true;
                    break;
                    }
                }

            if (Found && FileFilterExceptions != null)
                {
                foreach (string s in FileFilterExceptions)
                    {
                    string s2 = s;
                    if (s2?.Trim() != "" && !s2?.StartsWith("*") == true)
                        s2 = $"*{s2}";
                    if (s2 != "" && MatchesWildCard(FileName, s2))
                        {
                        return false;
                        }
                    }
                }
            if (Found && GlobalDirFilterExceptions != null)
                {
                if (GlobalDirFilterExceptions.Any(s => s != "" && MatchesWildCard(FullName, s)))
                    {
                    return false;
                    }
                }
            return Found;
            }
        #endregion
        #region MatchesFolderFilters
        public static bool MatchesFolderFilters(string[] DirFilterExceptions, string FolderName)
            {
            if (FolderName == null)
                throw new ArgumentNullException(nameof(FolderName));

            return DirFilterExceptions == null || Enumerable.All(DirFilterExceptions, s => s == "" || !MatchesWildCard(FolderName, s));
            }
        #endregion
        #region MatchesWildCard
        public static bool MatchesWildCard(string In, string WildCard)
            {
            if (In == null)
                throw new ArgumentNullException(nameof(In));
            if (WildCard == null)
                throw new ArgumentNullException(nameof(WildCard));

            if (!WildCard.StartsWith("*"))
                WildCard = $"*{WildCard}";

            while (WildCard.Contains("**") || WildCard.Contains("*?") || WildCard.Contains("?*"))
                {
                WildCard = WildCard.Replace("**", "*");
                WildCard = WildCard.Replace("*?", "*");
                WildCard = WildCard.Replace("?*", "*");
                }

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
        public static byte[] ReadAllBytes(this Stream input)
            {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
                {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                    ms.Write(buffer, 0, read);
                    }
                return ms.ToArray();
                }
            }
        #endregion
        #region SafeCopyFile
        public static bool SafeCopyFile(string s1, string s2, int tries, bool OverwriteIfExists)
            {
            return SafeMoveFile(s1, s2, tries, OverwriteIfExists, false);
            }
        #endregion
        #region SafeMoveFile
        public static bool SafeMoveFile(string s1, string s2, int tries, bool OverwriteIfExists, bool DeleteOriginal = true)
            {
            try
                {
                EnsurePathExists(s2);

                if (OverwriteIfExists && File.Exists(s2))
                    File.Delete(s2);

                s1 = s1.Replace("\\\\", "\\");
                s2 = s2.Replace("\\\\", "\\");

                if (s1.StartsWith("\\"))
                    s1 = $"\\{s1}";
                if (s2.StartsWith("\\"))
                    s2 = $"\\{s2}";

                string Dir = s2.Substring(0, s2.LastIndexOf('\\'));

                if (!Directory.Exists(Dir))
                    Directory.CreateDirectory(Dir);

                try
                    {
                    if (Path.GetPathRoot(s1) == Path.GetPathRoot(s2))
                        {
                        File.Move(s1, s2);
                        return true;
                        }
                    throw new Exception();
                    }
                catch
                    {
                    BufferedMove(s1, s2, DeleteOriginal);
                    return true;
                    }
                }
            catch (Exception e)
                {
                if (e.Message.Contains("The process cannot access the file because it is being used by another process."))
                    return false;

                if (tries >= 10)
                    {
                    throw new Exception($"Could not move file \'{s1}\' to destination \'{s2}\'", e);
                    }

                Thread.Sleep(1000);
                return SafeMoveFile(s1, s2, tries + 1, OverwriteIfExists, DeleteOriginal);
                }
            }
        #endregion
        #region WaitForFileUnlock
        public static void WaitForFileUnlock(string FullPath, int MaxWait)
            {
            const int Wait = 100;

            while (true)
                {
                try
                    {
                    FileStream fs = new FileStream(FullPath, FileMode.Open, FileAccess.ReadWrite);
                    fs.Close();
                    return;
                    }
                catch (Exception e)
                    {
                    if (MaxWait < Wait)
                        throw new Exception(FullPath, e);

                    MaxWait -= Wait;
                    Thread.Sleep(Wait);
                    }
                }
            }

        #endregion
        #endregion

        #region Constants
        public static event EventHandler BufferedMove_Progress;


        public static Func<byte[], char[]> _ByteArrayToCharArray = L.F<byte[], char[]>().Case(null, new char[] { })
            .Else(L.F<byte[], Func<byte, char>, char[]>(ListExt.Convert).Supply2(Convert.ToChar));


        public static Func<string, string> File_CleanFileName = L.Def.StringExt.RemoveChars.Surround2(Path.GetInvalidFileNameChars);

        public const FileMode DEFAULTFILEMODE = FileMode.Open;
        public const FileAccess DEFAULTFILEACCESS = FileAccess.Read;
        public const FileShare DEFAULTFILESHARE = FileShare.ReadWrite | FileShare.Delete;
        public static bool LOCKFILES = false;

        public static HashAlgorithm HashAlgorithm => new MD5CryptoServiceProvider();

        #endregion
        }
    public partial class Logic
        {
        /* TODO: L: File: Comment All Below */

        #region Constants
        public const char COMBINEPATHSDEFAULTSEPARATOR = '\\';
        public static string CombinePaths(params string[] Path)
            {
            if (Path == null)
                {
                throw new ArgumentNullException(nameof(Path));
                }
            return CombinePaths(COMBINEPATHSDEFAULTSEPARATOR, Path);
            }
        public static string CombinePaths(char Separator, params string[] Path)
            {
            if (Path == null)
                {
                throw new ArgumentNullException(nameof(Path));
                }

            string Out = Path.CollectStr<string, string[]>((i, s) =>
            {
                if (!s.IsEmpty())
                    {
                    string s2 = "";
                    if (i != 0)
                        {
                        s2 += Separator;
                        }
                    s2 += Path[i];
                    return s2;
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

        public static Func<string, byte[]> GetFileContents = FileName =>
        {
            FileStream s = FileName.GetFileStream();
            return FileExt.GetFileContents(s, (int)s.Length, 0);
        };
        #endregion
        }
    }