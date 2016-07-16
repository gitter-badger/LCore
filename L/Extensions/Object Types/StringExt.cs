﻿using System;
using System.Collections.Generic;
// using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using LCore.Tests;
using System.Text.RegularExpressions;
using LCore.Extensions.Optional;
using LCore.Interfaces;
// ReSharper disable StringCompareIsCultureSpecific.1
// ReSharper disable StringCompareToIsCultureSpecific
// ReSharper disable StringIndexOfIsCultureSpecific.2
// ReSharper disable StringIndexOfIsCultureSpecific.3
// ReSharper disable StringLastIndexOfIsCultureSpecific.1
// ReSharper disable StringLastIndexOfIsCultureSpecific.2
// ReSharper disable StringLastIndexOfIsCultureSpecific.3
// ReSharper disable UnusedMember.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Extends strings and char types.
    /// </summary>
    [ExtensionProvider]
    public static class StringExt
        {
        #region Extensions +

        #region Add
        /// <summary>
        /// Adds a series of chars to the supplied string and returns it.
        /// </summary>
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, new char[] { } }, "")]
        [TestResult(new object[] { null, new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "bcdefg")]
        [TestResult(new object[] { "", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "bcdefg")]
        [TestResult(new object[] { "a", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "abcdefg")]
        [TestResult(new object[] { "abc", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "abcbcdefg")]
        // ReSharper restore StringLiteralTypo
        public static string Add(this string In, params char[] Chars)
            {
            return In.Add((IEnumerable<char>)Chars);
            }
        /// <summary>
        /// Adds a collection of chars to the supplied string and returns it.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, new char[] { } }, "")]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { null, new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "bcdefg")]
        [TestResult(new object[] { "", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "bcdefg")]
        [TestResult(new object[] { "a", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "abcdefg")]
        [TestResult(new object[] { "abc", new[] { 'b', 'c', 'd', 'e', 'f', 'g' } }, "abcbcdefg")]
        [TestResult(new object[] { "abc", "abcbcdefg" }, "abcabcbcdefg")]
        // ReSharper restore StringLiteralTypo
        public static string Add(this string In, IEnumerable<char> Chars)
            {
            In = In ?? "";
            Chars = Chars ?? new char[] { };

            string Objs2;
            if (Chars.GetType().TypeEquals(typeof(string)))
                {
                Objs2 = (string)Chars;
                }
            else
                {
                Objs2 = new string(Chars.ToArray());
                }
            return In + Objs2;
            }
        #endregion

        #region After

        /// <summary>
        /// Returns the contents of <paramref name="In" /> after the first occurrence of 
        /// <paramref name="Sequence" />.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "-" }, "-bb--aa--bb--cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "--" }, "bb--aa--bb--cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "bb--" }, "aa--bb--cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "cc" }, "")]
        public static string After(this string In, string Sequence)
            {
            In = In ?? "";

            if (string.IsNullOrEmpty(Sequence))
                return In;

            int Index = In.IndexOf(Sequence);

            return Index < 0
                ? In
                : In.Sub(Index + Sequence.Length);
            }

        #endregion

        #region AfterLast

        /// <summary>
        /// Returns the contents of <paramref name="In" /> after the last occurrence of 
        /// <paramref name="Sequence" />.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "-" }, "cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "--" }, "cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "aa--" }, "bb--cc")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "cc" }, "")]
        public static string AfterLast(this string In, string Sequence)
            {
            In = In ?? "";

            if (string.IsNullOrEmpty(Sequence))
                return In;

            int Index = In.LastIndexOf(Sequence);

            return Index < 0
                ? In
                : In.Sub(Index + Sequence.Length);
            }

        #endregion

        #region AlignCenter
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If <paramref name="In" /> is longer than <paramref name="Length" />, the result is <paramref name="In" /> truncated to <paramref name="Length" />.
        /// This method will only fail if <paramref name="Length" /> is less than 0.
        /// </summary>
        [TestFails(new object[] { null, -1, (char)0 })]
        [TestFails(new object[] { "a", -1, ' ' })]
        [TestResult(new object[] { null, 5, ' ' }, "     ")]
        [TestResult(new object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new object[] { "a", 5, ' ' }, "  a  ")]
        [TestResult(new object[] { "abc", 5, ' ' }, " abc ")]
        [TestResult(new object[] { "   abc   ", 5, ' ' }, " abc ")]
        [TestResult(new object[] { "abcdef", 5, ' ' }, "abcde")]
        public static string AlignCenter(this string In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Center, PadChar);
            }
        #endregion

        #region AlignLeft
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If <paramref name="In" /> is longer than <paramref name="Length" />, the result is <paramref name="In" /> truncated to <paramref name="Length" />.
        /// This method will only fail if <paramref name="Length" /> is less than 0.
        /// </summary>
        [TestFails(new object[] { null, -1, (char)0 })]
        [TestFails(new object[] { "a", -1, ' ' })]
        [TestResult(new object[] { null, 5, ' ' }, "     ")]
        [TestResult(new object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new object[] { "a", 5, ' ' }, "a    ")]
        [TestResult(new object[] { "abc", 5, ' ' }, "abc  ")]
        [TestResult(new object[] { "   abc   ", 5, ' ' }, "abc  ")]
        [TestResult(new object[] { "abcdef", 5, ' ' }, "abcde")]
        public static string AlignLeft(this string In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Left, PadChar);
            }
        #endregion

        #region AlignRight
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If <paramref name="In" /> is longer than <paramref name="Length" />, the result is <paramref name="In" /> truncated to <paramref name="Length" />.
        /// This method will only fail if <paramref name="Length" /> is less than 0.
        /// </summary>
        [TestFails(new object[] { null, -1, (char)0 })]
        [TestFails(new object[] { "a", -1, ' ' })]
        [TestResult(new object[] { null, 5, ' ' }, "     ")]
        [TestResult(new object[] { " ", 5, ' ' }, "     ")]
        [TestResult(new object[] { "a", 5, ' ' }, "    a")]
        [TestResult(new object[] { "abc", 5, ' ' }, "  abc")]
        [TestResult(new object[] { "   abc   ", 5, ' ' }, "  abc")]
        [TestResult(new object[] { "abcdef", 5, ' ' }, "abcde")]
        public static string AlignRight(this string In, int Length, char PadChar = ' ')
            {
            return In.Pad(Length, L.Align.Right, PadChar);
            }
        #endregion

        #region Before

        /// <summary>
        /// Returns the contents of <paramref name="In" /> before the first occurrence of 
        /// <paramref name="Sequence" />.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "-" }, "aa")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "--" }, "aa")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "--cc" }, "aa--bb--aa--bb")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "aa" }, "")]
        public static string Before(this string In, string Sequence)
            {
            In = In ?? "";

            if (string.IsNullOrEmpty(Sequence))
                return In;

            int Index = In.IndexOf(Sequence);

            return Index == 0 ? "" :
                Index < 0 ? In :
                In.Sub(0, Index);
            }

        #endregion

        #region BeforeLast

        /// <summary>
        /// Returns the contents of <paramref name="In" /> before the last occurrence of 
        /// <paramref name="Sequence" />.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "-" }, "aa--bb--aa--bb-")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "--" }, "aa--bb--aa--bb")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "aa--" }, "aa--bb--")]
        [TestResult(new object[] { "aa--bb--aa--bb--cc", "aa--bb--a" }, "")]
        public static string BeforeLast(this string In, string Sequence)
            {
            In = In ?? "";

            if (string.IsNullOrEmpty(Sequence))
                return In;

            int Index = In.LastIndexOf(Sequence);

            return Index == 0 ? "" :
                Index < 0
                ? In
                : In.Sub(0, Index);
            }

        #endregion

        #region ByteArrayToString
        /// <summary>
        /// Takes a Byte[] and returns a String representation of the byte array.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { new byte[] { } }, "")]
        [TestResult(new object[] { new byte[] { 45, 69, 100, 68, 47, 87, 57, 54, 66 } }, "-EdD/W96B")]
        public static string ByteArrayToString(this byte[] In)
            {
            if (In.IsEmpty())
                return "";

            char[] Out = In.Convert(Convert.ToChar);

            return new string(Out);
            }
        #endregion

        #region CleanCRLF
        internal const char CrlfReplace = (char)222;

        /// <summary>
        /// Returns a string with line-endings replaced with a temporary character. 
        /// Used with http binary communication.
        /// </summary>
        /// <param name="In"></param>
        /// <returns>A string with line-endings replaced with a temporary character</returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "abab" }, "abab")]
        [TestResult(new object[] { "abab\r\n" }, "ababÞ")]
        [TestResult(new object[] { "abab\n" }, "ababÞ")]
        public static string CleanCrlf(this string In)
            {
            return (In ?? "").ReplaceLineEndings(CrlfReplace.ToString());
            }

        /// <summary>
        /// Returns a string with line-endings returned from a temporary character. 
        /// Used with http binary communication.
        /// </summary>
        /// <param name="In"></param>
        /// <returns>A string with line-endings returned from a temporary character. </returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "abab" }, "abab")]
        [TestResult(new object[] { "ababÞ" }, "abab\r\n")]
        public static string UnCleanCrlf(this string In)
            {
            return (In ?? "").Replace(new string(new[] { CrlfReplace }), "\r\n");
            }

        #endregion

        #region Combine
        /// <summary>
        /// Combines an IEnumerable<paramref name="In" /> using <paramref name="CombineStr" /> as a separator string.
        /// </summary>
        /// <param name="In"></param>
        /// <param name="CombineStr"></param>
        /// <returns>A combined string</returns>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { null, "a" }, "")]
        [TestResult(new object[] { new string[] { }, null }, "")]
        [TestResult(new object[] { new string[] { }, "" }, "")]
        [TestResult(new object[] { new string[] { }, "a" }, "")]
        [TestResult(new object[] { new[] { "b" }, "a" }, "b")]
        [TestResult(new object[] { new[] { "b", "b" }, "a" }, "bab")]
        // ReSharper disable once StringLiteralTypo
        [TestResult(new object[] { new[] { "b", "b", "b" }, "a" }, "babab")]
        [TestResult(new object[] { new[] { "b", "b", "b" }, "_a_" }, "b_a_b_a_b")]
        public static string Combine(this IEnumerable<string> In, string CombineStr)
            {
            string Out = "";
            int Count = In.Count();
            In.Each((i, o) =>
            {
                Out += o;
                if (i < Count - 1)
                    Out += CombineStr;
            });
            return Out;
            }
        #endregion

        #region Concatenate

        /// <summary>
        /// Concatenates a given String <paramref name="In" /> to length <paramref name="MaxLength" /> minus the length of <paramref name="ConcatenateString" />.
        /// You can specify a Concatenation String, which defaults to "..."
        /// </summary>

        [TestFails(new object[] { null, 0, "..." }, typeof(ArgumentException))]
        [TestResult(new object[] { null, 5, "..." }, "")]
        [TestResult(new object[] { null, -5, "..." }, "")]
        [TestResult(new object[] { "test string", -5, "..." }, "test string")]
        [TestResult(new object[] { "test string", 5, "..." }, "te...")]
        [TestResult(new object[] { "test string123456789", 15, "..." }, "test string1...")]
        public static string Concatenate(this string In, int MaxLength, string ConcatenateString = "...")
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
            return In;
            }

        #endregion

        #region ContainsAny
        /// <summary>
        /// Takes a string and returns whether it contains any of the strings in the collection
        /// This method will not fail.
        /// </summary>
        [TestResult(new object[] { null, null }, false)]
        [TestResult(new object[] { null, new string[] { } }, false)]
        [TestResult(new object[] { null, new string[] { null } }, false)]
        [TestResult(new object[] { null, new[] { "" } }, false)]
        [TestResult(new object[] { null, new[] { "a" } }, false)]
        [TestResult(new object[] { "a", new[] { "a" } }, true)]
        [TestResult(new object[] { "blah", new[] { "a" } }, true)]
        [TestResult(new object[] { "BLAH", new[] { "a" } }, false)]
        [TestResult(new object[] { "BLAH", new[] { "a", "A" } }, true)]
        public static bool ContainsAny(this string In, IEnumerable<string> Find)
            {
            if (In.IsEmpty() || Find.IsEmpty())
                return false;

            return Find.Count(In.Contains) > 0;
            }
        #endregion

        #region Count
        /// <summary>
        /// Returns the amount of times <paramref name="Search" /> appears in <paramref name="In" />.
        /// Overlapping sequences are counted multiple times.
        /// </summary>
        /// <param name="In">The source to search</param>
        /// <param name="Search">The search term</param>
        /// <returns>The amount of times <paramref name="Search" /> appears in <paramref name="In" /></returns>
        [TestResult(new object[] { null, null }, 0)]
        [TestResult(new object[] { "", "" }, 0)]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "aaabbbccc", "" }, 0)]
        [TestResult(new object[] { "aaabbbccc", "a" }, 3)]
        [TestResult(new object[] { "aaabbbccc", "aa" }, 2)]
        [TestResult(new object[] { "aaabbbccc", "aaa" }, 1)]
        // ReSharper restore StringLiteralTypo
        public static int Count(this string In, string Search)
            {
            if (In.IsEmpty() || Search.IsEmpty())
                return 0;

            int[] Nums = 0.To(In.Length - 1);

            return Nums.Where(i => In.Sub(i).StartsWith(Search)).Count();
            }
        #endregion

        #region Fill
        /// <summary>
        /// Returns a String filled with <paramref name="Count" /> characters of the source character.
        /// Throws an exception if <paramref name="Count" /> is less than 0.
        /// </summary>
        [TestFails(new object[] { 'a', -1 })]
        [TestResult(new object[] { 'a', 0 }, "")]
        [TestResult(new object[] { 'a', 3 }, "aaa")]
        // ReSharper disable once StringLiteralTypo
        [TestResult(new object[] { 'z', 5 }, "zzzzz")]
        public static string Fill(this char In, int Count)
            {
            return new string(new char[Count].Collect(o => In));
            }
        #endregion

        #region FirstCaps
        /// <summary>
        /// Formats an input string so that it is TitleCase.
        /// This method will not fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "BLAH" }, "Blah")]
        [TestResult(new object[] { "blah" }, "Blah")]
        [TestResult(new object[] { "bLaH" }, "Blah")]
        [TestResult(new object[] { "bLaH bLaH" }, "Blah Blah")]
        public static string FirstCaps(this string Value)
            {
            if (Value.IsEmpty())
                return "";

            var Builder = new StringBuilder(Value.Length);
            // Upper the first char.
            Builder.Append(char.ToUpper(Value[0]));

            Value.Each((i, Char) =>
            {
                if (i == 0)
                    return;

                // Get the current char.
                char Ch = Char;

                // Upper if after a space.
                if (i > 0 && char.IsWhiteSpace(Value[i - 1]))
                    Ch = char.ToUpper(Ch);
                else
                    Ch = char.ToLower(Ch);

                Builder.Append(Ch);
            });

            return Builder.ToString();
            }
        #endregion

        #region FormatFileSize
        /// <summary>
        /// Formats a file size Long into a friendly string, up to TB.
        /// The result will be displayed with <paramref name="Decimals" /> shown. Bytes will not display decimals.
        /// </summary>
        [TestFails(new object[] { (long)-1, 1 })]
        [TestFails(new object[] { 1024 + 512, -1 })]
        [TestFails(new object[] { -1, 0 })]
        [TestResult(new object[] { (long)0, 3 }, "0 B")]
        [TestResult(new object[] { (long)450, 3 }, "450 B")]
        [TestResult(new object[] { 1024 * 1024, 1 }, "1.0 MB")]
        [TestResult(new object[] { 1024 + (long)412, 0 }, "1 KB")]
        [TestResult(new object[] { 1024 + 512, 0 }, "2 KB")]
        [TestResult(new object[] { 1024 + 512, 2 }, "1.50 KB")]
        [TestResult(new object[] { 1024 + 512, 3 }, "1.500 KB")]
        [TestResult(new object[] { (long)(1024 * 1024 * 1024 * (long)1024 * (float)1.5), 5 }, "1.50000 TB")]
        [TestResult(new object[] { (long)35572226, 5 }, "33.92432 MB")]
        [TestResult(new object[] { long.MaxValue, 0 }, "8 EB")]
        public static string FormatFileSize(this long Size, int Decimals)
            {
            if (Size < 0) throw new ArgumentOutOfRangeException(nameof(Size));
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double Temp = Size;
            string Unit = "B";
            if (Temp >= 1024)
                {
                Temp = Temp / 1024;
                Unit = "KB";
                if (Temp >= 1024)
                    {
                    Temp = Temp / 1024;
                    Unit = "MB";
                    if (Temp >= 1024)
                        {
                        Temp = Temp / 1024;
                        Unit = "GB";
                        if (Temp >= 1024)
                            {
                            Temp = Temp / 1024;
                            Unit = "TB";
                            if (Temp >= 1024)
                                {
                                Temp = Temp / 1024;
                                Unit = "PB";
                                if (Temp >= 1024)
                                    {
                                    Temp = Temp / 1024;
                                    Unit = "EB";
                                    }
                                }
                            }
                        }
                    }
                double Power = Math.Pow(10, Decimals);
                Temp = Math.Round(Temp * Power) / Power;
                }
            string Out = Temp.ToString();

            if (Decimals > 0 && Unit != "B")
                {
                if (!Out.Contains("."))
                    {
                    Out += $".{'0'.Fill(Decimals)}";
                    }
                else
                    {
                    while (Out.Substring(Out.IndexOf(".") + 1).Length != Decimals)
                        {
                        Out += "0";
                        }
                    }
                }

            return $"{Out} {Unit}";
            }

        /// <summary>
        /// Formats a file size int into a friendly string, up to TB.
        /// The result will be displayed with <paramref name="Decimals" /> shown. Bytes will not display decimals.
        /// </summary>

        [TestFails(new object[] { -1, 1 })]
        [TestFails(new object[] { 1024 + 512, -1 })]
        [TestResult(new object[] { 1024 * 1024 + 512, 0 }, "1 MB")]
        [TestResult(new object[] { 1024 * 1024, 1 }, "1.0 MB")]
        [TestResult(new object[] { 1024 * 1024, 0 }, "1 MB")]
        [TestResult(new object[] { 1024 * 1024 * 5, 0 }, "5 MB")]
        [TestResult(new object[] { 1024 * 1024 * 1024, 0 }, "1 GB")]
        [TestResult(new object[] { 0, 3 }, "0 B")]
        [TestResult(new object[] { 450, 3 }, "450 B")]
        [TestResult(new object[] { 1024 + 412, 0 }, "1 KB")]
        [TestResult(new object[] { 1024 + 512, 0 }, "2 KB")]
        [TestResult(new object[] { 1024 + 512, 2 }, "1.50 KB")]
        [TestResult(new object[] { 1024 + 512, 3 }, "1.500 KB")]
        [TestResult(new object[] { 35572226, 5 }, "33.92432 MB")]
        [TestResult(new object[] { int.MaxValue, 0 }, "2 GB")]
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static string FormatFileSize(this int Size, int Decimals = 0)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));
            if (Size < 0) throw new ArgumentOutOfRangeException(nameof(Size));

            double Temp = Size;
            string Unit = "B";
            if (Temp >= 1024)
                {
                Temp = Temp / 1024;
                Unit = "KB";
                if (Temp >= 1024)
                    {
                    Temp = Temp / 1024;
                    Unit = "MB";
                    if (Temp >= 1024)
                        {
                        Temp = Temp / 1024;
                        Unit = "GB";
                        }
                    }
                double Power = Math.Pow(10, Decimals);
                Temp = Math.Round(Temp * Power) / Power;
                }
            string Out = Temp.ToString();

            if (Decimals > 0 && Unit != "B")
                {
                if (!Out.Contains("."))
                    {
                    Out += $".{'0'.Fill(Decimals)}";
                    }
                else
                    {
                    while (Out.Substring(Out.IndexOf(".") + 1).Length != Decimals)
                        {
                        Out += "0";
                        }
                    }
                }

            return $"{Out} {Unit}";
            }
        #endregion

        #region HasMatch
        /// <summary>
        /// Returns true if any expressions return a Regex match.
        /// </summary>
        /// <param name="In">String source</param>
        /// <param name="Expressions">Expressions to evaluate</param>
        /// <returns>true if any expressions return a Regex match.</returns>
        [TestResult(new object[] { null, null }, false)]
        [TestResult(new object[] { "", null }, false)]
        [TestResult(new object[] { "123", null }, false)]
        [TestResult(new object[] { "123", new string[] { } }, false)]
        [TestResult(new object[] { "123", new[] { @"\d+" } }, true)]
        public static bool HasMatch(this string In, params string[] Expressions)
            {
            return Expressions.Count(Str =>
            {
                var Reg = new Regex(Str);
                var Matches = Reg.Matches(In);
                return Matches.Count > 0;
            }) > 0;
            }
        #endregion

        #region Humanize
        /// <summary>
        /// Takes a String and returns a String inserting spaces where there are capital letters in the word. 
        /// Ex. "VeryGoodExample"  ->  "Very Good Example"
        /// This method will not fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "a" }, "A")]
        [TestResult(new object[] { "A" }, "A")]
        [TestResult(new object[] { "blah" }, "Blah")]
        [TestResult(new object[] { "BlahBlahBlah" }, "Blah Blah Blah")]
        [TestResult(new object[] { "blah_blah_blah" }, "Blah Blah Blah")]
        [TestResult(new object[] { "Blah0Blah1Blah2" }, "Blah 0 Blah 1 Blah 2")]
        [TestResult(new object[] { "VeryGoodExample" }, "Very Good Example")]
        public static string Humanize(this string FieldName)
            {
            char Last = ' ';

            string Out = (FieldName ?? "").Trim().CollectStr<char, string>(
                (i, Char) =>
                    {
                        if (i == 0 ||
                            (Last.IsNumber() && !Char.IsNumber()) ||
                            (!Last.IsNumber() && Char.IsNumber()) ||
                            (!char.IsUpper(Last) && char.IsUpper(Char)))
                            {
                            Last = Char;
                            return (i != 0 ? " " : "") + Char.ToString().ToUpper();
                            }
                        Last = Char;
                        return Char.ToString();
                    }).Trim();
            Out = Out.Replace("_", " ");
            Out = Out.ReplaceAll("  ", " ");

            return Out.FirstCaps();
            }
        #endregion

        #region IsEmpty
        /// <summary>
        /// Pass it any string reference to determine whether a String is null or Empty.
        /// This method will not fail.
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        [TestResult(new object[] { "" }, true)]
        [TestResult(new object[] { null }, true)]
        [TestResult(new object[] { " " }, true)]
        [TestResult(new object[] { "     " }, true)]
        [TestResult(new object[] { "a" }, false)]
        public static bool IsEmpty(this string In)
            {
            return In == null || In.Trim() == "";
            }
        #endregion

        #region IsNumber
        /// <summary>
        /// Returns whether a char is a number.
        /// This method will not fail.
        /// </summary>
        [TestResult(new object[] { 'a' }, false)]
        [TestResult(new object[] { '0' }, true)]
        [TestResult(new object[] { '9' }, true)]
        public static bool IsNumber(this char In)
            {
            return In >= '0' && In <= '9';
            }
        #endregion

        #region IsSymmetrical
        /// <summary>
        /// Returns true if the source <paramref name="In" /> is symmetrical to <paramref name="Compare" />. 
        /// Symmetry guages how similar two strings are from 0 to 1.
        /// Default threshhold is 95% Symmetry (0.95).
        /// </summary>
        /// <param name="In">The string to compare</param>
        /// <param name="Compare">The string to compare with</param>
        /// <param name="Threshhold">Double from 0 to 1, Required threshhold percent default 0.95</param>
        /// <returns> true if the source <paramref name="In" /> is symmetrical to <paramref name="Compare" />. </returns>

        [TestResult(new object[] { "holographic", "monographic", 0.7 }, true)]
        [TestResult(new object[] { "holographic", "monographic", 0.7001 }, false)]
        // ReSharper disable StringLiteralTypo
        // ReSharper disable once RedundantCast
        [TestResult(new object[] { "very very very very very very very very very very close", "very very very very very very very very very close", (double)0.95 }, true)]
        [TestResult(new object[] { "very very very very very very very very very very close", "very very very very very very very very very close", (double)1 }, false)]
        // ReSharper restore StringLiteralTypo
        public static bool IsSymmetrical(this string In, string Compare, double Threshhold = 0.95)
            {
            return In.Symmetry(Compare) >= Threshhold;
            }
        #endregion

        #region JoinLines
        /// <summary>
        /// Similar to combine.
        /// Takes a string collection and joines each item, using "\r\n" as the default newline string.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { new string[] { }, null }, "")]
        [TestResult(new object[] { new[] { "" }, null }, "")]
        [TestResult(new object[] { new[] { "", "" }, null }, "")]
        [TestResult(new object[] { new[] { "a", "a" }, null }, "aa")]
        [TestResult(new object[] { new[] { "a", "a" }, L.Str.NewLineString }, "a\r\na")]
        [TestResult(new object[] { new[] { "a", "a" }, " test " }, "a test a")]
        public static string JoinLines(this IEnumerable<string> In, string JoinStr = L.Str.NewLineString)
            {
            return L.Str.JoinLines(In, JoinStr);
            }
        #endregion

        #region Like
        /// <summary>
        /// Performs a case-insensitive comparison between the two Strings.
        /// White space at the beginning and end are ignored.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null, null }, true)]
        [TestResult(new object[] { "", null }, true)]
        [TestResult(new object[] { null, "" }, true)]
        [TestResult(new object[] { "  ", " " }, true)]
        [TestResult(new object[] { "  a  ", "" }, false)]
        [TestResult(new object[] { "  a  ", "a     " }, true)]
        [TestResult(new object[] { "  a  ", "b    " }, false)]
        [TestResult(new object[] { "FuNkYcAsE", "funkyCASE" }, true)]
        public static bool Like(this string In, string Compare)
            {
            if (In.IsEmpty())
                return Compare.IsEmpty();
            if (Compare.IsEmpty())
                return In.IsEmpty();

            In = In.Trim();
            Compare = Compare.Trim();

            return Compare.Length == In.Length && string.Equals(In, Compare, StringComparison.CurrentCultureIgnoreCase);
            }
        #endregion

        #region Lines
        /// <summary>
        /// Takes a String and returns its lines in an array.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, new string[] { })]
        [TestResult(new object[] { "" }, new string[] { })]
        [TestResult(new object[] { " " }, new string[] { })]
        [TestResult(new object[] { "a a" }, new[] { "a a" })]
        [TestResult(new object[] { "a few words" }, new[] { "a few words" })]
        [TestResult(new object[] { "a couple lines\r to test  " }, new[] { "a couple lines", "to test" })]
        [TestResult(new object[] { "a couple lines\n to test  " }, new[] { "a couple lines", "to test" })]
        [TestResult(new object[] { "a couple lines\r\n to test  " }, new[] { "a couple lines", "to test" })]
        [TestResult(new object[] { "a couple lines\r\n\r\n to test  " }, new[] { "a couple lines", "to test" })]
        [TestResult(new object[] { "a couple lines\r\r to test  " }, new[] { "a couple lines", "to test" })]
        [TestResult(new object[] { "a couple lines\n\n to test  " }, new[] { "a couple lines", "to test" })]
        public static string[] Lines(this string In)
            {
            string Out = (In ?? "").ReplaceAll("\r\n", "\r");

            Out = Out.ReplaceAll("\n", "\r");

            string[] Out2 = Out.Split("\r");

            for (int Index = 0; Index < Out2.Length; Index++)
                {
                Out2[Index] = Out2[Index].Trim();
                }
            return Out2;
            }
        #endregion

        #region Matches
        /// <summary>
        /// Returns all matches for <paramref name="In" /> nad Regex <paramref name="Expression" />.
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Expression"></param>
        /// <returns>All matches for <paramref name="In" /> nad Regex <paramref name="Expression" />.</returns>
        [Tested]
        public static List<Match> Matches(this string In, string Expression)
            {
            if (string.IsNullOrEmpty(In) || string.IsNullOrEmpty(Expression))
                return new List<Match>();

            var Reg = new Regex(Expression);
            var Matches = Reg.Matches(In);
            return Matches.List<Match>();
            }
        #endregion

        #region Pad
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If <paramref name="In" /> is longer than <paramref name="Length" />, the result is <paramref name="In" /> truncated to <paramref name="Length" />.
        /// This method will only fail if <paramref name="Length" /> is less than 0.
        /// </summary>
        [TestFails(new object[] { null, -1, L.Align.Right, (char)0 })]
        [TestFails(new object[] { "a", -1, L.Align.Right, ' ' })]
        [TestResult(new object[] { null, 5, L.Align.Left, ' ' }, "     ")]
        [TestResult(new object[] { " ", 5, L.Align.Left, ' ' }, "     ")]
        [TestResult(new object[] { "a", 5, L.Align.Left, ' ' }, "a    ")]
        [TestResult(new object[] { "a", 5, L.Align.Right, ' ' }, "    a")]
        [TestResult(new object[] { "a", 5, L.Align.Center, ' ' }, "  a  ")]
        [TestResult(new object[] { "abc", 5, L.Align.Left, ' ' }, "abc  ")]
        [TestResult(new object[] { "abc", 5, L.Align.Right, ' ' }, "  abc")]
        [TestResult(new object[] { "abc", 5, L.Align.Center, ' ' }, " abc ")]
        [TestResult(new object[] { "   abc   ", 5, L.Align.Right, ' ' }, "  abc")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Left, ' ' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Right, ' ' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Center, ' ' }, "abcde")]
        [TestResult(new object[] { null, 5, L.Align.Left, '0' }, "00000")]
        [TestResult(new object[] { " ", 5, L.Align.Left, '0' }, "00000")]
        [TestResult(new object[] { "a", 5, L.Align.Left, '0' }, "a0000")]
        [TestResult(new object[] { "a", 5, L.Align.Right, '0' }, "0000a")]
        [TestResult(new object[] { "a", 5, L.Align.Center, '0' }, "00a00")]
        [TestResult(new object[] { "abc", 5, L.Align.Left, '0' }, "abc00")]
        [TestResult(new object[] { "abc", 5, L.Align.Right, '0' }, "00abc")]
        [TestResult(new object[] { "abc", 5, L.Align.Center, '0' }, "0abc0")]
        [TestResult(new object[] { "   abc   ", 5, L.Align.Left, '0' }, "abc00")]
        [TestResult(new object[] { "   abc   ", 5, L.Align.Right, '0' }, "00abc")]
        [TestResult(new object[] { "   abc   ", 5, L.Align.Center, '0' }, "0abc0")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Left, '0' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Right, '0' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, L.Align.Center, '0' }, "abcde")]
        [TestResult(new object[] { "   abc   ", 6, L.Align.Center, '0' }, "00abc0")]
        public static string Pad(this string In, int Length, L.Align Alignment = L.Align.Left, char PadChar = ' ')
            {
            if (In.IsEmpty())
                return PadChar.Fill(Length);

            In = In.Trim();

            if (In.Length > Length)
                return In.Substring(0, Length);
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
        #endregion

        #region Pluralize
        /// <summary>
        /// Takes a string and returns a pluralized version of the word or phrase.
        /// This method will not fail. If the input is empty it will just return "".
        /// 
        /// <paramref name="Count" /> is used as the number of things you're referring to. 
        /// If you pass 1 (or -1), pluralization will not be applied
        /// </summary>
        [TestResult(new object[] { null, -1 }, "")]
        [TestResult(new object[] { "", -1 }, "")]
        [TestResult(new object[] { "blob", -2 }, "blobs")]
        [TestResult(new object[] { "blob", -1 }, "blob")]
        [TestResult(new object[] { "blob", 0 }, "blobs")]
        [TestResult(new object[] { "blob", 1 }, "blob")]
        [TestResult(new object[] { "blob", 2 }, "blobs")]
        [TestResult(new object[] { "person", 2 }, "people")]
        [TestResult(new object[] { "person", 1 }, "person")]
        [TestResult(new object[] { "Entry", 2 }, "Entries")]
        public static string Pluralize(this string In, int Count)
            {
            return L.Str.Pluralize(In, Count);
            }
        /// <summary>
        /// Takes a string and returns a pluralized version of the word or phrase.
        /// This method will not fail. If the input is empty it will just return "".
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "blob" }, "blobs")]
        [TestResult(new object[] { "person" }, "people")]
        [TestResult(new object[] { "Entry" }, "Entries")]
        [TestResult(new object[] { "Entries" }, "Entries")]
        public static string Pluralize(this string In)
            {
            return L.Str.Pluralize(In, 2);
            }
        #endregion

        #region RemoveAll
        /// <summary>
        /// Returns a String based on <paramref name="In" /> with all passed strings removed.
        /// </summary>
        /// <param name="In">The source string</param>
        /// <param name="Find">The strings to remove.</param>
        /// <returns>A String based on <paramref name="In" /> with all passed strings removed.</returns>
        [TestResult(new object[] { null, new string[] { } }, "")]
        [TestResult(new object[] { "", new string[] { } }, "")]
        [TestResult(new object[] { "a", new[] { "a" } }, "")]
        [TestResult(new object[] { "b", new[] { "a" } }, "b")]
        // ReSharper disable once StringLiteralTypo
        [TestResult(new object[] { "abbcbabbababcaab", new[] { "a", "b" } }, "cc")]
        public static string RemoveAll(this string In, params string[] Find)
            {
            string Out = In ?? "";

            Find.Each(Str => Out = Out.ReplaceAll(Str, ""));

            return Out;
            }
        #endregion

        #region ReplaceAll
        /// <summary>
        /// Takes a string and returns a string with all Occurrences of <paramref name="Find" /> replaced with <paramref name="Replace" />.
        /// This method will fail if <paramref name="Find" /> is empty.
        /// </summary>
        [TestFails(new object[] { "a", null, null })]
        [TestFails(new object[] { "a", null, "" })]
        [TestFails(new object[] { "a", null, "a" })]
        [TestFails(new object[] { null, "", null })]
        [TestFails(new object[] { "", "", null })]
        [TestFails(new object[] { "a", "", null })]
        [TestResult(new object[] { "", "a", null }, "")]
        [TestResult(new object[] { "", "a", "" }, "")]
        [TestResult(new object[] { "a", "a", null }, "")]
        [TestResult(new object[] { "a", "a", "" }, "")]
        [TestResult(new object[] { "baba", "a", "" }, "bb")]
        [TestResult(new object[] { "baba", "a", "r" }, "brbr")]
        // ReSharper disable once StringLiteralTypo
        [TestResult(new object[] { "babamm", "bam", "" }, "")]
        public static string ReplaceAll(this string In, string Find, string Replace)
            {
            string Out = In ?? "";
            while (Out.Contains(Find))
                {
                Out = Out.Replace(Find, Replace);
                }
            return Out;
            }

        /// <summary>
        /// Takes a string and <paramref name="Replacements" /> dictionary. 
        /// All keys are replaced with the corresponding value.
        /// </summary>
        [Tested]
        public static string ReplaceAll(this string In, IDictionary<string, string> Replacements)
            {
            string Out = In ?? "";

            Replacements = Replacements ?? new Dictionary<string, string>();

            while (Out.ContainsAny(Replacements.Keys))
                {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (string Key in Replacements.Keys)
                    {
                    string Replacement = Replacements.SafeGet(Key);

                    if (Replacement.ContainsAny(Replacements.Keys))
                        throw new Exception("Replacement values cannot contain replacement keys, this would cause an infinite loop.");

                    Out = Out.ReplaceAll(Key, Replacement);
                    }
                }

            return Out;
            }
        #endregion

        #region ReplaceLineEndings
        /// <summary>
        /// Takes a string with possibly corrupted line-endings and normalizes them all to \r\n.
        /// Removes duplicate \r.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { null, "" }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "abc", "" }, "abc")]
        [TestResult(new object[] { "abc\r\r\r\r\n abc \r\n\n\r\n\r\n", "\r\n" }, "abc\r\n abc \r\n\r\n\r\n\r\n")]
        public static string ReplaceLineEndings(this string In, string Replacement)
            {
            In = In ?? "";

            if (!In.Contains("\n"))
                return In;

            string Out = In;

            Out = Out.Replace("\n", "\r\n");

            while (Out.Contains("\r\r"))
                {
                Out = Out.Replace("\r\r", "\r");
                }
            Out = Out.Replace("\r\n", Replacement);

            return Out;
            }
        #endregion

        #region Reverse
        /// <summary>
        /// Takes a String and returns a reversed string. 
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { " " }, " ")]
        // ReSharper disable once StringLiteralTypo
        [TestResult(new object[] { "blahblah " }, " halbhalb")]
        public static string Reverse(this string In)
            {
            return new string((In ?? "").ToCharArray().Reverse());
            }
        #endregion

        #region Singularize
        /// <summary>
        /// Takes a string and returns a singularized version of the word or phrase.
        /// This method will not fail. If the input is empty it will just return "".
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "blobs" }, "blob")]
        [TestResult(new object[] { "people" }, "person")]
        [TestResult(new object[] { "Entries" }, "Entry")]
        [TestResult(new object[] { "Entry" }, "Entry")]
        public static string Singularize(this string In)
            {
            return L.Str.Singularize(In);
            }
        #endregion

        #region Split
        /// <summary>
        /// Takes a String and returns a String[] split by the <paramref name="SplitStr" />
        /// This method will throw an Exception if <paramref name="SplitStr" /> is empty.
        /// </summary>
        [TestFails(new object[] { null, null })]
        [TestFails(new object[] { "", null })]
        [TestFails(new object[] { "a", null })]
        [TestFails(new object[] { null, "" })]
        [TestFails(new object[] { "", "" })]
        [TestFails(new object[] { "a", "" })]
        [TestResult(new object[] { null, "a" }, new string[] { })]
        [TestResult(new object[] { "", "a" }, new string[] { })]
        [TestResult(new object[] { "a", "a" }, new string[] { })]
        [TestResult(new object[] { "bab", "a" }, new[] { "b", "b" })]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "babab", "a" }, new[] { "b", "b", "b" })]
        [TestResult(new object[] { "abababa", "a" }, new[] { "b", "b", "b" })]
        // ReSharper restore StringLiteralTypo
        public static string[] Split(this string In, string SplitStr)
            {
            if (string.IsNullOrEmpty(SplitStr))
                throw new ArgumentNullException(nameof(SplitStr));

            if (In.IsEmpty())
                return new string[] { };

            int Index = In.IndexOf(SplitStr);

            if (Index < 0)
                {
                return !In.IsEmpty() ? new[] { In } : new string[] { };
                }

            var Out = new List<string>();
            In.Traverse(Cursor =>
            {
                int Index2 = Cursor.IndexOf(SplitStr);
                if (Index2 < 0)
                    {
                    if (Cursor.Length > 0)
                        {
                        Out.Add(Cursor);
                        }
                    return null;
                    }
                if (Index2 > 0)
                    {
                    Out.Add(Cursor.Substring(0, Index2));
                    return Cursor.Substring(Index2);
                    }
                // if (Index == 0)
                // {
                return Cursor.Length > SplitStr.Length ? Cursor.Substring(SplitStr.Length) : null;
                // }
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

        #region SplitWithQuotes
        /// <summary>
        /// Returns a list of String segments from <paramref name="Line" />, split by <paramref name="SplitBy" />
        /// Very useful for CSV column formatting.
        /// </summary>
        /// <param name="Line">Source string</param>
        /// <param name="SplitBy">Character to split by</param>
        /// <returns></returns>
        [TestResult(new object[] { null, default(char) }, new string[] { })]
        [TestResult(new object[] { "", default(char) }, new string[] { })]
        [TestResult(new object[] { " ", default(char) }, new[] { " " })]
        [TestResult(new object[] { "text,\" more, and more\", even more", ',' }, new[] { "text", "\" more, and more\"", " even more" })]
        public static List<string> SplitWithQuotes(this string Line, char SplitBy)
            {
            Line = Line ?? "";

            var Out = new List<string>();

            int FieldStart = 0;
            for (int Index = 0; Index < Line.Length; Index++)
                {
                if (Line[Index] == SplitBy)
                    {
                    Out.Add(Line.Substring(FieldStart, Index - FieldStart));
                    FieldStart = Index + 1;
                    }

                if (Line[Index] == '"')
                    for (Index++; Line[Index] != '"'; Index++)
                        {
                        }
                }

            // Last column
            if (Line.Length - FieldStart != 0)
                Out.Add(Line.Substring(FieldStart, Line.Length - FieldStart));

            return Out;
            }

        #endregion

        #region Sub
        /// <summary>
        /// Alias for string.SubString with some additional argument protection.
        /// </summary>
        [TestResult(new object[] { null, 0, null }, "")]
        [TestResult(new object[] { "", 0, null }, "")]
        [TestResult(new object[] { "", 0, 1 }, "")]
        [TestResult(new object[] { "aaaa", 0, 1 }, "a")]
        [TestResult(new object[] { "aaaa", 0, 10 }, "aaaa")]
        [TestResult(new object[] { "aaaa", -1, 10 }, "aaaa")]
        [TestResult(new object[] { "aaaa", 5, 5 }, "")]
        [TestResult(new object[] { "aaaa", 4, 4 }, "")]
        [TestResult(new object[] { "aaaa", 3, 3 }, "a")]
        [TestResult(new object[] { "123456789123456789", 5, 8 }, "67891234")]
        public static string Sub(this string In, int Start, int? Length = null)
            {
            In = In ?? "";

            if (Start < 0)
                Start = 0;
            if (Start > In.Length)
                Start = In.Length;
            if (Start + Length > In.Length)
                Length = In.Length - Start;

            return Length == null || Length == 0 ?
                In.Substring(Start) :
                In.Substring(Start, (int)Length);
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
        [TestResult(new object[] { null, null, null }, "")]
        [TestResult(new object[] { "", "", "" }, "")]
        [TestResult(new object[] { null, "b", "c" }, "")]
        [TestResult(new object[] { "", "b", "c" }, "")]
        [TestResult(new object[] { "   ", "b", "c" }, "")]
        [TestResult(new object[] { "a", "b", null }, "ba")]
        [TestResult(new object[] { "a", null, "c" }, "ac")]
        [TestResult(new object[] { "a", "", "" }, "a")]
        [TestResult(new object[] { "a", "b", "c" }, "bac")]
        [TestResult(new object[] { "_a_", "_b", "c_" }, "_b_a_c_")]
        public static string Surround(this string In, string Before, string After)
            {
            return L.Str.Surround(In, Before, After);
            }
        #endregion

        #region Symmetry
        /// <summary>
        /// Returns the Percent of 'symmetry' between two strings. 
        /// Symmetry guages how similar two strings are from 0 to 1.
        /// </summary>
        /// <param name="In">The string to compare</param>
        /// <param name="Compare">The string to compare with</param>
        /// <returns>The Percent of 'symmetry between two strings as a double</returns>
        [TestResult(new object[] { "", "" }, (double)1)]
        // ReSharper disable RedundantCast
        [TestResult(new object[] { "elephant", "infant" }, (double)((double)1 / (double)3))]
        [TestResult(new object[] { "holographic", "monographic" }, (double)0.7)]
        // ReSharper restore RedundantCast
        public static double Symmetry(this string In, string Compare)
            {
            In = In ?? "";
            Compare = Compare ?? "";

            if (In == Compare)
                return 1;

            List<string> Pairs1 = WordLetterPairs(In.ToUpper());
            List<string> Pairs2 = WordLetterPairs(Compare.ToUpper());

            int Intersection = 0;
            int Union = Pairs1.Count + Pairs2.Count;

            foreach (string Str in Pairs1)
                {
                for (int Index = 0; Index < Pairs2.Count; Index++)
                    {
                    if (Str == Pairs2[Index])
                        {
                        Intersection++;
                        Pairs2.RemoveAt(Index);
                        // ReSharper disable once CommentTypo
                        //Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                        break;
                        }
                    }
                }

            return 2.0 * Intersection / Union;
            }

        private static List<string> WordLetterPairs(string Str)
            {
            var AllPairs = new List<string>();

            // Tokenize the string and put the tokens/words into an array
            string[] Words = Regex.Split(Str, @"\s");

            // For each word
            foreach (string Word in Words)
                {
                if (!string.IsNullOrEmpty(Word))
                    {
                    // Find the pairs of characters
                    string[] PairsInWord = LetterPairs(Word);

                    AllPairs.AddRange(PairsInWord);
                    }
                }
            return AllPairs;
            }
        private static string[] LetterPairs(string Str)
            {
            int NumPairs = Str.Length - 1;

            var Pairs = new string[NumPairs];

            for (int Index = 0; Index < NumPairs; Index++)
                {
                Pairs[Index] = Str.Substring(Index, 2);
                }

            return Pairs;
            }
        #endregion

        #region Times
        /// <summary>
        /// Takes a string and returns
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        [TestFails(new object[] { null, -1 }, typeof(ArgumentException))]
        [TestFails(new object[] { "a", -1 }, typeof(ArgumentException))]
        [TestResult(new object[] { null, 0 }, "")]
        [TestResult(new object[] { "", 0 }, "")]
        [TestResult(new object[] { "a", 0 }, "")]
        [TestResult(new object[] { "a", 1 }, "a")]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "ablah", 1 }, "ablah")]
        [TestResult(new object[] { "ablah", 2 }, "ablahablah")]
        [TestResult(new object[] { "ablah", 5 }, "ablahablahablahablahablah")]
        // ReSharper restore StringLiteralTypo
        public static string Times(this string In, int Count)
            {
            if (Count < 0)
                throw new ArgumentException("Count was less than 0.");
            if (Count == 0)
                return "";
            if (Count == 1)
                return In ?? "";

            string Out = "";

            for (int Index = 0; Index < Count; Index++)
                {
                Out += In;
                }

            return Out;
            }
        #endregion

        #region ToByteArray
        /// <summary>
        /// Takes a String and returns a Byte[] representation of the String.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, new byte[] { })]
        [TestResult(new object[] { "" }, new byte[] { })]
        [TestResult(new object[] { "-EdD/W96B" }, new byte[] { 45, 69, 100, 68, 47, 87, 57, 54, 66 })]
        public static byte[] ToByteArray(this string In)
            {
            return In.IsEmpty() ? new byte[] { } : Encoding.Unicode.GetBytes(In).EveryOtherByte();
            }

        #endregion

        #region ToHexString
        /// <summary>
        /// Takes an array of Bytes and returns a friendly hexadecimal string.
        /// Ex. Byte[] { 10, 50, 80, 120, 150, 200, 250, 250 }  ->  "0x0A32507896C8FAFA"
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { new byte[] { } }, "")]
        [TestResult(new object[] { new byte[] { 0, 0, 0, 0 } }, "0x00000000")]
        [TestResult(new object[] { new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 } }, "0x0000000000000000")]
        [TestResult(new object[] { new byte[] { 10, 50, 80, 120, 150, 200, 250, 250 } }, "0x0A32507896C8FAFA")]
        public static string ToHexString(this byte[] Bytes)
            {
            if (Bytes.IsEmpty())
                return "";

            var Char = new char[Bytes.Length * 2 + 2];
            Char[0] = '0'; Char[1] = 'x';

            for (int Index1 = 0, Index2 = 2; Index1 < Bytes.Length; ++Index1, ++Index2)
                {
                byte Byte = (byte)(Bytes[Index1] >> 4);
                Char[Index2] = (char)(Byte > 9 ? Byte + 0x37 : Byte + 0x30);
                Byte = (byte)(Bytes[Index1] & 0xF);
                Char[++Index2] = (char)(Byte > 9 ? Byte + 0x37 : Byte + 0x30);
                }

            return new string(Char);
            }
        #endregion

        #region ToStream
        /// <summary>
        /// Converts an input string into a memory stream.
        /// </summary>
        [Tested]
        public static Stream ToStream(this string Str)
            {
            var Stream = new MemoryStream();
            var Writer = new StreamWriter(Stream);
            Writer.Write(Str);
            Writer.Flush();
            Stream.Position = 0;
            return Stream;
            }
        #endregion

        #region ToUrlSlug
        /// <summary>
        /// Takes a String and returns a URL Slug String.
        /// Ex. Good Example  -> good-example
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "    " }, "")]
        [TestResult(new object[] { "a" }, "a")]
        [TestResult(new object[] { "A" }, "a")]
        [TestResult(new object[] { "  BlahBlah  " }, "blahblah")]
        [TestResult(new object[] { "  Blah Blah  " }, "blah-blah")]
        [TestResult(new object[] { "  BLAH_BLAH  " }, "blah-blah")]
        public static string ToUrlSlug(this string In)
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

        #region Trim
        /// <summary>
        /// Returns <paramref name="In" /> with <paramref name="TrimStr" /> removed from the start and 
        /// end if it's present. Trims multiple occurrences.
        /// </summary>
        [TestResult(new object[] { null, null }, "")]
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "abc", "" }, "abc")]
        [TestResult(new object[] { "abc", "a" }, "bc")]
        [TestResult(new object[] { "abc", "ab" }, "c")]
        [TestResult(new object[] { "abc", "bc" }, "a")]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "aabbbbbbbaaaaaaaa", "a" }, "bbbbbbb")]
        // ReSharper restore StringLiteralTypo
        public static string Trim(this string In, string TrimStr)
            {
            if (string.IsNullOrEmpty(In) || string.IsNullOrEmpty(TrimStr))
                return In ?? "";

            return In.TrimEnd(TrimStr).TrimStart(TrimStr);
            }
        #endregion

        #region TrimEnd
        /// <summary>
        /// Returns <paramref name="In" /> with <paramref name="TrimStr" /> removed from the end 
        /// if it's present. Trims multiple occurrences.
        /// </summary>        
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "abc", "" }, "abc")]
        [TestResult(new object[] { "abc", "a" }, "abc")]
        [TestResult(new object[] { "abc", "ab" }, "abc")]
        [TestResult(new object[] { "abc", "bc" }, "a")]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "aabbbbbbbaaaaaaaa", "a" }, "aabbbbbbb")]
        // ReSharper restore StringLiteralTypo
        public static string TrimEnd(this string In, string TrimStr)
            {
            if (string.IsNullOrEmpty(In) || string.IsNullOrEmpty(TrimStr))
                return In ?? "";

            while (In.EndsWith(TrimStr))
                {
                In = In == TrimStr ?
                    "" :
                    In.Substring(0, In.Length - TrimStr.Length);
                }

            return In;
            }
        #endregion

        #region TrimStart
        /// <summary>
        /// Returns <paramref name="In" /> with <paramref name="TrimStr" /> removed from the start 
        /// if it's present. Trims multiple occurrences.
        /// </summary>
        [TestResult(new object[] { "", null }, "")]
        [TestResult(new object[] { "", "" }, "")]
        [TestResult(new object[] { "abc", "" }, "abc")]
        [TestResult(new object[] { "abc", "a" }, "bc")]
        [TestResult(new object[] { "abc", "ab" }, "c")]
        [TestResult(new object[] { "abc", "bc" }, "abc")]
        // ReSharper disable StringLiteralTypo
        [TestResult(new object[] { "aabbbbbbbaaaaaaaa", "a" }, "bbbbbbbaaaaaaaa")]
        // ReSharper restore StringLiteralTypo
        public static string TrimStart(this string In, string TrimStr)
            {
            if (string.IsNullOrEmpty(In) || string.IsNullOrEmpty(TrimStr))
                return In ?? "";

            while (In.StartsWith(TrimStr))
                {
                In = In == TrimStr ?
                    "" :
                    In.Substring(TrimStr.Length);
                }

            return In;
            }
        #endregion

        #region Words
        /// <summary>
        /// Takes a String and returns its words in an array. Removes newlines.
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, new string[] { })]
        [TestResult(new object[] { "" }, new string[] { })]
        [TestResult(new object[] { " " }, new string[] { })]
        [TestResult(new object[] { "a a" }, new[] { "a", "a" })]
        [TestResult(new object[] { "a few words" }, new[] { "a", "few", "words" })]
        [TestResult(new object[] { "a couple lines\r\n to test" }, new[] { "a", "couple", "lines", "to", "test" })]
        public static string[] Words(this string In)
            {
            return In.ReplaceAll("\r\n", " ").Split(" ");
            }
        #endregion

        #region XMLClean
        /// <summary>
        /// Returns a String with all HTML tags replaced with "&lt;" and "&gt;"
        /// </summary>
        /// <param name="In">Source string</param>
        /// <returns>A String with all HTML tags replaced with "&lt;" and "&gt;"</returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "abc" }, "abc")]
        [TestResult(new object[] { "<abc>" }, "&lt;abc&gt;")]
        [TestResult(new object[] { "<abc></abc>" }, "&lt;abc&gt;&lt;/abc&gt;")]
        public static string XmlClean(this string In)
            {
            return (In ?? "").ReplaceAll("<", "&lt;").ReplaceAll(">", "&gt;");
            }
        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains System.String static methods and lambdas.
        /// </summary>
        public static class Str
            {
            #region Constants +
            /// <summary>
            /// New line string (C# "\r\n")
            /// </summary>
            public const string NewLineString = "\r\n"; // System.Environment.NewLine 

            #endregion

            #region Lambdas +

            #region Char

            /// <summary>
            /// Character indexer returns the character at index <paramref name="i" />
            /// </summary>
            public static char Char(string Str, int i)
                {
                return Str[i];
                }

            #endregion

            #region Empty

            /// <summary>
            /// Func that returns an empty string.
            /// </summary>
            public static readonly Func<string> Empty = () => "";

            #endregion

            #region JoinLines
            /// <summary>
            /// Function that joins strings from an IEnumerable <paramref name="Line" />.
            /// </summary>
            public static string JoinLines(IEnumerable<string> Line, string CombineStr)
                {
                return Line.Combine(CombineStr);
                }

            #endregion

            #region NumericalCompare
            /// <summary>
            /// Compares a string numerically, begin mindful of strings with sequences of numbers.
            /// Ex: File0005
            /// </summary>
            public static readonly Func<string, string, int> NumericalCompare = (Compare1, Compare2) =>
                {
                    int Len1 = Compare1.Length;
                    int Len2 = Compare2.Length;
                    int Marker1 = 0;
                    int Marker2 = 0;

                    // Walk through two the strings with two markers.
                    while (Marker1 < Len1 && Marker2 < Len2)
                        {
                        char Ch1 = Compare1[Marker1];
                        char Ch2 = Compare2[Marker2];

                        // Some buffers we can build up characters in for each chunk.
                        var Space1 = new char[Len1];
                        int Loc1 = 0;
                        var Space2 = new char[Len2];
                        int Loc2 = 0;

                        // Walk through all following characters that are digits or
                        // characters in BOTH strings starting at the appropriate marker.
                        // Collect char arrays.
                        do
                            {
                            Space1[Loc1++] = Ch1;
                            Marker1++;

                            if (Marker1 < Len1)
                                {
                                Ch1 = Compare1[Marker1];
                                }
                            else
                                {
                                break;
                                }
                            } while (char.IsDigit(Ch1) == char.IsDigit(Space1[0]));

                        do
                            {
                            Space2[Loc2++] = Ch2;
                            Marker2++;

                            if (Marker2 < Len2)
                                {
                                Ch2 = Compare2[Marker2];
                                }
                            else
                                {
                                break;
                                }
                            } while (char.IsDigit(Ch2) == char.IsDigit(Space2[0]));

                        // If we have collected numbers, compare them numerically.
                        // Otherwise, if we have strings, compare them alphabetically.
                        string Str1 = new string(Space1);
                        string Str2 = new string(Space2);

                        int Result;

                        if (char.IsDigit(Space1[0]) && char.IsDigit(Space2[0]))
                            {
                            int ThisNumericChunk = int.Parse(Str1);
                            int ThatNumericChunk = int.Parse(Str2);
                            Result = ThisNumericChunk.CompareTo(ThatNumericChunk);
                            }
                        else
                            {
                            Result = string.Compare(Str1, Str2, StringComparison.Ordinal);
                            }

                        if (Result != 0)
                            {
                            return Result;
                            }
                        }
                    return Len1 - Len2;
                };

            #endregion

            #region Pluralize

            /// <summary>
            /// Takes a string and returns a pluralized version of the word or phrase.
            /// This method will not fail. If the input is empty it will just return "".
            /// 
            /// <paramref name="Count" /> is used as the number of things you're referring to. 
            /// If you pass 1 (or -1), pluralization will not be applied
            /// </summary>
            public static string Pluralize(string Str, int Count)
                {
                if (Str.IsEmpty())
                    return "";

                if (Count == 0 || Math.Abs(Count) > 1)
                    return
                        PluralizationService.CreateService(
                            CultureInfo.CurrentCulture).Pluralize(Str);
                return Str ?? "";
                }

            #endregion

            #region RemoveChars

            /// <summary>
            /// Function that removes any of the supplied characters from a string.
            /// </summary>
            public static string RemoveChars(string Str, char[] Chars)
                {
                return Str.CollectStr(Substitute.Supply(Chars).Supply2(' ')).ReplaceAll("  ", " ").Trim();
                }

            #endregion

            #region ReplaceDouble
            /// <summary>
            /// Function that replaces all double occurrences of a string with single occurrences.
            /// </summary>
            public static readonly Func<string, char, string> ReplaceDouble = (StrIn, Char) =>
                {
                    string Str = Char.ToString();
                    return StrIn.ReplaceAll(Str + Str, Str);
                };

            #endregion

            #region Singularize

            /// <summary>
            /// Takes a string and returns a singularized version of the word or phrase.
            /// This method will not fail. If the input is empty it will just return "".
            /// </summary>
            public static readonly Func<string, string> Singularize = Str =>
                    Str.IsEmpty()
                        ? ""
                        : PluralizationService.CreateService(
                            CultureInfo.CurrentCulture).Singularize(Str);

            #endregion

            #region Substitute
            internal static readonly Func<char[], char, char, char> Substitute =
                (Chars, Char, Substitute) => Chars.Contains(Char) ? Substitute : Char;

            #endregion

            #region Surround

            /// <summary>
            /// Surrounds a string with <paramref name="Before" /> and <paramref name="After" />
            /// </summary>
            public static string Surround(string In, string Before, string After)
                {
                if (In.IsEmpty())
                    return "";

                return Before + In + After;
                }

            #endregion

            #region ToS
            /// <summary>
            /// Converts an object or IEnumerable to a detailed string.
            /// Ex: "System.String[] { a, b, c, d, e }"
            /// </summary>
            public static readonly Func<object, string> ToS =
                o =>
                {
                    if (o == null)
                        return "";
                    string Str = o as string;
                    if (Str != null)
                        {
                        return Str;
                        }
                    var Enumerable = o as IEnumerable;
                    return Enumerable != null ?
                        $"{Enumerable.GetType().FullName} {{ {Enumerable.Array().Convert(ToS).Combine(", ")} }}" :
                        o.ToString();
                };
            #endregion

            #endregion
            }

        /// <summary>
        /// Contains System.Char static methods and lambdas.
        /// </summary>
        public static class Char
            {
            #region Constants +
            /// <summary>
            /// New line character (C# '\n')
            /// </summary>
            public const char NewLineChar = '\n';

            /// <summary>
            /// Array of lower case characters for passwords (char[])
            /// </summary>
            public static readonly char[] LowerCaseChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            /// <summary>
            /// Array of upper case characters for passwords (char[])
            /// </summary>
            public static readonly char[] UpperCaseChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            /// <summary>
            /// Array of number characters for passwords (char[])
            /// </summary>
            public static readonly char[] NumberChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            /// <summary>
            /// Array of special characters for passwords (char[])
            /// </summary>
            public static readonly char[] SpecialChars = { '!', '#', '$', '%', '&', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '{', '|', '}' };
            #endregion
            }
        }
    }