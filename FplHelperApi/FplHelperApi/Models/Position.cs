using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace FplHelperApi.Models{ 

    public class Position
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("plural_name")]
        public string PluralName { get; set; }

        [JsonPropertyName("plural_name_short")]
        public string PluralNameShort { get; set; }

        [JsonPropertyName("singular_name")]
        public string SingularName { get; set; }

        [JsonPropertyName("singular_name_short")]
        public string SingularNameShort { get; set; }

        [JsonPropertyName("squad_select")]
        public int SquadSelect { get; set; }

        [JsonPropertyName("squad_min_play")]
        public int SquadMinPlay { get; set; }

        [JsonPropertyName("squad_max_play")]
        public int SquadMaxPlay { get; set; }

        [JsonPropertyName("ui_shirt_specific")]
        public bool UiShirtSpecific { get; set; }

        [JsonPropertyName("sub_positions_locked")]
        public List<int> SubPositionsLocked { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }
    }

}