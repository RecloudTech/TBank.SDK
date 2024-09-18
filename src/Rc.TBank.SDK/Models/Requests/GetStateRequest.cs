namespace Rc.TBank.SDK.Models.Requests;

internal sealed class GetStateRequest : AcquiringRequest
{
    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "GetState";

    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public string PaymentId { get; set; }

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(PaymentId))
            dictionary.Add(Fields.PAYMENTID, PaymentId);
        return dictionary;
    }
}