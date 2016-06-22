using System;
using System.Collections;
using Microsoft.Win32;

namespace LCore.Tools
    {
    /// <summary>
    /// Handles saving and loading Strings, int, booleans, and ArrayLists to the registry.
    /// All unhandled exceptions are Formed. Safe class.
    /// </summary>
    [Serializable]
    public class RegistryHandler
        {
        #region Public Variables
        internal class RegistryException : Exception
            {
            public RegistryException(Exception e)
                : base("A registry exception occurred", e)
                {
                }
            }
        internal class ArrayLoadException : Exception
            {
            public ArrayLoadException(Exception e)
                : base("Array Failed to load", e)
                {
                }
            }
        #endregion

        #region Private Variables

        private readonly RegistryKey Key;
        #endregion

        #region Constuctors
        public enum RegistryType { CurrentUser, LocalMachine }

        /// <summary>
        /// Creates a new RegistryHandler under the provided key.
        /// </summary>
        /// <exception cref="System.NullReferenceException">System.NullReferenceException</exception>
        /// <exception cref="RegistryHandler.RegistryException">RegistryHandler.RegistryException</exception>
        /// <param name="RegistrySubKey">Cannot be null</param>
        /// <param name="RootKey"></param>
        public RegistryHandler(string RegistrySubKey, RegistryKey RootKey)
            {
            if (RegistrySubKey == null)
                throw new NullReferenceException(nameof(RegistrySubKey));

            try
                {
                this.Key = RootKey.OpenSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                try
                    {
                    System.Security.AccessControl.RegistrySecurity r = RootKey.GetAccessControl();
                    r.AddAccessRule(new System.Security.AccessControl.RegistryAccessRule("Everyone", System.Security.AccessControl.RegistryRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
                    RootKey.SetAccessControl(r);
                    RootKey.Flush();
                    }
                catch { }
                }
            catch (Exception)
                {
                try
                    {
                    /*
                    System.Security.AccessControl.RegistrySecurity r = RootKey.GetAccessControl();
                    string s = "";
                    foreach (System.Security.AccessControl.AuthorizationRule o in r.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
                        {
                        s += "---\n";
                        s += $"{o.GetType().FullName}\n";
                        s += $"{o.IdentityReference.Value}\n";
                        s += $"{o.InheritanceFlags.ToString()}\n";
                        s += $"Inherited: {o.IsInherited.ToString()}\n";
                        s += $"{o.PropagationFlags.ToString()}\n";
                        s += $"{o.ToString()}\n";
                        }

                    // No showing this detailed data any more. No longer needed.
                    //throw new Exception(s);
                    //Key = RootKey.OpenSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    */
                    }
                catch (Exception)
                    {
                    //throw e2;
                    }
                }

            if (this.Key == null)
                {
                try
                    {
                    RootKey.CreateSubKey(RegistrySubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    this.Key = RootKey.OpenSubKey(RegistrySubKey, true);
                    }
                catch (Exception e)
                    {
                    throw new RegistryException(e);
                    }
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// The type of object in question
        /// </summary>
        [Serializable]
        public enum ObjType { Long, Int, String, Boolean, StringAry, ArrayList }
        /// <summary>
        /// Loads the requested item from the registry. If an array, the length 
        /// must be specified as the value of key [Name]Count.
        /// </summary>
        /// <exception cref="RegistryHandler.ArrayLoadException">RegistryHandler.ArrayLoadException</exception>
        /// <exception cref="RegistryHandler.RegistryException">RegistryHandler.RegistryException</exception>
        /// <param name="Name">The name of the registry key</param>
        /// <param name="ItemType">The Type of variable</param>
        /// <returns>Returns the item requested. If the item is not found, returns null.</returns>
        public object Load(string Name, ObjType ItemType)
            {
            if (Name == null)
                throw new ArgumentNullException();

            try
                {
                if (ItemType == ObjType.ArrayList)
                    {
                    int count = Convert.ToInt32(this.Key.GetValue($"{Name}Count"));

                    ArrayList Item = new ArrayList(count);
                    for (int i = 0; i < count; i++)
                        {
                        Item.Add(this.Key.GetValue(Name + i));
                        }
                    return Item;
                    }
                if (ItemType == ObjType.StringAry)
                    {
                    int count = Convert.ToInt32(this.Key.GetValue($"{Name}Count"));

                    string[] Item = new string[count];
                    for (int i = 0; i < count; i++)
                        {
                        Item[i] = this.Key.GetValue(Name + i).ToString();
                        }
                    return Item;
                    }
                object Value = this.Key.GetValue(Name);
                if (Value != null)
                    {
                    if (ItemType == ObjType.Int)
                        {
                        int Item = Convert.ToInt32(Value);
                        return Item;
                        }
                    if (ItemType == ObjType.Long)
                        {
                        long Item = Convert.ToInt64(Value);
                        return Item;
                        }
                    if (ItemType == ObjType.String)
                        {
                        string Item = Value.ToString();
                        return Item;
                        }
                    if (ItemType == ObjType.Boolean)
                        {
                        bool Item = Convert.ToBoolean(Value);
                        return Item;
                        }
                    }
                }
            catch (Exception e)
                {
                throw new Exception(Name, e);
                }
            return null;
            }

        public object[] LoadAll()
            {
            string[] Names = this.Key.GetValueNames();

            object[] Out = new object[Names.Length];

            for (int i = 0; i < Names.Length; i++)
                {
                Out[i] = this.Load(Names[i], ObjType.String);
                }
            return Out;
            }

        /// <summary>
        /// Stores an item in the registry. Supports integers, strings, characters,
        /// and ArrayLists.
        /// </summary>
        /// <exception cref="System.NullReferenceException">System.NullReferenceException</exception>
        /// <exception cref="RegistryHandler.RegistryException">RegistryHandler.RegistryException</exception>
        /// <param name="Name">The name of the key used to store the item</param>
        /// <param name="Item">The item to save using Item.ToString()</param>
        public void Save(string Name, object Item)
            {
            this.Save(Name, Item, 0);
            }
        /// <summary>
        /// Saves an ArrayList to the registry, starting from index Start
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">System.IndexOutOfRangeException</exception>
        /// <exception cref="System.NullReferenceException">System.NullReferenceException</exception>
        /// <exception cref="RegistryHandler.RegistryException">RegistryHandler.RegistryException</exception>
        /// <param name="Name">Registry key</param>
        /// <param name="Item">The List</param>
        /// <param name="Start">Index to start from. Must be less than the length of the ArrayList.</param>	
        public void Save(string Name, ArrayList Item, int Start)
            {
            this.Save(Name, (object)Item, Start);
            }
        #endregion

        #region Private Methods
        /// <summary>
        /// Saves an ArrayList to the registry, starting from index Start
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">System.IndexOutOfRangeException</exception>
        /// <exception cref="System.NullReferenceException">System.NullReferenceException</exception>
        /// <exception cref="RegistryHandler.RegistryException">RegistryHandler.RegistryException</exception>
        /// <param name="Name">Registry key</param>
        /// <param name="Item">The List</param>
        /// <param name="Start">Index to start from</param>	
        private void Save(string Name, object Item, int Start)
            {
            if (Item == null)
                Item = "";

            ArrayList list = Item as ArrayList;
            if (list != null && Start > list.Count && Start != 0)
                throw new IndexOutOfRangeException();
            if (Name == null)
                throw new NullReferenceException();
            try
                {
                if (list != null)
                    {
                    this.Key.SetValue($"{Name}Count", list.Count);

                    for (int i = Start; i < list.Count; i++)
                        {
                        string Value = null;
                        byte[] Value2 = null;

                        byte[] bytes = list[i] as byte[];
                        if (bytes != null)
                            Value2 = bytes;
                        else
                            Value = list[i].ToString();


                        if (list[i] is byte[])
                            this.Key.SetValue(Name + i, Value2, RegistryValueKind.Binary);
                        else
                            this.Key.SetValue(Name + i, Value);
                        }
                    }
                else if (Item is string[])
                    {
                    this.Key.SetValue($"{Name}Count", ((string[])Item).Length);

                    for (int i = Start; i < ((string[])Item).Length; i++)
                        {
                        this.Key.SetValue(Name + i, ((string[])Item)[i]);
                        }
                    }
                else
                    {
                    this.Key.SetValue(Name, Item);
                    }
                }
            catch (Exception e)
                {
                throw new Exception(Name, e);
                }

            }
        #endregion
        }
    public interface IRegistry
        {
        void RegistrySave(RegistryHandler MyRegistry);
        void RegistryLoad(RegistryHandler MyRegistry);
        }
    }