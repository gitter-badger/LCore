using System;
using System.Collections;
using System.Collections.Generic;
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

        #region Average
        /// <summary>
        /// Returns the average of all timespan elements in Times
        /// </summary>
        public static TimeSpan Average(this IEnumerable<TimeSpan> Times)
            {
            Times = Times ?? new TimeSpan[] { };

            long Total = 0;
            int Count = 0;

            Times.Each(Time =>
                {
                    Total += Time.Ticks;
                    Count++;
                });

            if (Count == 0)
                return new TimeSpan(0);

            long Out = Total / Count;

            return new TimeSpan(Out);
            }
        #endregion


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
        public static int DayOfWeekNumber(this DayOfWeek Day)
            {
            return L.Date.GetDayNumber(Day);
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
        [Tested]
        public static string ToSpecification(this DateTime Date)
            {
            string Day = Date.Day.ToString();
            if (Day.Length == 1) { Day = $"0{Day}"; }
            int MonthNum = Date.Month;
            string Month = L.Date.MonthNumberGetName(MonthNum);

            var MDate = Date.ToUniversalTime();
            string MTime = MDate.Hour.ToString().Length == 1 ? $"0{MDate.Hour}" : MDate.Hour.ToString();

            MTime += ":";
            if (MDate.Minute.ToString().Length == 1)
                {
                MTime += $"0{MDate.Minute}";
                }
            else
                {
                MTime += MDate.Minute.ToString();
                }

            MTime += ":";
            if (MDate.Second.ToString().Length == 1)
                {
                MTime += $"0{MDate.Second}";
                }
            else
                {
                MTime += MDate.Second.ToString();
                }

            string Str = Date.DayOfWeek.ToString().Substring(0, 3);
            Str += $", {Day} {Month.Substring(0, 3)}";
            Str += $" {Date.Year} {MTime} GMT";
            return Str;
            }
        #endregion

        #region MonthString
        /// <summary>
        /// Gets the name of the month for the source DateTime <paramref name="Date"/>
        /// </summary>
        [Tested]
        public static string GetMonthName(this DateTime Date)
            {
            return L.Date.GetMonthName(Date);
            }
        #endregion

        #region ToTimeString
        /// <summary>
        /// Returns a friendly formatted string from a timespan.
        /// Ex. 1 second
        ///     5 minutes
        ///     2 years
        /// </summary>
        public static string ToTimeString(this TimeSpan Time)
            {
            float Temp = (float)Time.TotalSeconds;
            string Unit = "second";
            if (Temp.Abs() > 60)
                {
                Unit = "minute";

                Temp = Temp / 60;
                if (Temp.Abs() > 60)
                    {
                    Unit = "hour";

                    Temp = Temp / 60;

                    if (Temp.Abs() > 24)
                        {
                        Unit = "day";
                        Temp = Temp / 24;

                        if (Temp.Abs() > 365)
                            {
                            Unit = "year";
                            Temp = Temp / 365;

                            if (Temp.Abs() > 365)
                                {
                                Unit = "century";
                                Temp = Temp / 365;
                                }
                            }
                        }
                    }
                }
            int Temp2 = (int)Temp;

            string Out = $"{Temp2} {Unit.Pluralize(Temp2)}";

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
            if (Start == DateTime.MinValue || Current == DateTime.MinValue)
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


            int Amount;
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
            else if (Difference.Days > 7)
                {
                Amount = Difference.Days / 7;
                Unit = "week";
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
                return Unit;
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

        #region IsPast
        /// <summary>
        /// Returns whether or not the given datetime is in the past
        /// </summary>
        public static bool IsPast(this DateTime In)
            {
            return In.Ticks < DateTime.Now.Ticks;
            }
        #endregion

        #region IsFuture
        /// <summary>
        /// Returns whether or not the given datetime is in the future
        /// </summary>
        public static bool IsFuture(this DateTime In)
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
            public static readonly Func<int, string> MonthNumberGetName = i =>
                {
                    switch (i)
                        {
                        case 1: return "January";
                        case 2: return "February";
                        case 3: return "March";
                        case 4: return "April";
                        case 5: return "May";
                        case 6: return "June";
                        case 7: return "July";
                        case 8: return "August";
                        case 9: return "September";
                        case 10: return "October";
                        case 11: return "November";
                        case 12: return "December";
                        }
                    throw new ArgumentException(nameof(i));
                };
            /// <summary>
            /// Returns the number of the day of the week, from
            /// Sunday: 0 to Saturday: 6.
            /// </summary>
            public static readonly Func<DayOfWeek, int> GetDayNumber = Day =>
                {
                    switch (Day)
                        {
                        case DayOfWeek.Sunday: return 0;
                        case DayOfWeek.Monday: return 1;
                        case DayOfWeek.Tuesday: return 2;
                        case DayOfWeek.Wednesday: return 3;
                        case DayOfWeek.Thursday: return 4;
                        case DayOfWeek.Friday: return 5;
                        case DayOfWeek.Saturday: return 6;
                        }
                    throw new ArgumentException(nameof(Day));
                };

            /// <summary>
            /// Returns the name of the months from a datetime.
            /// </summary>
            public static readonly Func<DateTime, string> GetMonthName = Date => MonthNumberGetName(Date.Month);
            #endregion
            }
        }
    }