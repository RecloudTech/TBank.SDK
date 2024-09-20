namespace Rc.TBank.SDK.Interfaces.Procedures;

public interface IQRPayProcedures
{
    Task<(string RedirectUrl, string WebQR)> GetPaymentInfoAsync(string paymentId);
    Task<Stream> GetQRCodeAsync(string paymentId);
}