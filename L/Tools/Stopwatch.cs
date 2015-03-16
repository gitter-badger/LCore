using System;
using System.Collections.Generic;
using LCore;

namespace LCore.Tools
	{
	public class StopWatch
		{
		private DateTime StartTime;

		public StopWatch()
			{
			Start();
			}

		public void Start()
			{
			StartTime = DateTime.Now;
			}
		public double Stop()
			{
			return (DateTime.Now.Ticks - StartTime.Ticks) * DateExt.TicksToMilliseconds;
			}
		}
	}