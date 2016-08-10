using System;
using System.Collections.Generic;
using LCore.Extensions;
using Enumerable = System.Linq.Enumerable;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace LMVC.Account
    {
    public static class Authentication
        {
        // Default length a UserSession will be valid.
        public static readonly TimeSpan UserSessionLength = new TimeSpan(days: 0, hours: 0, minutes: 30, seconds: 0);

        public static readonly TimeSpan UserAccountPasswordExpire = new TimeSpan(days: 90, hours: 0, minutes: 0, seconds: 0);

        // ReSharper disable PossibleNullReferenceException
        public static readonly char[] Password_UpperChars =
            Enumerable.Range(start: 65, count: 26).Convert(Char => (char) Char.TryConvertTo<char>()).Array();

        public static readonly char[] Password_LowerChars =
            Enumerable.Range(start: 97, count: 26).Convert(Char => (char) Char.TryConvertTo<char>()).Array();

        public static readonly char[] Password_NumberChars =
            Enumerable.Range(start: 48, count: 26).Convert(Char => (char) Char.TryConvertTo<char>()).Array();

        // ReSharper restore PossibleNullReferenceException
        public static readonly char[] Password_SpecialChars =
            {
            '!', '#', '$', '%', '&', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';',
            '<', '=', '>', '?', '@', '[', '\\', ']', '{', '|', '}'
            };

        public const string DateFormat = "yyyy-MM-dd h:mm tt";

        public static readonly PasswordRequirementRules PasswordDefaultRules = new PasswordRequirementRules
            {
            LengthMinimum = 8,
            LengthMaximum = null,
            LowerCaseMinimum = 1,
            NumberMinimum = 1,
            SpecialMinimum = null,
            UpperCaseMinimum = null
            };

        public struct PasswordRequirementRules
            {
            public int? LengthMinimum { get; set; }
            public int? LengthMaximum { get; set; }

            public int? LowerCaseMinimum { get; set; }
            public int? UpperCaseMinimum { get; set; }
            public int? NumberMinimum { get; set; }
            public int? SpecialMinimum { get; set; }
            }

        public static string GenerateRandomPassword(int? Length)
            {
            return GenerateRandomPassword(Length, PasswordDefaultRules);
            }

        public static string GenerateRandomPassword(int? Length, PasswordRequirementRules Rules)
            {
            if (Length == null)
                Length = Rules.LengthMinimum;

            if (Rules.LowerCaseMinimum + Rules.NumberMinimum + Rules.SpecialMinimum + Rules.UpperCaseMinimum > Length)
                Length = Rules.LowerCaseMinimum + Rules.NumberMinimum + Rules.SpecialMinimum + Rules.UpperCaseMinimum;

            var Out = new List<char>();

            if (Rules.LowerCaseMinimum > 0)
                {
                for (int Index = 0; Index < Rules.LowerCaseMinimum; Index++)
                    {
                    Out.Add(Password_LowerChars.Random());
                    }
                }

            if (Rules.UpperCaseMinimum > 0)
                {
                for (int Index = 0; Index < Rules.UpperCaseMinimum; Index++)
                    {
                    Out.Add(Password_UpperChars.Random());
                    }
                }

            if (Rules.NumberMinimum > 0)
                {
                for (int Index = 0; Index < Rules.NumberMinimum; Index++)
                    {
                    Out.Add(Password_NumberChars.Random());
                    }
                }

            if (Rules.SpecialMinimum > 0)
                {
                for (int Index = 0; Index < Rules.SpecialMinimum; Index++)
                    {
                    Out.Add(Password_SpecialChars.Random());
                    }
                }

            while (Out.Count < Length)
                {
                Out.Add(Password_LowerChars.Random());
                }

            Out = Out.Shuffle();

            string OutString = new string(Out.ToArray());

            return OutString;
            }

        public static bool PasswordFitsRules(string Password, PasswordRequirementRules Rules)
            {
            if (Rules.LengthMinimum > 0 && Password.Length < Rules.LengthMinimum)
                return false;
            if (Rules.LengthMaximum > 0 && Password.Length > Rules.LengthMaximum)
                return false;

            if (Rules.LowerCaseMinimum > 0 ||
                Rules.UpperCaseMinimum > 0 ||
                Rules.NumberMinimum > 0 ||
                Rules.SpecialMinimum > 0)
                {
                uint CountLower = Password.Count(Char => Password_LowerChars.Has(Char));
                uint CountUpper = Password.Count(Char => Password_UpperChars.Has(Char));
                uint CountNumbers = Password.Count(Char => Password_NumberChars.Has(Char));
                uint CountSpecial = Password.Count(Char => Password_SpecialChars.Has(Char));

                if (CountLower > 0 && CountLower < Rules.LowerCaseMinimum)
                    return false;

                if (CountUpper > 0 && CountUpper < Rules.UpperCaseMinimum)
                    return false;

                if (CountNumbers > 0 && CountNumbers < Rules.NumberMinimum)
                    return false;

                if (CountSpecial > 0 && CountSpecial < Rules.SpecialMinimum)
                    return false;
                }

            return true;
            }
        }
    }