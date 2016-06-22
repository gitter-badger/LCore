using System;
using LCore.Extensions.ObjectExt;
using System.Collections.Generic;
// using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Collections;
using System.Globalization;
using LCore.Tests;
using System.Text.RegularExpressions;
// ReSharper disable StringCompareIsCultureSpecific.1
// ReSharper disable StringCompareToIsCultureSpecific
// ReSharper disable StringIndexOfIsCultureSpecific.2
// ReSharper disable StringIndexOfIsCultureSpecific.3
// ReSharper disable StringLastIndexOfIsCultureSpecific.1
// ReSharper disable StringLastIndexOfIsCultureSpecific.2
// ReSharper disable StringLastIndexOfIsCultureSpecific.3

namespace LCore.Extensions
    {
    public static class StringExt
        {
        #region Extensions
        #region AlignCenter
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
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
            return In.Pad(Length, Logic.Align.Center, PadChar);
            }
        #endregion

        #region AlignLeft
        /// <summary>
        /// Takes a string and returns a padded string aligned Left.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
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
            return In.Pad(Length, Logic.Align.Left, PadChar);
            }
        #endregion

        #region AlignRight
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
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
            return In.Pad(Length, Logic.Align.Right, PadChar);
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

        // TODO: L: String: Untested
        #region CleanCRLF
        internal const char CRLFReplace = (char)222;

        /// <summary>
        /// Returns a string with line enders replaced with a temporary character. 
        /// Used with http binary communication.
        /// </summary>
        /// <param name="In"></param>
        /// <returns>A string with line enders replaced with a temporary character</returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "abab" }, "abab")]
        [TestResult(new object[] { "abab\r\n" }, "abab")]
        [TestResult(new object[] { "abab▐" }, "abab")]
        public static string CleanCRLF(this string In)
            {
            return (In ?? "").ReplaceLineEnders(CRLFReplace);
            }

        /// <summary>
        /// Returns a string with line enders returned from a temporary character. 
        /// Used with http binary communication.
        /// </summary>
        /// <param name="In"></param>
        /// <returns>Astring with line enders returned from a temporary character. </returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "abab" }, "abab")]
        [TestResult(new object[] { "abab\r\n" }, "abab")]
        [TestResult(new object[] { "abab▐" }, "abab")]
        public static string UnCleanCRLF(this string In)
            {
            return (In ?? "").Replace(new string(new[] { CRLFReplace }), "\r\n");
            }

        #endregion

        #region Combine
        /// <summary>
        /// Combines an IEnumerable[String] using [In] as a separator string.
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
        [TestResult(new object[] { new[] { "b", "b", "b" }, "a" }, "babab")]
        [TestResult(new object[] { new[] { "b", "b", "b" }, "_a_" }, "b_a_b_a_b")]
        public static string Combine(this IEnumerable<string> In, string CombineStr)
            {
            string Out = "";
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

        #region Concatenate

        /// <summary>
        /// Concatonates a given String [In] to length [MaxLength] minus the length of [ConcatonateString].
        /// You can specify a Concatonation String, which defaults to "..."
        /// </summary>

        [TestResult(new object[] { null, 0 }, "")]
        [TestResult(new object[] { "test string", 5 }, "te...")]
        [TestResult(new object[] { "test string123456789", 15 }, "test string1...")]
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

        // TODO: L: String: Untested
        #region Count
        /// <summary>
        /// Returns the amount of times [Search] appears in [In]
        /// </summary>
        /// <param name="In">The source to search</param>
        /// <param name="Search">The search term</param>
        /// <returns>The amount of times [Search] appears in [In]</returns>
        [TestResult(new object[] { null, null }, 0)]
        [TestResult(new object[] { "", "" }, 0)]
        [TestResult(new object[] { "aaabbbccc", "" }, 0)]
        [TestResult(new object[] { "aaabbbccc", "a" }, 3)]
        [TestResult(new object[] { "aaabbbccc", "aa" }, 5)]
        [TestResult(new object[] { "aaabbbccc", "aaa" }, 1)]
        public static int Count(this string In, string Search)
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
        #endregion

        #region Fill
        /// <summary>
        /// Returns a String filled with [Count] characters of the source character.
        /// Throws an exception if [Count] is less than 0.
        /// </summary>
        [TestFails(new object[] { 'a', -1 })]
        [TestResult(new object[] { 'a', 0 }, "")]
        [TestResult(new object[] { 'a', 3 }, "aaa")]
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

        #region FormatFileSize
        /// <summary>
        /// Formats a file size Long into a friendly string, up to TB.
        /// The result will be displayed with [Decimals] shown. Bytes will not display decimals.
        /// </summary>
        [TestFails(new object[] { (long)-1, 1 })]
        [TestFails(new object[] { 1024 + 512, -1 })]
        [TestResult(new object[] { (long)0, 3 }, "0 B")]
        [TestResult(new object[] { (long)450, 3 }, "450 B")]
        [TestResult(new object[] { 1024 + (long)412, 0 }, "1 KB")]
        [TestResult(new object[] { 1024 + 512, 0 }, "2 KB")]
        [TestResult(new object[] { 1024 + 512, 2 }, "1.50 KB")]
        [TestResult(new object[] { 1024 + 512, 3 }, "1.500 KB")]
        [TestResult(new object[] { (long)(1024 * 1024 * 1024 * (long)1024 * (float)1.5), 5 }, "1.50000 TB")]
        [TestResult(new object[] { (long)35572226, 5 }, "33.92432 MB")]
        public static string FormatFileSize(this long Size, int Decimals)
            {
            if (Size < 0 || Decimals < 0)
                throw new ArgumentException("Size cannot be negative");

            double temp = Size;
            string Unit = "B";
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
                double Power = Math.Pow(10, Decimals);
                temp = Math.Round(temp * Power) / Power;
                }
            string Out = temp.ToString();

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
        /// The result will be displayed with [Decimals] shown. Bytes will not display decimals.
        /// </summary>

        [TestFails(new object[] { -1, 1 })]
        [TestFails(new object[] { 1024 + 512, -1 })]
        [TestFails(new object[] { (long)-1 })]
        [TestResult(new object[] { (long)0 }, "0 B")]
        [TestResult(new object[] { (long)1 }, "1 B")]
        [TestResult(new object[] { (long)1024 }, "1 KB")]
        [TestResult(new object[] { 1024 + (long)411 }, "1 KB")]
        [TestResult(new object[] { 1024 + (long)512 }, "2 KB")]
        [TestResult(new object[] { 1024 * 1024 + 512 }, "1 MB")]
        [TestResult(new object[] { 1024 * 1024 }, "1 MB")]
        [TestResult(new object[] { 1024 * 1024 * 5 }, "5 MB")]
        [TestResult(new object[] { 1024 * 1024 * 1024 }, "1 GB")]
        [TestResult(new object[] { (long)1024 * 1024 * 1024 * 1024 }, "1 TB")]
        [TestResult(new object[] { (long)35572226 }, "34 MB")]
        [TestResult(new object[] { 0, 3 }, "0 B")]
        [TestResult(new object[] { 450, 3 }, "450 B")]
        [TestResult(new object[] { 1024 + 412, 0 }, "1 KB")]
        [TestResult(new object[] { 1024 + 512, 0 }, "2 KB")]
        [TestResult(new object[] { 1024 + 512, 2 }, "1.50 KB")]
        [TestResult(new object[] { 1024 + 512, 3 }, "1.500 KB")]
        [TestResult(new object[] { 35572226, 5 }, "33.92432 MB")]
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static string FormatFileSize(this int Size, int Decimals = 0)
            {
            if (Decimals <= 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double temp = Size;
            string Unit = "B";
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
                double Power = Math.Pow(10, Decimals);
                temp = Math.Round(temp * Power) / Power;
                }
            string Out = temp.ToString();

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

        // TODO: L: String: Untested
        #region HasMatch
        /// <summary>
        /// Returns true if any expressions return a Regex match.
        /// </summary>
        /// <param name="In">String source</param>
        /// <param name="Expressions">Expressions to evaluate</param>
        /// <returns>true if any expressions return a Regex match.</returns>
        public static bool HasMatch(this string In, params string[] Expressions)
            {
            return Expressions.Count(s =>
            {
                Regex Reg = new Regex(s);
                MatchCollection Matches = Reg.Matches(In);
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
            char last = ' ';

            string Out = (FieldName ?? "").Trim().CollectStr<char, string>(
                (i, c) =>
                    {
                        if (i == 0 ||
                            (last.IsNumber() && !c.IsNumber()) ||
                            (!last.IsNumber() && c.IsNumber()) ||
                            (!char.IsUpper(last) && char.IsUpper(c)))
                            {
                            last = c;
                            return (i != 0 ? " " : "") + c.ToString().ToUpper();
                            }
                        last = c;
                        return c.ToString();
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
        /// Returns whethre a char is a number.
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

        // TODO: L: String: Untested
        #region IsSymmetrical
        /// <summary>
        /// Returns true if the source [In] is symmetrical to [Compare]. 
        /// Symmetry guages how similar two strings are from 0 to 1.
        /// Default threshhold is 95% Symmetry (0.95).
        /// </summary>
        /// <param name="In">The string to compare</param>
        /// <param name="Compare">The string to compare with</param>
        /// <param name="Threshhold">Double from 0 to 1, Required threshhold percent default 0.95</param>
        /// <returns> true if the source [In] is symmetrical to [Compare]. </returns>
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
        [TestResult(new object[] { new[] { "a", "a" }, Logic.Def.StringExt.NewLineString }, "a\r\na")]
        [TestResult(new object[] { new[] { "a", "a" }, "blah" }, "ablaha")]
        public static string JoinLines(this IEnumerable<string> In, string JoinStr = Logic.Def.StringExt.NewLineString)
            {
            return Logic.Def.StringExt.JoinLines(In, JoinStr);
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

            for (int i = 0; i < Out2.Length; i++)
                {
                Out2[i] = Out2[i].Trim();
                }
            return Out2;
            }
        #endregion

        // TODO: L: String: Untested
        #region Matches
        /// <summary>
        /// Returns all matches for [In] nad Regex [Expression].
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Expression"></param>
        /// <returns>All matches for [In] nad Regex [Expression].</returns>
        public static List<Match> Matches(this string In, string Expression)
            {
            Regex Reg = new Regex(Expression);
            MatchCollection Matches = Reg.Matches(In);
            return Matches.List<Match>();
            }
        #endregion

        #region Pad
        /// <summary>
        /// Takes a string and returns a padded string aligned either on the Left or Right. Left = true for left, false for Right.
        /// The pad character defaults to a space ' '.
        /// If [In] is longer than [Length], the result is [In] truncated to [Length].
        /// This method will only fail if [Length] is less than 0.
        /// </summary>
        [TestFails(new object[] { null, -1, Logic.Align.Right, (char)0 })]
        [TestFails(new object[] { "a", -1, Logic.Align.Right, ' ' })]
        [TestResult(new object[] { null, 5, Logic.Align.Left, ' ' }, "     ")]
        [TestResult(new object[] { " ", 5, Logic.Align.Left, ' ' }, "     ")]
        [TestResult(new object[] { "a", 5, Logic.Align.Left, ' ' }, "a    ")]
        [TestResult(new object[] { "a", 5, Logic.Align.Right, ' ' }, "    a")]
        [TestResult(new object[] { "a", 5, Logic.Align.Center, ' ' }, "  a  ")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Left, ' ' }, "abc  ")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Right, ' ' }, "  abc")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Center, ' ' }, " abc ")]
        [TestResult(new object[] { "   abc   ", 5, Logic.Align.Right, ' ' }, "  abc")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Left, ' ' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Right, ' ' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Center, ' ' }, "abcde")]
        [TestResult(new object[] { null, 5, Logic.Align.Left, '0' }, "00000")]
        [TestResult(new object[] { " ", 5, Logic.Align.Left, '0' }, "00000")]
        [TestResult(new object[] { "a", 5, Logic.Align.Left, '0' }, "a0000")]
        [TestResult(new object[] { "a", 5, Logic.Align.Right, '0' }, "0000a")]
        [TestResult(new object[] { "a", 5, Logic.Align.Center, '0' }, "00a00")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Left, '0' }, "abc00")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Right, '0' }, "00abc")]
        [TestResult(new object[] { "abc", 5, Logic.Align.Center, '0' }, "0abc0")]
        [TestResult(new object[] { "   abc   ", 5, Logic.Align.Left, '0' }, "abc00")]
        [TestResult(new object[] { "   abc   ", 5, Logic.Align.Right, '0' }, "00abc")]
        [TestResult(new object[] { "   abc   ", 5, Logic.Align.Center, '0' }, "0abc0")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Left, '0' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Right, '0' }, "abcde")]
        [TestResult(new object[] { "abcdef", 5, Logic.Align.Center, '0' }, "abcde")]
        [TestResult(new object[] { "   abc   ", 6, Logic.Align.Center, '0' }, "00abc0")]
        public static string Pad(this string In, int Length, Logic.Align Alignment = Logic.Align.Left, char PadChar = ' ')
            {
            if (In.IsEmpty())
                return PadChar.Fill(Length);

            In = In.Trim();

            if (In.Length > Length)
                return In.Substring(0, Length);
            while (In.Length < Length)
                {
                if (Alignment == Logic.Align.Left)
                    In += PadChar;
                else if (Alignment == Logic.Align.Right)
                    In = PadChar + In;
                else if (Alignment == Logic.Align.Center)
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
            return Logic.Def.StringExt.Pluralize(In, Count);
            }
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "blob" }, "blobs")]
        [TestResult(new object[] { "person" }, "people")]
        [TestResult(new object[] { "Entry" }, "Entries")]
        [TestResult(new object[] { "Entries" }, "Entries")]
        public static string Pluralize(this string In)
            {
            return Logic.Def.StringExt.Pluralize(In, 2);
            }
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { "blobs" }, "blob")]
        [TestResult(new object[] { "people" }, "person")]
        [TestResult(new object[] { "Entries" }, "Entry")]
        [TestResult(new object[] { "Entry" }, "Entry")]
        public static string Singularize(this string In)
            {
            return Logic.Def.StringExt.Singularize(In);
            }
        #endregion

        // TODO: L: String: Untested
        #region RemoveAll
        /// <summary>
        /// Returns a String based on [In] with all instances of [Find] removed.
        /// </summary>
        /// <param name="In">The source string</param>
        /// <param name="Find">The string to remove.</param>
        /// <returns>A String based on [In] with all instances of [Find] removed.</returns>
        public static string RemoveAll(this string In, string Find)
            {
            return In.ReplaceAll(Find, "");
            }
        #endregion

        #region ReplaceAll
        /// <summary>
        /// Takes a string and returns a string with all Occurrences of [Find] replaced with [Replace].
        /// This method will fail if [Find] is empty.
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
        #endregion

        // TODO: L: String: Untested
        #region ReplaceLineEnders


        /// <summary>
        /// Takes a string with possibly corrupted line enders and normalizes them all to \r\n.
        /// Removes duplicate \r and duplicate \r\n
        /// </summary>
        public static string ReplaceLineEnders(this string In, params char[] Chars)
            {
            if (!In.Contains("\n"))
                return In;

            string Out = In;

            Out = Out.Replace("\n", "\r\n");

            while (Out.Contains("\r\r"))
                {
                Out = Out.Replace("\r\r", "\r");
                }
            Out = Out.Replace("\r\n", new string(Chars));

            return Out;
            }
        #endregion#region ToUrlSlug

        #region Reverse
        /// <summary>
        /// Takes a String and returns a reversed string. 
        /// This method cannot fail.
        /// </summary>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { "" }, "")]
        [TestResult(new object[] { " " }, " ")]
        [TestResult(new object[] { "blahblah " }, " halbhalb")]
        public static string Reverse(this string In)
            {
            return new string((In ?? "").ToCharArray().Reverse());
            }
        #endregion

        #region Split
        /// <summary>
        /// Takes a String and returns a String[] split by the [SplitStr]
        /// This method will throw an Excpetion if [SplitStr] is empty.
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
        [TestResult(new object[] { "babab", "a" }, new[] { "b", "b", "b" })]
        [TestResult(new object[] { "abababa", "a" }, new[] { "b", "b", "b" })]
        public static string[] Split(this string In, string SplitStr)
            {
            if (string.IsNullOrEmpty(SplitStr))
                throw new ArgumentNullException(nameof(SplitStr));

            if (In.IsEmpty())
                return new string[] { };

            int i = In.IndexOf(SplitStr);

            if (i < 0)
                {
                return !In.IsEmpty() ? new[] { In } : new string[] { };
                }

            List<string> Out = new List<string>();
            In.Traverse(Cursor =>
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
                if (Index == 0)
                    {
                    return Cursor.Length > SplitStr.Length ? Cursor.Substring(SplitStr.Length) : null;
                    }
                if (Index > 0)
                    {
                    Out.Add(Cursor.Substring(0, Index));
                    return Cursor.Substring(Index);
                    }
                return null;
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

        // TODO: L: String: Untested
        #region SplitWithQuotes
        /// <summary>
        /// Returns a list of String segments from [Line], split by [SplitBy]
        /// Very useful for CSV column formatting.
        /// </summary>
        /// <param name="Line">Source string</param>
        /// <param name="SplitBy">Character to split by</param>
        /// <returns></returns>
        public static List<string> SplitWithQuotes(this string Line, char SplitBy)
            {
            List<string> Out = new List<string>();

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
            return Logic.Def.StringExt.Surround(In, Before, After);
            }
        #endregion

        // TODO: L: String: Untested
        #region Symmetry
        /// <summary>
        /// Returns the Percent of 'symmetry' between two strings. 
        /// Symmetry guages how similar two strings are from 0 to 1.
        /// </summary>
        /// <param name="In">The string to compare</param>
        /// <param name="Compare">The string to compare with</param>
        /// <returns>The Percent of 'symmetry between two strings as a double</returns>
        public static double Symmetry(this string In, string Compare)
            {
            In = In ?? "";
            Compare = Compare ?? "";

            List<string> pairs1 = WordLetterPairs(In.ToUpper());
            List<string> pairs2 = WordLetterPairs(Compare.ToUpper());

            int intersection = 0;
            int union = pairs1.Count + pairs2.Count;

            foreach (string t in pairs1)
                {
                for (int j = 0; j < pairs2.Count; j++)
                    {
                    if (t == pairs2[j])
                        {
                        intersection++;
                        pairs2.RemoveAt(j);//Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                        break;
                        }
                    }
                }

            return 2.0 * intersection / union;
            }

        private static List<string> WordLetterPairs(string str)
            {
            List<string> AllPairs = new List<string>();

            // Tokenize the string and put the tokens/words into an array
            string[] Words = Regex.Split(str, @"\s");

            // For each word
            foreach (string t in Words)
                {
                if (!string.IsNullOrEmpty(t))
                    {
                    // Find the pairs of characters
                    string[] PairsInWord = LetterPairs(t);

                    AllPairs.AddRange(PairsInWord);
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
        [TestResult(new object[] { "ablah", 1 }, "ablah")]
        [TestResult(new object[] { "ablah", 2 }, "ablahablah")]
        [TestResult(new object[] { "ablah", 5 }, "ablahablahablahablahablah")]
        public static string Times(this string In, int Count)
            {
            if (Count < 0)
                throw new ArgumentException("Count was less than 0.");
            if (Count == 0)
                return "";
            if (Count == 1)
                return In ?? "";

            string Out = "";

            for (int i = 0; i < Count; i++)
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
        /// Takes an array of Bytes and returns a friendly hexidecimal string.
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

            char[] c = new char[Bytes.Length * 2 + 2];
            c[0] = '0'; c[1] = 'x';

            for (int y = 0, x = 2; y < Bytes.Length; ++y, ++x)
                {
                byte b = (byte)(Bytes[y] >> 4);
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = (byte)(Bytes[y] & 0xF);
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                }

            return new string(c);
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

        // TODO: L: String: Untested
        #region XMLClean
        /// <summary>
        /// Returns a String with all HTML tags replaced with "&lt;" and "&gt;"
        /// </summary>
        /// <param name="In">Source string</param>
        /// <returns>A String with all HTML tags replaced with "&lt;" and "&gt;"</returns>
        public static string XMLClean(this string In)
            {
            return (In ?? "").Replace("<", "&lt;").Replace(">", "&gt;");
            }
        #endregion

        #endregion
        }

    public partial class Logic
        {
        public partial class Def
            {
            public class StringExt
                {
                #region Constants
                /// <summary>
                /// New line string (C# "\r\n")
                /// </summary>
                public const string NewLineString = "\r\n"; // System.Environment.NewLine 

                #endregion

                #region Lambdas
                public static readonly Func<string> Empty = () => "";
                public static readonly Func<string, int, char> Char = (s, i) => s[i];
                public static readonly Func<char[], char, char, char> Substitute = (chars, c, sub) => chars.Contains(c) ? sub : c;
                public static readonly Func<string, char[], string> RemoveChars = (s, chars) => s.Collect(Substitute.Supply(chars).Supply2(' '))
                    .ReplaceAll("  ", " ").Trim();
                public static readonly Func<string, char, string> ReplaceDouble = (s, c) =>
                {
                    string s2 = c.ToString();
                    return s.ReplaceAll(s2 + s2, s2);
                };
                public static readonly Func<string, int, string> Pluralize = (s, c) =>
                {
                    if (s.IsEmpty())
                        return "";

                    if (c == 0 || Math.Abs(c) > 1)
                        return System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(s);
                    return s ?? "";
                };
                public static readonly Func<string, string> Singularize = s => s.IsEmpty() ? "" : System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.CurrentCulture).Singularize(s);
                public static readonly Func<IEnumerable<string>, string, string> JoinLines = (l, s) => l.Combine(s);
                public static readonly Func<string, string, string, string> Surround = (In, before, after) =>
                {
                    if (In.IsEmpty())
                        return "";

                    return before + In + after;
                };
                public static readonly Func<string, string, int> NumericalCompare = (s1, s2) =>
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
                            result = string.Compare(str1, str2, StringComparison.Ordinal);
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

            public class CharExt
                {
                #region Constants
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
    public partial class L
        {
        #region ToS
        public static Func<object, string> FN_ToS =
            o =>
            {
                if (o == null)
                    return "";
                string s = o as string;
                if (s != null)
                    {
                    return s;
                    }
                IEnumerable enumerable = o as IEnumerable;
                return enumerable != null ? $"{enumerable.GetType().FullName} {{ {enumerable.Array().Convert(FN_ToS).Combine(", ")} }}" : o.ToString();
            };
        #endregion
        }
    }