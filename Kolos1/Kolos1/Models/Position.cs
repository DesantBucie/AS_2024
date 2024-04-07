namespace Kolos1.Models
{
	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		
		// 1 * 
		public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }
		// 1..* *
		public virtual ICollection<Player>? Player { get; set; }
	}
}
