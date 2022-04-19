using CP.DAL.Models;

namespace CP.BLL.DTOs
{
    public class PlanningDTO
    {
        public int TeamId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public IList<Schedule> Schedules { get; set; }
    }
}
