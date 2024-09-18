using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class ChargeAcquiringResponse : BaseAcquiringResponse
{
    [JsonPropertyName("Message")] public string Message { get; set; }

    [JsonPropertyName("Details")] public string Details { get; set; }
}