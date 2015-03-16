using System;
using LCore;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;
using System.Security.AccessControl;
using Microsoft.Win32.SafeHandles;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas
        #region Byte
        public static Func<Byte> Byte_GetMaxValue = () => { return Byte.MaxValue; };
        public static Func<Byte> Byte_GetMinValue = () => { return Byte.MinValue; };
        public static Func<Byte, Int32> Byte_GetHashCode = (b) => { return b.GetHashCode(); };
        public static Func<Byte, String, IFormatProvider, String> Byte_ToString = (b, format, provider) => { return b.ToString(format, provider); };
        public static Func<Byte, Object, Int32> Byte_CompareTo = (b, value) => { return b.CompareTo(value); };
        public static Func<Byte, Byte, Int32> Byte_CompareTo2 = (b, value) => { return b.CompareTo(value); };
        public static Func<Byte, Object, Boolean> Byte_Equals = (b, obj) => { return b.Equals(obj); };
        public static Func<Byte, Byte, Boolean> Byte_Equals2 = (b, obj) => { return b.Equals(obj); };
        public static Func<String, Byte> Byte_Parse = (s) => { return Byte.Parse(s); };
        public static Func<String, NumberStyles, Byte> Byte_Parse2 = (s, style) => { return Byte.Parse(s, style); };
        public static Func<String, IFormatProvider, Byte> Byte_Parse3 = (s, provider) => { return Byte.Parse(s, provider); };
        public static Func<String, NumberStyles, IFormatProvider, Byte> Byte_Parse4 = (s, style, provider) => { return Byte.Parse(s, style, provider); };
        /* No Ref or Out Types 
        public static Func<String, Byte&, Boolean> Byte_TryParse = (s, result) => { return Byte.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Byte&, Boolean> Byte_TryParse2 = (s, style, provider, result) => { return Byte.TryParse(s, style, provider, result); };
        */
        public static Func<Byte, String> Byte_ToString2 = (b) => { return b.ToString(); };
        public static Func<Byte, String, String> Byte_ToString3 = (b, format) => { return b.ToString(format); };
        public static Func<Byte, IFormatProvider, String> Byte_ToString4 = (b, provider) => { return b.ToString(provider); };
        public static Func<Byte, TypeCode> Byte_GetTypeCode = (b) => { return b.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion

        #region File
        public static Func<String, StreamReader> File_OpenText = (path) => { return File.OpenText(path); };
        public static Func<String, StreamWriter> File_CreateText = (path) => { return File.CreateText(path); };
        public static Func<String, StreamWriter> File_AppendText = (path) => { return File.AppendText(path); };
        public static Action<String, String> File_Copy = (sourceFileName, destFileName) => { File.Copy(sourceFileName, destFileName); };
        public static Action<String, String, Boolean> File_Copy2 = (sourceFileName, destFileName, overwrite) => { File.Copy(sourceFileName, destFileName, overwrite); };
        public static Func<String, FileStream> File_Create = (path) => { return File.Create(path); };
        public static Func<String, Int32, FileStream> File_Create2 = (path, bufferSize) => { return File.Create(path, bufferSize); };
        /* Missing in Mono
        public static Func<String, Int32, FileOptions, FileStream> File_Create3 = (path, bufferSize, options) => { return File.Create(path, bufferSize, options); };
        public static Func<String, Int32, FileOptions, FileSecurity, FileStream> File_Create4 = (path, bufferSize, options, fileSecurity) => { return File.Create(path, bufferSize, options, fileSecurity); };
        public static Action<String> File_Decrypt = (path) => { File.Decrypt(path); };
        public static Action<String> File_Encrypt = (path) => { File.Encrypt(path); };
        public static Action<String, String, String, Boolean> File_Replace2 = (sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors) => { File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors); };
        public static Func<String, FileSecurity> File_GetAccessControl = (path) => { return File.GetAccessControl(path); };
        public static Func<String, AccessControlSections, FileSecurity> File_GetAccessControl2 = (path, includeSections) => { return File.GetAccessControl(path, includeSections); };
        public static Action<String, FileSecurity> File_SetAccessControl = (path, fileSecurity) => { File.SetAccessControl(path, fileSecurity); };
        public static Func<FileInfo, Boolean> FileInfo_GetIsReadOnly = (f) => { return f.IsReadOnly; };
        public static Action<FileInfo, Boolean> FileInfo_SetIsReadOnly = (f, b) => { f.IsReadOnly = b; };
        public static Action<String, String, String> File_Replace = (sourceFileName, destinationFileName, destinationBackupFileName) => { File.Replace(sourceFileName, destinationFileName, destinationBackupFileName); };
        */
        public static Action<String> File_Delete = (path) => { File.Delete(path); };
        public static Func<String, Boolean> File_Exists = (path) => { return File.Exists(path); };
        public static Func<String, FileMode, FileStream> File_Open = (path, mode) => { return File.Open(path, mode); };
        public static Func<String, FileMode, FileAccess, FileStream> File_Open2 = (path, mode, access) => { return File.Open(path, mode, access); };
        public static Func<String, FileMode, FileAccess, FileShare, FileStream> File_Open3 = (path, mode, access, share) => { return File.Open(path, mode, access, share); };
        public static Action<String, DateTime> File_SetCreationTime = (path, creationTime) => { File.SetCreationTime(path, creationTime); };
        public static Action<String, DateTime> File_SetCreationTimeUtc = (path, creationTimeUtc) => { File.SetCreationTimeUtc(path, creationTimeUtc); };
        public static Func<String, DateTime> File_GetCreationTime = (path) => { return File.GetCreationTime(path); };
        public static Func<String, DateTime> File_GetCreationTimeUtc = (path) => { return File.GetCreationTimeUtc(path); };
        public static Action<String, DateTime> File_SetLastAccessTime = (path, lastAccessTime) => { File.SetLastAccessTime(path, lastAccessTime); };
        public static Action<String, DateTime> File_SetLastAccessTimeUtc = (path, lastAccessTimeUtc) => { File.SetLastAccessTimeUtc(path, lastAccessTimeUtc); };
        public static Func<String, DateTime> File_GetLastAccessTime = (path) => { return File.GetLastAccessTime(path); };
        public static Func<String, DateTime> File_GetLastAccessTimeUtc = (path) => { return File.GetLastAccessTimeUtc(path); };
        public static Action<String, DateTime> File_SetLastWriteTime = (path, lastWriteTime) => { File.SetLastWriteTime(path, lastWriteTime); };
        public static Action<String, DateTime> File_SetLastWriteTimeUtc = (path, lastWriteTimeUtc) => { File.SetLastWriteTimeUtc(path, lastWriteTimeUtc); };
        public static Func<String, DateTime> File_GetLastWriteTime = (path) => { return File.GetLastWriteTime(path); };
        public static Func<String, DateTime> File_GetLastWriteTimeUtc = (path) => { return File.GetLastWriteTimeUtc(path); };
        public static Func<String, FileAttributes> File_GetAttributes = (path) => { return File.GetAttributes(path); };
        public static Action<String, FileAttributes> File_SetAttributes = (path, fileAttributes) => { File.SetAttributes(path, fileAttributes); };
        public static Func<String, FileStream> File_OpenRead = (path) => { return File.OpenRead(path); };
        public static Func<String, FileStream> File_OpenWrite = (path) => { return File.OpenWrite(path); };
        public static Func<String, String> File_ReadAllText = (path) => { return File.ReadAllText(path); };
        public static Func<String, Encoding, String> File_ReadAllText2 = (path, encoding) => { return File.ReadAllText(path, encoding); };
        public static Action<String, String> File_WriteAllText = (path, contents) => { File.WriteAllText(path, contents); };
        public static Action<String, String, Encoding> File_WriteAllText2 = (path, contents, encoding) => { File.WriteAllText(path, contents, encoding); };
        public static Func<String, Byte[]> File_ReadAllBytes = (path) => { return File.ReadAllBytes(path); };
        public static Action<String, Byte[]> File_WriteAllBytes = (path, bytes) => { File.WriteAllBytes(path, bytes); };
        public static Func<String, String[]> File_ReadAllLines = (path) => { return File.ReadAllLines(path); };
        public static Func<String, Encoding, String[]> File_ReadAllLines2 = (path, encoding) => { return File.ReadAllLines(path, encoding); };
        /* No Generic Types 
        public static Func<String, IEnumerable`1> File_ReadLines = (path) => { return File.ReadLines(path); };
        */
        /* No Generic Types 
        public static Func<String, Encoding, IEnumerable`1> File_ReadLines = (path, encoding) => { return File.ReadLines(path, encoding); };
        */
        public static Action<String, String[]> File_WriteAllLines = (path, contents) => { File.WriteAllLines(path, contents); };
        public static Action<String, String[], Encoding> File_WriteAllLines2 = (path, contents, encoding) => { File.WriteAllLines(path, contents, encoding); };
        /* No Generic Types 
        public static Action<String, IEnumerable`1> File_WriteAllLines = (path, contents) => {File.WriteAllLines(path, contents); };
        */
        /* No Generic Types 
        public static Action<String, IEnumerable`1, Encoding> File_WriteAllLines = (path, contents, encoding) => {File.WriteAllLines(path, contents, encoding); };
        */
        public static Action<String, String> File_AppendAllText = (path, contents) => { File.AppendAllText(path, contents); };
        public static Action<String, String, Encoding> File_AppendAllText2 = (path, contents, encoding) => { File.AppendAllText(path, contents, encoding); };
        /* No Generic Types 
        public static Action<String, IEnumerable`1> File_AppendAllLines = (path, contents) => {File.AppendAllLines(path, contents); };
        */
        /* No Generic Types 
        public static Action<String, IEnumerable`1, Encoding> File_AppendAllLines = (path, contents, encoding) => {File.AppendAllLines(path, contents, encoding); };
        */
        public static Action<String, String> File_Move = (sourceFileName, destFileName) => { File.Move(sourceFileName, destFileName); };
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region FileInfo
        public static Func<FileInfo, String> FileInfo_GetName = (f) => { return f.Name; };
        public static Func<FileInfo, Int64> FileInfo_GetLength = (f) => { return f.Length; };
        public static Func<FileInfo, String> FileInfo_GetDirectoryName = (f) => { return f.DirectoryName; };
        public static Func<FileInfo, DirectoryInfo> FileInfo_GetDirectory = (f) => { return f.Directory; };
        public static Func<FileInfo, Boolean> FileInfo_GetExists = (f) => { return f.Exists; };
        public static Func<FileSystemInfo, String> FileSystemInfo_GetFullName = (f) => { return f.FullName; };
        public static Func<FileSystemInfo, String> FileSystemInfo_GetExtension = (f) => { return f.Extension; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetCreationTime = (f) => { return f.CreationTime; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetCreationTime = (f, d) => { f.CreationTime = d; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetCreationTimeUtc = (f) => { return f.CreationTimeUtc; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetCreationTimeUtc = (f, d) => { f.CreationTimeUtc = d; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetLastAccessTime = (f) => { return f.LastAccessTime; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetLastAccessTime = (f, d) => { f.LastAccessTime = d; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetLastAccessTimeUtc = (f) => { return f.LastAccessTimeUtc; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetLastAccessTimeUtc = (f, d) => { f.LastAccessTimeUtc = d; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetLastWriteTime = (f) => { return f.LastWriteTime; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetLastWriteTime = (f, d) => { f.LastWriteTime = d; };
        public static Func<FileSystemInfo, DateTime> FileSystemInfo_GetLastWriteTimeUtc = (f) => { return f.LastWriteTimeUtc; };
        public static Action<FileSystemInfo, DateTime> FileSystemInfo_SetLastWriteTimeUtc = (f, d) => { f.LastWriteTimeUtc = d; };
        public static Func<FileSystemInfo, FileAttributes> FileSystemInfo_GetAttributes = (f) => { return f.Attributes; };
        public static Action<FileSystemInfo, FileAttributes> FileSystemInfo_SetAttributes = (f, f2) => { f.Attributes = f2; };
        public static Func<FileInfo, StreamReader> FileInfo_OpenText = (f) => { return f.OpenText(); };
        public static Func<FileInfo, StreamWriter> FileInfo_CreateText = (f) => { return f.CreateText(); };
        public static Func<FileInfo, StreamWriter> FileInfo_AppendText = (f) => { return f.AppendText(); };
        public static Func<FileInfo, String, FileInfo> FileInfo_CopyTo = (f, destFileName) => { return f.CopyTo(destFileName); };
        public static Func<FileInfo, String, Boolean, FileInfo> FileInfo_CopyTo2 = (f, destFileName, overwrite) => { return f.CopyTo(destFileName, overwrite); };
        public static Func<FileInfo, FileStream> FileInfo_Create = (f) => { return f.Create(); };
        public static Action<FileInfo> FileInfo_Delete = (f) => { f.Delete(); };
        /* Missing in Mono
        public static Func<FileInfo, FileSecurity> FileInfo_GetAccessControl = (f) => { return f.GetAccessControl(); };
        public static Func<FileInfo, AccessControlSections, FileSecurity> FileInfo_GetAccessControl2 = (f, includeSections) => { return f.GetAccessControl(includeSections); };
        public static Action<FileInfo, FileSecurity> FileInfo_SetAccessControl = (f, fileSecurity) => { f.SetAccessControl(fileSecurity); };
        public static Action<FileInfo> FileInfo_Decrypt = (f) => { f.Decrypt(); };
        public static Action<FileInfo> FileInfo_Encrypt = (f) => { f.Encrypt(); };
        public static Func<FileInfo, String, String, Boolean, FileInfo> FileInfo_Replace2 = (f, destinationFileName, destinationBackupFileName, ignoreMetadataErrors) => { return f.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors); };
        public static Func<FileInfo, String, String, FileInfo> FileInfo_Replace = (f, destinationFileName, destinationBackupFileName) => { return f.Replace(destinationFileName, destinationBackupFileName); };
         */
        public static Func<FileInfo, FileMode, FileStream> FileInfo_Open = (f, mode) => { return f.Open(mode); };
        public static Func<FileInfo, FileMode, FileAccess, FileStream> FileInfo_Open2 = (f, mode, access) => { return f.Open(mode, access); };
        public static Func<FileInfo, FileMode, FileAccess, FileShare, FileStream> FileInfo_Open3 = (f, mode, access, share) => { return f.Open(mode, access, share); };
        public static Func<FileInfo, FileStream> FileInfo_OpenRead = (f) => { return f.OpenRead(); };
        public static Func<FileInfo, FileStream> FileInfo_OpenWrite = (f) => { return f.OpenWrite(); };
        public static Action<FileInfo, String> FileInfo_MoveTo = (f, destFileName) => { f.MoveTo(destFileName); };
        public static Func<FileInfo, String> FileInfo_ToString = (f) => { return f.ToString(); };
        /* Method found on base type 
        public static Action<FileSystemInfo> FileSystemInfo_Refresh = (f) => {f.Refresh(); };
        */
        /* Method found on base type 
        public static Action<FileSystemInfo, SerializationInfo, StreamingContext> FileSystemInfo_GetObjectData = (f, info, context) => {f.GetObjectData(info, context); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_GetLifetimeService = (m) => { return m.GetLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_InitializeLifetimeService = (m) => { return m.InitializeLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Type, ObjRef> MarshalByRefObject_CreateObjRef = (m, requestedType) => { return m.CreateObjRef(requestedType); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<String, FileInfo> FileInfo_New = (fileName) => { return new FileInfo(fileName); };
        #endregion
        #region Directory
        public static Func<String, DirectoryInfo> Directory_GetParent = (path) => { return Directory.GetParent(path); };
        public static Func<String, DirectoryInfo> Directory_CreateDirectory = (path) => { return Directory.CreateDirectory(path); };
        /* Missing in Mono
        public static Func<String, DirectorySecurity, DirectoryInfo> Directory_CreateDirectory2 = (path, directorySecurity) => { return Directory.CreateDirectory(path, directorySecurity); };
        public static Func<String, DirectorySecurity> Directory_GetAccessControl = (path) => { return Directory.GetAccessControl(path); };
        public static Func<String, AccessControlSections, DirectorySecurity> Directory_GetAccessControl2 = (path, includeSections) => { return Directory.GetAccessControl(path, includeSections); };
        public static Action<String, DirectorySecurity> Directory_SetAccessControl = (path, directorySecurity) => { Directory.SetAccessControl(path, directorySecurity); };
         */
        public static Func<String, Boolean> Directory_Exists = (path) => { return Directory.Exists(path); };
        public static Action<String, DateTime> Directory_SetCreationTime = (path, creationTime) => { Directory.SetCreationTime(path, creationTime); };
        public static Action<String, DateTime> Directory_SetCreationTimeUtc = (path, creationTimeUtc) => { Directory.SetCreationTimeUtc(path, creationTimeUtc); };
        public static Func<String, DateTime> Directory_GetCreationTime = (path) => { return Directory.GetCreationTime(path); };
        public static Func<String, DateTime> Directory_GetCreationTimeUtc = (path) => { return Directory.GetCreationTimeUtc(path); };
        public static Action<String, DateTime> Directory_SetLastWriteTime = (path, lastWriteTime) => { Directory.SetLastWriteTime(path, lastWriteTime); };
        public static Action<String, DateTime> Directory_SetLastWriteTimeUtc = (path, lastWriteTimeUtc) => { Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc); };
        public static Func<String, DateTime> Directory_GetLastWriteTime = (path) => { return Directory.GetLastWriteTime(path); };
        public static Func<String, DateTime> Directory_GetLastWriteTimeUtc = (path) => { return Directory.GetLastWriteTimeUtc(path); };
        public static Action<String, DateTime> Directory_SetLastAccessTime = (path, lastAccessTime) => { Directory.SetLastAccessTime(path, lastAccessTime); };
        public static Action<String, DateTime> Directory_SetLastAccessTimeUtc = (path, lastAccessTimeUtc) => { Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc); };
        public static Func<String, DateTime> Directory_GetLastAccessTime = (path) => { return Directory.GetLastAccessTime(path); };
        public static Func<String, DateTime> Directory_GetLastAccessTimeUtc = (path) => { return Directory.GetLastAccessTimeUtc(path); };
        public static Func<String, String[]> Directory_GetFiles = (path) => { return Directory.GetFiles(path); };
        public static Func<String, String, String[]> Directory_GetFiles2 = (path, searchPattern) => { return Directory.GetFiles(path, searchPattern); };
        public static Func<String, String, SearchOption, String[]> Directory_GetFiles3 = (path, searchPattern, searchOption) => { return Directory.GetFiles(path, searchPattern, searchOption); };
        public static Func<String, String[]> Directory_GetDirectories = (path) => { return Directory.GetDirectories(path); };
        public static Func<String, String, String[]> Directory_GetDirectories2 = (path, searchPattern) => { return Directory.GetDirectories(path, searchPattern); };
        public static Func<String, String, SearchOption, String[]> Directory_GetDirectories3 = (path, searchPattern, searchOption) => { return Directory.GetDirectories(path, searchPattern, searchOption); };
        public static Func<String, String[]> Directory_GetFileSystemEntries = (path) => { return Directory.GetFileSystemEntries(path); };
        public static Func<String, String, String[]> Directory_GetFileSystemEntries2 = (path, searchPattern) => { return Directory.GetFileSystemEntries(path, searchPattern); };
        public static Func<String, String, SearchOption, String[]> Directory_GetFileSystemEntries3 = (path, searchPattern, searchOption) => { return Directory.GetFileSystemEntries(path, searchPattern, searchOption); };
        /* No Generic Types 
        public static Func<String, IEnumerable`1> Directory_EnumerateDirectories = (path) => { return Directory.EnumerateDirectories(path); };
        */
        /* No Generic Types 
        public static Func<String, String, IEnumerable`1> Directory_EnumerateDirectories = (path, searchPattern) => { return Directory.EnumerateDirectories(path, searchPattern); };
        */
        /* No Generic Types 
        public static Func<String, String, SearchOption, IEnumerable`1> Directory_EnumerateDirectories = (path, searchPattern, searchOption) => { return Directory.EnumerateDirectories(path, searchPattern, searchOption); };
        */
        /* No Generic Types 
        public static Func<String, IEnumerable`1> Directory_EnumerateFiles = (path) => { return Directory.EnumerateFiles(path); };
        */
        /* No Generic Types 
        public static Func<String, String, IEnumerable`1> Directory_EnumerateFiles = (path, searchPattern) => { return Directory.EnumerateFiles(path, searchPattern); };
        */
        /* No Generic Types 
        public static Func<String, String, SearchOption, IEnumerable`1> Directory_EnumerateFiles = (path, searchPattern, searchOption) => { return Directory.EnumerateFiles(path, searchPattern, searchOption); };
        */
        /* No Generic Types 
        public static Func<String, IEnumerable`1> Directory_EnumerateFileSystemEntries = (path) => { return Directory.EnumerateFileSystemEntries(path); };
        */
        /* No Generic Types 
        public static Func<String, String, IEnumerable`1> Directory_EnumerateFileSystemEntries = (path, searchPattern) => { return Directory.EnumerateFileSystemEntries(path, searchPattern); };
        */
        /* No Generic Types 
        public static Func<String, String, SearchOption, IEnumerable`1> Directory_EnumerateFileSystemEntries = (path, searchPattern, searchOption) => { return Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption); };
        */
        public static Func<String[]> Directory_GetLogicalDrives = () => { return Directory.GetLogicalDrives(); };
        public static Func<String, String> Directory_GetDirectoryRoot = (path) => { return Directory.GetDirectoryRoot(path); };
        public static Func<String> Directory_GetCurrentDirectory = () => { return Directory.GetCurrentDirectory(); };
        public static Action<String> Directory_SetCurrentDirectory = (path) => { Directory.SetCurrentDirectory(path); };
        public static Action<String, String> Directory_Move = (sourceDirName, destDirName) => { Directory.Move(sourceDirName, destDirName); };
        public static Action<String> Directory_Delete = (path) => { Directory.Delete(path); };
        public static Action<String, Boolean> Directory_Delete2 = (path, recursive) => { Directory.Delete(path, recursive); };
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region Path
        public static Func<Char> Path_GetDirectorySeparatorChar = () => { return Path.DirectorySeparatorChar; };
        public static Func<Char> Path_GetAltDirectorySeparatorChar = () => { return Path.AltDirectorySeparatorChar; };
        public static Func<Char> Path_GetVolumeSeparatorChar = () => { return Path.VolumeSeparatorChar; };
        public static Func<Char[]> Path_GetInvalidPathChars = () => { return Path.InvalidPathChars; };
        public static Func<Char> Path_GetPathSeparator = () => { return Path.PathSeparator; };
        public static Func<String, String, String> Path_ChangeExtension = (path, extension) => { return Path.ChangeExtension(path, extension); };
        public static Func<String, String> Path_GetDirectoryName = (path) => { return Path.GetDirectoryName(path); };
        public static Func<Char[]> Path_GetInvalidPathChars2 = () => { return Path.GetInvalidPathChars(); };
        public static Func<Char[]> Path_GetInvalidFileNameChars = () => { return Path.GetInvalidFileNameChars(); };
        public static Func<String, String> Path_GetExtension = (path) => { return Path.GetExtension(path); };
        public static Func<String, String> Path_GetFullPath = (path) => { return Path.GetFullPath(path); };
        public static Func<String, String> Path_GetFileName = (path) => { return Path.GetFileName(path); };
        public static Func<String, String> Path_GetFileNameWithoutExtension = (path) => { return Path.GetFileNameWithoutExtension(path); };
        public static Func<String, String> Path_GetPathRoot = (path) => { return Path.GetPathRoot(path); };
        public static Func<String> Path_GetTempPath = () => { return Path.GetTempPath(); };
        public static Func<String> Path_GetRandomFileName = () => { return Path.GetRandomFileName(); };
        public static Func<String> Path_GetTempFileName = () => { return Path.GetTempFileName(); };
        public static Func<String, Boolean> Path_HasExtension = (path) => { return Path.HasExtension(path); };
        public static Func<String, Boolean> Path_IsPathRooted = (path) => { return Path.IsPathRooted(path); };
        public static Func<String, String, String> Path_Combine = (path1, path2) => { return Path.Combine(path1, path2); };
        public static Func<String, String, String, String> Path_Combine2 = (path1, path2, path3) => { return Path.Combine(path1, path2, path3); };
        public static Func<String, String, String, String, String> Path_Combine3 = (path1, path2, path3, path4) => { return Path.Combine(path1, path2, path3, path4); };
        public static Func<String[], String> Path_Combine4 = (paths) => { return Path.Combine(paths); };
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region DirectoryInfo
        public static Func<DirectoryInfo, String> DirectoryInfo_GetName = (d) => { return d.Name; };
        public static Func<DirectoryInfo, DirectoryInfo> DirectoryInfo_GetParent = (d) => { return d.Parent; };
        public static Func<DirectoryInfo, Boolean> DirectoryInfo_GetExists = (d) => { return d.Exists; };
        public static Func<DirectoryInfo, DirectoryInfo> DirectoryInfo_GetRoot = (d) => { return d.Root; };
        public static Action<DirectoryInfo> DirectoryInfo_Create = (d) => { d.Create(); };
        public static Func<DirectoryInfo, String, FileInfo[]> DirectoryInfo_GetFiles = (d, searchPattern) => { return d.GetFiles(searchPattern); };
        public static Func<DirectoryInfo, FileInfo[]> DirectoryInfo_GetFiles2 = (d) => { return d.GetFiles(); };
        public static Func<DirectoryInfo, DirectoryInfo[]> DirectoryInfo_GetDirectories = (d) => { return d.GetDirectories(); };

        public static Func<DirectoryInfo, String, DirectoryInfo> DirectoryInfo_CreateSubdirectory = (d, path) => { return d.CreateSubdirectory(path); };
        /* Missing in Mono
        public static Func<DirectoryInfo, String, DirectorySecurity, DirectoryInfo> DirectoryInfo_CreateSubdirectory2 = (d, path, directorySecurity) => { return d.CreateSubdirectory(path, directorySecurity); };
        public static Action<DirectoryInfo, DirectorySecurity> DirectoryInfo_Create2 = (d, directorySecurity) => { d.Create(directorySecurity); };
        public static Func<DirectoryInfo, DirectorySecurity> DirectoryInfo_GetAccessControl = (d) => { return d.GetAccessControl(); };
        public static Func<DirectoryInfo, AccessControlSections, DirectorySecurity> DirectoryInfo_GetAccessControl2 = (d, includeSections) => { return d.GetAccessControl(includeSections); };
        public static Action<DirectoryInfo, DirectorySecurity> DirectoryInfo_SetAccessControl = (d, directorySecurity) => { d.SetAccessControl(directorySecurity); };
        */
        public static Func<DirectoryInfo, String, SearchOption, FileInfo[]> DirectoryInfo_GetFiles3 = (d, searchPattern, searchOption) => { return d.GetFiles(searchPattern, searchOption); };
        public static Func<DirectoryInfo, String, FileSystemInfo[]> DirectoryInfo_GetFileSystemInfos = (d, searchPattern) => { return d.GetFileSystemInfos(searchPattern); };
        public static Func<DirectoryInfo, String, SearchOption, FileSystemInfo[]> DirectoryInfo_GetFileSystemInfos2 = (d, searchPattern, searchOption) => { return d.GetFileSystemInfos(searchPattern, searchOption); };
        public static Func<DirectoryInfo, FileSystemInfo[]> DirectoryInfo_GetFileSystemInfos3 = (d) => { return d.GetFileSystemInfos(); };
        public static Func<DirectoryInfo, String, DirectoryInfo[]> DirectoryInfo_GetDirectories2 = (d, searchPattern) => { return d.GetDirectories(searchPattern); };
        public static Func<DirectoryInfo, String, SearchOption, DirectoryInfo[]> DirectoryInfo_GetDirectories3 = (d, searchPattern, searchOption) => { return d.GetDirectories(searchPattern, searchOption); };
        /* No Generic Types 
        public static Func<DirectoryInfo, IEnumerable`1> DirectoryInfo_EnumerateDirectories = (d) => { return d.EnumerateDirectories(); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, IEnumerable`1> DirectoryInfo_EnumerateDirectories = (d, searchPattern) => { return d.EnumerateDirectories(searchPattern); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, SearchOption, IEnumerable`1> DirectoryInfo_EnumerateDirectories = (d, searchPattern, searchOption) => { return d.EnumerateDirectories(searchPattern, searchOption); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, IEnumerable`1> DirectoryInfo_EnumerateFiles = (d) => { return d.EnumerateFiles(); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, IEnumerable`1> DirectoryInfo_EnumerateFiles = (d, searchPattern) => { return d.EnumerateFiles(searchPattern); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, SearchOption, IEnumerable`1> DirectoryInfo_EnumerateFiles = (d, searchPattern, searchOption) => { return d.EnumerateFiles(searchPattern, searchOption); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, IEnumerable`1> DirectoryInfo_EnumerateFileSystemInfos = (d) => { return d.EnumerateFileSystemInfos(); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, IEnumerable`1> DirectoryInfo_EnumerateFileSystemInfos = (d, searchPattern) => { return d.EnumerateFileSystemInfos(searchPattern); };
        */
        /* No Generic Types 
        public static Func<DirectoryInfo, String, SearchOption, IEnumerable`1> DirectoryInfo_EnumerateFileSystemInfos = (d, searchPattern, searchOption) => { return d.EnumerateFileSystemInfos(searchPattern, searchOption); };
        */
        public static Action<DirectoryInfo, String> DirectoryInfo_MoveTo = (d, destDirName) => { d.MoveTo(destDirName); };
        public static Action<DirectoryInfo> DirectoryInfo_Delete = (d) => { d.Delete(); };
        public static Action<DirectoryInfo, Boolean> DirectoryInfo_Delete2 = (d, recursive) => { d.Delete(recursive); };
        public static Func<DirectoryInfo, String> DirectoryInfo_ToString = (d) => { return d.ToString(); };
        /* Method found on base type 
        public static Action<FileSystemInfo> FileSystemInfo_Refresh = (f) => {f.Refresh(); };
        */
        /* Method found on base type 
        public static Action<FileSystemInfo, SerializationInfo, StreamingContext> FileSystemInfo_GetObjectData = (f, info, context) => {f.GetObjectData(info, context); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_GetLifetimeService = (m) => { return m.GetLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_InitializeLifetimeService = (m) => { return m.InitializeLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Type, ObjRef> MarshalByRefObject_CreateObjRef = (m, requestedType) => { return m.CreateObjRef(requestedType); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<String, DirectoryInfo> DirectoryInfo_New = (path) => { return new DirectoryInfo(path); };
        #endregion
        #region DriveInfo
        public static Func<DriveInfo, String> DriveInfo_GetName = (d) => { return d.Name; };
        public static Func<DriveInfo, DriveType> DriveInfo_GetDriveType = (d) => { return d.DriveType; };
        public static Func<DriveInfo, String> DriveInfo_GetDriveFormat = (d) => { return d.DriveFormat; };
        /* Missing in Mono
        public static Func<DriveInfo, Boolean> DriveInfo_GetIsReady = (d) => { return d.IsReady; };
        public static Func<DriveInfo, String> DriveInfo_GetVolumeLabel = (d) => { return d.VolumeLabel; };
        public static Action<DriveInfo, String> DriveInfo_SetVolumeLabel = (d, s) => { d.VolumeLabel = s; };
        public static Func<DriveInfo[]> DriveInfo_GetDrives = () => { return DriveInfo.GetDrives(); };
         */
        public static Func<DriveInfo, Int64> DriveInfo_GetAvailableFreeSpace = (d) => { return d.AvailableFreeSpace; };
        public static Func<DriveInfo, Int64> DriveInfo_GetTotalFreeSpace = (d) => { return d.TotalFreeSpace; };
        public static Func<DriveInfo, Int64> DriveInfo_GetTotalSize = (d) => { return d.TotalSize; };
        public static Func<DriveInfo, DirectoryInfo> DriveInfo_GetRootDirectory = (d) => { return d.RootDirectory; };
        public static Func<DriveInfo, String> DriveInfo_ToString = (d) => { return d.ToString(); };
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<String, DriveInfo> DriveInfo_New = (driveName) => { return new DriveInfo(driveName); };
        #endregion
        #region FileStream
        public static Func<FileStream, Boolean> FileStream_GetCanRead = (f) => { return f.CanRead; };
        public static Func<FileStream, Boolean> FileStream_GetCanWrite = (f) => { return f.CanWrite; };
        public static Func<FileStream, Boolean> FileStream_GetCanSeek = (f) => { return f.CanSeek; };
        public static Func<FileStream, Boolean> FileStream_GetIsAsync = (f) => { return f.IsAsync; };
        public static Func<FileStream, Int64> FileStream_GetLength = (f) => { return f.Length; };
        public static Func<FileStream, String> FileStream_GetName = (f) => { return f.Name; };
        public static Func<FileStream, Int64> FileStream_GetPosition = (f) => { return f.Position; };
        public static Action<FileStream, Int64> FileStream_SetPosition = (f, i) => { f.Position = i; };
        public static Func<FileStream, IntPtr> FileStream_GetHandle = (f) => { return f.Handle; };
        public static Func<FileStream, SafeFileHandle> FileStream_GetSafeFileHandle = (f) => { return f.SafeFileHandle; };
        public static Action<FileStream> FileStream_Flush = (f) => { f.Flush(); };
        public static Action<FileStream, Boolean> FileStream_Flush2 = (f, flushToDisk) => { f.Flush(flushToDisk); };
        public static Action<FileStream, Int64> FileStream_SetLength = (f, value) => { f.SetLength(value); };
        public static Func<FileStream, Byte[], Int32, Int32, Int32> FileStream_Read = (f, array, offset, count) => { return f.Read(array, offset, count); };
        public static Func<FileStream, Int64, SeekOrigin, Int64> FileStream_Seek = (f, offset, origin) => { return f.Seek(offset, origin); };
        public static Action<FileStream, Byte[], Int32, Int32> FileStream_Write = (f, array, offset, count) => { f.Write(array, offset, count); };
        /* Too Many Parameters :( 
        public static Func<FileStream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> FileStream_BeginRead = (f, array, offset, numBytes, userCallback, stateObject) => { return f.BeginRead(array, offset, numBytes, userCallback, stateObject); };
        */
        public static Func<FileStream, IAsyncResult, Int32> FileStream_EndRead = (f, asyncResult) => { return f.EndRead(asyncResult); };
        public static Func<FileStream, Int32> FileStream_ReadByte = (f) => { return f.ReadByte(); };
        /* Too Many Parameters :( 
        public static Func<FileStream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> FileStream_BeginWrite = (f, array, offset, numBytes, userCallback, stateObject) => { return f.BeginWrite(array, offset, numBytes, userCallback, stateObject); };
        */
        public static Action<FileStream, IAsyncResult> FileStream_EndWrite = (f, asyncResult) => { f.EndWrite(asyncResult); };
        public static Action<FileStream, Byte> FileStream_WriteByte = (f, value) => { f.WriteByte(value); };
        public static Action<FileStream, Int64, Int64> FileStream_Lock = (f, position, length) => { f.Lock(position, length); };
        public static Action<FileStream, Int64, Int64> FileStream_Unlock = (f, position, length) => { f.Unlock(position, length); };
        /* Method found on base type 
        public static Action<Stream, Stream> Stream_CopyTo = (s, destination) => {s.CopyTo(destination); };
        */
        /* Method found on base type 
        public static Action<Stream, Stream, Int32> Stream_CopyTo = (s, destination, bufferSize) => {s.CopyTo(destination, bufferSize); };
        */
        /* Method found on base type 
        public static Action<Stream> Stream_Close = (s) => {s.Close(); };
        */
        /* Method found on base type 
        public static Action<Stream> Stream_Dispose = (s) => {s.Dispose(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_GetLifetimeService = (m) => { return m.GetLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_InitializeLifetimeService = (m) => { return m.InitializeLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Type, ObjRef> MarshalByRefObject_CreateObjRef = (m, requestedType) => { return m.CreateObjRef(requestedType); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<String, FileMode, FileStream> FileStream_New = (path, mode) => { return new FileStream(path, mode); };
        public static Func<String, FileMode, FileAccess, FileStream> FileStream_New2 = (path, mode, access) => { return new FileStream(path, mode, access); };
        public static Func<String, FileMode, FileAccess, FileShare, FileStream> FileStream_New3 = (path, mode, access, share) => { return new FileStream(path, mode, access, share); };
        /* Too Many Parameters :( 
        public static Func<String, FileMode, FileAccess, FileShare, Int32, FileStream> FileStream_New = (path, mode, access, share, bufferSize) => { return new FileStream(path, mode, access, share, bufferSize); };
        */
        /* Too Many Parameters :( 
        public static Func<String, FileMode, FileAccess, FileShare, Int32, FileOptions, FileStream> FileStream_New = (path, mode, access, share, bufferSize, options) => { return new FileStream(path, mode, access, share, bufferSize, options); };
        */
        /* Too Many Parameters :( 
        public static Func<String, FileMode, FileAccess, FileShare, Int32, Boolean, FileStream> FileStream_New = (path, mode, access, share, bufferSize, useAsync) => { return new FileStream(path, mode, access, share, bufferSize, useAsync); };
        */
        /* Too Many Parameters :( 
        public static Func<String, FileMode, FileSystemRights, FileShare, Int32, FileOptions, FileSecurity, FileStream> FileStream_New = (path, mode, rights, share, bufferSize, options, fileSecurity) => { return new FileStream(path, mode, rights, share, bufferSize, options, fileSecurity); };
        */
        /* Too Many Parameters :( 
        public static Func<String, FileMode, FileSystemRights, FileShare, Int32, FileOptions, FileStream> FileStream_New = (path, mode, rights, share, bufferSize, options) => { return new FileStream(path, mode, rights, share, bufferSize, options); };
        */
        public static Func<IntPtr, FileAccess, FileStream> FileStream_New4 = (handle, access) => { return new FileStream(handle, access); };
        public static Func<IntPtr, FileAccess, Boolean, FileStream> FileStream_New5 = (handle, access, ownsHandle) => { return new FileStream(handle, access, ownsHandle); };
        public static Func<IntPtr, FileAccess, Boolean, Int32, FileStream> FileStream_New6 = (handle, access, ownsHandle, bufferSize) => { return new FileStream(handle, access, ownsHandle, bufferSize); };
        /* Too Many Parameters :( 
        public static Func<IntPtr, FileAccess, Boolean, Int32, Boolean, FileStream> FileStream_New = (handle, access, ownsHandle, bufferSize, isAsync) => { return new FileStream(handle, access, ownsHandle, bufferSize, isAsync); };
        */
        /* Missing in Mono
        public static Func<FileStream, FileSecurity> FileStream_GetAccessControl = (f) => { return f.GetAccessControl(); };
        public static Action<FileStream, FileSecurity> FileStream_SetAccessControl = (f, fileSecurity) => { f.SetAccessControl(fileSecurity); };
        public static Func<SafeFileHandle, FileAccess, FileStream> FileStream_New7 = (handle, access) => { return new FileStream(handle, access); };
        public static Func<SafeFileHandle, FileAccess, Int32, FileStream> FileStream_New8 = (handle, access, bufferSize) => { return new FileStream(handle, access, bufferSize); };
        public static Func<SafeFileHandle, FileAccess, Int32, Boolean, FileStream> FileStream_New9 = (handle, access, bufferSize, isAsync) => { return new FileStream(handle, access, bufferSize, isAsync); };
         */
        #endregion
        #region Stream
        public static Func<Stream> Stream_GetNull = () => { return Stream.Null; };
        public static Func<Stream, Boolean> Stream_GetCanRead = (s) => { return s.CanRead; };
        public static Func<Stream, Boolean> Stream_GetCanSeek = (s) => { return s.CanSeek; };
        public static Func<Stream, Boolean> Stream_GetCanTimeout = (s) => { return s.CanTimeout; };
        public static Func<Stream, Boolean> Stream_GetCanWrite = (s) => { return s.CanWrite; };
        public static Func<Stream, Int64> Stream_GetLength = (s) => { return s.Length; };
        public static Func<Stream, Int64> Stream_GetPosition = (s) => { return s.Position; };
        public static Action<Stream, Int64> Stream_SetPosition = (s, i) => { s.Position = i; };
        public static Func<Stream, Int32> Stream_GetReadTimeout = (s) => { return s.ReadTimeout; };
        public static Action<Stream, Int32> Stream_SetReadTimeout = (s, i) => { s.ReadTimeout = i; };
        public static Func<Stream, Int32> Stream_GetWriteTimeout = (s) => { return s.WriteTimeout; };
        public static Action<Stream, Int32> Stream_SetWriteTimeout = (s, i) => { s.WriteTimeout = i; };
        public static Action<Stream, Stream> Stream_CopyTo = (s, destination) => { s.CopyTo(destination); };
        public static Action<Stream, Stream, Int32> Stream_CopyTo2 = (s, destination, bufferSize) => { s.CopyTo(destination, bufferSize); };
        public static Action<Stream> Stream_Close = (s) => { s.Close(); };
        public static Action<Stream> Stream_Dispose = (s) => { s.Dispose(); };
        public static Action<Stream> Stream_Flush = (s) => { s.Flush(); };
        /* Too Many Parameters :( 
        public static Func<Stream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> Stream_BeginRead = (s, buffer, offset, count, callback, state) => { return s.BeginRead(buffer, offset, count, callback, state); };
        */
        public static Func<Stream, IAsyncResult, Int32> Stream_EndRead = (s, asyncResult) => { return s.EndRead(asyncResult); };
        /* Too Many Parameters :( 
        public static Func<Stream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> Stream_BeginWrite = (s, buffer, offset, count, callback, state) => { return s.BeginWrite(buffer, offset, count, callback, state); };
        */
        public static Action<Stream, IAsyncResult> Stream_EndWrite = (s, asyncResult) => { s.EndWrite(asyncResult); };
        public static Func<Stream, Int64, SeekOrigin, Int64> Stream_Seek = (s, offset, origin) => { return s.Seek(offset, origin); };
        public static Action<Stream, Int64> Stream_SetLength = (s, value) => { s.SetLength(value); };
        public static Func<Stream, Byte[], Int32, Int32, Int32> Stream_Read = (s, buffer, offset, count) => { return s.Read(buffer, offset, count); };
        public static Func<Stream, Int32> Stream_ReadByte = (s) => { return s.ReadByte(); };
        public static Action<Stream, Byte[], Int32, Int32> Stream_Write = (s, buffer, offset, count) => { s.Write(buffer, offset, count); };
        public static Action<Stream, Byte> Stream_WriteByte = (s, value) => { s.WriteByte(value); };
        public static Func<Stream, Stream> Stream_Synchronized = (stream) => { return Stream.Synchronized(stream); };
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_GetLifetimeService = (m) => { return m.GetLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_InitializeLifetimeService = (m) => { return m.InitializeLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Type, ObjRef> MarshalByRefObject_CreateObjRef = (m, requestedType) => { return m.CreateObjRef(requestedType); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region BufferedStream
        public static Func<BufferedStream, Boolean> BufferedStream_GetCanRead = (b) => { return b.CanRead; };
        public static Func<BufferedStream, Boolean> BufferedStream_GetCanWrite = (b) => { return b.CanWrite; };
        public static Func<BufferedStream, Boolean> BufferedStream_GetCanSeek = (b) => { return b.CanSeek; };
        public static Func<BufferedStream, Int64> BufferedStream_GetLength = (b) => { return b.Length; };
        public static Func<BufferedStream, Int64> BufferedStream_GetPosition = (b) => { return b.Position; };
        public static Action<BufferedStream, Int64> BufferedStream_SetPosition = (b, i) => { b.Position = i; };
        public static Action<BufferedStream> BufferedStream_Flush = (b) => { b.Flush(); };
        public static Func<BufferedStream, Byte[], Int32, Int32, Int32> BufferedStream_Read = (b, array, offset, count) => { return b.Read(array, offset, count); };
        public static Func<BufferedStream, Int32> BufferedStream_ReadByte = (b) => { return b.ReadByte(); };
        public static Action<BufferedStream, Byte[], Int32, Int32> BufferedStream_Write = (b, array, offset, count) => { b.Write(array, offset, count); };
        public static Action<BufferedStream, Byte> BufferedStream_WriteByte = (b, value) => { b.WriteByte(value); };
        public static Func<BufferedStream, Int64, SeekOrigin, Int64> BufferedStream_Seek = (b, offset, origin) => { return b.Seek(offset, origin); };
        public static Action<BufferedStream, Int64> BufferedStream_SetLength = (b, value) => { b.SetLength(value); };
        /* Method found on base type 
        public static Action<Stream, Stream> Stream_CopyTo = (s, destination) => {s.CopyTo(destination); };
        */
        /* Method found on base type 
        public static Action<Stream, Stream, Int32> Stream_CopyTo = (s, destination, bufferSize) => {s.CopyTo(destination, bufferSize); };
        */
        /* Method found on base type 
        public static Action<Stream> Stream_Close = (s) => {s.Close(); };
        */
        /* Method found on base type 
        public static Action<Stream> Stream_Dispose = (s) => {s.Dispose(); };
        */
        /* Too Many Parameters :( 
        public static Func<Stream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> Stream_BeginRead = (s, buffer, offset, count, callback, state) => { return s.BeginRead(buffer, offset, count, callback, state); };
        */
        /* Method found on base type 
        public static Func<Stream, IAsyncResult, Int32> Stream_EndRead = (s, asyncResult) => { return s.EndRead(asyncResult); };
        */
        /* Too Many Parameters :( 
        public static Func<Stream, Byte[], Int32, Int32, AsyncCallback, Object, IAsyncResult> Stream_BeginWrite = (s, buffer, offset, count, callback, state) => { return s.BeginWrite(buffer, offset, count, callback, state); };
        */
        /* Method found on base type 
        public static Action<Stream, IAsyncResult> Stream_EndWrite = (s, asyncResult) => {s.EndWrite(asyncResult); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_GetLifetimeService = (m) => { return m.GetLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Object> MarshalByRefObject_InitializeLifetimeService = (m) => { return m.InitializeLifetimeService(); };
        */
        /* Method found on base type 
        public static Func<MarshalByRefObject, Type, ObjRef> MarshalByRefObject_CreateObjRef = (m, requestedType) => { return m.CreateObjRef(requestedType); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<Stream, BufferedStream> BufferedStream_New = (stream) => { return new BufferedStream(stream); };
        public static Func<Stream, Int32, BufferedStream> BufferedStream_New2 = (stream, bufferSize) => { return new BufferedStream(stream, bufferSize); };
        #endregion
        #endregion

        public const char COMBINEPATHSDEFAULTSEPARATOR = '\\';
        public static String CombinePaths(params String[] Path)
            {
            if (Path == null)
                {
                throw new ArgumentNullException("Path");
                }
            return CombinePaths(COMBINEPATHSDEFAULTSEPARATOR, Path);
            }
        public static String CombinePaths(char Separator, params String[] Path)
            {
            if (Path == null)
                {
                throw new ArgumentNullException("Path");
                }

            String Out = Path.CollectStr<String, String[]>((i, s) =>
            {
                if (!s.IsEmpty())
                    {
                    String s2 = "";
                    if (i != 0)
                        {
                        s2 += Separator;
                        }
                    s2 += Path[i];
                    return s2;
                    }
                return null;
            });

            Out = Out.Replace(Separator.ToString() + Separator.ToString(), Separator.ToString());
            Out = Out.Replace("http:/", "http://");
            Out = Out.Replace("https:/", "https://");

            // Fix for UNC paths
            if (Out.StartsWith("\\") && !Out.StartsWith("\\\\"))
                {
                Out = "\\" + Out;
                }

            return Out;
            }

        public static Func<String, Byte[]> GetFileContents = (FileName) =>
        {
            FileStream s = FileName.GetFileStream();
            return FileExt.GetFileContents(s, (int)s.Length, 0);
        };
        }
    public static class FileExt
        {
        public static void EnsurePathExists(this String Path)
            {
            String DirPath = Path;

            if (DirPath.Contains("\\"))
                DirPath = DirPath.Substring(0, DirPath.LastIndexOf("\\"));

            if (!Directory.Exists(DirPath))
                Directory.CreateDirectory(DirPath);
            }
        public static Boolean SafeCopyFile(String s1, String s2, int tries, Boolean OverwriteIfExists)
            {
            return SafeMoveFile(s1, s2, tries, OverwriteIfExists, false);
            }
        public static Boolean SafeMoveFile(String s1, String s2, int tries, Boolean OverwriteIfExists)
            {
            return SafeMoveFile(s1, s2, tries, OverwriteIfExists, true);
            }
        public static Boolean SafeMoveFile(String s1, String s2, int tries, Boolean OverwriteIfExists, Boolean DeleteOriginal)
            {
            try
                {
                EnsurePathExists(s2);

                if (OverwriteIfExists && File.Exists(s2))
                    File.Delete(s2);

                s1 = s1.Replace("\\\\", "\\");
                s2 = s2.Replace("\\\\", "\\");

                if (s1.StartsWith("\\"))
                    s1 = "\\" + s1;
                if (s2.StartsWith("\\"))
                    s2 = "\\" + s2;

                String Dir = s2.Substring(0, s2.LastIndexOf('\\'));

                if (!Directory.Exists(Dir))
                    Directory.CreateDirectory(Dir);

                try
                    {
                    if (System.IO.Path.GetPathRoot(s1) == System.IO.Path.GetPathRoot(s2))
                        {
                        File.Move(s1, s2);
                        return true;
                        }
                    else
                        {
                        throw new Exception();
                        }
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
                    throw new Exception("Could not move file '" + s1 + "' to destination '" + s2 + "'", e);
                    }

                Thread.Sleep(1000);
                return SafeMoveFile(s1, s2, tries + 1, OverwriteIfExists, DeleteOriginal);
                }
            }
        public static event EventHandler BufferedMove_Progress;
        public static void BufferedMove(String s1, String s2, Boolean DeleteOriginal)
            {
            FileStream f1 = new FileStream(s1, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream f2 = new FileStream(s2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            f2.Seek(0, SeekOrigin.Begin);
            f2.SetLength(f1.Length);

            int BufferSize = 128 * 1024;

            long TotalSize = f1.Length;
            long Index = 0;

            while (Index < TotalSize)
                {
                long ChunkSize = TotalSize - Index;

                if (ChunkSize > BufferSize)
                    ChunkSize = BufferSize;
                Byte[] Bytes = new Byte[ChunkSize];
                f1.Read(Bytes, 0, (int)ChunkSize);
                f2.Write(Bytes, 0, (int)ChunkSize);
                f2.Flush();
                Index += ChunkSize;
                if (BufferedMove_Progress != null)
                    {
                    BufferedMove_Progress(new long[] { Index, TotalSize }, null);
                    }
                }

            f2.Close();
            f1.Close();

            if (DeleteOriginal)
                File.Delete(s1);
            }

        public static Func<byte[], char[]> _ByteArrayToCharArray = L.F<byte[], char[]>().Case(null, new char[] { })
            .Else(L.F<byte[], Func<byte, char>, char[]>(ListExt.Convert<byte, char>).Supply2(System.Convert.ToChar));
        public static char[] ByteArrayToCharArray(byte[] In)
            {
            if (In == null)
                {
                return new char[0];
                }
            char[] Out = new char[In.Length];

            for (int i = 0; i < In.Length; i++)
                {
                Out[i] = System.Convert.ToChar(In[i]);
                }
            return Out;
            }
        public static Func<String, String> File_CleanFileName = L.String_RemoveChars.Surround2(System.IO.Path.GetInvalidFileNameChars);

        public static String CleanFileName(this String In)
            {
            return File_CleanFileName(In);
            }
        public static Byte[] EveryOtherByte(this Byte[] In)
            {
            Byte[] Out = new byte[In.Length / 2];
            for (int i = 0; i < Out.Length; i++)
                {
                Out[i] = In[i * 2];
                }
            return Out;
            }
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
            finally
                {
                }
            return memStream;
            }
        public static Boolean MatchesFileFilters(String[] FileFilter, String[] FileFilterExceptions, String[] GlobalDirFilterExceptions, String FullName)
            {
            if (FullName == null)
                throw new ArgumentNullException("FullName");

            String FileName = FullName;

            if (FileName.Contains("\\"))
                FileName = FileName.Substring(FileName.LastIndexOf('\\') + 1);

            return MatchesFileFilters(FileFilter, FileFilterExceptions, GlobalDirFilterExceptions, FullName, FileName);
            }

        public static Boolean MatchesFolderFilters(String[] DirFilterExceptions, String FolderName)
            {
            if (FolderName == null)
                throw new ArgumentNullException("FolderName");

            if (DirFilterExceptions != null)
                {
                foreach (String s in DirFilterExceptions)
                    {
                    if (s != "" && MatchesWildCard(FolderName, s))
                        {
                        return false;
                        }
                    }
                }
            return true;
            }
        public static Boolean MatchesWildCard(String In, String WildCard)
            {
            if (In == null)
                throw new ArgumentNullException("Compare String");
            if (WildCard == null)
                throw new ArgumentNullException("Wildcard");

            if (!WildCard.StartsWith("*"))
                WildCard = "*" + WildCard;

            while (WildCard.Contains("**") || WildCard.Contains("*?") || WildCard.Contains("?*"))
                {
                WildCard = WildCard.Replace("**", "*");
                WildCard = WildCard.Replace("*?", "*");
                WildCard = WildCard.Replace("?*", "*");
                }

            return MatchesWildCardLowerCase(In.ToLower(), WildCard.ToLower());
            }
        private static Boolean MatchesWildCardLowerCase(String In, String WildCard)
            {
            if (WildCard == "*")
                {
                return true;
                }
            else if (WildCard == "?" && In.Length == 1)
                {
                return true;
                }
            else if (WildCard == In)
                {
                return true;
                }
            else
                {
                if (WildCard.Length == 0)
                    {
                    return false;
                    }
                else if (WildCard[0] == '*')
                    {
                    if (In.Length > 1 || (In.Length > 0 && WildCard.Length > 1 && In[0] == WildCard[1]))
                        {
                        if (In[0] == WildCard[1])
                            {
                            return MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(2)) ||
                                    MatchesWildCardLowerCase(In.Substring(1), WildCard);
                            }
                        else if (In[1] == WildCard[1])
                            {
                            return MatchesWildCardLowerCase(In.Substring(2), WildCard.Substring(2)) ||
                                    MatchesWildCardLowerCase(In.Substring(2), WildCard); ;
                            }
                        else
                            return MatchesWildCardLowerCase(In.Substring(1), WildCard);
                        }
                    else
                        {
                        return false;
                        }
                    }
                else if (WildCard[0] == '?')
                    {
                    return MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(1));
                    }
                else
                    {
                    return (In.Length != 0 && WildCard[0] == In[0] && MatchesWildCardLowerCase(In.Substring(1), WildCard.Substring(1)));
                    }
                }
            }
        private static Boolean MatchesFileFilters(String[] FileFilter, String[] FileFilterExceptions, String[] GlobalDirFilterExceptions, String FullName, String FileName)
            {
            if (FileFilter == null || FileFilter.Length == 0)
                FileFilter = new String[] { "*.*" };

            Boolean Found = false;

            foreach (String s in FileFilter)
                {
                String Test = s;
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
                foreach (String s in FileFilterExceptions)
                    {
                    String s2 = s;
                    if (s2 != null && s2.Trim() != "" && !s2.StartsWith("*"))
                        s2 = "*" + s2;
                    if (s2 != "" && MatchesWildCard(FileName, s2))
                        {
                        return false;
                        }
                    }
                }
            if (Found && GlobalDirFilterExceptions != null)
                {
                foreach (String s in GlobalDirFilterExceptions)
                    {
                    if (s != "" && MatchesWildCard(FullName, s))
                        {
                        return false;
                        }
                    }
                }
            return Found;
            }

        public static void WaitForFileUnlock(String FullPath, int MaxWait)
            {
            int Wait = 100;

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
        public const FileMode DEFAULTFILEMODE = FileMode.Open;
        public const FileAccess DEFAULTFILEACCESS = FileAccess.Read;
        public const FileShare DEFAULTFILESHARE = FileShare.ReadWrite | FileShare.Delete;
        public static Boolean LOCKFILES = false;
        public static FileStream GetFileStream(this String FullPath)
            {
            try { return new FileStream(FullPath, DEFAULTFILEMODE, DEFAULTFILEACCESS, DEFAULTFILESHARE); }
            catch { return null; }
            }

        public static HashAlgorithm HashAlgorithm { get { return new MD5CryptoServiceProvider(); } }
        public static Byte[] GetFileContents(FileStream F, int MaxSize, int PartNum)
            {
            if (F == null)
                throw new ArgumentNullException("FileStream");

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
                MaxSize = (int)F.Length - (PartNum * MaxSize);
                }

            if (StartPos > F.Length || MaxSize < 0)
                throw new ArgumentException("PartNum: " + PartNum);

            int tries = 0;
            Byte[] Contents = null;
            while (tries < 2)
                {
                try
                    {
                    Contents = new Byte[MaxSize];
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
                    System.Threading.Thread.Sleep(200);
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
		public static Byte[] GetFileHash(this String FullPath)
            {
            if (FullPath == null)
                throw new ArgumentNullException("FullPath");
            if (!File.Exists(FullPath))
                throw new FileNotFoundException(FullPath);

			return GetStreamHash(GetStringStream(FullPath));
            }

		public static Byte[] GetStringHash(this String In)
			{
			return GetStreamHash(GetStringStream(In));
			}
        public static Byte[] GetStreamHash(this Stream InputStream)
            {
            if (InputStream == null)
                throw new ArgumentNullException("InputStream");

            Byte[] Hash = HashAlgorithm.ComputeHash(InputStream);
            try { InputStream.Close(); }
            catch { }
            return Hash;
            }
        public static Stream GetStringStream(this String In)
            {
            return new MemoryStream(In.ToByteArray());
            }
        }
    }