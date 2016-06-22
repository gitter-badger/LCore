using System;
using LCore.Extensions;

namespace LCore.Tools
	{
	public class StopWatch
		{
		private DateTime StartTime;

		public StopWatch()
			{
		    this.Start();
			}

		public void Start()
			{
		    this.StartTime = DateTime.Now;
			}
		public double Stop()
			{
			return (DateTime.Now.Ticks - this.StartTime.Ticks) * DateExt.TicksToMilliseconds;
			}
		}
	}