using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace heinousHorror.Helper
{
    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, HashAlgorithm hashAlgorithm, int saltLength)
        {
            RandomNumberGenerator.RNG rng = new RandomNumberGenerator.RNG();
            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            var digestBytes = hashAlgorithm.ComputeHash(passwordWithSaltBytes.ToArray());

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }
        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt, HashAlgorithm hashAlgorithm)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(enteredPassword);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            var digestBytes = hashAlgorithm.ComputeHash(passwordWithSaltBytes.ToArray());
            return Convert.ToBase64String(digestBytes) == storedHash;
        }
    }
}