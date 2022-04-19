namespace CP.DAL.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int RegimeId { get; set; }
        public Regime Regime { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
