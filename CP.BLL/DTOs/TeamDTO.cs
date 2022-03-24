namespace CP.BLL.DTOs
{
    /// <summary>
    /// Represents a team data transfer object.
    /// </summary>
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
    }
}
