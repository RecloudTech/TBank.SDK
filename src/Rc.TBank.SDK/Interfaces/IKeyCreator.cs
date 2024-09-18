using System.Security.Cryptography;

namespace Rc.TBank.SDK.Interfaces;

/// <summary>
///     Интерфейс для реализации собственного механизма создания ключей.
/// </summary>
public interface IKeyCreator
{
    /// <summary>
    ///     Создаёт ключ.
    /// </summary>
    /// <returns>Созданный ключ</returns>
    RSA Create();
}