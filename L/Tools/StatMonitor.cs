using System;
using System.Collections.Generic;

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

				for (int i = 0; i < WalkingStats.Length; i++)
					{
					if (WalkingStats[i] != 0)
						{
						Total += WalkingStats[i];
						Num++;
						}
					}

				if (Num == 0)
					return double.NaN;
				else
					return (double)(Total / (double)Num);
				}
			}

		private int WalkingAverageSize;
		private double[] WalkingStats;

		private int CurrentPos = 0;

		public StatMonitor(int WalkingAverageSize)
			{
			if (WalkingAverageSize < 1)
				throw new ArgumentException("WalkingAverageSize must be greater than 0. (" + WalkingAverageSize + ")");

			this.WalkingAverageSize = WalkingAverageSize;
			this.Clear();
			}

		public void AddStat(double Stat)
			{
			WalkingStats[CurrentPos] = Stat;
			CurrentPos = CurrentPos + 1;
			if (CurrentPos > WalkingStats.Length - 1)
				CurrentPos = 0;
			}

		public void Clear()
			{
			WalkingStats = new double[WalkingAverageSize];
			CurrentPos = 0;
			}
		}
	}