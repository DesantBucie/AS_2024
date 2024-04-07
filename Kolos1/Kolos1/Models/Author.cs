namespace Kolos1.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		// 1 *
		public virtual ICollection<Article>? Articles { get; set; }
	}
}
