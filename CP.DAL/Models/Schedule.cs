namespace CP.DAL.Models
{
    public class Schedule
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public DateTime DateId { get; set; }
        public Date Date { get; set; }
    }
}
