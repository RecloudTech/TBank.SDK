namespace Rc.TBank.SDK.Interfaces.Procedures;

public interface IPayProcedures
{
    Task<bool> CanPayAsync();
    Task<string> InitPayAsync(int amount, 
        string orderId, 
        string customerKey, 
        string description = default!, 
        string payForm = default!, 
        bool recurrent = default);
}