using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LCore
	{
	public class Lists<T1, T2>
		{
		private List<T1> _List1;
		private List<T2> _List2;

		public ReadOnlyCollection<T1> List1
			{
			get
				{
				return _List1.AsReadOnly();
				}
			}
		public ReadOnlyCollection<T2> List2
			{
			get
				{
				return _List2.AsReadOnly();
				}
			}

		public int Count
			{
			get { return List1.Count; }
			}
		public void Add(T1 o1, T2 o2)
			{
			_List1.Add(o1);
			_List2.Add(o2);
			}
		public void Set(int Index, T1 Value, T2 Value2)
			{
			Set(Index, Value);
			Set(Index, Value2);
			}
		public void Set(int Index, T1 Value)
			{
			_List1[Index] = Value;
			}
		public void Set(int Index, T2 Value)
			{
			_List2[Index] = Value;
			}

		public Lists()
			: this(new List<T1>(), new List<T2>())
			{
			}
		public Lists(List<T1> List1, List<T2> List2)
			{
			if (List1 == null)
				throw new ArgumentNullException("List1");
			if (List2 == null)
				throw new ArgumentNullException("List2");
			if (List1.Count != List2.Count)
				throw new ArgumentException("List counts did not match");

			this._List1 = List1;
			this._List2 = List2;
			}
		}
	}