namespace Rc.TBank.SDK.Models.Requests;

internal sealed class ChargeRequest : AcquiringRequest
{
    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "Charge";

    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public string PaymentId { get; set; }

    /// <summary>
    ///     Возвращает идентификатор рекуррентного платежа.
    /// </summary>
    public string RebillId { get; set; }

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(PaymentId))
            dictionary.Add(Fields.PAYMENTID, PaymentId);
        if (!string.IsNullOrEmpty(RebillId))
            dictionary.Add(Fields.REBILLID, RebillId);
        return dictionary;
    }
}