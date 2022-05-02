namespace CP.BLL.DTOs
{
    public class PlanningShiftGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
