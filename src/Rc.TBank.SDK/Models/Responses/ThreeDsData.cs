namespace Rc.TBank.SDK.Models.Responses;

/// <summary>
///     Хранит данные, необходимые для прохождения 3DS.
/// </summary>
public class ThreeDsData
{
    /// <summary>
    ///     Возвращает Access Control Server Url
    /// </summary>
    public string ACSUrl { get; internal set; }

    /// <summary>
    ///     Возвращает данные продавца.
    /// </summary>
    public string MD { get; internal set; }

    /// <summary>
    ///     Возвращает запрос на аутентификацию плательщика.
    /// </summary>
    public string PaReq { get; internal set; }

    /// <summary>
    ///     Возвращает флаг, требует ли терминал прохождения 3DS.
    /// </summary>
    public bool IsThreeDsNeed { get; internal set; }
}