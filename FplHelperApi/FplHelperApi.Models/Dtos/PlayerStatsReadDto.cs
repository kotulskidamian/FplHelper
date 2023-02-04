namespace FplHelperApi.Models.Dtos
{
    public class PlayerStatsReadDto
    {
        public int PlayerId { get; set; }
        public string SelectedByPercent { get; set; }
        public int TotalPoints { get; set; }
        public string ValueSeason { get; set; }
        public int Cost { get; set; }
        public string ExpectedGoals { get; set; }
        public string ExpectedAssists { get; set; }
        public int Starts { get; set; }

    }
}
