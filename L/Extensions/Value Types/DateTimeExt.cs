using System;
using LCore.Tests;

namespace LCore.Extensions
    {
    public static class DateExt
        {
        #region Extensions
        /* TODO: L: DateTime: Comment All Below */

        public const double MaxTimerInterval = 2085732000;

        public const double TicksToMilliseconds = 0.0001;

        #region DayOfWeekNumber
        [TestResult(new object[] { DayOfWeek.Monday }, 1)]
        [TestResult(new object[] { DayOfWeek.Tuesday }, 2)]
        [TestResult(new object[] { DayOfWeek.Wednesday }, 3)]
        [TestResult(new object[] { DayOfWeek.Thursday }, 4)]
        [TestResult(new object[] { DayOfWeek.Friday }, 5)]
        [TestResult(new object[] { DayOfWeek.Saturday }, 6)]
        [TestResult(new object[] { DayOfWeek.Sunday }, 0)]
        public static int DayOfWeekNumber(this DayOfWeek day)
            {
            return Logic.Def.DateTimeExt.GetDayNumber(day);
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region CleanDateString
        public static string CleanDateString(this DateTime In)
            {
            return In.ToString().Replace(":", ".").Replace("\\", "-").Replace("/", "-");
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region ToPubDate
        public static string ToPubDate(this DateTime d)
            {
            try
                {
                string day = d.Day.ToString();
                if (day.Length == 1) { day = $"0{day}"; }
                int month = d.Month;
                string Month = Logic.Def.DateTimeExt.Month_GetString(month);

                DateTime mDate = d.ToUniversalTime();
                string mTime = mDate.Hour.ToString().Length == 1 ? $"0{mDate.Hour}" : mDate.Hour.ToString();

                mTime += ":";
                if (mDate.Minute.ToString().Length == 1)
                    {
                    mTime += $"0{mDate.Minute}";
                    }
                else
                    {
                    mTime += mDate.Minute.ToString();
                    }

                mTime += ":";
                if (mDate.Second.ToString().Length == 1)
                    {
                    mTime += $"0{mDate.Second}";
                    }
                else
                    {
                    mTime += mDate.Second.ToString();
                    }

                string RV = d.DayOfWeek.ToString().Substring(0, 3);
                RV += $", {day} {Month.Substring(0, 3)}";
                RV += $" {d.Year} {mTime} GMT";
                return RV;

                }
            catch (Exception)
                {
                return null;
                }
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region MonthString
        private static string MonthString(this DateTime d)
            {
            return Logic.Def.DateTimeExt.GetMonthString(d);
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region TimeSpanToString
        public static string TimeSpanToString(this TimeSpan t)
            {
            float temp = (float)t.TotalSeconds;
            string unit = "second";
            if (temp > 60)
                {
                unit = "minute";

                temp = temp / 60;
                if (temp > 60)
                    {
                    unit = "hour";

                    temp = temp / 60;

                    if (temp > 24)
                        {
                        unit = "day";
                        temp = temp / 24;
                        }
                    }
                }
            int temp2 = (int)temp;

            string Out = $"{temp2} {unit}{(temp2 == 1 ? "" : "s")}";

            return Out;
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region TimeDifference
        public static string TimeDifference(this DateTime Start, DateTime Current, bool IncludeAgo)
            {
            if (Start == DateTime.MinValue)
                return "Never";

            string Post = "";
            TimeSpan Difference;
            if (Start.Ticks < Current.Ticks)
                {
                if (IncludeAgo)
                    Post = "ago";
                Difference = Current.Subtract(Start);
                }
            else
                {
                if (IncludeAgo)
                    Post = "from now";

                Difference = Start.Subtract(Current);
                }


            int Amount = 0;
            string Unit = "Just now";

            if (Difference.Days > 365)
                {
                Amount = Difference.Days / 365;
                Unit = "year";
                }
            else if (Difference.Days > 30)
                {
                Amount = Difference.Days / 30;
                Unit = "month";
                }
            else if (Difference.Days > 0)
                {
                Amount = Difference.Days;
                Unit = "day";
                }
            else if (Difference.Hours > 0)
                {
                Amount = Difference.Hours;
                Unit = "hour";
                }
            else if (Difference.Minutes > 0)
                {
                Amount = Difference.Minutes;
                Unit = "minute";
                }
            else if (Difference.Seconds > 0)
                {
                Amount = Difference.Seconds;
                Unit = "second";
                }
            else
                {
                Post = "";
                }

            if (Amount > 1)
                {
                Unit += "s";
                }

            string Out = "";

            if (Amount > 0)
                Out += $"{Amount} ";

            Out += Unit;
            if (Post != "")
                {
                Out += $" {Post}";
                }

            return Out;
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region Past
        public static bool Past(this DateTime In)
            {
            return In.Ticks < DateTime.Now.Ticks;
            }
        #endregion

        // TODO: L: DateTime: Untested
        #region Future
        public static bool Future(this DateTime In)
            {
            return In.Ticks > DateTime.Now.Ticks;
            }
        #endregion

        #endregion
        }
    public partial class Logic
        {
        public partial class Def
            {
            public class DateTimeExt
                {
                #region Lambdas
                public static Func<int, string> Month_GetString = L.F<int, string>()
                        .Case(1, "January")
                        .Case(2, "February")
                        .Case(3, "March")
                        .Case(4, "April")
                        .Case(5, "May")
                        .Case(6, "June")
                        .Case(7, "July")
                        .Case(8, "August")
                        .Case(9, "September")
                        .Case(10, "October")
                        .Case(11, "November")
                        .Case(12, "December")
                        .Else(Fail).Debug();

                public static Func<DayOfWeek, int> GetDayNumber = L.F<DayOfWeek, int>()
                        .Case(DayOfWeek.Sunday, 0)
                        .Case(DayOfWeek.Monday, 1)
                        .Case(DayOfWeek.Tuesday, 2)
                        .Case(DayOfWeek.Wednesday, 3)
                        .Case(DayOfWeek.Thursday, 4)
                        .Case(DayOfWeek.Friday, 5)
                        .Case(DayOfWeek.Saturday, 6)
                        .Else(Fail).Debug();

                public static Func<DateTime, string> GetMonthString = d => Month_GetString(d.Month);
                #endregion
                }

            }
        }
    }