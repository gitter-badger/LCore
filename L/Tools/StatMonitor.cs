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

            foreach (double t in this.WalkingStats)
                {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (t != 0)
                    {
                    Total += t;
                    Num++;
                    }
                }

            if (Num == 0)
                return double.NaN;

            return Total / Num;
            }

        private readonly int WalkingAverageSize;
        private double[] WalkingStats;

        private int CurrentPos;

        /// <summary>
        /// Create a new StatMonitor using a particular walking average size.
        /// [WalkingAverageSize] must be at least 1.
        /// </summary>
        /// <param name="WalkingAverageSize"></param>
        public StatMonitor(int WalkingAverageSize)
            {
            if (WalkingAverageSize < 1)
                throw new ArgumentException($"WalkingAverageSize must be greater than 0. ({WalkingAverageSize})");

            this.WalkingAverageSize = WalkingAverageSize;
            this.Clear();
            }

        /// <summary>
        /// Add a statistic to the data.
        /// </summary>
        public void AddStat(double Stat)
            {
            this.WalkingStats[this.CurrentPos] = Stat;
            this.CurrentPos = this.CurrentPos + 1;
            if (this.CurrentPos > this.WalkingStats.Length - 1)
                this.CurrentPos = 0;
            }

        /// <summary>
        /// Clears all statistics.
        /// </summary>
        public void Clear()
            {
            this.WalkingStats = new double[this.WalkingAverageSize];
            this.CurrentPos = 0;
            }
        }
    }