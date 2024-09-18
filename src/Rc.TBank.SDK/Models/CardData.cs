using System.Security.Cryptography;

namespace Rc.TBank.SDK.Models;

/// <summary>
///     Интерфейс данных карты.
/// </summary>
public abstract class CardData
{
    internal abstract string Encode(RSA publicKey);
}