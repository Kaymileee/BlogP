
using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;



namespace Blog.Models.Entities
{
    public class User
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public string? Code { get; set; }
        public string? Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public List<Post>? Posts { get; set; }

    }


}

