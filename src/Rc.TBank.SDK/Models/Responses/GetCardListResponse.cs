using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class GetCardListResponse
{
    [JsonPropertyName("CardId")] public string CardId { get; set; }

    [JsonPropertyName("Pan")] public string Pan { get; set; }

    [JsonPropertyName("Status")] public string Status { get; set; }

    [JsonPropertyName("RebillId")] public string RebillId { get; set; }

    [JsonPropertyName("CardType")] public int CardType { get; set; }

    [JsonPropertyName("ExpDate")] public string ExpDate { get; set; }
}