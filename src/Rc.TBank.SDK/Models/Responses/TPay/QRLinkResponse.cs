using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses.TPay;

public class QRLinkResponse
{
    [JsonPropertyName("Success")]
    public bool? Success { get; set; }

    [JsonPropertyName("ErrorCode")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("Params")]
    public Params Params { get; set; }
}