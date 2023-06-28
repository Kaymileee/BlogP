using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities
{
  public class Category
  {
    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public string? ParentId { get; set; }
    public virtual ICollection<PostCategory>? PostCategories { get; set; }
  }
}
