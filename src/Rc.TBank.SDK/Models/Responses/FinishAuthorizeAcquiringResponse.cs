namespace Rc.TBank.SDK.Models.Responses;

public class FinishAuthorizeAcquiringResponse : BaseAcquiringResponse
{
    /// <summary>
    ///     Возвращает Access Control Server Url.
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
}