namespace MCT.Functions.Models;

public class Spell
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("desc")]
    public string Description { get; set; }

    [JsonProperty("higher_level")]
    public string HigherLevel { get; set; }

    [JsonProperty("range")]
    public string Range { get; set; }

    [JsonProperty("components")]
    public string Components { get; set; }

    [JsonProperty("material")]
    public string Material { get; set; }

    [JsonProperty("ritual")]
    public string Ritual { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("concentration")]
    public string Concentration { get; set; }

    [JsonProperty("casting_time")]
    public string CastingTime { get; set; }

    [JsonProperty("level_int")]
    public int Level { get; set; }

    [JsonProperty("school")]
    public string School { get; set; }

    [JsonProperty("dnd_class")]
    public string Class { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}