namespace Blog.Data.Entities
{
  public class Tag
  {
    public int? TagId { get; set; }
    public string? TagName { get; set; }
    public string? TagSlug { get; set; }
    public string? TagContent { get; set; }
    public List<Post>? Posts { get; set; }

  }
}
