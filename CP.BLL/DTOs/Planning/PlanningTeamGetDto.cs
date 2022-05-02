namespace CP.BLL.DTOs
{
    public class PlanningTeamGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PlanningEmployeeGetDto> Employees { get; set; }
    }
}
