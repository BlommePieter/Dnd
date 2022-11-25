namespace MCT.Functions.Models;

public class Weapon
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("cost")]
    public string Cost { get; set; }

    [JsonProperty("damage_dice")]
    public string DamageDice { get; set; }

    [JsonProperty("damage_type")]
    public string DamageType { get; set; }

    [JsonProperty("weight")]
    public string Weight { get; set; }

    [JsonProperty("properties")]
    public List<string> Properties { get; set; }
}