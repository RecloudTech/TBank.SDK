namespace Rc.TBank.SDK.Models.Requests;

/// <summary>
///     Представляет настройки запроса.
/// </summary>
internal abstract class AcquiringRequest
{
    #region Methods

    public virtual IDictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            { Fields.TERMINALKEY, TerminalKey },
            { Fields.TOKEN, Token }
        };
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public abstract string Operation { get; }

    /// <summary>
    ///     Возвращает идентификатор терминала, выдается Продавцу Банком.
    /// </summary>
    public string TerminalKey { get; set; }

    /// <summary>
    ///     Возвращает подпись запроса.
    /// </summary>
    public string Token { get; set; }

    #endregion
}