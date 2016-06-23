using System;
using System.Security.Cryptography;
using LCore.Extensions;

// ReSharper disable MemberCanBePrivate.Global

namespace Singularity.Account
    {
    public static class Crypto
        {
        public const string Salt = "D47D1450-FC43-483F-92CF-B0FE70D1DFE0";

        public static SHA256 GetSHA()
            {
            return SHA256CryptoServiceProvider.Create();
            }

        public static string GetHash(string In)
            {
            SHA256 SHA = GetSHA();

            // Add Salt
            In += Salt;

            byte[] Bytes = SHA.ComputeHash(In.ToStream());

            string Out = Bytes.ToHexString();

            return Out;
            }
        }
    }
