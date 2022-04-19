namespace CP.DAL.Models
{
    /// <summary>
    /// Represents a working regime.
    /// </summary>
    public class Regime
    {
        /// <summary>
        /// The identifier and primary key of the regime. 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the regime.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of hours to work within the regime.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// The percentage of the regime.
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// The collection navigation property with <seealso cref="Employee"/>.
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }

        /// <summary>
        /// The collection navigation property with <seealso cref="Shift"/>.
        /// </summary>
        public IEnumerable<Shift> Shifts { get; set; }
    }
}
