using LCore.Extensions;
using System;
using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// Class used to provide structured Method Profile times 
    /// for the Profile extension method.
    /// </summary>
    public class MethodProfileData
        {
        /// <summary>
        /// The collection of execution times for the method.
        /// </summary>
        public List<TimeSpan> Times { get; } = new List<TimeSpan>();

        /// <summary>
        /// The data cached.
        /// </summary>
        public object Data;

        /// <summary>
        /// Computes the average millisecond execution time for the method
        /// </summary>
        public double AverageMS
            {
            get
                {
                double Out = 0;
                this.Times.Each(Time => { Out += Time.Ticks; });
                Out = Out / this.Times.Count;
                Out = Out * L.Date.TicksToMilliseconds;
                return Out;
                }
            }
        }
    }