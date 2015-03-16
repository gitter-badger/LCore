using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LCore
    {
    public class Schedule
        {
        public const String XML_NAME_STR = "Schedule";
        public const String XML_MODE_STR = "Mode";
        public const String XML_TIME_STR = "TimeOfDay";
        public const String XML_DAY_STR = "DayOfWeek";
        public const char SplitChar = '|';
        public const ScheduleMode DEFAULT_MODE = ScheduleMode.Daily;
        public static DateTime DEFAULT_TIME_OF_DAY = DateTime.MinValue;

        public static DayOfWeek[] AllDays = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
        public static String[] AllDaysStr = Enum.GetNames(typeof(System.DayOfWeek));

        public enum ScheduleMode { Monthly, Daily, One_Time, Manual };

        public ScheduleMode Mode = ScheduleMode.Manual;
        public List<DateTime> TimesOfDay = new List<DateTime>();
        public List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>();
        public List<int> DaysOfMonth = new List<int>();
        public DateTime OneTimeScheduleDate = DateTime.MinValue;

        public override String ToString()
            {
            String Out = "";

            Out = Mode.ToString();

            if (Mode == ScheduleMode.Daily)
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
            else if (Mode == ScheduleMode.Monthly)
                {
                Out += SplitChar;

                for (int i = 0; i < this.DaysOfMonth.Count; i++)
                    {
                    Out += this.DaysOfMonth[i].ToString();
                    if (i < this.DaysOfMonth.Count - 1)
                        Out += ",";
                    }
                }
            else if (Mode == ScheduleMode.One_Time)
                {
                Out += SplitChar +
                    OneTimeScheduleDate.ToString();
                }
            else if (Mode == ScheduleMode.Manual)
                {
                }
            return Out;
            }

        public static Schedule FromString(String In)
            {
            Schedule Out = new Schedule();

            String[] split = In.Split(SplitChar);

            ScheduleMode Mode = split[0].ParseEnum<ScheduleMode>();
            Out.Mode = Mode;

            if (Mode == ScheduleMode.Daily)
                {
                String[] days = split[1].Split(',');
                List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>();
                for (int i = 0; i < days.Length; i++)
                    {
                    DaysOfWeek.Add(days[i].ParseEnum<DayOfWeek>());
                    }

                Out.DaysOfWeek = DaysOfWeek;

                String[] times = split[2].Split(',');
                List<DateTime> TimesOfDay = new List<DateTime>();
                for (int i = 0; i < times.Length; i++)
                    {
                    TimesOfDay.Add(Convert.ToDateTime(times[i]));
                    }
                TimesOfDay.Sort();

                Out.TimesOfDay = TimesOfDay;
                }
            else if (Mode == ScheduleMode.Monthly)
                {
                String[] days = split[1].Split(',');
                List<int> DaysOfMonth = new List<int>();
                for (int i = 0; i < days.Length; i++)
                    {
                    DaysOfMonth.Add(Convert.ToInt32(days[i]));
                    }
                DaysOfMonth.Sort();

                Out.DaysOfMonth = DaysOfMonth;
                }
            else if (Mode == ScheduleMode.One_Time)
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