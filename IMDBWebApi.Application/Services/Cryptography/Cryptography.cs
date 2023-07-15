
using System.Security.Cryptography;
using System.Text;

namespace IMDBWebApi.Application.Services.Cryptography
{
    public class Cryptography : ICryptography
    {
        public byte[] CryptographyPassword(string plainText, byte[] salt) 
            => SHA256.HashData(Encoding.UTF8.GetBytes(plainText).Concat(salt).ToArray());

        public byte[] CreateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[12];
            rng.GetBytes(buff);
            return buff;
        }

        public bool VerifyPassword(byte[] originalHashSalt, byte[] originalSalt, string plainText)
        {
            var plainTextHash = CryptographyPassword(plainText, originalSalt);
            return plainTextHash.SequenceEqual(originalHashSalt);
        }
    }
}
