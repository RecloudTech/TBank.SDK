using Rc.TBank.SDK.Core.Helpers.TPay;
using Rc.TBank.SDK.Interfaces.Procedures;

namespace Rc.TBank.SDK.Core;

public class TPayProcedures(string terminalKey, HttpClient httpClient, AcquiringSdk acquiringSdk) : ITPayProcedures
{
    
    private readonly TPayApi _tPayApi = new(terminalKey, httpClient, acquiringSdk);
    
    public Task<bool> CanPayAsync() => _tPayApi.CanPayAsync();
    public Task<string> InitPayAsync(
        int amount, 
        string orderId, 
        string customerKey, 
        string description = default!, 
        string payForm = default!, 
        bool recurrent = default) 
        => _tPayApi.InitPayAsync(amount, orderId, customerKey, description, payForm, recurrent);

    public Task<(string RedirectUrl, string WebQR)> GetPaymentInfoAsync(string paymentId) => _tPayApi.GetPaymentInfoAsync(paymentId);
    public Task<Stream> GetQRCodeAsync(string paymentId) => _tPayApi.GetQRCodeAsync(paymentId);
}