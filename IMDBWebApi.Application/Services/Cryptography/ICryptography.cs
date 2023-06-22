
namespace IMDBWebApi.Application.Services.Cryptography
{
    public interface ICryptography
    {
        byte[] CryptographyPassword(string plainText, byte[] salt);
        byte[] CreateSalt();
        bool VerifyPassword(byte[] originalHash, byte[] originalSalt, string plainText);
    }
}
