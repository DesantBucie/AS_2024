namespace Kolos1.Models
{
	public class EventType
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		// 1 *
		public virtual ICollection<MatchEvent>? MatchEvents { get; set; }
	}
}
