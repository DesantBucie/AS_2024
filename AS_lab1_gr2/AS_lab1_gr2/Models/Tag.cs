namespace AS_lab1_gr2.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        // * *
        public virtual ICollection<Article>? Articles { get; set; }
    }
}
    
