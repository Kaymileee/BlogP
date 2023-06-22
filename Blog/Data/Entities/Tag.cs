using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities
{
    public class Tag
    {
        [Key]
        public string? TagSlug { get; set; }
        public string? TagName { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}
