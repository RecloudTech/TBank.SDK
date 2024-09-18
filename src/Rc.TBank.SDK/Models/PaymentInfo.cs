namespace Rc.TBank.SDK.Models;

/// <summary>
///     Информация о платеже.
/// </summary>
public class PaymentInfo
{
    /// <summary>
    ///     Возвращает номер заказа в системе Продавца.
    /// </summary>
    public string OrderId { get; internal set; }

    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public int PaymentId { get; internal set; }

    /// <summary>
    ///     Возвращает статус транзакции.
    /// </summary>
    public PaymentStatus Status { get; internal set; }
}