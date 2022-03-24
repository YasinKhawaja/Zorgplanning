namespace CP.BLL.DTOs
{
    /// <summary>
    /// Represents a regime data transfer object.
    /// </summary>
    public class RegimeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public int Percentage { get; set; }
    }
}
