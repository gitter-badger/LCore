using System;
using System.Collections.Generic;
using System.Linq;
using LCore.Extensions;
#pragma warning disable 1591

namespace LCore.Tools
    {
    public class Schedule
        {
        public const string XmlNameStr = "Schedule";
        public const string XmlModeStr = "Mode";
        public const string XmlTimeStr = "TimeOfDay";
        public const string XmlDayStr = "DayOfWeek";
        public const char SplitChar = '|';
        public const ScheduleMode DefaultMode = ScheduleMode.Daily;
        public static DateTime DefaultTimeOfDay = DateTime.MinValue;

        public static DayOfWeek[] AllDays = { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
        public static string[] AllDaysStr = Enum.GetNames(typeof(DayOfWeek));

        public enum ScheduleMode { Monthly, Daily, OneTime, Manual }

        public ScheduleMode Mode = ScheduleMode.Manual;
        public List<DateTime> TimesOfDay = new List<DateTime>();
        public List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>();
        public List<int> DaysOfMonth = new List<int>();
        public DateTime OneTimeScheduleDate = DateTime.MinValue;

        public override string ToString()
            {
            string Out = this.Mode.ToString();

            if (this.Mode == ScheduleMode.Daily)
                {
                Out += SplitChar;
                for (int i = 0; i < this.DaysOfWeek.Count; i++)
                    {
                    Out += this.DaysOfWeek[i].ToString();
                    if (i < this.DaysOfWeek.Count - 1)
                        Out += ",";
                    }

                Out += SplitChar;
                for (int i = 0; i < this.TimesOfDay.Count; i++)
                    {
                    Out += this.TimesOfDay[i].ToString();
                    if (i < this.TimesOfDay.Count - 1)
                        Out += ",";
                    }
                }
            else if (this.Mode == ScheduleMode.Monthly)
                {
                Out += SplitChar;

                for (int i = 0; i < this.DaysOfMonth.Count; i++)
                    {
                    Out += this.DaysOfMonth[i].ToString();
                    if (i < this.DaysOfMonth.Count - 1)
                        Out += ",";
                    }
                }
            else if (this.Mode == ScheduleMode.OneTime)
                {
                Out += SplitChar + this.OneTimeScheduleDate.ToString();
                }
            else if (this.Mode == ScheduleMode.Manual)
                {
                }
            return Out;
            }

        public static Schedule FromString(string In)
            {
            var Out = new Schedule();

            string[] split = In.Split(SplitChar);

            var Mode = split[0].ParseEnum<ScheduleMode>();
            Out.Mode = Mode;

            if (Mode == ScheduleMode.Daily)
                {
                string[] days = split[1].Split(',');
                List<DayOfWeek> DaysOfWeek = days.Select(t => t.ParseEnum<DayOfWeek>()).ToList();

                Out.DaysOfWeek = DaysOfWeek;

                string[] times = split[2].Split(',');
                List<DateTime> TimesOfDay = times.Select(t => Convert.ToDateTime(t)).ToList();
                TimesOfDay.Sort();

                Out.TimesOfDay = TimesOfDay;
                }
            else if (Mode == ScheduleMode.Monthly)
                {
                string[] days = split[1].Split(',');
                List<int> DaysOfMonth = days.Select(t => Convert.ToInt32(t)).ToList();
                DaysOfMonth.Sort();

                Out.DaysOfMonth = DaysOfMonth;
                }
            else if (Mode == ScheduleMode.OneTime)
                {
                Out.OneTimeScheduleDate = Convert.ToDateTime(split[1]);
                }
            else if (Mode == ScheduleMode.Manual)
                {
                }


            return Out;
            }
        }
    }