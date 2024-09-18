using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class BaseAcquiringResponse
{
    [JsonPropertyName("Success")] public bool Success { get; set; }

    [JsonPropertyName("ErrorCode")] public string ErrorCode { get; set; }

    [JsonPropertyName("TerminalKey")] public string TerminalKey { get; set; }

    [JsonPropertyName("Status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentStatus Status { get; set; }

    [JsonPropertyName("PaymentId")] public string PaymentId { get; set; }

    [JsonPropertyName("OrderId")] public string OrderId { get; set; }

    [JsonPropertyName("Amount")] public int Amount { get; set; }
}