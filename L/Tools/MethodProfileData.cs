using LCore.Extensions;
using System;
using System.Collections.Generic;

namespace LCore.Tools
    {
    public class MethodProfileData
        {
        public List<TimeSpan> Times = new List<TimeSpan>();
        public object Data;
        public double AverageMS
            {
            get
                {
                double Out = 0;
                this.Times.Each(t => { Out += t.Ticks; });
                Out = Out / this.Times.Count;
                Out = Out * DateExt.TicksToMilliseconds;
                return Out;
                }
            }
        }
    }