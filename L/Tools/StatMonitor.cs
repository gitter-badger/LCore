using System;

namespace LCore.Tools
    {
    /// <summary>
    /// A simple utility to monitor a series of number and compute the walking average over
    /// a number of results.
    /// </summary>
    public class StatMonitor
        {
        /// <summary>
        /// Computes the current walking average of the data.
        /// </summary>
        public double GetCurrentAverageStat()
            {
            int Num = 0;
            double Total = 0;

            foreach (double Stat in this._WalkingStats)
                {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (Stat != 0)
                    {
                    Total += Stat;
                    Num++;
                    }
                }

            if (Num == 0)
                return double.NaN;

            return Total / Num;
            }

        private readonly int _WalkingAverageSize;
        private double[] _WalkingStats;

        private int _CurrentPos;

        /// <summary>
        /// Create a new StatMonitor using a particular walking average size.
        /// [WalkingAverageSize] must be at least 1.
        /// </summary>
        /// <param name="WalkingAverageSize"></param>
        /// <exception cref="ArgumentException">[WalkingAverageSize] was not greater than 0.</exception>
        public StatMonitor(int WalkingAverageSize)
            {
            if (WalkingAverageSize < 1)
                throw new ArgumentException($"WalkingAverageSize must be greater than 0. ({WalkingAverageSize})");

            this._WalkingAverageSize = WalkingAverageSize;
            this.Clear();
            }

        /// <summary>
        /// Add a statistic to the data.
        /// </summary>
        public void AddStat(double Stat)
            {
            this._WalkingStats[this._CurrentPos] = Stat;
            this._CurrentPos = this._CurrentPos + 1;
            if (this._CurrentPos > this._WalkingStats.Length - 1)
                this._CurrentPos = 0;
            }

        /// <summary>
        /// Clears all statistics.
        /// </summary>
        public void Clear()
            {
            this._WalkingStats = new double[this._WalkingAverageSize];
            this._CurrentPos = 0;
            }
        }
    }