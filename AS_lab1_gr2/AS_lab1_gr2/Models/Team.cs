namespace AS_lab1_gr2.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime FoundingDate { get; set; }
        // 1 *
        public virtual ICollection<Player>? Players { get; set; }
    }
}
