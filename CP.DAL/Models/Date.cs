namespace CP.DAL.Models
{
    /// <summary>
    /// Represents a date.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public DateTime DateId { get; set; }

        /// <summary>
        /// Indicates if the date is a holiday.
        /// </summary>
        public bool IsHoliday { get; set; }

        /// <summary>
        /// The collection navigation property of <seealso cref="Absence"/>.
        /// </summary>
        public IEnumerable<Absence> Absences { get; set; }
    }
}
