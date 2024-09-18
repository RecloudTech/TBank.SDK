using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class GetStateRequestBuilder : AcquiringRequestBuilder<GetStateRequest>
{
    #region Ctor

    public GetStateRequestBuilder(string password, string terminalKey) : base(password, terminalKey)
    {
    }

    #endregion

    #region Base Members

    protected override void Validate()
    {
        Assert.IsNonNullOrEmpty(Request.PaymentId, Fields.PAYMENTID);
    }

    #endregion

    #region Public Members

    /// <summary>
    ///     Устанавливает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public GetStateRequestBuilder SetPaymentId(string value)
    {
        Request.PaymentId = value;
        return this;
    }

    #endregion
}