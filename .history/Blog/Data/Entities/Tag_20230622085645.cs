namespace Blog.Models.Entities
{
  public class Tag
  {
    public int? TagId { get; set; }
    public string? TagName { get; set; }
    public string? TagId { get; set; }
    public string? TagContent { get; set; }
    public List<Post>? Posts { get; set; }

  }
}
