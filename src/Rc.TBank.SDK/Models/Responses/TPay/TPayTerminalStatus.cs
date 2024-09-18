using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses.TPay;

public class TPayTerminalStatus
{
    [JsonPropertyName("Params")]
    public Params Params { get; set; }

    [JsonPropertyName("Success")]
    public bool Success { get; set; }

    [JsonPropertyName("ErrorCode")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; }

    [JsonPropertyName("Details")]
    public string Details { get; set; }
}