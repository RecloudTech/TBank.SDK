using System.Security.Cryptography;
using Rc.TBank.SDK.Interfaces;
using Rc.TBank.SDK.Models.Exceptions;

namespace Rc.TBank.SDK.Core.Helpers;

/// <summary>
///     Обеспечивает функциональность для создания RSA ключа из предоставленной строковой источника.
/// </summary>
public class StringKeyCreator : IKeyCreator
{
    /// <summary>
    ///     Содержит строковой источник, из которого будет сгенерирован RSA ключ.
    /// </summary>
    private readonly string _source;

    /// <summary>
    ///     Создаёт экземпляр.
    /// </summary>
    /// <param name="source">Строка с ключом.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public StringKeyCreator(string source)
    {
        if (string.IsNullOrEmpty(source))
            throw new ArgumentNullException("Source cannot be null or empty");

        _source = source;
    }

    /// <summary>
    ///     Создаёт ключ на основе строки с ключом.
    /// </summary>
    /// <returns>Созданный ключ RSA.</returns>
    /// <exception cref="AcquiringSdkException">Если не удалось создать или декодировать ключ.</exception>
    public RSA Create()
    {
        try
        {
            var publicBytes = Convert.FromBase64String(_source);

            var rsa = DecodeRsaPublicKey(publicBytes);

            if (rsa == null)
                throw new AcquiringSdkException("Не удалось декодировать публичный ключ");

            return rsa;
        }
        catch (Exception exception)
        {
            throw new AcquiringSdkException("Не удалось создать публичный ключ", exception);
        }
    }

    /// <summary>
    ///     Декодирует открытый RSA ключ из массива байт.
    /// </summary>
    /// <param name="publicBytes">Массив байт, содержащий открытый RSA ключ.</param>
    /// <returns>Инициализированный экземпляр класса <see cref="RSA" /> или null, если декодирование не удалось.</returns>
    /// <exception cref="CryptographicException"></exception>
    private static RSA DecodeRsaPublicKey(byte[] publicBytes)
    {
        var rsa = RSA.Create();
        try
        {
            rsa.ImportSubjectPublicKeyInfo(publicBytes, out _);
        }
        catch (CryptographicException)
        {
            try
            {
                rsa.ImportRSAPublicKey(publicBytes, out _);
            }
            catch (CryptographicException)
            {
                rsa = null;
            }
        }

        return rsa;
    }
}