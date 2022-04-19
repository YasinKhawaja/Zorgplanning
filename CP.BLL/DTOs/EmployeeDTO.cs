using CP.DAL.Models;

namespace CP.BLL.DTOs
{
    /// <summary>
    /// Represents an employee data transfer object.
    /// </summary>
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFixedNight { get; set; }
        public int TeamId { get; set; }
        public int RegimeId { get; set; }
    }
}
