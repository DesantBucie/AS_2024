namespace Kolos1.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Lead { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public DateTime CreationDate { get; set; }

		// * *
		public virtual ICollection<Tag>? Tags { get; set; }
		// 1 *
		public virtual ICollection<Comment>? Comments { get; set; }
		// * 1
		public virtual Category? Cateogry { get; set; }
		public int? CategoryId { get; set; }
		// * 1
		public virtual Author? Author { get; set; }
		public int? AuthorId {  get; set; }

		// * 0..1
		public virtual Match? Match { get; set; }
		public int? MatchId { get; set; }
	}
}
