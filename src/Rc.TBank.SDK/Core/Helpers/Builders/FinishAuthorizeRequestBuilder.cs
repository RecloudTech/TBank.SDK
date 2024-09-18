using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class FinishAuthorizeRequestBuilder : AcquiringRequestBuilder<FinishAuthorizeRequest>
{
    #region Ctor

    public FinishAuthorizeRequestBuilder(string password, string terminalKey)
        : base(password, terminalKey)
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
    public FinishAuthorizeRequestBuilder SetPaymentId(string value)
    {
        Request.PaymentId = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает параметр, который определяет отравлять email с квитанцией или нет.
    /// </summary>
    public FinishAuthorizeRequestBuilder SetSendEmail(bool value)
    {
        Request.SendEmail = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает зашифрованные данные карты.
    /// </summary>
    public FinishAuthorizeRequestBuilder SetCardData(string value)
    {
        Request.CardData = value;
        return this;
    }

    /// <summary>
    ///     Устанавливает электронный адрес на который будет отправлена квитанция об оплате.
    /// </summary>
    public FinishAuthorizeRequestBuilder SetInfoEmail(string value)
    {
        Request.InfoEmail = value;
        return this;
    }

    #endregion
}