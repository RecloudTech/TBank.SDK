namespace Rc.TBank.SDK.Models.Requests;

internal sealed class RemoveCardRequest : AcquiringRequest
{
    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "RemoveCard";

    /// <summary>
    ///     Возвращает идентификатор карты в системе Банка.
    /// </summary>
    public string CardId { get; set; }

    /// <summary>
    ///     Возвращает идентификатор покупателя в системе Продавца.
    /// </summary>
    public string CustomerKey { get; set; }

    #region Methods

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(CardId))
            dictionary.Add(Fields.CARDID, CardId);
        if (!string.IsNullOrEmpty(CustomerKey))
            dictionary.Add(Fields.CUSTOMERKEY, CustomerKey);
        return dictionary;
    }

    #endregion
}