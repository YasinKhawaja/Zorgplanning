using CP.DAL.Models;

namespace CP.BLL.DTOs
{
    /// <summary>
    /// Represents an absence data transfer object.
    /// </summary>
    public class AbsenceDTO
    {
        public int EmployeeId { get; set; }
        public DateTime Day { get; set; }
        public AbsenceType Type { get; set; }
    }
}
