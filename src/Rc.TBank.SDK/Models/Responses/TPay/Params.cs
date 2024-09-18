using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses.TPay;

public class Params
{
    [JsonPropertyName("Allowed")]
    public bool Allowed { get; set; }

    [JsonPropertyName("Version")]
    public string Version { get; set; }
    [JsonPropertyName("RedirectUrl")]
    public string RedirectUrl { get; set; }

    [JsonPropertyName("WebQR")]
    public string WebQR { get; set; }
}