namespace Rc.TBank.SDK.Interfaces.Procedures;

public interface ITPayProcedures
{
    Task<bool> CanPayAsync();
    Task<string> InitPayAsync(int amount, 
        string orderId, 
        string customerKey, 
        string description = default!, 
        string payForm = default!, 
        bool recurrent = default);

    Task<(string RedirectUrl, string WebQR)> GetPaymentInfoAsync(string paymentId);
    Task<Stream> GetQRCodeAsync(string paymentId);
}