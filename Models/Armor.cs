namespace MCT.Functions.Models;

public class Armor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("cost")]
    public string Cost { get; set; }

    [JsonProperty("ac_string")]
    public string ArmorClass { get; set; }

    [JsonProperty("strength_requirement")]
    public Nullable<int> Strength { get; set; }

    [JsonProperty("stealth_disadvantage")]
    public bool StealthDisadvantage { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}