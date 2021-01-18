using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace heinousHorror.Helper
{
    public class RandomNumberGenerator
    {
        public class RNG
        {
            public string GenerateRandomCryptographicKey(int keyLength)
            {
                return Convert.ToBase64String(GenerateRandomCryptographicBytes(keyLength));
            }

            public byte[] GenerateRandomCryptographicBytes(int keyLength)
            {
                RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
                byte[] randomBytes = new byte[keyLength];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return randomBytes;
            }
        }
    }
}
