using System.Text.Json.Serialization;

namespace FplHelperApi.Models
{
    public class Team
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("draw")]
        public int Draw { get; set; }

        [JsonPropertyName("form")]
        public object Form { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("loss")]
        public int Loss { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("played")]
        public int Played { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        [JsonPropertyName("strength")]
        public int Strength { get; set; }

        [JsonPropertyName("team_division")]
        public object TeamDivision { get; set; }

        [JsonPropertyName("unavailable")]
        public bool Unavailable { get; set; }

        [JsonPropertyName("win")]
        public int Win { get; set; }

        [JsonPropertyName("strength_overall_home")]
        public int StrengthOverallHome { get; set; }

        [JsonPropertyName("strength_overall_away")]
        public int StrengthOverallAway { get; set; }

        [JsonPropertyName("strength_attack_home")]
        public int StrengthAttackHome { get; set; }

        [JsonPropertyName("strength_attack_away")]
        public int StrengthAttackAway { get; set; }

        [JsonPropertyName("strength_defence_home")]
        public int StrengthDefenceHome { get; set; }

        [JsonPropertyName("strength_defence_away")]
        public int StrengthDefenceAway { get; set; }

        [JsonPropertyName("pulse_id")]
        public int PulseId { get; set; }
    }

}