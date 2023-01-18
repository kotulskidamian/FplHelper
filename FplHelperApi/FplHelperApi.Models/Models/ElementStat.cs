using System.Text.Json.Serialization;

namespace FplHelperApi.Models
{
    public class ElementStat
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}