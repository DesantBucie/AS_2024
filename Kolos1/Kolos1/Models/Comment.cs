namespace Kolos1.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content = string.Empty;

		// * 1
		public virtual Article? Article { get; set; }
		public int? ArticleId { get; set; }
	}
}
