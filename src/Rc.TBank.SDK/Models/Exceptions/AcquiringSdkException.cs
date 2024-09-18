namespace Rc.TBank.SDK.Models.Exceptions;

/// <summary>
///     Исключение выбрасываемое методами <see cref="AcquiringSdk" />.
/// </summary>
public class AcquiringSdkException : Exception
{
    #region Ctor

    protected AcquiringSdkException()
    {
    }

    internal AcquiringSdkException(string message) : base(message)
    {
    }

    public AcquiringSdkException(string message, Exception innerException) : base(message, innerException)
    {
    }

    #endregion
}