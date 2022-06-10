namespace SocialMedia.Helper.Crypto
{
    public interface ICryptoHelper
    {
        string Decrypt(string input);
        string Encrypt(string input);
    }
}