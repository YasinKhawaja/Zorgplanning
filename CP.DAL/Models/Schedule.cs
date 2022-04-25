namespace CP.DAL.Models
{
    public class Schedule
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public int DateId { get; set; }
        public CalendarDate CalendarDate { get; set; }
    }
}
