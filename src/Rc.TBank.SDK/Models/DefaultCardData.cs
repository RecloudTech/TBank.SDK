using System.Security.Cryptography;
using Rc.TBank.SDK.Core.Helpers;

namespace Rc.TBank.SDK.Models;

public class DefaultCardData : CardData
{
    /// <summary>
    ///     Номер карты.
    /// </summary>
    public string Pan { get; set; }

    /// <summary>
    ///     Срок действия.
    /// </summary>
    public string ExpiryDate { get; set; }

    /// <summary>
    ///     Защитный код.
    /// </summary>
    public string SecureCode { get; set; }

    internal override string Encode(RSA publicKey)
    {
        return CryptoUtils.EncryptRsa($"PAN={Pan};ExpDate={ExpiryDate};CVV={SecureCode}", publicKey);
    }
}