using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;
using LCore.UnitTesting;

namespace LCore
{
    public partial class Logic
    {
        #region Base Lambdas
        #region DateTime
        public static Func<DateTime> DateTime_GetMinValue = () => { return DateTime.MinValue; };
        public static Func<DateTime> DateTime_GetMaxValue = () => { return DateTime.MaxValue; };
        public static Func<DateTime, DateTime> DateTime_GetDate = (d) => { return d.Date; };
        public static Func<DateTime, Int32> DateTime_GetDay = (d) => { return d.Day; };
        public static Func<DateTime, DayOfWeek> DateTime_GetDayOfWeek = (d) => { return d.DayOfWeek; };
        public static Func<DateTime, Int32> DateTime_GetDayOfYear = (d) => { return d.DayOfYear; };
        public static Func<DateTime, Int32> DateTime_GetHour = (d) => { return d.Hour; };
        public static Func<DateTime, DateTimeKind> DateTime_GetKind = (d) => { return d.Kind; };
        public static Func<DateTime, Int32> DateTime_GetMillisecond = (d) => { return d.Millisecond; };
        public static Func<DateTime, Int32> DateTime_GetMinute = (d) => { return d.Minute; };
        public static Func<DateTime, Int32> DateTime_GetMonth = (d) => { return d.Month; };
        public static Func<DateTime> DateTime_GetNow = () => { return DateTime.Now; };
        public static Func<DateTime> DateTime_GetUtcNow = () => { return DateTime.UtcNow; };
        public static Func<DateTime> DateTime_GetToday = () => { return DateTime.Today; };
        public static Func<DateTime, Int32> DateTime_GetSecond = (d) => { return d.Second; };
        public static Func<DateTime, Int64> DateTime_GetTicks = (d) => { return d.Ticks; };
        public static Func<DateTime, TimeSpan> DateTime_GetTimeOfDay = (d) => { return d.TimeOfDay; };
        public static Func<DateTime, Int32> DateTime_GetYear = (d) => { return d.Year; };
        public static Func<DateTime, TimeSpan, DateTime> DateTime_Add = (d, value) => { return d.Add(value); };
        public static Func<DateTime, Double, DateTime> DateTime_AddDays = (d, value) => { return d.AddDays(value); };
        public static Func<DateTime, Double, DateTime> DateTime_AddHours = (d, value) => { return d.AddHours(value); };
        public static Func<DateTime, Double, DateTime> DateTime_AddMilliseconds = (d, value) => { return d.AddMilliseconds(value); };
        public static Func<DateTime, Double, DateTime> DateTime_AddMinutes = (d, value) => { return d.AddMinutes(value); };
        public static Func<DateTime, Int32, DateTime> DateTime_AddMonths = (d, months) => { return d.AddMonths(months); };
        public static Func<DateTime, Double, DateTime> DateTime_AddSeconds = (d, value) => { return d.AddSeconds(value); };
        public static Func<DateTime, Int64, DateTime> DateTime_AddTicks = (d, value) => { return d.AddTicks(value); };
        public static Func<DateTime, Int32, DateTime> DateTime_AddYears = (d, value) => { return d.AddYears(value); };
        public static Func<DateTime, DateTime, Int32> DateTime_Compare = (t1, t2) => { return DateTime.Compare(t1, t2); };
        public static Func<DateTime, Object, Int32> DateTime_CompareTo = (d, value) => { return d.CompareTo(value); };
        public static Func<DateTime, DateTime, Int32> DateTime_CompareTo2 = (d, value) => { return d.CompareTo(value); };
        public static Func<Int32, Int32, Int32> DateTime_DaysInMonth = (year, month) => { return DateTime.DaysInMonth(year, month); };
        public static Func<DateTime, Object, Boolean> DateTime_Equals = (d, value) => { return d.Equals(value); };
        public static Func<DateTime, DateTime, Boolean> DateTime_Equals2 = (d, value) => { return d.Equals(value); };
        public static Func<DateTime, DateTime, Boolean> DateTime_Equals3 = (t1, t2) => { return DateTime.Equals(t1, t2); };
        public static Func<Int64, DateTime> DateTime_FromBinary = (dateData) => { return DateTime.FromBinary(dateData); };
        public static Func<Int64, DateTime> DateTime_FromFileTime = (fileTime) => { return DateTime.FromFileTime(fileTime); };
        public static Func<Int64, DateTime> DateTime_FromFileTimeUtc = (fileTime) => { return DateTime.FromFileTimeUtc(fileTime); };
        public static Func<Double, DateTime> DateTime_FromOADate = (d) => { return DateTime.FromOADate(d); };
        public static Func<DateTime, Boolean> DateTime_IsDaylightSavingTime = (d) => { return d.IsDaylightSavingTime(); };
        public static Func<DateTime, DateTimeKind, DateTime> DateTime_SpecifyKind = (value, kind) => { return DateTime.SpecifyKind(value, kind); };
        public static Func<DateTime, Int64> DateTime_ToBinary = (d) => { return d.ToBinary(); };
        public static Func<DateTime, Int32> DateTime_GetHashCode = (d) => { return d.GetHashCode(); };
        public static Func<Int32, Boolean> DateTime_IsLeapYear = (year) => { return DateTime.IsLeapYear(year); };
        public static Func<String, DateTime> DateTime_Parse = (s) => { return DateTime.Parse(s); };
        public static Func<String, IFormatProvider, DateTime> DateTime_Parse2 = (s, provider) => { return DateTime.Parse(s, provider); };
        public static Func<String, IFormatProvider, DateTimeStyles, DateTime> DateTime_Parse3 = (s, provider, styles) => { return DateTime.Parse(s, provider, styles); };
        public static Func<String, String, IFormatProvider, DateTime> DateTime_ParseExact = (s, format, provider) => { return DateTime.ParseExact(s, format, provider); };
        public static Func<String, String, IFormatProvider, DateTimeStyles, DateTime> DateTime_ParseExact2 = (s, format, provider, style) => { return DateTime.ParseExact(s, format, provider, style); };
        public static Func<String, String[], IFormatProvider, DateTimeStyles, DateTime> DateTime_ParseExact3 = (s, formats, provider, style) => { return DateTime.ParseExact(s, formats, provider, style); };
        public static Func<DateTime, DateTime, TimeSpan> DateTime_Subtract = (d, value) => { return d.Subtract(value); };
        public static Func<DateTime, TimeSpan, DateTime> DateTime_Subtract2 = (d, value) => { return d.Subtract(value); };
        public static Func<DateTime, Double> DateTime_ToOADate = (d) => { return d.ToOADate(); };
        public static Func<DateTime, Int64> DateTime_ToFileTime = (d) => { return d.ToFileTime(); };
        public static Func<DateTime, Int64> DateTime_ToFileTimeUtc = (d) => { return d.ToFileTimeUtc(); };
        public static Func<DateTime, DateTime> DateTime_ToLocalTime = (d) => { return d.ToLocalTime(); };
        public static Func<DateTime, String> DateTime_ToLongDateString = (d) => { return d.ToLongDateString(); };
        public static Func<DateTime, String> DateTime_ToLongTimeString = (d) => { return d.ToLongTimeString(); };
        public static Func<DateTime, String> DateTime_ToShortDateString = (d) => { return d.ToShortDateString(); };
        public static Func<DateTime, String> DateTime_ToShortTimeString = (d) => { return d.ToShortTimeString(); };
        public static Func<DateTime, String> DateTime_ToString = (d) => { return d.ToString(); };
        public static Func<DateTime, String, String> DateTime_ToString2 = (d, format) => { return d.ToString(format); };
        public static Func<DateTime, IFormatProvider, String> DateTime_ToString3 = (d, provider) => { return d.ToString(provider); };
        public static Func<DateTime, String, IFormatProvider, String> DateTime_ToString4 = (d, format, provider) => { return d.ToString(format, provider); };
        public static Func<DateTime, DateTime> DateTime_ToUniversalTime = (d) => { return d.ToUniversalTime(); };
        public static Func<DateTime, TimeSpan, DateTime> DateTime_Add2 = (d, t) => { return d + t; };
        public static Func<DateTime, TimeSpan, DateTime> DateTime_Subtract3 = (d, t) => { return d - t; };
        public static Func<DateTime, DateTime, TimeSpan> DateTime_Subtract4 = (d1, d2) => { return d1 - d2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_Equals4 = (d1, d2) => { return d1 == d2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_NotEquals = (d1, d2) => { return d1 != d2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_LessThan = (t1, t2) => { return t1 < t2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_LessThanOrEqual = (t1, t2) => { return t1 <= t2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_GreaterThan = (t1, t2) => { return t1 > t2; };
        public static Func<DateTime, DateTime, Boolean> DateTime_GreaterThanOrEqual = (t1, t2) => { return t1 >= t2; };
        public static Func<DateTime, String[]> DateTime_GetDateTimeFormats = (d) => { return d.GetDateTimeFormats(); };
        public static Func<DateTime, IFormatProvider, String[]> DateTime_GetDateTimeFormats2 = (d, provider) => { return d.GetDateTimeFormats(provider); };
        public static Func<DateTime, Char, String[]> DateTime_GetDateTimeFormats3 = (d, format) => { return d.GetDateTimeFormats(format); };
        public static Func<DateTime, Char, IFormatProvider, String[]> DateTime_GetDateTimeFormats4 = (d, format, provider) => { return d.GetDateTimeFormats(format, provider); };
        public static Func<DateTime, TypeCode> DateTime_GetTypeCode = (d) => { return d.GetTypeCode(); };
        public static Func<DateTime> DateTime_Empty = DateTime_GetMinValue;
        public static Func<Int64, DateTime> DateTime_New = (ticks) => { return new DateTime(ticks); };
        public static Func<Int64, DateTimeKind, DateTime> DateTime_New2 = (ticks, kind) => { return new DateTime(ticks, kind); };
        public static Func<Int32, Int32, Int32, DateTime> DateTime_New3 = (year, month, day) => { return new DateTime(year, month, day); };
        public static Func<Int32, Int32, Int32, Calendar, DateTime> DateTime_New4 = (year, month, day, calendar) => { return new DateTime(year, month, day, calendar); };
        /* Too Many Parameters :( 
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, DateTime> DateTime_New5 = (year, month, day, hour, minute, second) => { return new DateTime(year, month, day, hour, minute, second); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, DateTimeKind, DateTime> DateTime_New6 = (year, month, day, hour, minute, second, kind) => { return new DateTime(year, month, day, hour, minute, second, kind); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, Calendar, DateTime> DateTime_New7 = (year, month, day, hour, minute, second, calendar) => { return new DateTime(year, month, day, hour, minute, second, calendar); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, Int32, DateTime> DateTime_New8 = (year, month, day, hour, minute, second, millisecond) => { return new DateTime(year, month, day, hour, minute, second, millisecond); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, Int32, DateTimeKind, DateTime> DateTime_New9 = (year, month, day, hour, minute, second, millisecond, kind) => { return new DateTime(year, month, day, hour, minute, second, millisecond, kind); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, DateTime> DateTime_New10 = (year, month, day, hour, minute, second, millisecond, calendar) => { return new DateTime(year, month, day, hour, minute, second, millisecond, calendar); };
        public static Func<Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, DateTimeKind, DateTime> DateTime_New11 = (year, month, day, hour, minute, second, millisecond, calendar, kind) => { return new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind); };
        public static Func<String, String, IFormatProvider, DateTimeStyles, DateTime&, Boolean> DateTime_TryParseExact = (s, format, provider, style, result) => { return DateTime.TryParseExact(s, format, provider, style, result); };
        public static Func<String, String[], IFormatProvider, DateTimeStyles, DateTime&, Boolean> DateTime_TryParseExact = (s, formats, provider, style, result) => { return DateTime.TryParseExact(s, formats, provider, style, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, DateTime&, Boolean> DateTime_TryParse = (s, result) => { return DateTime.TryParse(s, result); };
        public static Func<String, IFormatProvider, DateTimeStyles, DateTime&, Boolean> DateTime_TryParse = (s, provider, styles, result) => { return DateTime.TryParse(s, provider, styles, result); };
        */
        #endregion
        #region TimeSpan
        public static Func<TimeSpan> TimeSpan_GetZero = () => { return TimeSpan.Zero; };
        public static Func<TimeSpan> TimeSpan_GetMaxValue = () => { return TimeSpan.MaxValue; };
        public static Func<TimeSpan> TimeSpan_GetMinValue = () => { return TimeSpan.MinValue; };
        public static Func<Int64> TimeSpan_GetTicksPerMillisecond = () => { return TimeSpan.TicksPerMillisecond; };
        public static Func<Int64> TimeSpan_GetTicksPerSecond = () => { return TimeSpan.TicksPerSecond; };
        public static Func<Int64> TimeSpan_GetTicksPerMinute = () => { return TimeSpan.TicksPerMinute; };
        public static Func<Int64> TimeSpan_GetTicksPerHour = () => { return TimeSpan.TicksPerHour; };
        public static Func<Int64> TimeSpan_GetTicksPerDay = () => { return TimeSpan.TicksPerDay; };
        public static Func<TimeSpan, Int64> TimeSpan_GetTicks = (t) => { return t.Ticks; };
        public static Func<TimeSpan, Int32> TimeSpan_GetDays = (t) => { return t.Days; };
        public static Func<TimeSpan, Int32> TimeSpan_GetHours = (t) => { return t.Hours; };
        public static Func<TimeSpan, Int32> TimeSpan_GetMilliseconds = (t) => { return t.Milliseconds; };
        public static Func<TimeSpan, Int32> TimeSpan_GetMinutes = (t) => { return t.Minutes; };
        public static Func<TimeSpan, Int32> TimeSpan_GetSeconds = (t) => { return t.Seconds; };
        public static Func<TimeSpan, Double> TimeSpan_GetTotalDays = (t) => { return t.TotalDays; };
        public static Func<TimeSpan, Double> TimeSpan_GetTotalHours = (t) => { return t.TotalHours; };
        public static Func<TimeSpan, Double> TimeSpan_GetTotalMilliseconds = (t) => { return t.TotalMilliseconds; };
        public static Func<TimeSpan, Double> TimeSpan_GetTotalMinutes = (t) => { return t.TotalMinutes; };
        public static Func<TimeSpan, Double> TimeSpan_GetTotalSeconds = (t) => { return t.TotalSeconds; };
        public static Func<TimeSpan, TimeSpan, TimeSpan> TimeSpan_Add = (t, ts) => { return t.Add(ts); };
        public static Func<TimeSpan, TimeSpan, Int32> TimeSpan_Compare = (t1, t2) => { return TimeSpan.Compare(t1, t2); };
        public static Func<TimeSpan, Object, Int32> TimeSpan_CompareTo = (t, value) => { return t.CompareTo(value); };
        public static Func<TimeSpan, TimeSpan, Int32> TimeSpan_CompareTo2 = (t, value) => { return t.CompareTo(value); };
        public static Func<Double, TimeSpan> TimeSpan_FromDays = (value) => { return TimeSpan.FromDays(value); };
        public static Func<TimeSpan, TimeSpan> TimeSpan_Duration = (t) => { return t.Duration(); };
        public static Func<TimeSpan, Object, Boolean> TimeSpan_Equals = (t, value) => { return t.Equals(value); };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_Equals2 = (t, obj) => { return t.Equals(obj); };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_Equals3 = (t1, t2) => { return TimeSpan.Equals(t1, t2); };
        public static Func<TimeSpan, Int32> TimeSpan_GetHashCode = (t) => { return t.GetHashCode(); };
        public static Func<Double, TimeSpan> TimeSpan_FromHours = (value) => { return TimeSpan.FromHours(value); };
        public static Func<Double, TimeSpan> TimeSpan_FromMilliseconds = (value) => { return TimeSpan.FromMilliseconds(value); };
        public static Func<Double, TimeSpan> TimeSpan_FromMinutes = (value) => { return TimeSpan.FromMinutes(value); };
        public static Func<TimeSpan, TimeSpan> TimeSpan_Negate = (t) => { return t.Negate(); };
        public static Func<Double, TimeSpan> TimeSpan_FromSeconds = (value) => { return TimeSpan.FromSeconds(value); };
        public static Func<TimeSpan, TimeSpan, TimeSpan> TimeSpan_Subtract = (t, ts) => { return t.Subtract(ts); };
        public static Func<Int64, TimeSpan> TimeSpan_FromTicks = (value) => { return TimeSpan.FromTicks(value); };
        public static Func<String, TimeSpan> TimeSpan_Parse = (s) => { return TimeSpan.Parse(s); };
        public static Func<String, IFormatProvider, TimeSpan> TimeSpan_Parse2 = (input, formatProvider) => { return TimeSpan.Parse(input, formatProvider); };
        public static Func<String, String, IFormatProvider, TimeSpan> TimeSpan_ParseExact = (input, format, formatProvider) => { return TimeSpan.ParseExact(input, format, formatProvider); };
        public static Func<String, String[], IFormatProvider, TimeSpan> TimeSpan_ParseExact2 = (input, formats, formatProvider) => { return TimeSpan.ParseExact(input, formats, formatProvider); };
        public static Func<String, String, IFormatProvider, TimeSpanStyles, TimeSpan> TimeSpan_ParseExact3 = (input, format, formatProvider, styles) => { return TimeSpan.ParseExact(input, format, formatProvider, styles); };
        public static Func<String, String[], IFormatProvider, TimeSpanStyles, TimeSpan> TimeSpan_ParseExact4 = (input, formats, formatProvider, styles) => { return TimeSpan.ParseExact(input, formats, formatProvider, styles); };
        /* No Ref or Out Types 
        public static Func<String, TimeSpan&, Boolean> TimeSpan_TryParse = (s, result) => { return TimeSpan.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, IFormatProvider, TimeSpan&, Boolean> TimeSpan_TryParse2 = (input, formatProvider, result) => { return TimeSpan.TryParse(input, formatProvider, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, String, IFormatProvider, TimeSpan&, Boolean> TimeSpan_TryParseExact = (input, format, formatProvider, result) => { return TimeSpan.TryParseExact(input, format, formatProvider, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, String[], IFormatProvider, TimeSpan&, Boolean> TimeSpan_TryParseExact2 = (input, formats, formatProvider, result) => { return TimeSpan.TryParseExact(input, formats, formatProvider, result); };
        */
        /* Too Many Parameters :( 
        public static Func<String, String, IFormatProvider, TimeSpanStyles, TimeSpan&, Boolean> TimeSpan_TryParseExact3 = (input, format, formatProvider, styles, result) => { return TimeSpan.TryParseExact(input, format, formatProvider, styles, result); };
        */
        /* Too Many Parameters :( 
        public static Func<String, String[], IFormatProvider, TimeSpanStyles, TimeSpan&, Boolean> TimeSpan_TryParseExact4 = (input, formats, formatProvider, styles, result) => { return TimeSpan.TryParseExact(input, formats, formatProvider, styles, result); };
        */
        public static Func<TimeSpan, String> TimeSpan_ToString = (t) => { return t.ToString(); };
        public static Func<TimeSpan, String, String> TimeSpan_ToString2 = (t, format) => { return t.ToString(format); };
        public static Func<TimeSpan, String, IFormatProvider, String> TimeSpan_ToString3 = (t, format, formatProvider) => { return t.ToString(format, formatProvider); };
        public static Func<TimeSpan, TimeSpan> TimeSpan_ShiftRight = (t) => { return t; };
        public static Func<TimeSpan, TimeSpan, TimeSpan> TimeSpan_Subtract2 = (t1, t2) => { return t1 - t2; };
        public static Func<TimeSpan, TimeSpan> TimeSpan_ShiftLeft = (t) => { return t; };
        public static Func<TimeSpan, TimeSpan, TimeSpan> TimeSpan_Add2 = (t1, t2) => { return t1 + t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_Equals4 = (t1, t2) => { return t1 == t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_NotEquals = (t1, t2) => { return t1 != t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_LessThan = (t1, t2) => { return t1 < t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_LessThanOrEqual = (t1, t2) => { return t1 <= t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_GreaterThan = (t1, t2) => { return t1 > t2; };
        public static Func<TimeSpan, TimeSpan, Boolean> TimeSpan_GreaterThanOrEqual = (t1, t2) => { return t1 >= t2; };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<Int64, TimeSpan> TimeSpan_New = (ticks) => { return new TimeSpan(ticks); };
        public static Func<Int32, Int32, Int32, TimeSpan> TimeSpan_New2 = (hours, minutes, seconds) => { return new TimeSpan(hours, minutes, seconds); };
        public static Func<Int32, Int32, Int32, Int32, TimeSpan> TimeSpan_New3 = (days, hours, minutes, seconds) => { return new TimeSpan(days, hours, minutes, seconds); };
        /* Too Many Parameters :( 
        public static Func<Int32, Int32, Int32, Int32, Int32, TimeSpan> TimeSpan_New4 = (days, hours, minutes, seconds, milliseconds) => { return new TimeSpan(days, hours, minutes, seconds, milliseconds); };
        */
        #endregion
        #endregion

        #region DateTime
        public static Func<int, String> DateTime_Month_GetString = L.F<int, String>()
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
                .Else(L.Fail).Debug();

        public static Func<DayOfWeek, int> DateTime_GetDayNumber = L.F<DayOfWeek, int>()
                .Case(DayOfWeek.Sunday, 0)
                .Case(DayOfWeek.Monday, 1)
                .Case(DayOfWeek.Tuesday, 2)
                .Case(DayOfWeek.Wednesday, 3)
                .Case(DayOfWeek.Thursday, 4)
                .Case(DayOfWeek.Friday, 5)
                .Case(DayOfWeek.Saturday, 6)
                .Else(L.Fail).Debug();

        public static Func<DateTime, String> DateTime_GetMonthString = DateTime_Month_GetString.Surround(L.DateTime_GetMonth);
        #endregion
    }
    public static class DateExt
    {
        public const double MaxTimerInterval = 2085732000;

        public const double TicksToMilliseconds = 0.0001;

        [TestResult(new Object[] { DayOfWeek.Monday }, 1)]
        [TestResult(new Object[] { DayOfWeek.Tuesday }, 2)]
        [TestResult(new Object[] { DayOfWeek.Wednesday }, 3)]
        [TestResult(new Object[] { DayOfWeek.Thursday }, 4)]
        [TestResult(new Object[] { DayOfWeek.Friday }, 5)]
        [TestResult(new Object[] { DayOfWeek.Saturday }, 6)]
        [TestResult(new Object[] { DayOfWeek.Sunday }, 0)]
        public static int DayOfWeekNumber(this DayOfWeek day)
        {
            return L.DateTime_GetDayNumber(day);
        }

        #region Clean
        public static String CleanDateString(this DateTime In)
        {
            return In.ToString().Replace(":", ".").Replace("\\", "-").Replace("/", "-");
        }
        public static String ToPubDate(this DateTime d)
        {
            try
            {
                string RV = "";
                string day = d.Day.ToString();
                if (day.Length == 1) { day = "0" + day; }
                int month = d.Month;
                String Month = "";
                Month = L.DateTime_Month_GetString(month);

                string mTime = "";
                DateTime mDate = d.ToUniversalTime();
                if (mDate.Hour.ToString().Length == 1)
                {
                    mTime = "0" + mDate.Hour.ToString();
                }
                else
                {
                    mTime = mDate.Hour.ToString();
                }

                mTime += ":";
                if (mDate.Minute.ToString().Length == 1)
                {
                    mTime += "0" + mDate.Minute.ToString();
                }
                else
                {
                    mTime += mDate.Minute.ToString();
                }

                mTime += ":";
                if (mDate.Second.ToString().Length == 1)
                {
                    mTime += "0" + mDate.Second.ToString();
                }
                else
                {
                    mTime += mDate.Second.ToString();
                }

                RV = d.DayOfWeek.ToString().Substring(0, 3);
                RV += ", " + day + " " + Month.Substring(0, 3);
                RV += " " + d.Year.ToString() + " " + mTime + " GMT";
                return RV;

            }
            catch (Exception)
            {
                return null;
            }
        }
        private static String Date_MonthString(this DateTime d)
        {
            return L.DateTime_GetMonthString(d);

            /*
            String Month = "";
            if (month == 1) { Month = "January"; }
            else if (month == 2) { Month = "February"; }
            else if (month == 3) { Month = "March"; }
            else if (month == 4) { Month = "April"; }
            else if (month == 5) { Month = "May"; }
            else if (month == 6) { Month = "June"; }
            else if (month == 7) { Month = "July"; }
            else if (month == 8) { Month = "August"; }
            else if (month == 9) { Month = "September"; }
            else if (month == 10) { Month = "October"; }
            else if (month == 11) { Month = "November"; }
            else if (month == 12) { Month = "December"; }
            return Month;
             */
        }
        public static String TimeSpanToString(this TimeSpan t)
        {
            float temp = (float)t.TotalSeconds;
            String unit = "second";
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

            String Out = temp2.ToString() + " " + unit + (temp2 == 1 ? "" : "s");

            return Out;
        }
        public static String TimeDifference(this DateTime Start, DateTime Current, Boolean IncludeAgo)
        {
            if (Start == DateTime.MinValue)
                return "Never";

            String Post = "";
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
            String Unit = "Just now";

            if (Difference.Days > 365)
            {
                Amount = (int)(Difference.Days / 365);
                Unit = "year";
            }
            else if (Difference.Days > 30)
            {
                Amount = (int)(Difference.Days / 30);
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

            String Out = "";

            if (Amount > 0)
                Out += Amount.ToString() + " ";

            Out += Unit;
            if (Post != "")
            {
                Out += " " + Post;
            }

            return Out;
        }
        public static Boolean Past(this DateTime In)
        {
            return In.Ticks < DateTime.Now.Ticks;
        }
        public static Boolean Future(this DateTime In)
        {
            return In.Ticks > DateTime.Now.Ticks;
        }
        #endregion
    }
}