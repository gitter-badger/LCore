using System;
using System.Collections;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable InconsistentNaming

namespace NSort
    {
    /// <summary>
    /// Abstract base class for Swap sort algorithms.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class serves as a base class for swap based sort algorithms.
    /// </para>
    /// </remarks>

    public abstract class SwapSorter : ISorter
        {
        private IComparer _Comparer;
        private ISwap _Swapper;

        protected SwapSorter()
            {
            this._Comparer = new ComparableComparer();
            this._Swapper = new DefaultSwap();
            }

        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="swapper"/> is <see langword="null" />.</exception>
        protected SwapSorter(IComparer comparer, ISwap swapper)
            {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            if (swapper == null)
                throw new ArgumentNullException(nameof(swapper));

            this._Comparer = comparer;
            this._Swapper = swapper;
            }

        /// <summary>
        /// Gets or sets the <see cref="IComparer"/> object
        /// </summary>
        /// <value>
        /// Comparer object
        /// </value>
        /// <exception cref="NullReferenceException" accessor="set">comparer is null</exception>
        public IComparer Comparer
            {
            get
                {
                return this._Comparer;
                }
            set
                {
                if (value == null)
                    throw new NullReferenceException(nameof(this._Comparer));
                this._Comparer = value;
                }
            }

        /// <summary>
        /// Gets or set the swapper object
        /// </summary>
        /// <value>
        /// The <see cref="ISwap"/> swapper.
        /// </value>
        /// <exception cref="NullReferenceException" accessor="set">swapper is null</exception>
        public ISwap Swapper
            {
            get
                {
                return this._Swapper;
                }
            set
                {
                if (value == null)
                    throw new NullReferenceException(nameof(this._Swapper));
                this._Swapper = value;
                }
            }

        public abstract void Sort(IList list);
        }
    }
