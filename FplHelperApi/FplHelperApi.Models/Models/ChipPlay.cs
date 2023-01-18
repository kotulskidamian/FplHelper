using System.Text.Json.Serialization;

namespace FplHelperApi.Models
{
    public class ChipPlay
    {
        [JsonPropertyName("chip_name")]
        public string ChipName { get; set; }

        [JsonPropertyName("num_played")]
        public int NumPlayed { get; set; }
    }

}