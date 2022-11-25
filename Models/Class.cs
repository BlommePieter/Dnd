using Newtonsoft.Json;

namespace MCT.Functions.Models;

public class Class
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("desc")]
    public string Description { get; set; }

    [JsonProperty("hit_dice")]
    public string HitDice { get; set; }

    [JsonProperty("prof_armor")]
    public string ArmorProf { get; set; }

    [JsonProperty("prof_weapons")]
    public string WeaponProf { get; set; }

    [JsonProperty("prof_tools")]
    public string ToolProf { get; set; }

    [JsonProperty("prof_saving_throws")]
    public string SavingThrowProf { get; set; }

    [JsonProperty("prof_skills")]
    public string SkillProf { get; set; }

    [JsonProperty("equipment")]
    public string Equipment { get; set; }

    [JsonProperty("spellcasting_ability")]
    public string SpellcastingAbility { get; set; }

    [JsonProperty("subtypes_name")]
    public string SubtypeName { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}