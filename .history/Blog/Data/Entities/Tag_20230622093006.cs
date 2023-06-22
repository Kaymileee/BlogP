namespace Blog.Data.Entities
{
  public class Tag
  {
    public int? TagId { get; set; }
    public string? TagName { get; set; }
    public string? TagSlug { get; set; }
    public ICollection<Post>? Posts { get; set; }

  }
}
