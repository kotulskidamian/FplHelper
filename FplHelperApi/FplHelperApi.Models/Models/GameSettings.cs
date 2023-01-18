using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace FplHelperApi.Models
{
    public class GameSettings
    {
        [JsonPropertyName("league_join_private_max")]
        public int LeagueJoinPrivateMax { get; set; }

        [JsonPropertyName("league_join_public_max")]
        public int LeagueJoinPublicMax { get; set; }

        [JsonPropertyName("league_max_size_public_classic")]
        public int LeagueMaxSizePublicClassic { get; set; }

        [JsonPropertyName("league_max_size_public_h2h")]
        public int LeagueMaxSizePublicH2h { get; set; }

        [JsonPropertyName("league_max_size_private_h2h")]
        public int LeagueMaxSizePrivateH2h { get; set; }

        [JsonPropertyName("league_max_ko_rounds_private_h2h")]
        public int LeagueMaxKoRoundsPrivateH2h { get; set; }

        [JsonPropertyName("league_prefix_public")]
        public string LeaguePrefixPublic { get; set; }

        [JsonPropertyName("league_points_h2h_win")]
        public int LeaguePointsH2hWin { get; set; }

        [JsonPropertyName("league_points_h2h_lose")]
        public int LeaguePointsH2hLose { get; set; }

        [JsonPropertyName("league_points_h2h_draw")]
        public int LeaguePointsH2hDraw { get; set; }

        [JsonPropertyName("league_ko_first_instead_of_random")]
        public bool LeagueKoFirstInsteadOfRandom { get; set; }

        [JsonPropertyName("cup_start_event_id")]
        public object CupStartEventId { get; set; }

        [JsonPropertyName("cup_stop_event_id")]
        public object CupStopEventId { get; set; }

        [JsonPropertyName("cup_qualifying_method")]
        public object CupQualifyingMethod { get; set; }

        [JsonPropertyName("cup_type")]
        public object CupType { get; set; }

        [JsonPropertyName("squad_squadplay")]
        public int SquadSquadplay { get; set; }

        [JsonPropertyName("squad_squadsize")]
        public int SquadSquadsize { get; set; }

        [JsonPropertyName("squad_team_limit")]
        public int SquadTeamLimit { get; set; }

        [JsonPropertyName("squad_total_spend")]
        public int SquadTotalSpend { get; set; }

        [JsonPropertyName("ui_currency_multiplier")]
        public int UiCurrencyMultiplier { get; set; }

        [JsonPropertyName("ui_use_special_shirts")]
        public bool UiUseSpecialShirts { get; set; }

        [JsonPropertyName("ui_special_shirt_exclusions")]
        public List<object> UiSpecialShirtExclusions { get; set; }

        [JsonPropertyName("stats_form_days")]
        public int StatsFormDays { get; set; }

        [JsonPropertyName("sys_vice_captain_enabled")]
        public bool SysViceCaptainEnabled { get; set; }

        [JsonPropertyName("transfers_cap")]
        public int TransfersCap { get; set; }

        [JsonPropertyName("transfers_sell_on_fee")]
        public double TransfersSellOnFee { get; set; }

        [JsonPropertyName("league_h2h_tiebreak_stats")]
        public List<string> LeagueH2hTiebreakStats { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }

}