using System.Text.Json.Serialization; 
namespace FplHelperApi.Models{ 

    public class TopElementInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }

}