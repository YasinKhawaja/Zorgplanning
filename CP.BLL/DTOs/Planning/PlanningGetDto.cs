namespace CP.BLL.DTOs
{
    public class PlanningGetDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public PlanningTeamGetDto Team { get; set; }
        public IEnumerable<DateTime> Holidays { get; set; }
    }
}
