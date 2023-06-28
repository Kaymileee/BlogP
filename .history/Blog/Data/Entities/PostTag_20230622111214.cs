namespace Blog.Data.Entities
{
  public class PostTag
  {
    public int PostId { get; set; }
    public Post? Post { get; set; }

    public string? tagId { get; set; }
    public Tag? Tag { get; set; }
  }
}
