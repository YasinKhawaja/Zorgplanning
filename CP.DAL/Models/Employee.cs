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
        /// The date of birth of the employee.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The gender of the employee.
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// The primary address information of the employee.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The secondary address information of the employee.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The postal code of the town.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The name of the town.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public Country Country { get; set; }

        ///// <summary>
        ///// The employee code of the employee.
        ///// </summary>
        //public string Code { get; set; }

        /// <summary>
        /// The indication of the employee can only work night shifts.
        /// </summary>
        public bool IsFixedNight { get; set; }

        /// <summary>
        /// The indication of the employee is active and can be requested in the frontend.
        /// </summary>
        public bool? IsActive { get; set; }

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
    }
}
