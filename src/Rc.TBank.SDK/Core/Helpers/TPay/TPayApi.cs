using System.Text;
using System.Text.Json;
using Rc.TBank.SDK.Models.Requests.TPay;
using Rc.TBank.SDK.Models.Responses.TPay;

namespace Rc.TBank.SDK.Core.Helpers.TPay;

public class TPayApi(string terminalKey, HttpClient httpClient, AcquiringSdk acquiringSdk)
{
    public async Task<bool> CanPayAsync()
    {
        var content = await httpClient.GetStreamAsync(
            $"https://securepay.tinkoff.ru/v2/TinkoffPay/terminals/{terminalKey}/status");

        var dto = await JsonSerializer.DeserializeAsync<TPayTerminalStatus>(content).AsTask();

        return dto?.Params.Allowed ?? false;
    }

    public Task<string> InitPayAsync(int amount, string orderId, string customerKey,
        string description = default!,
        string payForm = default!, bool recurrent = default)
    {
        return acquiringSdk.Init(amount, orderId, customerKey, description, payForm, recurrent);
    }

    public async Task<(string RedirectUrl, string WebQR)> GetPaymentInfoAsync(string paymentId, string version = "2.0")
    {
        var content = await httpClient.GetStreamAsync(
            $"https://securepay.tinkoff.ru/v2/TinkoffPay/transactions/{paymentId}/versions/{version}/link");

        var dto = await JsonSerializer.DeserializeAsync<QRLinkResponse>(content).AsTask();

        if (dto is null)
        {
            return (string.Empty, string.Empty);
        }
        
        return (dto.Params.RedirectUrl, dto.Params.WebQR);
    }

    public Task<Stream> GetQRCodeAsync(string paymentId)
    {
        return httpClient.GetStreamAsync($"https://securepay.tinkoff.ru/v2/TinkoffPay/{paymentId}/QR");
    }
}