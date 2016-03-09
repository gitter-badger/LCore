using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCore.Statistics
    {
    public abstract class SampleSet
        {
        /// <summary>
        /// PopulationSize defaults to the SampleSize unless specified.
        /// </summary>
        public long PopulationSize { get; protected set; }

        public long SampleSize { get; protected set; }

        public virtual Boolean IsSample
            {
            get
                {
                return PopulationSize != SampleSize;
                }
            }
        }
    }
