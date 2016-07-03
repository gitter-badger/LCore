using System;
using LCore.Tests;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods for DateTime and TimeSpan.
    /// </summary>
    [ExtensionProvider]
    public static class DateExt
        {
        #region Extensions +

        #region DayOfWeekNumber
        /// <summary>
        /// Takes a DayOfWeek and returns the number of day of the week it is.
        /// Values are from Sunday: 0 to Saturday: 6
        /// </summary>
        [TestResult(new object[] { DayOfWeek.Monday }, 1)]
        [TestResult(new object[] { DayOfWeek.Tuesday }, 2)]
        [TestResult(new object[] { DayOfWeek.Wednesday }, 3)]
        [TestResult(new object[] { DayOfWeek.Thursday }, 4)]
        [TestResult(new object[] { DayOfWeek.Friday }, 5)]
        [TestResult(new object[] { DayOfWeek.Saturday }, 6)]
        [TestResult(new object[] { DayOfWeek.Sunday }, 0)]
        public static int DayOfWeekNumber(this DayOfWeek day)
            {
            return L.Date.GetDayNumber(day);
            }
        #endregion

        #region CleanDateString
        /// <summary>
        /// Returns a cleaned string, with replacements made.
        /// These strings are safe to be used in a file name.
        /// </summary>
        public static string CleanDateString(this DateTime In)
            {
            return In.ToString().Replace(":", ".").Replace("\\", "-").Replace("/", "-");
            }
        #endregion

        #region ToSpecification
        /// <summary>
        /// Converts a DateTime to string using Date and Time Specification of RFC 822
        /// </summary>
        public static string ToSpecification(this DateTime d)
            {
            try
                {
                string day = d.Day.ToString();
                if (day.Length == 1) { day = $"0{day}"; }
                int month = d.Month;
                string Month = L.Date.Month_GetString(month);

                var mDate = d.ToUniversalTime();
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

        #region MonthString
        private static string MonthString(this DateTime d)
            {
            return L.Date.GetMonthString(d);
            }
        #endregion

        #region ToTimeString
        /// <summary>
        /// Returns a friendly formatted string from a timespan.
        /// Ex. 1 second
        ///     5 minutes
        ///     2 years
        /// </summary>
        public static string ToTimeString(this TimeSpan t)
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

            string Out = $"{temp2} {unit.Pluralize(temp2)}";

            return Out;
            }
        #endregion

        #region TimeDifference
        /// <summary>
        /// Returns a friendly formatted string representing the difference between the two DateTimes.
        /// If Start is DateTime.MinValue then the output is "Never".
        /// 
        /// Ex. 5 hours ago
        ///     2 days from now
        ///     1 year ago
        /// </summary>
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

            Unit = Unit.Pluralize(Amount);

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

        #region Past
        /// <summary>
        /// Returns whether or not the given datetime is in the past
        /// </summary>
        public static bool Past(this DateTime In)
            {
            return In.Ticks < DateTime.Now.Ticks;
            }
        #endregion

        #region Future
        /// <summary>
        /// Returns whether or not the given datetime is in the future
        /// </summary>
        public static bool Future(this DateTime In)
            {
            return In.Ticks > DateTime.Now.Ticks;
            }
        #endregion

        #endregion
        }
    public static partial class L
        {
        /// <summary>
        /// Contains System.DateTime and System.TimeSpan static methods and lambdas.
        /// </summary>
        public static class Date
            {
            #region Constants +

            /// <summary>
            /// This is the maximum number of ticks that a System.Timing.Timer will still operate.
            /// </summary>
            public const double MaxTimerInterval = 2085732000;

            /// <summary>
            /// Constant value for converting from Ticks to Milliseconds.
            /// </summary>
            public const double TicksToMilliseconds = 0.0001;

            #endregion

            #region Lambdas +
            /// <summary>
            /// Returns the name of the month by the number of the month.
            /// Fails if the number is not between 1 and 12.
            /// </summary>
            public static readonly Func<int, string> Month_GetString = F<int, string>()
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
                    .Else(Exc.Fail).Debug();

            /// <summary>
            /// Returns the number of the day of the week, from
            /// Sunday: 0 to Saturday: 6.
            /// </summary>
            public static readonly Func<DayOfWeek, int> GetDayNumber = F<DayOfWeek, int>()
                    .Case(DayOfWeek.Sunday, 0)
                    .Case(DayOfWeek.Monday, 1)
                    .Case(DayOfWeek.Tuesday, 2)
                    .Case(DayOfWeek.Wednesday, 3)
                    .Case(DayOfWeek.Thursday, 4)
                    .Case(DayOfWeek.Friday, 5)
                    .Case(DayOfWeek.Saturday, 6)
                    .Else(Exc.Fail).Debug();

            /// <summary>
            /// Returns the name of the months from a datetime.
            /// </summary>
            public static Func<DateTime, string> GetMonthString = d => Month_GetString(d.Month);
            #endregion
            }
        }
    }