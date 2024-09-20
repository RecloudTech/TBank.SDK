using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class FastPaymentSystemResponse : BaseAcquiringResponse
{
    [JsonPropertyName("Data")]
    public string Data { get; set; }
}