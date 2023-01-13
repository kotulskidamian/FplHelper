namespace FplHelperApi.Dtos
{
    public class PlayerReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string SelectedByPercent { get; set; }
        public int TotalPoints { get; set; }
        public string ExpectedGoals { get; set; }
        public string ExpectedAssists { get; set; }
    }
}
