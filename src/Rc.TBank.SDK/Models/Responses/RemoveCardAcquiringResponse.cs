using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class RemoveCardAcquiringResponse : BaseAcquiringResponse
{
    [JsonPropertyName("CardId")] public string CardId { get; set; }

    [JsonPropertyName("CardType")] public int CardType { get; set; }
}