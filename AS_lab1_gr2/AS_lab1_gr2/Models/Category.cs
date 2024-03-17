using AS_lab1_gr2.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // 1 * 
    public virtual ICollection<Article>? Articles { get; set; }
} 