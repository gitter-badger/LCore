using System;
using System.Reflection;
using System.Security.Cryptography;
using LCore.Extensions;

// ReSharper disable MemberCanBePrivate.Global

namespace LMVC.Account
    {
    public static class Crypto
        {
        public const string Salt = "76032832-8D9A-48C1-88CF-0592BA9801EB";

        public static SHA256 GetSHA()
            {
            try
                {
                return SHA256CryptoServiceProvider.Create();
                }
            catch (TargetInvocationException)
                {
                return null;
                }
            }

        public static string GetHash(string In)
            {
            var SHA = GetSHA();

            // Add Salt
            In += Salt;

            byte[] Bytes = SHA.ComputeHash(In.ToStream());

            string Out = Bytes.ToHexString();

            return Out;
            }
        }
    }
