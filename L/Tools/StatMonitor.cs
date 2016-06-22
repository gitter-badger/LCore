using System;

namespace LCore.Tools
    {
    [Serializable]
    public class StatMonitor
        {
        public double CurrentAverageStat
            {
            get
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
            }

        private readonly int WalkingAverageSize;
        private double[] WalkingStats;

        private int CurrentPos;

        public StatMonitor(int WalkingAverageSize)
            {
            if (WalkingAverageSize < 1)
                throw new ArgumentException($"WalkingAverageSize must be greater than 0. ({WalkingAverageSize})");

            this.WalkingAverageSize = WalkingAverageSize;
            this.Clear();
            }

        public void AddStat(double Stat)
            {
            this.WalkingStats[this.CurrentPos] = Stat;
            this.CurrentPos = this.CurrentPos + 1;
            if (this.CurrentPos > this.WalkingStats.Length - 1)
                this.CurrentPos = 0;
            }

        public void Clear()
            {
            this.WalkingStats = new double[this.WalkingAverageSize];
            this.CurrentPos = 0;
            }
        }
    }