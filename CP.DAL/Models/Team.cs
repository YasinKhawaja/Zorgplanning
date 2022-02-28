namespace CP.DAL.Models
{
    /// <summary>
    /// Represents a team of employees.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The collection navigation property of <seealso cref="Employee"/>.
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }
    }
}
