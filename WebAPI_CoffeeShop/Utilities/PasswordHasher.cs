using System;
using System.Security.Cryptography;

namespace WebAPI_CoffeeShop.Utilities
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;
        private const string Prefix = "PBKDF2";

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = DeriveHash(password, salt, Iterations);
            return string.Join("$", Prefix, Iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public static bool VerifyPassword(string password, string storedPassword)
        {
            if (password == null || string.IsNullOrWhiteSpace(storedPassword))
            {
                return false;
            }

            if (!IsHashed(storedPassword))
            {
                return SlowEquals(storedPassword, password);
            }

            string[] parts = storedPassword.Split('$');
            if (parts.Length != 4 || !int.TryParse(parts[1], out int iterations))
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] expectedHash = Convert.FromBase64String(parts[3]);
            byte[] actualHash = DeriveHash(password, salt, iterations);
            return SlowEquals(expectedHash, actualHash);
        }

        public static bool IsHashed(string password)
        {
            return password != null && password.StartsWith(Prefix + "$", StringComparison.Ordinal);
        }

        private static byte[] DeriveHash(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static bool SlowEquals(string left, string right)
        {
            return SlowEquals(
                System.Text.Encoding.UTF8.GetBytes(left ?? string.Empty),
                System.Text.Encoding.UTF8.GetBytes(right ?? string.Empty));
        }

        private static bool SlowEquals(byte[] left, byte[] right)
        {
            uint diff = (uint)left.Length ^ (uint)right.Length;
            int length = Math.Min(left.Length, right.Length);

            for (int i = 0; i < length; i++)
            {
                diff |= (uint)(left[i] ^ right[i]);
            }

            return diff == 0;
        }
    }
}
