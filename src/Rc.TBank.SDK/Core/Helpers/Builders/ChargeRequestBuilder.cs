using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class ChargeRequestBuilder : AcquiringRequestBuilder<ChargeRequest>
{
    #region Ctor

    public ChargeRequestBuilder(string password, string terminalKey)
        : base(password, terminalKey)
    {
    }

    #endregion

    #region Base Members

    protected override void Validate()
    {
        Assert.IsNonNullOrEmpty(Request.PaymentId, Fields.PAYMENTID);
        Assert.IsNonNullOrEmpty(Request.RebillId, Fields.REBILLID);
    }

    #endregion

    #region Public Members

    /// <summary>
    ///     Устанавливает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public ChargeRequestBuilder SetPaymentId(string value)
    {
        Request.PaymentId = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает идентификатор рекуррентного платежа.
    /// </summary>
    public ChargeRequestBuilder SetRebillId(string value)
    {
        Request.RebillId = value;
        return this;
    }

    #endregion
}