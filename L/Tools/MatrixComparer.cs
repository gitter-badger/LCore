using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using System.IO;

namespace LCore.Tools
	{
	public class MatrixComparer : ComparableComparer
		{
		public new int Compare(IComparable x, IComparable y)
			{
			return base.Compare(x, y);
			}
		}
	}