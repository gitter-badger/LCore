using System;
using System.Collections.Generic;
using System.Linq;
using LCore.Extensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace LMVC.Account
    {
    public static class Authentication
        {
        // Default length a UserSession will be valid.
        public static readonly TimeSpan UserSessionLength = new TimeSpan(0, 0, 30, 0);

        public static readonly TimeSpan UserAccountPasswordExpire = new TimeSpan(90, 0, 0, 0);

        public static readonly char[] Password_UpperChars = Enumerable.Range(65, 26).Select(Char => (char)Char).ToArray();
        public static readonly char[] Password_LowerChars = Enumerable.Range(97, 26).Select(Char => (char)Char).ToArray();
        public static readonly char[] Password_NumberChars = Enumerable.Range(48, 26).Select(Char => (char)Char).ToArray();
        public static readonly char[] Password_SpecialChars = { '!', '#', '$', '%', '&', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '{', '|', '}' };

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
                    Out.Add(Password_LowerChars.RandomItem());
                    }
                }

            if (Rules.UpperCaseMinimum > 0)
                {
                for (int Index = 0; Index < Rules.UpperCaseMinimum; Index++)
                    {
                    Out.Add(Password_UpperChars.RandomItem());
                    }
                }

            if (Rules.NumberMinimum > 0)
                {
                for (int Index = 0; Index < Rules.NumberMinimum; Index++)
                    {
                    Out.Add(Password_NumberChars.RandomItem());
                    }
                }

            if (Rules.SpecialMinimum > 0)
                {
                for (int Index = 0; Index < Rules.SpecialMinimum; Index++)
                    {
                    Out.Add(Password_SpecialChars.RandomItem());
                    }
                }

            while (Out.Count < Length)
                {
                Out.Add(Password_LowerChars.RandomItem());
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
                int CountLower = Password.Count(Char => Password_LowerChars.Contains(Char));
                int CountUpper = Password.Count(Char => Password_UpperChars.Contains(Char));
                int CountNumbers = Password.Count(Char => Password_NumberChars.Contains(Char));
                int CountSpecial = Password.Count(Char => Password_SpecialChars.Contains(Char));

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
