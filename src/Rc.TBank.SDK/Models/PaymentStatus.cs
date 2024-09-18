namespace Rc.TBank.SDK.Models;

/// <summary>
///     Статус платежа.
/// </summary>
public enum PaymentStatus
{
    /// <summary>
    ///     Платеж зарегистрирован в шлюзе, но его обработка в процессинге не начата.
    /// </summary>
    NEW,

    /// <summary>
    ///     Платеж отменен Продавцом.
    /// </summary>
    CANCELLED,

    /// <summary>
    ///     Проверка платежных данных Покупателя.
    /// </summary>
    PREAUTHORIZING,

    /// <summary>
    ///     Покупатель переправлен на страницу оплаты.
    /// </summary>
    FORMSHOWED,

    /// <summary>
    ///     Покупатель начал аутентификацию.
    /// </summary>
    AUTHORIZING,

    /// <summary>
    ///     Покупатель начал аутентификацию по протоколу 3-D Secure.
    /// </summary>
    DS_CHECKING,

    /// <summary>
    ///     Покупатель завершил аутентификацию по протоколу 3-D Secure.
    /// </summary>
    DS_CHECKED,

    /// <summary>
    ///     Средства заблокированы, но не списаны.
    /// </summary>
    AUTHORIZED,

    /// <summary>
    ///     Начало отмены блокировки средств.
    /// </summary>
    REVERSING,

    /// <summary>
    ///     Денежные средства разблокированы.
    /// </summary>
    REVERSED,

    /// <summary>
    ///     Начало списания денежных средств.
    /// </summary>
    CONFIRMING,

    /// <summary>
    ///     Денежные средства списаны.
    /// </summary>
    CONFIRMED,

    /// <summary>
    ///     Начало возврата денежных средств.
    /// </summary>
    REFUNDING,

    /// <summary>
    ///     Произведен возврат денежных средств.
    /// </summary>
    REFUNDED,

    /// <summary>
    ///     Платеж отклонен Банком.
    /// </summary>
    REJECTED,

    /// <summary>
    ///     Статус не определен.
    /// </summary>
    UNKNOWN
}