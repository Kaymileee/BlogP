using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities
{
  public class Category
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    //public virtual List<Post> Posts { get; set; }
  }
}
