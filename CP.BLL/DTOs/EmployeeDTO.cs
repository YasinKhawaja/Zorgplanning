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
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public Country Country { get; set; }
        public bool IsFixedNight { get; set; }
        public bool IsActive { get; set; }
        public int TeamId { get; set; }
        public int RegimeId { get; set; }
    }
}
