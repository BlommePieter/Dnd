namespace MCT.Functions.Models;

public class Item
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("desc")]
    public string Description { get; set; }

    [JsonProperty("rarity")]
    public string Rarity { get; set; }

    [JsonProperty("requires_attunement")]
    public string Attunement { get; set; }
}