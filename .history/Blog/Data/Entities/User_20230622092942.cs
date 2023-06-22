
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
  public class User
  {
    [Key]
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
    public bool? IsEmailConfirmed { get; set; }
    public string? Code { get; set; }
    public string? Avatar { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastLogin { get; set; }
    public ICollection<Post>? Posts { get; set; }

  }


}

