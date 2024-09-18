using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class Param
{
    [JsonPropertyName("Route")] public string Route { get; set; }

    [JsonPropertyName("Source")] public string Source { get; set; }

    [JsonPropertyName("CreditAmount")] public int CreditAmount { get; set; }
}