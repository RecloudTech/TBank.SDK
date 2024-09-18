using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class GetCardListRequestBuilder : AcquiringRequestBuilder<GetCardListRequest>
{
    #region Ctor

    public GetCardListRequestBuilder(string password, string terminalKey)
        : base(password, terminalKey)
    {
    }

    #endregion

    #region Base Members

    protected override void Validate()
    {
        Assert.IsNonNullOrEmpty(Request.CustomerKey, Fields.CUSTOMERKEY);
    }

    #endregion

    #region Public Members

    /// <summary>
    ///     Устанавливает идентификатор покупателя в системе Продавца.
    /// </summary>
    public GetCardListRequestBuilder SetCustomerKey(string value)
    {
        Request.CustomerKey = value;
        return this;
    }

    #endregion
}