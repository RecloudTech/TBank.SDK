namespace Rc.TBank.SDK.Models.Requests;

internal sealed class Check3DSVersionRequest : AcquiringRequest
{
    public override string Operation => "Check3dsVersion";
    
    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public string PaymentId { get; set; }
    
    /// <summary>
    ///     Возвращает зашифрованные данные карты.
    /// </summary>
    public string CardData { get; set; }
    
}