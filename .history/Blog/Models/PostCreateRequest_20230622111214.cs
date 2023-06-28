namespace Blog.Models
{
    public class PostCreateRequest
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid? UserId { get; set; }
        public string[]? ListTag { get; set; }
    }
}