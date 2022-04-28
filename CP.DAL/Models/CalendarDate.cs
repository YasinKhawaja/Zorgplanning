namespace CP.DAL.Models
{
    /// <summary>
    /// Represents a date.
    /// </summary>
    public class CalendarDate
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public int DateId { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// Indicates if the date is a holiday.
        /// </summary>
        public string HolidayName { get; set; }

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
