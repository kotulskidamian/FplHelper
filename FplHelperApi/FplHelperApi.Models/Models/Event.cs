using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;

namespace FplHelperApi.Models
{
    public class Event
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("deadline_time")]
        public DateTime DeadlineTime { get; set; }

        [JsonPropertyName("average_entry_score")]
        public int AverageEntryScore { get; set; }

        [JsonPropertyName("finished")]
        public bool Finished { get; set; }

        [JsonPropertyName("data_checked")]
        public bool DataChecked { get; set; }

        [JsonPropertyName("highest_scoring_entry")]
        public int? HighestScoringEntry { get; set; }

        [JsonPropertyName("deadline_time_epoch")]
        public int DeadlineTimeEpoch { get; set; }

        [JsonPropertyName("deadline_time_game_offset")]
        public int DeadlineTimeGameOffset { get; set; }

        [JsonPropertyName("highest_score")]
        public int? HighestScore { get; set; }

        [JsonPropertyName("is_previous")]
        public bool IsPrevious { get; set; }

        [JsonPropertyName("is_current")]
        public bool IsCurrent { get; set; }

        [JsonPropertyName("is_next")]
        public bool IsNext { get; set; }

        [JsonPropertyName("cup_leagues_created")]
        public bool CupLeaguesCreated { get; set; }

        [JsonPropertyName("h2h_ko_matches_created")]
        public bool H2hKoMatchesCreated { get; set; }

        [JsonPropertyName("chip_plays")]
        public List<ChipPlay> ChipPlays { get; set; }

        [JsonPropertyName("most_selected")]
        public int? MostSelected { get; set; }

        [JsonPropertyName("most_transferred_in")]
        public int? MostTransferredIn { get; set; }

        [JsonPropertyName("top_element")]
        public int? TopElement { get; set; }

        [JsonPropertyName("top_element_info")]
        public TopElementInfo TopElementInfo { get; set; }

        [JsonPropertyName("transfers_made")]
        public int TransfersMade { get; set; }

        [JsonPropertyName("most_captained")]
        public int? MostCaptained { get; set; }

        [JsonPropertyName("most_vice_captained")]
        public int? MostViceCaptained { get; set; }
    }

}