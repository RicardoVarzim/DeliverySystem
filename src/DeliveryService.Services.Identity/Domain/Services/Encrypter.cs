﻿using System;
using System.Security.Cryptography;

namespace DeliveryService.Services.Identity.Domain.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int SaltSize = 50;
        private static readonly int DeriveBytesIterationsCount = 10000;

        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);
            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private byte[] GetBytes(string salt)
        {
            var bytes = new byte[salt.Length * sizeof(char)];
            Buffer.BlockCopy(salt.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public string GetSalt(string value)
        {
            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}
