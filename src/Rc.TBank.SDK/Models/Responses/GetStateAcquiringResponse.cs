using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Responses;

public class GetStateAcquiringResponse : BaseAcquiringResponse
{
    [JsonPropertyName("Details")] public string Details { get; set; }

    [JsonPropertyName("Params")] public List<Param> Params { get; set; }
}