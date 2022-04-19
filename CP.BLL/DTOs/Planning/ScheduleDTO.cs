namespace CP.BLL.DTOs
{
    public class ScheduleDTO
    {
        public string Nurse { get; set; }
        public double Regime { get; set; }
        IList<ShiftDTO> Shifts { get; set; }
    }
}
