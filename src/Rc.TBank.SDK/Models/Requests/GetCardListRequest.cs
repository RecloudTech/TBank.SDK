namespace Rc.TBank.SDK.Models.Requests;

internal sealed class GetCardListRequest : AcquiringRequest
{
    #region Methods

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(CustomerKey))
            dictionary.Add(Fields.CUSTOMERKEY, CustomerKey);
        return dictionary;
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "GetCardList";

    /// <summary>
    ///     Возвращает идентификатор покупателя в системе Продавца.
    /// </summary>
    public string CustomerKey { get; set; }

    #endregion
}