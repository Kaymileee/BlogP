namespace Blog.Data.Entities
{
  public class PostCategory
  {
    public int PostId { get; set; }
    public virtual Post? Post { get; set; }

    public string? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
  }
}
