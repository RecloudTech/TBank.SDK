using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal class FastPaymentSystemQrBuilder : AcquiringRequestBuilder<FastPaymentSystemQrRequest>
{
    public FastPaymentSystemQrBuilder(string password, string terminalKey) : base(password, terminalKey)
    {
        
    }

    protected override void Validate()
    {
        
    }
    
    /// <summary>
    ///     Устанавливает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public FastPaymentSystemQrBuilder SetPaymentId(string value)
    {
        Request.PaymentId = value;
        return this;
    }

    public FastPaymentSystemQrBuilder SetDataType(string value)
    {
        Request.DataType = value;
        return this;
    }
}