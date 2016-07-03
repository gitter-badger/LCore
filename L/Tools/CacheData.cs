using LCore.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// Stores function result and execution time data used from L caching methods.
    /// </summary>
    public class CacheData
        {
        /// <summary>
        /// Data from method results
        /// </summary>
        public readonly object Data;

        /// <summary>
        /// The original execution length for this particular method cache
        /// </summary>
        public readonly long OriginalTimeMS;

        private readonly List<long> TimeTakenMS = new List<long>();

        /// <summary>
        /// Adds a value of time to the cache
        /// </summary>
        public void AddTime(long Time)
            {
            this.TimeTakenMS.Add(Time);
            }

        /// <summary>
        /// Creates a new CacheData object from a method result.
        /// </summary>
        public CacheData(object Data, long OriginalTimeMS)
            {
            this.Data = Data;
            this.OriginalTimeMS = OriginalTimeMS;
            }

        /// <summary>
        /// Estimates the total CPU time saved by this cache.
        /// </summary>
        public long TotalTimeSaved => this.OriginalTimeMS - (long)this.TimeTakenMS.Average();

        /// <summary>
        /// Estimates the percentage of time saved vs. used by this cache.
        /// </summary>
        public float PercentSaved => (float)1 - (float)(this.TimeTakenMS.Average() / this.OriginalTimeMS);
        }
    }