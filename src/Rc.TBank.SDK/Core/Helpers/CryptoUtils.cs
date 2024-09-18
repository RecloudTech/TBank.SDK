using System.Security.Cryptography;
using System.Text;

namespace Rc.TBank.SDK.Core.Helpers;

public class CryptoUtils
{
    public static string ComputeSha256Hash(string rawData)
    {
        using (var sha256Hash = SHA256.Create())
        {
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            var builder = new StringBuilder();
            foreach (var t in bytes) builder.Append(t.ToString("x2"));
            return builder.ToString();
        }
    }

    public static string EncryptRsa(string content, RSA publicKey)
    {
        var plainBuffer = Encoding.UTF8.GetBytes(content);
        var encryptedBuffer = publicKey.Encrypt(plainBuffer, RSAEncryptionPadding.Pkcs1);

        return Convert.ToBase64String(encryptedBuffer);
    }
}