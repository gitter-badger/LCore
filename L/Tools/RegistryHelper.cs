using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
using Microsoft.Win32;
using Enumerable = System.Linq.Enumerable;

#pragma warning disable 1591

namespace LCore.Tools
    {
    using System.IO;
    using System.Security;

    /// <summary>
    /// Handles saving and loading Strings, int, booleans, and IEnumerables to the registry.
    /// All unhandled exceptions are Formed. Safe class.
    /// </summary>
    public class RegistryHelper
        {
        protected readonly RegistryKey Key;

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="System.IO.IOException">A system error occurred; for example, the current key has been deleted.</exception>
        public void RemoveAll()
            {
            this.Remove(this.Key.GetValueNames());
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="System.IO.IOException">A system error occurred; for example, the current key has been deleted.</exception>
        public void Remove(params string[] Names)
            {
            foreach (string Name in Names)
                {
                if (this.Key.GetValueNames().Has(Name))
                    this.Key.DeleteValue(Name);
                }
            }

        /// <exception cref="ArgumentNullException"><paramref name="Obj"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="Name"/> cannot be null or empty.</exception>
        /// <exception cref="UnauthorizedAccessException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is read-only, and cannot be written to; for example, the key has not been opened with write access. -or-The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows Millennium Edition or Windows 98.</exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to create or modify registry keys. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows 2000, Windows XP, or Windows Server 2003.</exception>
        public void Save(string Name, object Obj)
            {
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(Name));
            if (Obj == null) throw new ArgumentNullException(nameof(Obj));

            if (Obj is string)
                this.Save(Name, (string)Obj);
            else if (Obj is IConvertible)
                this.Save(Name, (IConvertible)Obj);
            else if (Obj is IEnumerable<object>)
                this.Save(Name, (IEnumerable<object>)Obj);
            else if (Obj is byte[])
                this.Save(Name, (byte[])Obj);
            else
                throw new ArgumentException($"Unknown type: {Obj.GetType().FullName}", nameof(Obj));
            }

        /// <exception cref="ArgumentNullException"><paramref name="Name" /> is null. </exception>
        /// <exception cref="UnauthorizedAccessException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is read-only, and cannot be written to; for example, the key has not been opened with write access. -or-The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows Millennium Edition or Windows 98.</exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to create or modify registry keys. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows 2000, Windows XP, or Windows Server 2003.</exception>
        public void Save(string Name, string Str)
            {
            this.Key.SetValue(Name, Str);
            }

        /// <exception cref="ArgumentNullException"><paramref name="Obj" /> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="Obj" /> is an unsupported data type. </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="UnauthorizedAccessException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is read-only, and cannot be written to; for example, the key has not been opened with write access. -or-The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows Millennium Edition or Windows 98.</exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to create or modify registry keys. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows 2000, Windows XP, or Windows Server 2003.</exception>
        public void Save(string Name, IConvertible Obj)
            {
            this.Key.SetValue(Name, Obj.ConvertToString());
            }

        /// <exception cref="ArgumentNullException"><paramref name="List" /> is null. </exception>
        /// <exception cref="ArgumentException">The type of <paramref name="List" /> did not match the registry data type specified by <paramref>
        ///         <name>valueKind</name>
        ///     </paramref>
        ///     , therefore the data could not be converted properly. </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="UnauthorizedAccessException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is read-only, and cannot be written to; for example, the key has not been opened with write access.-or-The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows Millennium Edition or Windows 98. </exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to create or modify registry keys. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows 2000, Windows XP, or Windows Server 2003.</exception>
        public void Save(string Name, byte[] List)
            {
            this.Key.SetValue(Name, List, RegistryValueKind.Binary);
            }

        /// <exception cref="ArgumentNullException"><paramref name="List" /> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="List" /> is an unsupported data type. </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="UnauthorizedAccessException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is read-only, and cannot be written to; for example, the key has not been opened with write access. -or-The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows Millennium Edition or Windows 98.</exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to create or modify registry keys. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> object represents a root-level node, and the operating system is Windows 2000, Windows XP, or Windows Server 2003.</exception>
        public void Save(string Name, IEnumerable<object> List)
            {
            uint Count = List.Count();

            this.Key.SetValue($"{Name}_Count", Count);

            List.Each((i, Item) => this.Save($"{Name}_{i}", Item));
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public object LoadObject(string Name)
            {
            return this.Key.GetValue(Name);
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public string LoadString(string Name)
            {
            return (string)this.Key.GetValue(Name);
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public int? LoadInt(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<int>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public long? LoadLong(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<long>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public float? LoadFloat(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<float>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public double? LoadDouble(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<double>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public char? LoadChar(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<char>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        public bool? LoadBool(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<bool>();
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        public byte[] LoadBinary(string Name)
            {
            return (byte[])this.Key.GetValue(Name);
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="IOException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value has been marked for deletion. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="FormatException">Count registry value is not properly set</exception>
        /// <exception cref="InvalidCastException">Count registry value is not properly set</exception>
        /// <exception cref="OverflowException">Count registry value is not properly set</exception>
        public List<object> LoadList(string Name)
            {
            int Count = Convert.ToInt32(this.Key.GetValue($"{Name}_Count"));

            var Items = new List<object>();

            for (int Index = 0; Index < Count; Index++)
                {
                Items.Add(this.Key.GetValue($"{Name}_{Index}"));
                }

            return Items;
            }

        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="IOException">A system error occurred; for example, the current key has been deleted.</exception>
        public List<Set<string, object>> LoadAll()
            {
            string[] Names = this.Key.GetValueNames();

            Names.Sort();

            return Enumerable.ToList(
                Enumerable.Select(Names,
                T => new Set<string, object>(T, this.LoadObject(T))));
            }

        /// <summary>
        /// Creates a new RegistryHandler under the provided key.
        /// </summary>
        /// <param name="RegistrySubKey">Cannot be null</param>
        /// <param name="RootKey"></param>
        /// <exception cref="InvalidOperationException">Could not open registry key</exception>
        /// <exception cref="ArgumentException">Value cannot be null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="RootKey"/> is <see langword="null" />.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to read the registry key. </exception>
        public RegistryHelper(string RegistrySubKey, RegistryKey RootKey)
            {
            if (string.IsNullOrEmpty(RegistrySubKey))
                throw new ArgumentException("Value cannot be null or empty.", nameof(RegistrySubKey));
            if (RootKey == null)
                throw new ArgumentNullException(nameof(RootKey));

            this.Key = RootKey.OpenSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (this.Key == null)
                {
                var Control = RootKey.GetAccessControl();
                Control.AddAccessRule(new System.Security.AccessControl.RegistryAccessRule("Everyone",
                    System.Security.AccessControl.RegistryRights.FullControl,
                    System.Security.AccessControl.AccessControlType.Allow));

                RootKey.SetAccessControl(Control);
                RootKey.Flush();

                RootKey.CreateSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

                this.Key = RootKey.OpenSubKey(RegistrySubKey, true);


                return;
                }

            if (this.Key == null)
                throw new InvalidOperationException($"Could not open registry key: {this.Key}");

            }
        /*
                internal class RegistryException : Exception
                    {
                    public RegistryException(Exception e)
                        : base("A registry exception occurred", e)
                        {
                        }
                    }*/
        }
    public interface IRegistry
        {
        void RegistrySave(RegistryHelper MyRegistry);
        void RegistryLoad(RegistryHelper MyRegistry);
        }
    }