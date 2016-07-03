// PathFilter.cs
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
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace ICSharpCode.SharpZipLib.Core
    {
    /// <summary>
    /// PathFilter filters directories and files using a form of <see cref="System.Text.RegularExpressions.Regex">regular expressions</see>
    /// by full path name.
    /// See <see cref="NameFilter">NameFilter</see> for more detail on filtering.
    /// </summary>
    public class PathFilter : IScanFilter
        {
        #region Constructors
        /// <summary>
        /// Initialise a new instance of <see cref="PathFilter"></see>.
        /// </summary>
        /// <param name="filter">The <see cref="NameFilter">filter</see> expression to apply.</param>
        public PathFilter(string filter)
            {
            this.nameFilter_ = new NameFilter(filter);
            }
        #endregion

        #region IScanFilter Members
        /// <summary>
        /// Test a name to see if it matches the filter.
        /// </summary>
        /// <param name="name">The name to test.</param>
        /// <returns>True if the name matches, false otherwise.</returns>
        /// <remarks><see cref="Path.GetFullPath(string)"/> is used to get the full path before matching.</remarks>
        public virtual bool IsMatch(string name)
            {
            bool result = false;

            if (name != null)
                {
                string cooked = name.Length > 0 ? Path.GetFullPath(name) : "";
                result = this.nameFilter_.IsMatch(cooked);
                }
            return result;
            }
        #endregion

        #region Instance Fields

        private NameFilter nameFilter_;
        #endregion
        }

    /// <summary>
    /// ExtendedPathFilter filters based on name, file size, and the last write time of the file.
    /// </summary>
    /// <remarks>Provides an example of how to customise filtering.</remarks>
    public class ExtendedPathFilter : PathFilter
        {
        #region Constructors
        /// <summary>
        /// Initialise a new instance of ExtendedPathFilter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <param name="minSize">The minimum file size to include.</param>
        /// <param name="maxSize">The maximum file size to include.</param>
        public ExtendedPathFilter(string filter,
            long minSize, long maxSize)
            : base(filter)
            {
            this.MinSize = minSize;
            this.MaxSize = maxSize;
            }

        /// <summary>
        /// Initialise a new instance of ExtendedPathFilter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <param name="minDate">The minimum <see cref="DateTime"/> to include.</param>
        /// <param name="maxDate">The maximum <see cref="DateTime"/> to include.</param>
        public ExtendedPathFilter(string filter,
            DateTime minDate, DateTime maxDate)
            : base(filter)
            {
            this.MinDate = minDate;
            this.MaxDate = maxDate;
            }

        /// <summary>
        /// Initialise a new instance of ExtendedPathFilter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <param name="minSize">The minimum file size to include.</param>
        /// <param name="maxSize">The maximum file size to include.</param>
        /// <param name="minDate">The minimum <see cref="DateTime"/> to include.</param>
        /// <param name="maxDate">The maximum <see cref="DateTime"/> to include.</param>
        public ExtendedPathFilter(string filter,
            long minSize, long maxSize,
            DateTime minDate, DateTime maxDate)
            : base(filter)
            {
            this.MinSize = minSize;
            this.MaxSize = maxSize;
            this.MinDate = minDate;
            this.MaxDate = maxDate;
            }
        #endregion

        #region IScanFilter Members
        /// <summary>
        /// Test a filename to see if it matches the filter.
        /// </summary>
        /// <param name="name">The filename to test.</param>
        /// <returns>True if the filter matches, false otherwise.</returns>
        /// <exception cref="System.IO.FileNotFoundException">The <see paramref="fileName"/> doesnt exist</exception>
        public override bool IsMatch(string name)
            {
            bool result = base.IsMatch(name);

            if (result)
                {
                var fileInfo = new FileInfo(name);
                result =
                    (this.MinSize <= fileInfo.Length) &&
                    (this.MaxSize >= fileInfo.Length) &&
                    (this.MinDate <= fileInfo.LastWriteTime) &&
                    (this.MaxDate >= fileInfo.LastWriteTime)
                    ;
                }
            return result;
            }
        #endregion

        #region Properties
        /// <summary>
        /// Get/set the minimum size/length for a file that will match this filter.
        /// </summary>
        /// <remarks>The default value is zero.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">value is less than zero; greater than <see cref="MaxSize"/></exception>
        public long MinSize
            {
            get { return this.minSize_; }
            set
                {
                if ((value < 0) || (this.maxSize_ < value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.minSize_ = value;
                }
            }

        /// <summary>
        /// Get/set the maximum size/length for a file that will match this filter.
        /// </summary>
        /// <remarks>The default value is <see cref="T:long.MaxValue"/></remarks>
        /// <exception cref="ArgumentOutOfRangeException">value is less than zero or less than <see cref="MinSize"/></exception>
        public long MaxSize
            {
            get { return this.maxSize_; }
            set
                {
                if ((value < 0) || (this.minSize_ > value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.maxSize_ = value;
                }
            }

        /// <summary>
        /// Get/set the minimum <see cref="DateTime"/> value that will match for this filter.
        /// </summary>
        /// <remarks>Files with a LastWrite time less than this value are excluded by the filter.</remarks>
        public DateTime MinDate
            {
            get
                {
                return this.minDate_;
                }

            set
                {
                if (value > this.maxDate_)
                    {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
                    throw new ArgumentOutOfRangeException(nameof(value), "Exceeds MaxDate");
#endif
                    }

                this.minDate_ = value;
                }
            }

        /// <summary>
        /// Get/set the maximum <see cref="DateTime"/> value that will match for this filter.
        /// </summary>
        /// <remarks>Files with a LastWrite time greater than this value are excluded by the filter.</remarks>
        public DateTime MaxDate
            {
            get
                {
                return this.maxDate_;
                }

            set
                {
                if (this.minDate_ > value)
                    {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
                    throw new ArgumentOutOfRangeException(nameof(value), "Exceeds MinDate");
#endif
                    }

                this.maxDate_ = value;
                }
            }
        #endregion

        #region Instance Fields

        private long minSize_;
        private long maxSize_ = long.MaxValue;
        private DateTime minDate_ = DateTime.MinValue;
        private DateTime maxDate_ = DateTime.MaxValue;
        #endregion
        }

    /// <summary>
    /// NameAndSizeFilter filters based on name and file size.
    /// </summary>
    /// <remarks>A sample showing how filters might be extended.</remarks>
    [Obsolete("Use ExtendedPathFilter instead")]
    public class NameAndSizeFilter : PathFilter
        {

        /// <summary>
        /// Initialise a new instance of NameAndSizeFilter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <param name="minSize">The minimum file size to include.</param>
        /// <param name="maxSize">The maximum file size to include.</param>
        public NameAndSizeFilter(string filter, long minSize, long maxSize)
            : base(filter)
            {
            this.MinSize = minSize;
            this.MaxSize = maxSize;
            }

        /// <summary>
        /// Test a filename to see if it matches the filter.
        /// </summary>
        /// <param name="name">The filename to test.</param>
        /// <returns>True if the filter matches, false otherwise.</returns>
        public override bool IsMatch(string name)
            {
            bool result = base.IsMatch(name);

            if (result)
                {
                var fileInfo = new FileInfo(name);
                long length = fileInfo.Length;
                result =
                    (this.MinSize <= length) &&
                    (this.MaxSize >= length);
                }
            return result;
            }

        /// <summary>
        /// Get/set the minimum size for a file that will match this filter.
        /// </summary>
        public long MinSize
            {
            get { return this.minSize_; }
            set
                {
                if ((value < 0) || (this.maxSize_ < value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.minSize_ = value;
                }
            }

        /// <summary>
        /// Get/set the maximum size for a file that will match this filter.
        /// </summary>
        public long MaxSize
            {
            get { return this.maxSize_; }
            set
                {
                if ((value < 0) || (this.minSize_ > value))
                    {
                    throw new ArgumentOutOfRangeException(nameof(value));
                    }

                this.maxSize_ = value;
                }
            }

        #region Instance Fields

        private long minSize_;
        private long maxSize_ = long.MaxValue;
        #endregion
        }
    }
