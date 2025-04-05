using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class InitAcquiringResponse : BaseAcquiringResponse
{
    [JsonPropertyName("PaymentURL")]
    public string PaymentURL { get; set; }
}