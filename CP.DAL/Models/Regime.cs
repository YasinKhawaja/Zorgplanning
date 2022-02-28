namespace CP.DAL.Models
{
    public class Regime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
