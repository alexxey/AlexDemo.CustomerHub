using System.Security.Cryptography;

namespace AlexDemo.CustomerHub.Core.Application.ServiceProviders
{
    public sealed class PasswordServiceProvider
    {
        // Length of the salt
        private const int SaltSize = 16; // 128-bit
        
        // Length of the hash
        private const int HashSize = 32; // 256-bit
        
        // Number of iterations
        private const int Iterations = 10000;

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            // Generate a salt
            passwordSalt = new byte[SaltSize];
            RandomNumberGenerator.Fill(passwordSalt);

            // Hash the password along with the salt using PBKDF2
            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, passwordSalt, Iterations, HashAlgorithmName.SHA256);
            passwordHash = rfc2898DeriveBytes.GetBytes(HashSize);
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, storedSalt, Iterations, HashAlgorithmName.SHA256))
            {
                var computedHash = rfc2898DeriveBytes.GetBytes(HashSize);
                return AreHashesEqual(storedHash, computedHash);
            }
        }

        private static bool AreHashesEqual(byte[] hash1, byte[] hash2)
        {
            uint diff = (uint)hash1.Length ^ (uint)hash2.Length;
            for (int i = 0; i < hash1.Length && i < hash2.Length; i++)
            {
                diff |= (uint)(hash1[i] ^ hash2[i]);
            }
            return diff == 0;
        }
    }
}
