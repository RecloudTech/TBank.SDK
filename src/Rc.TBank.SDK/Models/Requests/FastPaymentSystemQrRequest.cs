namespace Rc.TBank.SDK.Models.Requests;

internal class FastPaymentSystemQrRequest : AcquiringRequest
{
    public override string Operation => "GetQr";

    /// <summary>
    ///     Возвращает уникальный идентификатор транзакции в системе Банка.
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    ///     Default: "PAYLOAD" Enum: "PAYLOAD" "IMAGE" Тип возвращаемых данных: PAYLOAD — в ответе возвращается только Payload — по умолчанию; IMAGE — в ответе возвращается SVG изображение QR.
    /// </summary>
    public string DataType { get; set; } = "PAYLOAD";
    
    public override IDictionary<string, string> ToDictionary()
    {
        var dictionary = base.ToDictionary();
        if (!string.IsNullOrEmpty(PaymentId))
            dictionary.Add(Fields.PAYMENTID, PaymentId);
        if (!string.IsNullOrEmpty(DataType))
            dictionary.Add(Fields.DATATYPE, DataType);
        return dictionary;
    }
}