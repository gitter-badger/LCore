using System;
using System.Collections.Generic;

using System.Text;

namespace LCore
    {
    public class NaturalCompare
        {
        // code from:
        // http://www.koders.com/cpp/fidF5AAF1A078FDF388A06B907831A5364B597E4E14.aspx?s=opengl

        // conversion to C# by David Hamel, 08/16/2010

        private Boolean match_case;

        public NaturalCompare()
            {
            match_case = true;
            }

        public NaturalCompare(Boolean _matchcase)
            {
            match_case = _matchcase;
            }

        // ---------------------------------------------------------------------------
        // compare 'a' and 'b' naturally: embedded sequences of digits are treated
        // numerically

        public int CompareNatural(string a, string b)
            {
            int ai, bi;
            char ca, cb;
            Boolean fractional;
            int result;

            for (ai = bi = 0; ; ai++, bi++)
                {
                // DRH: prevent indexing to null character
                ca = (ai == a.Length) ? '\0' : a[ai];
                cb = (bi == b.Length) ? '\0' : b[bi];

                // skip over leading spaces or zeros
                while (char.IsWhiteSpace(ca))
                    ca = a[++ai];

                while (char.IsWhiteSpace(cb))
                    cb = b[++bi];

                // process run of digits
                if (char.IsDigit(ca) && char.IsDigit(cb))
                    {
                    fractional = (ca == '0' || cb == '0');

                    if (fractional)
                        {
                        if ((result = CompareNaturalLeft(a, ai, b, bi)) != 0)
                            return result;
                        }
                    else
                        {
                        if ((result = CompareNaturalRight(a, ai, b, bi)) != 0)
                            return result;
                        }
                    }

                if (ca == '\0' && cb == '\0')
                    {
                    // The strings compare the same.  Perhaps the caller
                    // will want to call strcmp to break the tie.
                    return 0;
                    }

                if (!match_case)
                    {
                    ca = char.ToUpper(ca);
                    cb = char.ToUpper(cb);
                    }

                if (ca < cb)
                    return -1;
                else if (ca > cb)
                    return 1;
                }
            }

        // ---------------------------------------------------------------------------
        private int CompareNaturalRight(string a, int ai, string b, int bi)
            {
            int bias = 0;

            // The longest run of digits wins.  That aside, the greatest
            // value wins, but we can't know that it will until we've scanned
            // both numbers to know that they have the same magnitude, so we
            // remember it in 'bias'

            for (; ; ai++, bi++)
                {
                // DRH: indexing to the null character in a string raises an exception
                if (ai == a.Length && bi == b.Length)
                    return 0;
                else if (ai == a.Length)
                    return -1;
                else if (bi == b.Length)
                    return 1;

                else if (!char.IsDigit(a[ai]) && !char.IsDigit(b[bi]))
                    return bias;
                else if (!char.IsDigit(a[ai]))
                    return -1;
                else if (!char.IsDigit(b[bi]))
                    return 1;
                else if (a[ai] < b[bi])
                    {
                    if (bias == 0)
                        bias = -1;
                    }
                else if (a[ai] > b[bi])
                    {
                    if (bias == 0)
                        bias = 1;
                    }
                else if (a[ai] == '\0' && b[bi] == '\0')
                    {
                    return bias;
                    }
                }
            }

        // ---------------------------------------------------------------------------
        private int CompareNaturalLeft(string a, int ai, string b, int bi)
            {
            // Compare two left-aligned numbers: the first to have a
            // different value wins

            for (; ; ai++, bi++)
                {
                // DRH: added
                // indexing to the null character in a string raises an exception
                if (ai == a.Length && bi == b.Length)
                    return 0;
                else if (ai == a.Length)
                    return -1;
                else if (bi == b.Length)
                    return 1;

                else if (!char.IsDigit(a[ai]) && !char.IsDigit(b[bi]))
                    return 0;
                else if (!char.IsDigit(a[ai]))
                    return -1;
                else if (!char.IsDigit(b[bi]))
                    return 1;
                else if (a[ai] < b[bi])
                    return -1;
                else if (a[ai] > b[bi])
                    return 1;
                }
            }
        }
    }