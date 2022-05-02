namespace CP.BLL.DTOs
{
    public class PlanningEmployeeGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFixedNight { get; set; }
        public PlanningRegimeGetDto Regime { get; set; }
        public IEnumerable<PlanningScheduleGetDto> Schedules { get; set; }
        public IEnumerable<PlanningAbsenceGetDto> Absences { get; set; }
    }
}
