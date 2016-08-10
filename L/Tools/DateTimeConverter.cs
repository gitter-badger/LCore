using System;
using System.Globalization;


namespace LCore.Tools
    {
    /// <summary>
    /// Provides methods for converting <see cref="DateTime"/> structures to and from the equivalent RFC 3339 string representation.
    /// </summary>
    public static class DateTimeConverter
        {
        //============================================================
        //  Private members
        //============================================================

        #region Private Members

        /// <summary>
        /// Private member to hold array of formats that RFC 3339 date-time representations conform to.
        /// </summary>
        private static string[] _Formats = new string[0];

        /// <summary>
        /// Private member to hold the DateTime format string for representing a DateTime in the RFC 3339 format.
        /// </summary>
        private const string Format = "yyyy-MM-dd'T'HH:mm:ss.fffK";

        #endregion

        //============================================================
        //  Public Properties
        //============================================================

        #region Rfc3339DateTimeFormat

        /// <summary>
        /// Gets the custom format specifier that may be used to represent a <see cref="DateTime"/> in the RFC 3339 format.
        /// </summary>
        /// <value>A <i>DateTime format string</i> that may be used to represent a <see cref="DateTime"/> in the RFC 3339 format.</value>
        /// <remarks>
        /// <para>
        /// This method returns a string representation of a <see cref="DateTime"/> that 
        /// is precise to the three most significant digits of the seconds fraction; that is, it represents 
        /// the milliseconds in a date and time value. The <see cref="Rfc3339DateTimeFormat"/> is a valid 
        /// date-time format string for use in the <see cref="DateTime.ToString(String, IFormatProvider)"/> method.
        /// </para>
        /// </remarks>
        public static string Rfc3339DateTimeFormat => Format;

        #endregion

        #region Rfc3339DateTimePatterns

        /// <summary>
        /// Gets an array of the expected formats for RFC 3339 date-time string representations.
        /// </summary>
        /// <value>
        /// An array of the expected formats for RFC 3339 date-time string representations 
        /// that may used in the <see cref="DateTime.TryParseExact(String, string[], IFormatProvider, DateTimeStyles, out DateTime)"/> method.
        /// </value>
        public static string[] Rfc3339DateTimePatterns
            {
            get
                {
                if (_Formats.Length > 0)
                    {
                    return _Formats;
                    }
                _Formats = new string[11];

                // Rfc3339DateTimePatterns
                // ReSharper disable StringLiteralTypo
                _Formats[0] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
                _Formats[1] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffffK";
                _Formats[2] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffK";
                _Formats[3] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffK";
                _Formats[4] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK";
                _Formats[5] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffK";
                _Formats[6] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fK";
                _Formats[7] = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";

                // Fall back patterns
                _Formats[8] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK"; // RoundtripDateTimePattern
                // ReSharper restore StringLiteralTypo
                _Formats[9] = DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern;
                _Formats[10] = DateTimeFormatInfo.InvariantInfo.SortableDateTimePattern;

                return _Formats;
                }
            }

        #endregion

        //============================================================
        //  Public Methods
        //============================================================

        #region Parse(string s)

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent.
        /// </summary>
        /// <param name="Str">A string containing a date and time to convert.</param>
        /// <returns>A <see cref="DateTime"/> equivalent to the date and time contained in <paramref name="Str"/>.</returns>
        /// <remarks>
        /// The string <paramref name="Str"/> is parsed using formatting information in the <see cref="DateTimeFormatInfo.InvariantInfo"/> object.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="Str"/> is a <b>null</b> reference (Nothing in Visual Basic).</exception>
        /// <exception cref="FormatException"><paramref name="Str"/> does not contain a valid RFC 3339 string representation of a date and time.</exception>
        
        public static DateTime Parse(string Str)
            {
            //------------------------------------------------------------
            //  Validate parameter
            //------------------------------------------------------------
            if (Str == null)
                {
                throw new ArgumentNullException(nameof(Str));
                }

            DateTime Result;
            if (TryParse(Str, out Result))
                {
                return Result;
                }
            throw new FormatException($"{Str} is not a valid RFC 3339 string representation of a date and time.");
            }

        #endregion

        #region ToString(DateTime utcDateTime)

        /// <summary>
        /// Converts the value of the specified <see cref="DateTime"/> object to its equivalent string representation.
        /// </summary>
        /// <param name="UtcDateTime">The Coordinated Universal Time (UTC) <see cref="DateTime"/> to convert.</param>
        /// <returns>A RFC 3339 string representation of the value of the <paramref name="UtcDateTime"/>.</returns>
        /// <remarks>
        /// <para>
        /// This method returns a string representation of the <paramref name="UtcDateTime"/> that 
        /// is precise to the three most significant digits of the seconds fraction; that is, it represents 
        /// the milliseconds in a date and time value.
        /// </para>
        /// <para>
        /// While it is possible to display higher precision fractions of a second component of a time value, 
        /// that value may not be meaningful. The precision of date and time values depends on the resolution 
        /// of the system clock. On Windows NT 3.5 and later, and Windows Vista operating systems, the clock's 
        /// resolution is approximately 10-15 milliseconds.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentException">The specified <paramref name="UtcDateTime"/> object does not represent a <see cref="DateTimeKind.Utc">Coordinated Universal Time (UTC)</see> value.</exception>
        
        public static string ToString(DateTime UtcDateTime)
            {
            if (UtcDateTime.Kind != DateTimeKind.Utc)
                {
                UtcDateTime = UtcDateTime.ToUniversalTime();
                }

            return UtcDateTime.ToString(Rfc3339DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            }

        #endregion

        #region TryParse(string s, out DateTime result)

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent.
        /// </summary>
        /// <param name="Str">A string containing a date and time to convert.</param>
        /// <param name="Result">
        /// When this method returns, contains the <see cref="DateTime"/> value equivalent to the date and time 
        /// contained in <paramref name="Str"/>, if the conversion succeeded, 
        /// or <see cref="DateTime.MinValue">MinValue</see> if the conversion failed. 
        /// The conversion fails if the s parameter is a <b>null</b> reference (Nothing in Visual Basic), 
        /// or does not contain a valid string representation of a date and time. 
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns><b>true</b> if the <paramref name="Str"/> parameter was converted successfully; otherwise, <b>false</b>.</returns>
        /// <remarks>
        /// The string <paramref name="Str"/> is parsed using formatting information in the <see cref="DateTimeFormatInfo.InvariantInfo"/> object.
        /// </remarks>
        
        public static bool TryParse(string Str, out DateTime Result)
            {
            //------------------------------------------------------------
            //  Attempt to convert string representation
            //------------------------------------------------------------
            bool WasConverted = false;
            Result = DateTime.MinValue;

            if (!string.IsNullOrEmpty(Str))
                {
                DateTime ParseResult;
                if (DateTime.TryParseExact(Str, Rfc3339DateTimePatterns, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AdjustToUniversal,
                    out ParseResult))
                    {
                    Result = DateTime.SpecifyKind(ParseResult, DateTimeKind.Utc);
                    WasConverted = true;
                    }
                }

            return WasConverted;
            }

        #endregion
        }
    }