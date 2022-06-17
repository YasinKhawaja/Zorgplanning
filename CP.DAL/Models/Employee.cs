namespace CP.DAL.Models
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the employee. 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Indicates if the employee can only work night shifts.
        /// </summary>
        public bool IsFixedNight { get; set; }

        /// <summary>
        /// The foreign key with <seealso cref="CP.DAL.Models.Team"/>.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// The reference navigation property of <seealso cref="CP.DAL.Models.Team"/>.
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// The foreign key with <seealso cref="CP.DAL.Models.Regime"/>.
        /// </summary>
        public int RegimeId { get; set; }

        /// <summary>
        /// The reference navigation property of <seealso cref="CP.DAL.Models.Regime"/>.
        /// </summary>
        public Regime Regime { get; set; }

        /// <summary>
        /// The collection navigation property of <seealso cref="Absence"/>.
        /// </summary>
        public IEnumerable<Absence> Absences { get; set; }

        /// <summary>
        /// The collection navigation property of <seealso cref="Schedule"/>.
        /// </summary>
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
