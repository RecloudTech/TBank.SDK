namespace Rc.TBank.SDK.Models.Requests;

internal sealed class InitRequest : AcquiringRequest
{
    /// <summary>
    ///     Вовзвращает имя опреации.
    /// </summary>
    public override string Operation => "Init";

    /// <summary>
    ///     Возвращает сумму в копейках.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///     Возвращает номер заказа в системе продавца.
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    ///     Возвращает краткое описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Возвращает название шаблона формы оплаты продавца.
    /// </summary>
    public string PayForm { get; set; }

    /// <summary>
    ///     Возвращает идентификатор покупателя в системе Продавца.
    /// </summary>
    public string CustomerKey { get; set; }

    /// <summary>
    ///     Возвращает параметр, который определяет регистрировать платеж как рекуррентный или нет.
    /// </summary>
    public bool Recurrent { get; set; }

    #region Methods

    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        dictionary.Add(Fields.AMOUNT, $"{Amount:0}");
        if (!string.IsNullOrEmpty(OrderId))
            dictionary.Add(Fields.ORDERID, OrderId);
        if (!string.IsNullOrEmpty(Description))
            dictionary.Add(Fields.DESCRIPTION, Description);
        if (!string.IsNullOrEmpty(PayForm))
            dictionary.Add(Fields.PAYFORM, PayForm);
        if (!string.IsNullOrEmpty(CustomerKey))
            dictionary.Add(Fields.CUSTOMERKEY, CustomerKey);
        if (Recurrent)
            dictionary.Add(Fields.RECURRENT, "Y");
        return dictionary;
    }

    #endregion
}