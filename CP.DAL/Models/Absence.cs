namespace CP.DAL.Models
{
    /// <summary>
    /// Represents an absence day.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// The composite key with <see cref="DateId"/> and the foreign key with <seealso cref="Models.Employee"/>.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The composite key with <see cref="EmployeeId"/> and the foreign key with <seealso cref="Models.CalendarDate"/>.
        /// </summary>
        public DateTime DateId { get; set; }

        /// <summary>
        /// The type of absence.
        /// </summary>
        public AbsenceType Type { get; set; }

        /// <summary>
        /// The reference navigation property of <seealso cref="Models.Employee"/>.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The reference navigation property of <seealso cref="Models.CalendarDate"/>.
        /// </summary>
        public CalendarDate Date { get; set; }
    }
}
