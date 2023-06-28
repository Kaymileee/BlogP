using Blog.Data.Entities;
using Blog.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Blog.Data.Entities
{
  public class Post
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? Content { get; set; }
    //n-n
    public virtual ICollection<PostCategory>? PostCategories { get; set; }
    public virtual ICollection<PostTag>? PostTags { get; set; }
    //1:n
    [JsonIgnore]
    public User? User { get; set; }
    public Guid? UserId { get; set; }
    //n-n
    public virtual ICollection<Tag>? Tags { get; set; }
    //1:n
    public virtual ICollection<Comment>? Comments { get; set; }
    public string? ListTag { get; set; }
    public virtual ICollection<Attachment>? Attachments { get; set; }
    public PostStatus? Status { get; set; }
  }
}
