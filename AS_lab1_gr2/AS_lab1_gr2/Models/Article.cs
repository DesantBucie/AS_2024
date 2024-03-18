namespace AS_lab1_gr2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

        // 1 *
        public virtual ICollection<Comment>? Comments { get; set; }
        // * 1
        public Category? Category;
        public int? CategoryId { get; set; }
        // * *
        public virtual ICollection<Tag>? Tags { get; set; }
        // * 1
        public virtual Author? Author { get; set; } = null!;
        public int? AuthorId {  get; set; }
        // * 0..1 
        public virtual Match? Match { get; set; } = null!;
        public int? MatchId { get; set;}
    }
}
