namespace FplHelperApi.Dtos
{
    public class PlayerStatsReadDto
    {
        public int PlayerId { get; set; }
        public string SelectedByPercent { get; set; }
        public int TotalPoints { get; set; }
        public string ExpectedGoals { get; set; }
        public string ExpectedAssists { get; set; }
        public int Starts { get; set; }

    }
}
