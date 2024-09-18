namespace Rc.TBank.SDK.Models.Requests;

internal sealed class FinishAuthorizeRequest : AcquiringRequest
{
    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "FinishAuthorize";

    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public string PaymentId { get; set; }

    /// <summary>
    ///     Возвращает параметр, который определяет отравлять email с квитанцией или нет.
    /// </summary>
    public bool SendEmail { get; set; }

    /// <summary>
    ///     Возвращает зашифрованные данные карты.
    /// </summary>
    public string CardData { get; set; }

    /// <summary>
    ///     Возвращает электронный адрес на который будет отправлена квитанция об оплате.
    /// </summary>
    public string InfoEmail { get; set; }

    #region Methods

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(PaymentId))
            dictionary.Add(Fields.PAYMENTID, PaymentId);
        if (SendEmail && !string.IsNullOrEmpty(InfoEmail))
        {
            dictionary.Add(Fields.SENDEMAIL, SendEmail.ToString().ToLower());
            dictionary.Add(Fields.INFOEMAIL, InfoEmail);
        }

        if (!string.IsNullOrEmpty(CardData))
            dictionary.Add(Fields.CARDDATA, CardData);
        return dictionary;
    }

    #endregion
}