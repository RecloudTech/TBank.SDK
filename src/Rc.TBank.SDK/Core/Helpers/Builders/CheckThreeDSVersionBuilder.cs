using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class CheckThreeDSVersionBuilder : AcquiringRequestBuilder<Check3DSVersionRequest>
{
    public CheckThreeDSVersionBuilder(string password, string terminalKey) : base(password, terminalKey)
    {
        
    }

    protected override void Validate()
    {
        Assert.IsNonNullOrEmpty(Request.PaymentId, Fields.PAYMENTID);
    }

    /// <summary>
    ///     Устанавливает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public CheckThreeDSVersionBuilder SetPaymentId(string value)
    {
        Request.PaymentId = value;
        return this;
    }
    
    /// <summary>
    ///     Устанавливает зашифрованные данные карты.
    /// </summary>
    public CheckThreeDSVersionBuilder SetCardData(string value)
    {
        Request.CardData = value;
        return this;
    }
}