using System;
using System.Diagnostics.CodeAnalysis;

namespace LCore.Statistics
    {
    [ExcludeFromCodeCoverage]
    internal abstract class SampleSet
        {
        /// <summary>
        /// PopulationSize defaults to the SampleSize unless specified.
        /// </summary>
        public long PopulationSize { get; protected set; }

        public long SampleSize { get; protected set; }

        public virtual bool IsSample => this.PopulationSize != this.SampleSize;
        }
    }
