using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
using Microsoft.Win32;
using Enumerable = System.Linq.Enumerable;

#pragma warning disable 1591

namespace LCore.Tools
    {
    /// <summary>
    /// Handles saving and loading Strings, int, booleans, and IEnumerables to the registry.
    /// All unhandled exceptions are Formed. Safe class.
    /// </summary>
    public class RegistryHelper
        {
        public enum RegistryType { CurrentUser, LocalMachine }

        protected readonly RegistryKey Key;

        public void RemoveAll()
            {
            this.Remove(this.Key.GetValueNames());
            }

        public void Remove(params string[] Names)
            {
            foreach (string Name in Names)
                {
                if (this.Key.GetValueNames().Has(Name))
                    this.Key.DeleteValue(Name);
                }
            }

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
        public void Save(string Name, string Str)
            {
            this.Key.SetValue(Name, Str);
            }
        public void Save(string Name, IConvertible Obj)
            {
            this.Key.SetValue(Name, Obj.ConvertTo<string>());
            }
        public void Save(string Name, byte[] List)
            {
            this.Key.SetValue(Name, List, RegistryValueKind.Binary);
            }
        public void Save(string Name, IEnumerable<object> List)
            {
            int Count = List.Count();

            this.Key.SetValue($"{Name}_Count", Count);

            List.Each((i, Item) => this.Save($"{Name}_{i}", Item));
            }

        public object LoadObject(string Name)
            {
            return this.Key.GetValue(Name);
            }
        public string LoadString(string Name)
            {
            return (string)this.Key.GetValue(Name);
            }
        public int? LoadInt(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<int>();
            }
        public long? LoadLong(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<long>();
            }
        public float? LoadFloat(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<float>();
            }
        public double? LoadDouble(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<double>();
            }
        public char? LoadChar(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<char>();
            }
        public bool? LoadBool(string Name)
            {
            return this.Key.GetValue(Name)?.ToString().ConvertTo<bool>();
            }
        public byte[] LoadBinary(string Name)
            {
            return (byte[])this.Key.GetValue(Name);
            }
        public List<object> LoadList(string Name)
            {
            int Count = Convert.ToInt32(this.Key.GetValue($"{Name}_Count"));

            var Items = new List<object>();

            for (int i = 0; i < Count; i++)
                {
                Items.Add(this.Key.GetValue($"{Name}_{i}"));
                }

            return Items;
            }

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
        /// <exception cref="System.NullReferenceException">System.NullReferenceException</exception>
        /// <param name="RegistrySubKey">Cannot be null</param>
        /// <param name="RootKey"></param>
        public RegistryHelper(string RegistrySubKey, RegistryKey RootKey)
            {
            if (string.IsNullOrEmpty(RegistrySubKey))
                throw new ArgumentException("Value cannot be null or empty.", nameof(RegistrySubKey));
            if (RootKey == null)
                throw new ArgumentNullException(nameof(RootKey));

            this.Key = RootKey.OpenSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (this.Key == null)
                throw new Exception($"Could not open registry key: {this.Key}");

            /*
                        if (this.Key == null)
                            {
                            try
                                {
                                var r = RootKey.GetAccessControl();
                                r.AddAccessRule(new System.Security.AccessControl.RegistryAccessRule("Everyone",
                                    System.Security.AccessControl.RegistryRights.FullControl,
                                    System.Security.AccessControl.AccessControlType.Allow));
                                RootKey.SetAccessControl(r);
                                RootKey.Flush();

                                RootKey.CreateSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

                                this.Key = RootKey.OpenSubKey(RegistrySubKey, true);
                                }
                            catch (Exception e)
                                {
                                throw new RegistryException(e);
                                }
                            return;
                            }*/
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