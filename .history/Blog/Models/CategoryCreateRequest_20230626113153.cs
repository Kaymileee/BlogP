namespace Blog.Models;

public class CategoryCreateRequest
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Parent { get; set; }
}