using Rc.TBank.SDK.Core.Helpers.Builders;
using Rc.TBank.SDK.Core.Helpers.TPay;
using Rc.TBank.SDK.Interfaces.Procedures;
using Rc.TBank.SDK.Models.Exceptions;
using Rc.TBank.SDK.Models.Responses;

namespace Rc.TBank.SDK.Core;

public class FastPaymentSystem(string password, string terminalKey, HttpClient httpClient, AcquiringSdk acquiringSdk) : IFastPaymentSystem
{
    private readonly TPayApi _tPayApi = new(terminalKey, httpClient, acquiringSdk);
    
    public Task<bool> CanPayAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> InitPayAsync(
        int amount, 
        string orderId, 
        string customerKey, 
        string description = default!, 
        string payForm = default!, 
        bool recurrent = default) 
        => _tPayApi.InitPayAsync(amount, orderId, customerKey, description, payForm, recurrent);

    public async Task<(string RedirectUrl, string WebQR)> GetPaymentInfoAsync(string paymentId)
    {
        var data = await GetQrPaymentData(paymentId);

        return (data.Data, string.Empty);
    }

    public Task<Stream> GetQRCodeAsync(string paymentId)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    ///     Возвращает статус платежа.
    /// </summary>
    /// <param name="paymentId">Уникальный идентификатор транзакции в системе Банка.</param>
    /// <returns>Статус платежа.</returns>
    public async Task<FastPaymentSystemResponse> GetQrPaymentData(string paymentId)
    {
        var request = new FastPaymentSystemQrBuilder(password, terminalKey)
            .SetPaymentId(paymentId)
            .SetDataType("PAYLOAD")
            .Build();

        try
        {
            var response = await acquiringSdk.GetApi(request.Operation).GetFastPaymentSystemQrData(request);
            if (response is { Success: true }) 
                return response;
            throw new AcquiringApiException(response);
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }
    }
}