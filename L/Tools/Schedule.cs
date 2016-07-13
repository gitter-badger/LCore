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
                for (int Index = 0; Index < this.DaysOfWeek.Count; Index++)
                    {
                    Out += this.DaysOfWeek[Index].ToString();
                    if (Index < this.DaysOfWeek.Count - 1)
                        Out += ",";
                    }

                Out += SplitChar;
                for (int Index = 0; Index < this.TimesOfDay.Count; Index++)
                    {
                    Out += this.TimesOfDay[Index].ToString();
                    if (Index < this.TimesOfDay.Count - 1)
                        Out += ",";
                    }
                }
            else if (this.Mode == ScheduleMode.Monthly)
                {
                Out += SplitChar;

                for (int Index = 0; Index < this.DaysOfMonth.Count; Index++)
                    {
                    Out += this.DaysOfMonth[Index].ToString();
                    if (Index < this.DaysOfMonth.Count - 1)
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

            string[] Split = In.Split(SplitChar);

            var Mode = Split[0].ParseEnum<ScheduleMode>();
            Out.Mode = Mode;

            if (Mode == ScheduleMode.Daily)
                {
                string[] Days = Split[1].Split(',');
                List<DayOfWeek> DaysOfWeek = Days.Select(Day => Day.ParseEnum<DayOfWeek>()).ToList();

                Out.DaysOfWeek = DaysOfWeek;

                string[] Times = Split[2].Split(',');
                List<DateTime> TimesOfDay = Times.Select(Time => Convert.ToDateTime(Time)).ToList();
                TimesOfDay.Sort();

                Out.TimesOfDay = TimesOfDay;
                }
            else if (Mode == ScheduleMode.Monthly)
                {
                string[] Days = Split[1].Split(',');
                List<int> DaysOfMonth = Days.Select(Day => Convert.ToInt32(Day)).ToList();
                DaysOfMonth.Sort();

                Out.DaysOfMonth = DaysOfMonth;
                }
            else if (Mode == ScheduleMode.OneTime)
                {
                Out.OneTimeScheduleDate = Convert.ToDateTime(Split[1]);
                }
            else if (Mode == ScheduleMode.Manual)
                {
                }


            return Out;
            }
        }
    }