using Rc.TBank.SDK.Core.Helpers.Builders;
using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers;

internal class InitRequestBuilder(string password, string terminalKey)
    : AcquiringRequestBuilder<InitRequest>(password, terminalKey)
{
    #region Base Members

    protected override void Validate()
    {
        Assert.IsNonNegative(Request.Amount, Fields.AMOUNT);
        Assert.IsNonNullOrEmpty(Request.OrderId, Fields.ORDERID);
    }

    #endregion

    #region Public Members

    /// <summary>
    ///     Устанавливает сумму в копейках.
    /// </summary>
    public InitRequestBuilder SetAmount(decimal value)
    {
        Request.Amount = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает номер заказа в системе продавца.
    /// </summary>
    public InitRequestBuilder SetOrderId(string value)
    {
        Request.OrderId = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает краткое описание.
    /// </summary>
    public InitRequestBuilder SetDescription(string value)
    {
        Request.Description = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает название шаблона формы оплаты продавца.
    /// </summary>
    public InitRequestBuilder SetPayForm(string value)
    {
        Request.PayForm = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает идентификатор покупателя в системе Продавца.
    /// </summary>
    public InitRequestBuilder SetCustomerKey(string value)
    {
        Request.CustomerKey = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает параметр, который определяет регистрировать платеж как рекуррентный или нет.
    /// </summary>
    public InitRequestBuilder SetRecurrent(bool value)
    {
        Request.Recurrent = value;
        return this;
    }

    #endregion
}