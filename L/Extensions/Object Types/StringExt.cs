using System;
using LCore;
using LCore.ObjectExtensions;
using System.Collections.Generic;
// using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Globalization;
using LCore.UnitTesting;
using System.Text.RegularExpressions;

namespace LCore
    {
    public partial class L : Logic
        {
        #region Base Lambdas
        #region String
        public static Func<String> String_GetEmpty = () => { return String.Empty; };
        public static Func<String, Int32, Char> String_GetAt = (s, index) => { return s[index]; };
        public static Func<String, Int32> String_GetLength = (s) => { return s.Length; };
        public static Func<String, String[], String> String_Join = (separator, value) => { return String.Join(separator, value); };
        public static Func<String, Object[], String> String_Join2 = (separator, values) => { return String.Join(separator, values); };
        public static Func<String, String[], Int32, Int32, String> String_Join5 = (separator, value, startIndex, count) => { return String.Join(separator, value, startIndex, count); };
        public static Func<String, Object, Boolean> String_Equals = (s, obj) => { return s.Equals(obj); };
        public static Func<String, String, Boolean> String_Equals2 = (s, value) => { return s.Equals(value); };
        public static Func<String, String, StringComparison, Boolean> String_Equals3 = (s, value, comparisonType) => { return s.Equals(value, comparisonType); };
        public static Func<String, String, Boolean> String_Equals4 = (a, b) => { return String.Equals(a, b); };
        public static Func<String, String, StringComparison, Boolean> String_Equals5 = (a, b, comparisonType) => { return String.Equals(a, b, comparisonType); };
        public static Func<String, String, Boolean> String_Equals6 = (a, b) => { return a == b; };
        public static Func<String, String, Boolean> String_NotEquals = (a, b) => { return a != b; };
        public static Func<String, Char[]> String_ToCharArray = (s) => { return s.ToCharArray(); };
        public static Func<String, Int32, Int32, Char[]> String_ToCharArray2 = (s, startIndex, length) => { return s.ToCharArray(startIndex, length); };
        public static Func<String, Boolean> String_IsNullOrEmpty = (value) => { return String.IsNullOrEmpty(value); };
        public static Func<String, Boolean> String_IsNullOrWhiteSpace = (value) => { return String.IsNullOrWhiteSpace(value); };
        public static Func<String, Int32> String_GetHashCode = (s) => { return s.GetHashCode(); };
        public static Func<String, Char[], String[]> String_Split = (s, separator) => { return s.Split(separator); };
        public static Func<String, Char[], Int32, String[]> String_Split2 = (s, separator, count) => { return s.Split(separator, count); };
        public static Func<String, Char[], StringSplitOptions, String[]> String_Split3 = (s, separator, options) => { return s.Split(separator, options); };
        public static Func<String, Char[], Int32, StringSplitOptions, String[]> String_Split4 = (s, separator, count, options) => { return s.Split(separator, count, options); };
        public static Func<String, String[], StringSplitOptions, String[]> String_Split5 = (s, separator, options) => { return s.Split(separator, options); };
        public static Func<String, String[], Int32, StringSplitOptions, String[]> String_Split6 = (s, separator, count, options) => { return s.Split(separator, count, options); };
        public static Func<String, Int32, String> String_Substring = (s, startIndex) => { return s.Substring(startIndex); };
        public static Func<String, Int32, Int32, String> String_Substring2 = (s, startIndex, length) => { return s.Substring(startIndex, length); };
        public static Func<String, Char[], String> String_Trim = (s, trimChars) => { return s.Trim(trimChars); };
        public static Func<String, Char[], String> String_TrimStart = (s, trimChars) => { return s.TrimStart(trimChars); };
        public static Func<String, Char[], String> String_TrimEnd = (s, trimChars) => { return s.TrimEnd(trimChars); };
        public static Func<String, Boolean> String_IsNormalized = (s) => { return s.IsNormalized(); };
        public static Func<String, NormalizationForm, Boolean> String_IsNormalized2 = (s, normalizationForm) => { return s.IsNormalized(normalizationForm); };
        public static Func<String, String> String_Normalize = (s) => { return s.Normalize(); };
        public static Func<String, NormalizationForm, String> String_Normalize2 = (s, normalizationForm) => { return s.Normalize(normalizationForm); };
        public static Func<String, String, Int32> String_Compare = (strA, strB) => { return String.Compare(strA, strB); };
        public static Func<String, String, Boolean, Int32> String_Compare2 = (strA, strB, ignoreCase) => { return String.Compare(strA, strB, ignoreCase); };
        public static Func<String, String, StringComparison, Int32> String_Compare3 = (strA, strB, comparisonType) => { return String.Compare(strA, strB, comparisonType); };
        public static Func<String, String, CultureInfo, CompareOptions, Int32> String_Compare4 = (strA, strB, culture, options) => { return String.Compare(strA, strB, culture, options); };
        public static Func<String, String, Boolean, CultureInfo, Int32> String_Compare5 = (strA, strB, ignoreCase, culture) => { return String.Compare(strA, strB, ignoreCase, culture); };
        public static Func<String, Object, Int32> String_CompareTo = (s, value) => { return s.CompareTo(value); };
        public static Func<String, String, Int32> String_CompareTo2 = (s, strB) => { return s.CompareTo(strB); };
        public static Func<String, String, Int32> String_CompareOrdinal = (strA, strB) => { return String.CompareOrdinal(strA, strB); };
        public static Func<String, String, Boolean> String_Contains = (s, value) => { return s.Contains(value); };
        public static Func<String, String, Boolean> String_EndsWith = (s, value) => { return s.EndsWith(value); };
        public static Func<String, String, StringComparison, Boolean> String_EndsWith2 = (s, value, comparisonType) => { return s.EndsWith(value, comparisonType); };
        public static Func<String, String, Boolean, CultureInfo, Boolean> String_EndsWith3 = (s, value, ignoreCase, culture) => { return s.EndsWith(value, ignoreCase, culture); };
        public static Func<String, Char, Int32> String_IndexOf = (s, value) => { return s.IndexOf(value); };
        public static Func<String, Char, Int32, Int32> String_IndexOf2 = (s, value, startIndex) => { return s.IndexOf(value, startIndex); };
        public static Func<String, Char, Int32, Int32, Int32> String_IndexOf3 = (s, value, startIndex, count) => { return s.IndexOf(value, startIndex, count); };
        public static Func<String, Char[], Int32> String_IndexOfAny = (s, anyOf) => { return s.IndexOfAny(anyOf); };
        public static Func<String, Char[], Int32, Int32> String_IndexOfAny2 = (s, anyOf, startIndex) => { return s.IndexOfAny(anyOf, startIndex); };
        public static Func<String, Char[], Int32, Int32, Int32> String_IndexOfAny3 = (s, anyOf, startIndex, count) => { return s.IndexOfAny(anyOf, startIndex, count); };
        public static Func<String, String, Int32> String_IndexOf4 = (s, value) => { return s.IndexOf(value); };
        public static Func<String, String, Int32, Int32> String_IndexOf5 = (s, value, startIndex) => { return s.IndexOf(value, startIndex); };
        public static Func<String, String, Int32, Int32, Int32> String_IndexOf6 = (s, value, startIndex, count) => { return s.IndexOf(value, startIndex, count); };
        public static Func<String, String, StringComparison, Int32> String_IndexOf7 = (s, value, comparisonType) => { return s.IndexOf(value, comparisonType); };
        public static Func<String, String, Int32, StringComparison, Int32> String_IndexOf8 = (s, value, startIndex, comparisonType) => { return s.IndexOf(value, startIndex, comparisonType); };
        public static Func<String, Char, Int32> String_LastIndexOf = (s, value) => { return s.LastIndexOf(value); };
        public static Func<String, Char, Int32, Int32> String_LastIndexOf2 = (s, value, startIndex) => { return s.LastIndexOf(value, startIndex); };
        public static Func<String, Char, Int32, Int32, Int32> String_LastIndexOf3 = (s, value, startIndex, count) => { return s.LastIndexOf(value, startIndex, count); };
        public static Func<String, Char[], Int32> String_LastIndexOfAny = (s, anyOf) => { return s.LastIndexOfAny(anyOf); };
        public static Func<String, Char[], Int32, Int32> String_LastIndexOfAny2 = (s, anyOf, startIndex) => { return s.LastIndexOfAny(anyOf, startIndex); };
        public static Func<String, Char[], Int32, Int32, Int32> String_LastIndexOfAny3 = (s, anyOf, startIndex, count) => { return s.LastIndexOfAny(anyOf, startIndex, count); };
        public static Func<String, String, Int32> String_LastIndexOf4 = (s, value) => { return s.LastIndexOf(value); };
        public static Func<String, String, Int32, Int32> String_LastIndexOf5 = (s, value, startIndex) => { return s.LastIndexOf(value, startIndex); };
        public static Func<String, String, Int32, Int32, Int32> String_LastIndexOf6 = (s, value, startIndex, count) => { return s.LastIndexOf(value, startIndex, count); };
        public static Func<String, String, StringComparison, Int32> String_LastIndexOf7 = (s, value, comparisonType) => { return s.LastIndexOf(value, comparisonType); };
        public static Func<String, String, Int32, StringComparison, Int32> String_LastIndexOf8 = (s, value, startIndex, comparisonType) => { return s.LastIndexOf(value, startIndex, comparisonType); };
        public static Func<String, Int32, String> String_PadLeft = (s, totalWidth) => { return s.PadLeft(totalWidth); };
        public static Func<String, Int32, Char, String> String_PadLeft2 = (s, totalWidth, paddingChar) => { return s.PadLeft(totalWidth, paddingChar); };
        public static Func<String, Int32, String> String_PadRight = (s, totalWidth) => { return s.PadRight(totalWidth); };
        public static Func<String, Int32, Char, String> String_PadRight2 = (s, totalWidth, paddingChar) => { return s.PadRight(totalWidth, paddingChar); };
        public static Func<String, String, Boolean> String_StartsWith = (s, value) => { return s.StartsWith(value); };
        public static Func<String, String, StringComparison, Boolean> String_StartsWith2 = (s, value, comparisonType) => { return s.StartsWith(value, comparisonType); };
        public static Func<String, String, Boolean, CultureInfo, Boolean> String_StartsWith3 = (s, value, ignoreCase, culture) => { return s.StartsWith(value, ignoreCase, culture); };
        public static Func<String, String> String_ToLower = (s) => { return s.ToLower(); };
        public static Func<String, CultureInfo, String> String_ToLower2 = (s, culture) => { return s.ToLower(culture); };
        public static Func<String, String> String_ToLowerInvariant = (s) => { return s.ToLowerInvariant(); };
        public static Func<String, String> String_ToUpper = (s) => { return s.ToUpper(); };
        public static Func<String, CultureInfo, String> String_ToUpper2 = (s, culture) => { return s.ToUpper(culture); };
        public static Func<String, String> String_ToUpperInvariant = (s) => { return s.ToUpperInvariant(); };
        public static Func<String, String> String_ToString = (s) => { return s.ToString(); };
        public static Func<String, IFormatProvider, String> String_ToString2 = (s, provider) => { return s.ToString(provider); };
        public static Func<String, Object> String_Clone = (s) => { return s.Clone(); };
        public static Func<String, String> String_Trim2 = (s) => { return s.Trim(); };
        public static Func<String, Int32, String, String> String_Insert = (s, startIndex, value) => { return s.Insert(startIndex, value); };
        public static Func<String, Char, Char, String> String_Replace = (s, oldChar, newChar) => { return s.Replace(oldChar, newChar); };
        public static Func<String, String, String, String> String_Replace2 = (s, oldValue, newValue) => { return s.Replace(oldValue, newValue); };
        public static Func<String, Int32, Int32, String> String_Remove = (s, startIndex, count) => { return s.Remove(startIndex, count); };
        public static Func<String, Int32, String> String_Remove2 = (s, startIndex) => { return s.Remove(startIndex); };
        public static Func<String, Object, String> String_Format = (format, arg0) => { return String.Format(format, arg0); };
        public static Func<String, Object, Object, String> String_Format2 = (format, arg0, arg1) => { return String.Format(format, arg0, arg1); };
        public static Func<String, Object, Object, Object, String> String_Format3 = (format, arg0, arg1, arg2) => { return String.Format(format, arg0, arg1, arg2); };
        public static Func<String, Object[], String> String_Format4 = (format, args) => { return String.Format(format, args); };
        public static Func<IFormatProvider, String, Object[], String> String_Format5 = (provider, format, args) => { return String.Format(provider, format, args); };
        public static Func<String, String> String_Copy = (str) => { return String.Copy(str); };
        public static Func<Object, String> String_Concat = (arg0) => { return String.Concat(arg0); };
        public static Func<Object, Object, String> String_Concat2 = (arg0, arg1) => { return String.Concat(arg0, arg1); };
        public static Func<Object, Object, Object, String> String_Concat3 = (arg0, arg1, arg2) => { return String.Concat(arg0, arg1, arg2); };
        public static Func<Object, Object, Object, Object, String> String_Concat4 = (arg0, arg1, arg2, arg3) => { return String.Concat(arg0, arg1, arg2, arg3); };
        public static Func<Object[], String> String_Concat5 = (args) => { return String.Concat(args); };
        public static Func<String, String, String> String_Concat8 = (str0, str1) => { return String.Concat(str0, str1); };
        public static Func<String, String, String, String> String_Concat9 = (str0, str1, str2) => { return String.Concat(str0, str1, str2); };
        public static Func<String, String, String, String, String> String_Concat10 = (str0, str1, str2, str3) => { return String.Concat(str0, str1, str2, str3); };
        public static Func<String[], String> String_Concat11 = (values) => { return String.Concat(values); };
        public static Func<String, String> String_Intern = (str) => { return String.Intern(str); };
        public static Func<String, String> String_IsInterned = (str) => { return String.IsInterned(str); };
        public static Func<String, TypeCode> String_GetTypeCode = (s) => { return s.GetTypeCode(); };
        public static Func<String, CharEnumerator> String_GetEnumerator = (s) => { return s.GetEnumerator(); };
        public static Func<Char[], Int32, Int32, String> String_New = (value, startIndex, length) => { return new String(value, startIndex, length); };
        public static Func<Char[], String> String_New2 = (value) => { return new String(value); };
        public static Func<Char, Int32, String> String_New3 = (c, count) => { return new String(c, count); };
        /* Too Many Parameters :( 
        public static Action<String, Int32, Char[], Int32, Int32> String_CopyTo = (s, sourceIndex, destination, destinationIndex, count) => {s.CopyTo(sourceIndex, destination, destinationIndex, count); };
        public static Func<String, Int32, String, Int32, Int32, Int32> String_Compare6 = (strA, indexA, strB, indexB, length) => { return String.Compare(strA, indexA, strB, indexB, length); };
        public static Func<String, Int32, String, Int32, Int32, Boolean, Int32> String_Compare7 = (strA, indexA, strB, indexB, length, ignoreCase) => { return String.Compare(strA, indexA, strB, indexB, length, ignoreCase); };
        public static Func<String, Int32, String, Int32, Int32, Boolean, CultureInfo, Int32> String_Compare8 = (strA, indexA, strB, indexB, length, ignoreCase, culture) => { return String.Compare(strA, indexA, strB, indexB, length, ignoreCase, culture); };
        public static Func<String, Int32, String, Int32, Int32, CultureInfo, CompareOptions, Int32> String_Compare9 = (strA, indexA, strB, indexB, length, culture, options) => { return String.Compare(strA, indexA, strB, indexB, length, culture, options); };
        public static Func<String, Int32, String, Int32, Int32, StringComparison, Int32> String_Compare10 = (strA, indexA, strB, indexB, length, comparisonType) => { return String.Compare(strA, indexA, strB, indexB, length, comparisonType); };
        public static Func<String, Int32, String, Int32, Int32, Int32> String_CompareOrdinal2 = (strA, indexA, strB, indexB, length) => { return String.CompareOrdinal(strA, indexA, strB, indexB, length); };
        public static Func<String, String, Int32, Int32, StringComparison, Int32> String_IndexOf9 = (s, value, startIndex, count, comparisonType) => { return s.IndexOf(value, startIndex, count, comparisonType); };
        public static Func<String, String, Int32, Int32, StringComparison, Int32> String_LastIndexOf9 = (s, value, startIndex, count, comparisonType) => { return s.LastIndexOf(value, startIndex, count, comparisonType); };
        */
        /* No Generic Types 
        public static Func<String, IEnumerable`1, String> String_Join3 = (separator, values) => { return String.Join(separator, values); };
        public static Func<String, IEnumerable`1, String> String_Join4 = (separator, values) => { return String.Join(separator, values); };
        public static Func<IEnumerable`1, String> String_Concat6 = (values) => { return String.Concat(values); };
        public static Func<IEnumerable`1, String> String_Concat7 = (values) => { return String.Concat(values); };
        */
        #endregion
        #region Char
        public static Func<Char> Char_GetMaxValue = () => { return Char.MaxValue; };
        public static Func<Char> Char_GetMinValue = () => { return Char.MinValue; };
        public static Func<Char, Int32> Char_GetHashCode = (c) => { return c.GetHashCode(); };
        public static Func<Char, Object, Boolean> Char_Equals = (c, obj) => { return c.Equals(obj); };
        public static Func<Char, Char, Boolean> Char_Equals2 = (c, obj) => { return c.Equals(obj); };
        public static Func<Char, Object, Int32> Char_CompareTo = (c, value) => { return c.CompareTo(value); };
        public static Func<Char, Char, Int32> Char_CompareTo2 = (c, value) => { return c.CompareTo(value); };
        public static Func<Char, String> Char_ToString = (c) => { return c.ToString(); };
        public static Func<Char, IFormatProvider, String> Char_ToString2 = (c, provider) => { return c.ToString(provider); };
        public static Func<Char, String> Char_ToString3 = (c) => { return Char.ToString(c); };
        public static Func<String, Char> Char_Parse = (s) => { return Char.Parse(s); };
        /* No Ref or Out Types 
        public static Func<String, Char&, Boolean> Char_TryParse = (s, result) => { return Char.TryParse(s, result); };
        */
        public static Func<Char, Boolean> Char_IsDigit = (c) => { return Char.IsDigit(c); };
        public static Func<Char, Boolean> Char_IsLetter = (c) => { return Char.IsLetter(c); };
        public static Func<Char, Boolean> Char_IsWhiteSpace = (c) => { return Char.IsWhiteSpace(c); };
        public static Func<Char, Boolean> Char_IsUpper = (c) => { return Char.IsUpper(c); };
        public static Func<Char, Boolean> Char_IsLower = (c) => { return Char.IsLower(c); };
        public static Func<Char, Boolean> Char_IsPunctuation = (c) => { return Char.IsPunctuation(c); };
        public static Func<Char, Boolean> Char_IsLetterOrDigit = (c) => { return Char.IsLetterOrDigit(c); };
        public static Func<Char, CultureInfo, Char> Char_ToUpper = (c, culture) => { return Char.ToUpper(c, culture); };
        public static Func<Char, Char> Char_ToUpper2 = (c) => { return Char.ToUpper(c); };
        public static Func<Char, Char> Char_ToUpperInvariant = (c) => { return Char.ToUpperInvariant(c); };
        public static Func<Char, CultureInfo, Char> Char_ToLower = (c, culture) => { return Char.ToLower(c, culture); };
        public static Func<Char, Char> Char_ToLower2 = (c) => { return Char.ToLower(c); };
        public static Func<Char, Char> Char_ToLowerInvariant = (c) => { return Char.ToLowerInvariant(c); };
        public static Func<Char, TypeCode> Char_GetTypeCode = (c) => { return c.GetTypeCode(); };
        public static Func<Char, Boolean> Char_IsControl = (c) => { return Char.IsControl(c); };
        public static Func<String, Int32, Boolean> Char_IsControl2 = (s, index) => { return Char.IsControl(s, index); };
        public static Func<String, Int32, Boolean> Char_IsDigit2 = (s, index) => { return Char.IsDigit(s, index); };
        public static Func<String, Int32, Boolean> Char_IsLetter2 = (s, index) => { return Char.IsLetter(s, index); };
        public static Func<String, Int32, Boolean> Char_IsLetterOrDigit2 = (s, index) => { return Char.IsLetterOrDigit(s, index); };
        public static Func<String, Int32, Boolean> Char_IsLower2 = (s, index) => { return Char.IsLower(s, index); };
        public static Func<Char, Boolean> Char_IsNumber = (c) => { return Char.IsNumber(c); };
        public static Func<String, Int32, Boolean> Char_IsNumber2 = (s, index) => { return Char.IsNumber(s, index); };
        public static Func<String, Int32, Boolean> Char_IsPunctuation2 = (s, index) => { return Char.IsPunctuation(s, index); };
        public static Func<Char, Boolean> Char_IsSeparator = (c) => { return Char.IsSeparator(c); };
        public static Func<String, Int32, Boolean> Char_IsSeparator2 = (s, index) => { return Char.IsSeparator(s, index); };
        public static Func<Char, Boolean> Char_IsSurrogate = (c) => { return Char.IsSurrogate(c); };
        public static Func<String, Int32, Boolean> Char_IsSurrogate2 = (s, index) => { return Char.IsSurrogate(s, index); };
        public static Func<Char, Boolean> Char_IsSymbol = (c) => { return Char.IsSymbol(c); };
        public static Func<String, Int32, Boolean> Char_IsSymbol2 = (s, index) => { return Char.IsSymbol(s, index); };
        public static Func<String, Int32, Boolean> Char_IsUpper2 = (s, index) => { return Char.IsUpper(s, index); };
        public static Func<String, Int32, Boolean> Char_IsWhiteSpace2 = (s, index) => { return Char.IsWhiteSpace(s, index); };
        public static Func<Char, UnicodeCategory> Char_GetUnicodeCategory = (c) => { return Char.GetUnicodeCategory(c); };
        public static Func<String, Int32, UnicodeCategory> Char_GetUnicodeCategory2 = (s, index) => { return Char.GetUnicodeCategory(s, index); };
        public static Func<Char, Double> Char_GetNumericValue = (c) => { return Char.GetNumericValue(c); };
        public static Func<String, Int32, Double> Char_GetNumericValue2 = (s, index) => { return Char.GetNumericValue(s, index); };
        public static Func<Char, Boolean> Char_IsHighSurrogate = (c) => { return Char.IsHighSurrogate(c); };
        public static Func<String, Int32, Boolean> Char_IsHighSurrogate2 = (s, index) => { return Char.IsHighSurrogate(s, index); };
        public static Func<Char, Boolean> Char_IsLowSurrogate = (c) => { return Char.IsLowSurrogate(c); };
        public static Func<String, Int32, Boolean> Char_IsLowSurrogate2 = (s, index) => { return Char.IsLowSurrogate(s, index); };
        public static Func<String, Int32, Boolean> Char_IsSurrogatePair = (s, index) => { return Char.IsSurrogatePair(s, index); };
        public static Func<Char, Char, Boolean> Char_IsSurrogatePair2 = (highSurrogate, lowSurrogate) => { return Char.IsSurrogatePair(highSurrogate, lowSurrogate); };
        public static Func<Int32, String> Char_ConvertFromUtf32 = (utf32) => { return Char.ConvertFromUtf32(utf32); };
        public static Func<Char, Char, Int32> Char_ConvertToUtf32 = (highSurrogate, lowSurrogate) => { return Char.ConvertToUtf32(highSurrogate, lowSurrogate); };
        public static Func<String, Int32, Int32> Char_ConvertToUtf322 = (s, index) => { return Char.ConvertToUtf32(s, index); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #endregion

        #region ToS
        public static Func<Object, String> ToS =
            (o) =>
                {
                if (o == null)
                    return "";
                else if (o is String)
                    {
                    return (String)o;
                    }
                else if (o is IEnumerable)
                    {
                    return o.GetType().FullName + " { " + ((IEnumerable)o).Array().Convert(L.ToS).Combine(", ") + " }";
                    }
                else
                    {
                    return o.ToString();
                    }
                };
        #endregion
        }
    public partial class Logic
        {
        public const String NewLineString = "\r\n"; // System.Environment.NewLine 
        public const char NewLineChar = '\n';

        public static char[] Char_LowerCaseChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static char[] Char_UpperCaseChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static char[] Char_NumberChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] Char_SpecialChars = new char[] { '!', '@', '#', '$', '%', '*', '_' };

        #region Lambdas
        public static Func<String> String_Empty = () => { return ""; };
        public static Func<String, int, char> String_Char = (s, i) => { return s[i]; };
        public static Func<Char[], Char, Char, Char> Char_Substitute = (chars, c, sub) => { return chars.Contains(c) ? sub : c; };
        public static Func<String, Char[], String> String_RemoveChars = (s, chars) =>
        {
            return s.Collect(Char_Substitute.Supply(chars).Supply2(' '))
                .ReplaceAll("  ", " ").Trim();
        };
        public static Func<String, Char, String> String_ReplaceDouble = (s, c) =>
        {
            String s2 = c.ToString();
            return s.ReplaceAll(s2 + s2, s2);
        };
        public static Func<String, int, String> String_Pluralize = (s, c) =>
        {
            if (s.IsEmpty())
                return "";

            if (c == 0 || Math.Abs(c) > 1)
                return System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(s);
            else
                return s ?? "";
        };
        public static Func<String, String> String_Singularize = (s) =>
        {
            if (s.IsEmpty())
                return "";

            return System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.CurrentCulture).Singularize(s);
        };
        public static Func<IEnumerable<String>, String, String> String_JoinLines = (l, s) =>
        {
            return l.Combine(s);
        };
        public static Func<String, String, String, String> String_Surround = (In, before, after) =>
        {
            if (In.IsEmpty())
                return "";

            return before + In + after;
        };
        public static Func<String, String, int> String_NumericalCompare = (s1, s2) =>
        {
            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            while (marker1 < len1 && marker2 < len2)
                {
                char ch1 = s1[marker1];
                char ch2 = s2[marker2];

                // Some buffers we can build up characters in for each chunk.
                char[] space1 = new char[len1];
                int loc1 = 0;
                char[] space2 = new char[len2];
                int loc2 = 0;

                // Walk through all following characters that are digits or
                // characters in BOTH strings starting at the appropriate marker.
                // Collect char arrays.
                do
                    {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                        {
                        ch1 = s1[marker1];
                        }
                    else
                        {
                        break;
                        }
                    } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                    {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                        {
                        ch2 = s2[marker2];
                        }
                    else
                        {
                        break;
                        }
                    } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                // If we have collected numbers, compare them numerically.
                // Otherwise, if we have strings, compare them alphabetically.
                string str1 = new string(space1);
                string str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                    {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                else
                    {
                    result = str1.CompareTo(str2);
                    }

                if (result != 0)
                    {
                    return result;
                    }
                }
            return len1 - len2;
        };
        #endregion
        }
    public static class StringExt
        {
        public const char CRLFReplace = (char)222;

        #region Split
        /// <summary>
        /// Takes a String and returns a String[] split by the [SplitStr]
        /// This method will throw an Excpetion if [SplitStr] is empty.
        /// </summary>
        [TestFails(new Object[] { null, null })]
        [TestFails(new Object[] { "", null })]
        [TestFails(new Object[] { "a", null })]
        [TestFails(new Object[] { null, "" })]
        [TestFails(new Object[] { "", "" })]
        [TestFails(new Object[] { "a", "" })]
        [TestResult(new Object[] { null, "a" }, new String[] { })]
        [TestResult(new Object[] { "", "a" }, new String[] { })]
        [TestResult(new Object[] { "a", "a" }, new String[] { })]
        [TestResult(new Object[] { "bab", "a" }, new String[] { "b", "b" })]
        [TestResult(new Object[] { "babab", "a" }, new String[] { "b", "b", "b" })]
        [TestResult(new Object[] { "abababa", "a" }, new String[] { "b", "b", "b" })]
        public static String[] Split(this String In, String SplitStr)
            {
            if (SplitStr == null || SplitStr.Length == 0)
                throw new ArgumentNullException("SplitStr");

            if (In.IsEmpty())
                return new String[] { };

            int i = In.IndexOf(SplitStr);

            if (i < 0)
                {
                if (!In.IsEmpty())
                    {
                    return new String[] { In };
                    }
                else
                    {
                    return new String[] { };
                    }
                }

            List<String> Out = new List<String>();
            In.Traverse((Cursor) =>
            {
                int Index = Cursor.IndexOf(SplitStr);
                if (Index < 0)
                    {
                    if (Cursor.Length > 0)
                        {
                        Out.Add(Cursor);
                        }
                    return null;
                    }
                else if (Index == 0)
                    {
                    if (Cursor.Length > SplitStr.Length)
                        {
                        return Cursor.Substring(SplitStr.Length);
                        }
                    else
                        {
                        return null;
                        }
                    }
                else if (Index > 0)
                    {
                    Out.Add(Cursor.Substring(0, Index));
                    return Cursor.Substring(Index);
                    }
                else // Should never happen
                    {
                    return null;
                    }
            });
            /*
            while (Cursor.Length > 0)
                {
                int Index = Cursor.IndexOf(SplitStr);
                if (Index < 0)
                    {
                    if (Cursor.Length > 0)
                        {
                        Out.Add(Cursor);
                        }
                    break;
                    }
                else if (Index == 0)
                    {
                    if (Cursor.Length > SplitStr.Length)
                        {
                        Cursor = Cursor.Substring(SplitStr.Length);
                        continue;
                        }
                    else
                        {
                        break;
                        }
                    }
                else if (Index > 0)
                    {
                    Out.Add(Cursor.Substring(0, Index));
                    Cursor = Cursor.Substring(Index);
                    }
                }*/

            return Out.ToArray();
            }
        #endregion
        #region LeftAlign
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
        /// </summary>
        [TestFails(new Object[] { null, -1, (char)0 })]
        [TestFails(new Object[] { "a", -1, ' ' })]
        [TestResult(new Object[] { null, 5, ' ' }, "     ")]
        [TestResult(new Object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new Object[] { "a", 5, ' ' }, "a    ")]
        [TestResult(new Object[] { "abc", 5, ' ' }, "abc  ")]
        [TestResult(new Object[] { "   abc   ", 5, ' ' }, "abc  ")]
        [TestResult(new Object[] { "abcdef", 5, ' ' }, "abcde")]
        public static String LeftAlign(this String In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Left, PadChar);
            }
        #endregion
        #region RightAlign
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
        /// </summary>
        [TestFails(new Object[] { null, -1, (char)0 })]
        [TestFails(new Object[] { "a", -1, ' ' })]
        [TestResult(new Object[] { null, 5, ' ' }, "     ")]
        [TestResult(new Object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new Object[] { "a", 5, ' ' }, "    a")]
        [TestResult(new Object[] { "abc", 5, ' ' }, "  abc")]
        [TestResult(new Object[] { "   abc   ", 5, ' ' }, "  abc")]
        [TestResult(new Object[] { "abcdef", 5, ' ' }, "abcde")]
        public static String RightAlign(this String In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Right, PadChar);
            }
        #endregion
        #region CenterAlign
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
        /// </summary>
        [TestFails(new Object[] { null, -1, (char)0 })]
        [TestFails(new Object[] { "a", -1, ' ' })]
        [TestResult(new Object[] { null, 5, ' ' }, "     ")]
        [TestResult(new Object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new Object[] { "a", 5, ' ' }, "  a  ")]
        [TestResult(new Object[] { "abc", 5, ' ' }, " abc ")]
        [TestResult(new Object[] { "   abc   ", 5, ' ' }, " abc ")]
        [TestResult(new Object[] { "abcdef", 5, ' ' }, "abcde")]
        public static String CenterAlign(this String In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Center, PadChar);
            }
        #endregion
        #region Pad
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
        /// </summary>
        [TestFails(new Object[] { null, -1, L.Align.Right, (char)0 })]
        [TestFails(new Object[] { "a", -1, L.Align.Right, ' ' })]
        [TestResult(new Object[] { null, 5, L.Align.Left, ' ' }, "     ")]
        [TestResult(new Object[] { " ", 5, L.Align.Left, ' ' }, "     ")]
        [TestResult(new Object[] { "a", 5, L.Align.Left, ' ' }, "a    ")]
        [TestResult(new Object[] { "a", 5, L.Align.Right, ' ' }, "    a")]
        [TestResult(new Object[] { "a", 5, L.Align.Center, ' ' }, "  a  ")]
        [TestResult(new Object[] { "abc", 5, L.Align.Left, ' ' }, "abc  ")]
        [TestResult(new Object[] { "abc", 5, L.Align.Right, ' ' }, "  abc")]
        [TestResult(new Object[] { "abc", 5, L.Align.Center, ' ' }, " abc ")]
        [TestResult(new Object[] { "   abc   ", 5, L.Align.Right, ' ' }, "  abc")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Left, ' ' }, "abcde")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Right, ' ' }, "abcde")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Center, ' ' }, "abcde")]
        [TestResult(new Object[] { null, 5, L.Align.Left, '0' }, "00000")]
        [TestResult(new Object[] { " ", 5, L.Align.Left, '0' }, "00000")]
        [TestResult(new Object[] { "a", 5, L.Align.Left, '0' }, "a0000")]
        [TestResult(new Object[] { "a", 5, L.Align.Right, '0' }, "0000a")]
        [TestResult(new Object[] { "a", 5, L.Align.Center, '0' }, "00a00")]
        [TestResult(new Object[] { "abc", 5, L.Align.Left, '0' }, "abc00")]
        [TestResult(new Object[] { "abc", 5, L.Align.Right, '0' }, "00abc")]
        [TestResult(new Object[] { "abc", 5, L.Align.Center, '0' }, "0abc0")]
        [TestResult(new Object[] { "   abc   ", 5, L.Align.Left, '0' }, "abc00")]
        [TestResult(new Object[] { "   abc   ", 5, L.Align.Right, '0' }, "00abc")]
        [TestResult(new Object[] { "   abc   ", 5, L.Align.Center, '0' }, "0abc0")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Left, '0' }, "abcde")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Right, '0' }, "abcde")]
        [TestResult(new Object[] { "abcdef", 5, L.Align.Center, '0' }, "abcde")]
        [TestResult(new Object[] { "   abc   ", 6, L.Align.Center, '0' }, "00abc0")]
        public static String Pad(this String In, int Length, L.Align Alignment = L.Align.Left, char PadChar = ' ')
            {
            if (In.IsEmpty())
                return PadChar.Fill(Length);

            In = In.Trim();

            if (In.Length > Length)
                return In.Substring(0, Length);
            else
                {
                while (In.Length < Length)
                    {
                    if (Alignment == L.Align.Left)
                        In += PadChar;
                    else if (Alignment == L.Align.Right)
                        In = PadChar + In;
                    else if (Alignment == L.Align.Center)
                        {
                        if (In.Length % 2 == 0)
                            In += PadChar;
                        else
                            In = PadChar + In;
                        }
                    }

                return In;
                }
            }
        #endregion
        #region Pluralize
        /// <summary>
        /// Takes a string and returns a pluralized version of the word or phrase.
        /// This method will not fail. If the input is empty it will just return "".
        /// </summary>
        [TestResult(new Object[] { null, -1 }, "")]
        [TestResult(new Object[] { "", -1 }, "")]
        [TestResult(new Object[] { "blob", -2 }, "blobs")]
        [TestResult(new Object[] { "blob", -1 }, "blob")]
        [TestResult(new Object[] { "blob", 0 }, "blobs")]
        [TestResult(new Object[] { "blob", 1 }, "blob")]
        [TestResult(new Object[] { "blob", 2 }, "blobs")]
        [TestResult(new Object[] { "person", 2 }, "people")]
        [TestResult(new Object[] { "person", 1 }, "person")]
        [TestResult(new Object[] { "Entry", 2 }, "Entries")]
        public static String Pluralize(this String In, int Count)
            {
            return L.String_Pluralize(In, Count);
            }
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { "blob" }, "blobs")]
        [TestResult(new Object[] { "person" }, "people")]
        [TestResult(new Object[] { "Entry" }, "Entries")]
        [TestResult(new Object[] { "Entries" }, "Entries")]
        public static String Pluralize(this String In)
            {
            return L.String_Pluralize(In, 2);
            }
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { "blobs" }, "blob")]
        [TestResult(new Object[] { "people" }, "person")]
        [TestResult(new Object[] { "Entries" }, "Entry")]
        [TestResult(new Object[] { "Entry" }, "Entry")]
        public static String Singularize(this String In)
            {
            return L.String_Singularize(In);
            }
        #endregion
        #region Fill
        /// <summary>
        /// Returns a String filled with [Count] characters of the source character.
        /// Throws an exception if [Count] is less than 0.
        /// </summary>
        [TestFails(new Object[] { 'a', -1 })]
        [TestResult(new Object[] { 'a', 0 }, "")]
        [TestResult(new Object[] { 'a', 3 }, "aaa")]
        [TestResult(new Object[] { 'z', 5 }, "zzzzz")]
        public static String Fill(this char In, int Count)
            {
            return new String(new char[Count].Collect<char>((o) => In));
            }
        #endregion
        #region IsEmpty
        /// <summary>
        /// Pass it any string reference to determine whether a String is null or Empty.
        /// This method will not fail.
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        [TestResult(new Object[] { "" }, true)]
        [TestResult(new Object[] { null }, true)]
        [TestResult(new Object[] { " " }, true)]
        [TestResult(new Object[] { "     " }, true)]
        [TestResult(new Object[] { "a" }, false)]
        public static Boolean IsEmpty(this String In)
            {
            return In == null || In.Trim() == "";
            }
        #endregion
        #region FormatFileSize
        /// <summary>
        /// Formats a file size Long into a friendly string, up to TB.
        /// </summary>
        [TestFails(new Object[] { (long)-1 })]
        [TestResult(new Object[] { (long)0 }, "0 B")]
        [TestResult(new Object[] { (long)1 }, "1 B")]
        [TestResult(new Object[] { (long)1024 }, "1 KB")]
        [TestResult(new Object[] { (long)1024 + (long)411 }, "1 KB")]
        [TestResult(new Object[] { (long)1024 + (long)512 }, "2 KB")]
        [TestResult(new Object[] { (long)((long)1024 * (long)1024 + (long)512) }, "1 MB")]
        [TestResult(new Object[] { (long)((long)1024 * (long)1024) }, "1 MB")]
        [TestResult(new Object[] { (long)(((long)1024 * (long)1024) * 5) }, "5 MB")]
        [TestResult(new Object[] { (long)((long)1024 * (long)1024 * (long)1024) }, "1 GB")]
        [TestResult(new Object[] { (long)((long)1024 * (long)1024 * (long)1024 * (long)1024) }, "1 TB")]
        [TestResult(new Object[] { (long)35572226 }, "34 MB")]
        public static String FormatFileSize(this long Size)
            {
            return FormatFileSize(Size, 0);
            }
        [TestFails(new Object[] { (int)-1 })]
        [TestResult(new Object[] { (int)0 }, "0 B")]
        [TestResult(new Object[] { (int)1 }, "1 B")]
        [TestResult(new Object[] { (int)1024 }, "1 KB")]
        [TestResult(new Object[] { (int)1024 + (int)411 }, "1 KB")]
        [TestResult(new Object[] { (int)1024 + (int)512 }, "2 KB")]
        [TestResult(new Object[] { (int)((int)1024 * (int)1024 + (int)512) }, "1 MB")]
        [TestResult(new Object[] { (int)((int)1024 * (int)1024) }, "1 MB")]
        [TestResult(new Object[] { (int)(((int)1024 * (int)1024) * 5) }, "5 MB")]
        [TestResult(new Object[] { (int)((int)1024 * (int)1024 * (int)1024) }, "1 GB")]
        [TestResult(new Object[] { (int)35572226 }, "34 MB")]
        public static String FormatFileSize(this int Size)
            {
            return FormatFileSize(Size, 0);
            }
        #endregion
        #region FormatFileSize
        /// <summary>
        /// Formats a file size Long into a friendly string, up to TB.
        /// The result will be displayed with [Decimals] shown. Bytes will not display decimals.
        /// </summary>
        [TestFails(new Object[] { (long)-1, 1 })]
        [TestFails(new Object[] { (long)1024 + (long)512, -1 })]
        [TestResult(new Object[] { (long)0, 3 }, "0 B")]
        [TestResult(new Object[] { (long)450, 3 }, "450 B")]
        [TestResult(new Object[] { (long)1024 + (long)412, 0 }, "1 KB")]
        [TestResult(new Object[] { (long)1024 + (long)512, 0 }, "2 KB")]
        [TestResult(new Object[] { (long)1024 + (long)512, 2 }, "1.50 KB")]
        [TestResult(new Object[] { (long)1024 + (long)512, 3 }, "1.500 KB")]
        [TestResult(new Object[] { (long)(((long)1024 * (long)1024 * (long)1024 * (long)1024) * (float)1.5), 5 }, "1.50000 TB")]
        [TestResult(new Object[] { (long)35572226, 5 }, "33.92432 MB")]
        public static String FormatFileSize(this long Size, int Decimals)
            {
            if (Size < 0 || Decimals < 0)
                throw new ArgumentException("Size cannot be negative");

            double temp = (double)Size;
            String Unit = "B";
            if (temp >= 1024)
                {
                temp = temp / 1024;
                Unit = "KB";
                if (temp >= 1024)
                    {
                    temp = temp / 1024;
                    Unit = "MB";
                    if (temp >= 1024)
                        {
                        temp = temp / 1024;
                        Unit = "GB";
                        if (temp >= 1024)
                            {
                            temp = temp / 1024;
                            Unit = "TB";
                            }
                        }
                    }
                double Power = System.Math.Pow(10, (double)Decimals);
                temp = Math.Round(temp * Power) / Power;
                }
            String Out = temp.ToString();

            if (Decimals > 0 && Unit != "B")
                {
                if (!Out.Contains("."))
                    {
                    Out += "." + '0'.Fill(Decimals);
                    }
                else
                    {
                    while (Out.Substring(Out.IndexOf(".") + 1).Length != Decimals)
                        {
                        Out += "0";
                        }
                    }
                }

            return Out + " " + Unit;
            }

        /// <summary>
        /// Formats a file size int into a friendly string, up to TB.
        /// The result will be displayed with [Decimals] shown. Bytes will not display decimals.
        /// </summary>
        [TestFails(new Object[] { (int)-1, 1 })]
        [TestFails(new Object[] { (int)1024 + (int)512, -1 })]
        [TestResult(new Object[] { (int)0, 3 }, "0 B")]
        [TestResult(new Object[] { (int)450, 3 }, "450 B")]
        [TestResult(new Object[] { (int)1024 + (int)412, 0 }, "1 KB")]
        [TestResult(new Object[] { (int)1024 + (int)512, 0 }, "2 KB")]
        [TestResult(new Object[] { (int)1024 + (int)512, 2 }, "1.50 KB")]
        [TestResult(new Object[] { (int)1024 + (int)512, 3 }, "1.500 KB")]
        [TestResult(new Object[] { (int)35572226, 5 }, "33.92432 MB")]
        public static String FormatFileSize(this int Size, int Decimals)
            {
            if (Size < 0 || Decimals < 0)
                throw new ArgumentException("Size cannot be negative");

            double temp = (double)Size;
            String Unit = "B";
            if (temp >= 1024)
                {
                temp = temp / 1024;
                Unit = "KB";
                if (temp >= 1024)
                    {
                    temp = temp / 1024;
                    Unit = "MB";
                    if (temp >= 1024)
                        {
                        temp = temp / 1024;
                        Unit = "GB";
                        if (temp >= 1024)
                            {
                            temp = temp / 1024;
                            Unit = "TB";
                            }
                        }
                    }
                double Power = System.Math.Pow(10, (double)Decimals);
                temp = Math.Round(temp * Power) / Power;
                }
            String Out = temp.ToString();

            if (Decimals > 0 && Unit != "B")
                {
                if (!Out.Contains("."))
                    {
                    Out += "." + '0'.Fill(Decimals);
                    }
                else
                    {
                    while (Out.Substring(Out.IndexOf(".") + 1).Length != Decimals)
                        {
                        Out += "0";
                        }
                    }
                }

            return Out + " " + Unit;
            }
        #endregion
        #region ContainsAny
        /// <summary>
        /// Takes a string and returns whether it contains any of the strings in the collection
        /// This method will not fail.
        /// </summary>
        [TestResult(new Object[] { null, null }, false)]
        [TestResult(new Object[] { null, new String[] { } }, false)]
        [TestResult(new Object[] { null, new String[] { null } }, false)]
        [TestResult(new Object[] { null, new String[] { "" } }, false)]
        [TestResult(new Object[] { null, new String[] { "a" } }, false)]
        [TestResult(new Object[] { "a", new String[] { "a" } }, true)]
        [TestResult(new Object[] { "blah", new String[] { "a" } }, true)]
        [TestResult(new Object[] { "BLAH", new String[] { "a" } }, false)]
        [TestResult(new Object[] { "BLAH", new String[] { "a", "A" } }, true)]
        public static Boolean ContainsAny(this String In, IEnumerable<String> Find)
            {
            if (In.IsEmpty() || Find.IsEmpty())
                return false;

            return Find.Count<String>((find) =>
            {
                return In.Contains(find);
            }) > 0;
            }
        #endregion
        #region FirstCaps
        /// <summary>
        /// Formats an input string so that it is TitleCase.
        /// This method will not fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { "BLAH" }, "Blah")]
        [TestResult(new Object[] { "blah" }, "Blah")]
        [TestResult(new Object[] { "bLaH" }, "Blah")]
        [TestResult(new Object[] { "bLaH bLaH" }, "Blah Blah")]
        public static String FirstCaps(this String Value)
            {
            if (Value.IsEmpty())
                return "";

            StringBuilder sb = new StringBuilder(Value.Length);
            // Upper the first char.
            sb.Append(char.ToUpper(Value[0]));

            Value.EachI((i, ch) =>
            {
                if (i == 0)
                    return;

                // Get the current char.
                char c = ch;

                // Upper if after a space.
                if (i > 0 && char.IsWhiteSpace(Value[i - 1]))
                    c = char.ToUpper(c);
                else
                    c = char.ToLower(c);

                sb.Append(c);
            });

            return sb.ToString();
            }
        #endregion
        #region IsNumber
        /// <summary>
        /// Returns whethre a char is a number.
        /// This method will not fail.
        /// </summary>
        [TestResult(new Object[] { 'a' }, false)]
        [TestResult(new Object[] { '0' }, true)]
        [TestResult(new Object[] { '9' }, true)]
        public static Boolean IsNumber(this char In)
            {
            return In >= '0' && In <= '9';
            }
        #endregion
        #region Combine
        /// <summary>
        /// Takes an 
        /// </summary>
        [TestResult(new Object[] { null, null }, "")]
        [TestResult(new Object[] { null, "" }, "")]
        [TestResult(new Object[] { null, "a" }, "")]
        [TestResult(new Object[] { new String[] { }, null }, "")]
        [TestResult(new Object[] { new String[] { }, "" }, "")]
        [TestResult(new Object[] { new String[] { }, "a" }, "")]
        [TestResult(new Object[] { new String[] { "b" }, "a" }, "b")]
        [TestResult(new Object[] { new String[] { "b", "b" }, "a" }, "bab")]
        [TestResult(new Object[] { new String[] { "b", "b", "b" }, "a" }, "babab")]
        [TestResult(new Object[] { new String[] { "b", "b", "b" }, "_a_" }, "b_a_b_a_b")]
        public static String Combine(this IEnumerable<String> In, String CombineStr)
            {
            String Out = "";
            int Count = In.Count();
            In.EachI((i, o) =>
            {
                Out += o;
                if (i < Count - 1)
                    Out += CombineStr;
            });
            return Out;
            }
        #endregion
        #region Humanize
        /// <summary>
        /// Takes a String and returns a String inserting spaces where there are capital letters in the word. 
        /// Ex. "VeryGoodExample"  ->  "Very Good Example"
        /// This method will not fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { "a" }, "A")]
        [TestResult(new Object[] { "A" }, "A")]
        [TestResult(new Object[] { "blah" }, "Blah")]
        [TestResult(new Object[] { "BlahBlahBlah" }, "Blah Blah Blah")]
        [TestResult(new Object[] { "blah_blah_blah" }, "Blah Blah Blah")]
        [TestResult(new Object[] { "Blah0Blah1Blah2" }, "Blah 0 Blah 1 Blah 2")]
        [TestResult(new Object[] { "VeryGoodExample" }, "Very Good Example")]
        public static String Humanize(this String FieldName)
            {
            char last = ' ';

            String Out = (FieldName ?? "").Trim().CollectStr<char, String>(
                (i, c) =>
                    {
                    if (i == 0 ||
                        (last.IsNumber() && !c.IsNumber()) ||
                        (!last.IsNumber() && c.IsNumber()) ||
                        (!Char.IsUpper(last) && Char.IsUpper(c)))
                        {
                        last = c;
                        return (i != 0 ? " " : "") + c.ToString().ToUpper();
                        }
                    else
                        {
                        last = c;
                        return c.ToString();
                        }
                    }).Trim();
            Out = Out.Replace("_", " ");
            Out = Out.ReplaceAll("  ", " ");

            return Out.FirstCaps();
            }
        #endregion
        #region ReplaceAll
        /// <summary>
        /// Takes a string and returns a string with all Occurrences of [Find] replaced with [Replace].
        /// This method will fail if [Find] is empty.
        /// </summary>
        [TestFails(new Object[] { "a", null, null })]
        [TestFails(new Object[] { "a", null, "" })]
        [TestFails(new Object[] { "a", null, "a" })]
        [TestFails(new Object[] { null, "", null })]
        [TestFails(new Object[] { "", "", null })]
        [TestFails(new Object[] { "a", "", null })]
        [TestResult(new Object[] { "", "a", null }, "")]
        [TestResult(new Object[] { "", "a", "" }, "")]
        [TestResult(new Object[] { "a", "a", null }, "")]
        [TestResult(new Object[] { "a", "a", "" }, "")]
        [TestResult(new Object[] { "baba", "a", "" }, "bb")]
        [TestResult(new Object[] { "baba", "a", "r" }, "brbr")]
        [TestResult(new Object[] { "babamm", "bam", "" }, "")]
        public static String ReplaceAll(this String In, String Find, String Replace)
            {
            String Out = In ?? "";
            while (Out.Contains(Find))
                {
                Out = Out.Replace(Find, Replace);
                }
            return Out;
            }
        #endregion
        #region RemoveAll
        public static String RemoveAll(this String In, String Find)
            {
            return In.ReplaceAll(Find, "");
            }
        #endregion
        #region ToUrlSlug
        /// <summary>
        /// Takes a String and returns a URL Slug String.
        /// Ex. Good Example  -> good-example
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { "    " }, "")]
        [TestResult(new Object[] { "a" }, "a")]
        [TestResult(new Object[] { "A" }, "a")]
        [TestResult(new Object[] { "  BlahBlah  " }, "blahblah")]
        [TestResult(new Object[] { "  Blah Blah  " }, "blah-blah")]
        [TestResult(new Object[] { "  BLAH_BLAH  " }, "blah-blah")]
        public static String ToUrlSlug(this String In)
            {
            string Out = (In ?? "").ToLower();
            Out = Out.ReplaceAll("_", "-");
            Out = Regex.Replace(Out, @"[^a-z0-9\s-]", "");
            Out = Regex.Replace(Out, @"\s+", " ").Trim();
            //	Out = Out.Substring(0, Out.Length <= 45 ? Out.Length : 45).Trim();
            Out = Regex.Replace(Out, @"\s", "-");
            return Out;
            }
        #endregion
        #region Surround
        /// <summary>
        /// Surrounds the source String with Before and After
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Before"></param>
        /// <param name="After"></param>
        /// <returns></returns>
        [TestResult(new Object[] { null, null, null }, "")]
        [TestResult(new Object[] { "", "", "" }, "")]
        [TestResult(new Object[] { null, "b", "c" }, "")]
        [TestResult(new Object[] { "", "b", "c" }, "")]
        [TestResult(new Object[] { "   ", "b", "c" }, "")]
        [TestResult(new Object[] { "a", "b", null }, "ba")]
        [TestResult(new Object[] { "a", null, "c" }, "ac")]
        [TestResult(new Object[] { "a", "", "" }, "a")]
        [TestResult(new Object[] { "a", "b", "c" }, "bac")]
        [TestResult(new Object[] { "_a_", "_b", "c_" }, "_b_a_c_")]
        public static String Surround(this String In, String Before, String After)
            {
            return L.String_Surround(In, Before, After);
            }
        #endregion
        #region ToHexString
        /// <summary>
        /// Takes an array of Bytes and returns a friendly hexidecimal string.
        /// Ex. Byte[] { 10, 50, 80, 120, 150, 200, 250, 250 }  ->  "0x0A32507896C8FAFA"
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { new Byte[] { } }, "")]
        [TestResult(new Object[] { new Byte[] { 0, 0, 0, 0 } }, "0x00000000")]
        [TestResult(new Object[] { new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 } }, "0x0000000000000000")]
        [TestResult(new Object[] { new Byte[] { 10, 50, 80, 120, 150, 200, 250, 250 } }, "0x0A32507896C8FAFA")]
        public static String ToHexString(this byte[] Bytes)
            {
            if (Bytes.IsEmpty())
                return "";

            char[] c = new char[Bytes.Length * 2 + 2];
            byte b;
            c[0] = '0'; c[1] = 'x';

            for (int y = 0, x = 2; y < Bytes.Length; ++y, ++x)
                {
                b = ((byte)(Bytes[y] >> 4));
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(Bytes[y] & 0xF));
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                }

            return new string(c);
            }
        #endregion
        #region ByteArrayToString
        /// <summary>
        /// Takes a Byte[] and returns a String representation of the byte array.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { new Byte[] { } }, "")]
        [TestResult(new Object[] { new Byte[] { 45, 69, 100, 68, 47, 87, 57, 54, 66 } }, "-EdD/W96B")]
        public static String ByteArrayToString(this byte[] In)
            {
            if (In.IsEmpty())
                return "";

            char[] Out = In.Convert(System.Convert.ToChar);

            return new String(Out);
            }
        #endregion
        #region ToByteArray
        /// <summary>
        /// Takes a String and returns a Byte[] representation of the String.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, new Byte[] { })]
        [TestResult(new Object[] { "" }, new Byte[] { })]
        [TestResult(new Object[] { "-EdD/W96B" }, new Byte[] { 45, 69, 100, 68, 47, 87, 57, 54, 66 })]
        public static Byte[] ToByteArray(this String In)
            {
            if (In.IsEmpty())
                return new Byte[] { };

            return System.Text.Encoding.Unicode.GetBytes(In).EveryOtherByte();
            }
        #endregion
        #region JoinLines
        /// <summary>
        /// Similar to combine.
        /// Takes a string collection and joines each item, using "\r\n" as the default newline string.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null, null }, "")]
        [TestResult(new Object[] { new String[] { }, null }, "")]
        [TestResult(new Object[] { new String[] { "" }, null }, "")]
        [TestResult(new Object[] { new String[] { "", "" }, null }, "")]
        [TestResult(new Object[] { new String[] { "a", "a" }, null }, "aa")]
        [TestResult(new Object[] { new String[] { "a", "a" }, L.NewLineString }, "a\r\na")]
        [TestResult(new Object[] { new String[] { "a", "a" }, "blah" }, "ablaha")]
        public static String JoinLines(this IEnumerable<String> In, String JoinStr = L.NewLineString)
            {
            return L.String_JoinLines(In, JoinStr);
            }
        #endregion
        #region Words
        /// <summary>
        /// Takes a String and returns its words in an array. Removes newlines.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, new String[] { })]
        [TestResult(new Object[] { "" }, new String[] { })]
        [TestResult(new Object[] { " " }, new String[] { })]
        [TestResult(new Object[] { "a a" }, new String[] { "a", "a" })]
        [TestResult(new Object[] { "a few words" }, new String[] { "a", "few", "words" })]
        [TestResult(new Object[] { "a couple lines\r\n to test" }, new String[] { "a", "couple", "lines", "to", "test" })]
        public static String[] Words(this String In)
            {
            return In.ReplaceAll("\r\n", " ").Split(" ");
            }
        #endregion
        #region Lines
        /// <summary>
        /// Takes a String and returns its lines in an array.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, new String[] { })]
        [TestResult(new Object[] { "" }, new String[] { })]
        [TestResult(new Object[] { " " }, new String[] { })]
        [TestResult(new Object[] { "a a" }, new String[] { "a a" })]
        [TestResult(new Object[] { "a few words" }, new String[] { "a few words" })]
        [TestResult(new Object[] { "a couple lines\r to test  " }, new String[] { "a couple lines", "to test" })]
        [TestResult(new Object[] { "a couple lines\n to test  " }, new String[] { "a couple lines", "to test" })]
        [TestResult(new Object[] { "a couple lines\r\n to test  " }, new String[] { "a couple lines", "to test" })]
        [TestResult(new Object[] { "a couple lines\r\n\r\n to test  " }, new String[] { "a couple lines", "to test" })]
        [TestResult(new Object[] { "a couple lines\r\r to test  " }, new String[] { "a couple lines", "to test" })]
        [TestResult(new Object[] { "a couple lines\n\n to test  " }, new String[] { "a couple lines", "to test" })]
        public static String[] Lines(this String In)
            {
            String Out = (In ?? "").ReplaceAll("\r\n", "\r");

            Out = Out.ReplaceAll("\n", "\r");

            return Out.Split("\r").Collect(L.String_Trim2);
            }
        #endregion
        #region Like
        /// <summary>
        /// Performs a case-insensitive comparison between the two Strings.
        /// White space at the beginning and end are ignored.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null, null }, true)]
        [TestResult(new Object[] { "", null }, true)]
        [TestResult(new Object[] { null, "" }, true)]
        [TestResult(new Object[] { "  ", " " }, true)]
        [TestResult(new Object[] { "  a  ", "a     " }, true)]
        [TestResult(new Object[] { "  a  ", "b    " }, false)]
        [TestResult(new Object[] { "FuNkYcAsE", "funkyCASE" }, true)]
        public static Boolean Like(this String In, String Compare)
            {
            if (In.IsEmpty())
                return Compare.IsEmpty();
            if (Compare.IsEmpty())
                return In.IsEmpty();

            In = In.Trim();
            Compare = Compare.Trim();

            if (Compare.Length != In.Length)
                return false;

            return In.ToLower() == Compare.ToLower();
            }
        #endregion
        #region Times
        /// <summary>
        /// Takes a string and returns
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        [TestFails(new Object[] { null, -1 }, typeof(ArgumentException))]
        [TestFails(new Object[] { "a", -1 }, typeof(ArgumentException))]
        [TestResult(new Object[] { null, 0 }, "")]
        [TestResult(new Object[] { "", 0 }, "")]
        [TestResult(new Object[] { "a", 0 }, "")]
        [TestResult(new Object[] { "a", 1 }, "a")]
        [TestResult(new Object[] { "ablah", 1 }, "ablah")]
        [TestResult(new Object[] { "ablah", 2 }, "ablahablah")]
        [TestResult(new Object[] { "ablah", 5 }, "ablahablahablahablahablah")]
        public static String Times(this String In, int Count)
            {
            if (Count < 0)
                throw new ArgumentException("Count was less than 0.");
            if (Count == 0)
                return "";
            if (Count == 1)
                return In ?? "";

            String Out = "";

            for (int i = 0; i < Count; i++)
                {
                Out += In;
                }

            return Out;
            }
        #endregion
        #region Reverse
        /// <summary>
        /// Takes a String and returns a reversed string. 
        /// This method cannot fail.
        /// </summary>
        [TestResult(new Object[] { null }, "")]
        [TestResult(new Object[] { "" }, "")]
        [TestResult(new Object[] { " " }, " ")]
        [TestResult(new Object[] { "blahblah " }, " halbhalb")]
        public static String Reverse(this String In)
            {
            return new String((In ?? "").ToCharArray().Reverse());
            }
        #endregion

        public static int Count(this String In, String Search)
            {
            if (In.IsEmpty() || Search.IsEmpty())
                return 0;

            int Count = 0;

            while (In.Length > 0)
                {
                int index = In.IndexOf(Search);

                if (index > 0 && index + Search.Length < In.Length)
                    {
                    Count++;
                    In = In.Substring(index + Search.Length);
                    }
                else
                    break;
                }

            return Count;
            }

        public static Boolean IsSymmetrical(this string In, string Compare, double Threshhold = 0.95)
            {
            return In.Symmetry(Compare) >= Threshhold;
            }
        public static double Symmetry(this string In, string Compare)
            {
            In = In ?? "";
            Compare = Compare ?? "";

            List<string> pairs1 = WordLetterPairs(In.ToUpper());
            List<string> pairs2 = WordLetterPairs(Compare.ToUpper());

            int intersection = 0;
            int union = pairs1.Count + pairs2.Count;

            for (int i = 0; i < pairs1.Count; i++)
                {
                for (int j = 0; j < pairs2.Count; j++)
                    {
                    if (pairs1[i] == pairs2[j])
                        {
                        intersection++;
                        pairs2.RemoveAt(j);//Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                        break;
                        }
                    }
                }

            return (2.0 * intersection) / union;
            }


        private static List<string> WordLetterPairs(string str)
            {
            List<string> AllPairs = new List<string>();

            // Tokenize the string and put the tokens/words into an array
            string[] Words = Regex.Split(str, @"\s");

            // For each word
            for (int w = 0; w < Words.Length; w++)
                {
                if (!string.IsNullOrEmpty(Words[w]))
                    {
                    // Find the pairs of characters
                    String[] PairsInWord = LetterPairs(Words[w]);

                    for (int p = 0; p < PairsInWord.Length; p++)
                        {
                        AllPairs.Add(PairsInWord[p]);
                        }
                    }
                }
            return AllPairs;
            }
        private static string[] LetterPairs(string str)
            {
            int numPairs = str.Length - 1;

            string[] pairs = new string[numPairs];

            for (int i = 0; i < numPairs; i++)
                {
                pairs[i] = str.Substring(i, 2);
                }

            return pairs;
            }

        public static Boolean HasMatch(this String In, params String[] Expressions)
            {
            return Expressions.Count((s) =>
            {
                Regex Reg = new Regex(s);
                MatchCollection Matches = Reg.Matches(In);
                return Matches.Count > 0;
            }) > 0;
            }
        public static List<Match> Matches(this String In, String Expression)
            {
            Regex Reg = new Regex(Expression);
            MatchCollection Matches = Reg.Matches(In);
            return Matches.List<Match>();
            }


        public static List<String> SplitWithQuotes(this String Line, Char SplitBy)
            {
            List<String> Out = new List<String>();

            int fieldStart = 0;
            for (int i = 0; i < Line.Length; i++)
                {
                if (Line[i] == SplitBy)
                    {
                    Out.Add(Line.Substring(fieldStart, i - fieldStart));
                    fieldStart = i + 1;
                    }

                if (Line[i] == '"')
                    for (i++; Line[i] != '"'; i++)
                        {
                        }
                }

            // Last column
            if (Line.Length - fieldStart != 0)
                Out.Add(Line.Substring(fieldStart, Line.Length - fieldStart));

            return Out;
            }

        /// <summary>
        /// Concatonates a given String [In] to length [MaxLength] minus the length of [ConcatonateString].
        /// You can specify a Concatonation String, which defaults to "..."
        /// </summary>
        public static String Concatenate(this String In, int MaxLength, String ConcatenateString = "...")
            {
            ConcatenateString = ConcatenateString ?? "";

            if (MaxLength < 0)
                return In ?? "";
            if (MaxLength < ConcatenateString.Length)
                throw new ArgumentException("MaxLength");

            In = In ?? "";
            In = In.Trim();

            if (In.Length > MaxLength)
                {
                return In.Substring(0, MaxLength - ConcatenateString.Length) + ConcatenateString;
                }
            else
                {
                return In;
                }
            }

        /// <summary>
        /// Takes a string with possibly corrupted line enders and normalizes them all to \r\n.
        /// Removes duplicate \r and duplicate \r\n
        /// </summary>
        public static String ReplaceLineEnders(this String In, params char[] Chars)
            {
            if (!In.Contains("\n"))
                return In;

            String Out = In;

            Out = Out.Replace("\n", "\r\n");

            while (Out.Contains("\r\r"))
                {
                Out = Out.Replace("\r\r", "\r");
                }
            Out = Out.Replace("\r\n", new String(Chars));

            return Out;
            }
        public static String XMLClean(this String In)
            {
            return (In ?? "").Replace("<", "&lt;").Replace(">", "&gt;");
            }
        public static String UnCleanCRLF(this String In)
            {
            return (In ?? "").Replace(new String(new char[] { CRLFReplace }), "\r\n");
            }
        public static String URLClean(this string URLPart)
            {
            String Out = URLPart.Replace("#", "%23");
            return Out;
            }
        }
    }