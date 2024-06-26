namespace AS_lab1_gr2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Article>? Articles { get; set; }

    }
}
