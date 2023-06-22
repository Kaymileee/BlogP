namespace Blog.Data.Entities
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post? Post { get; set; }

        public string? TagSlug { get; set; }
        public Tag? Tag { get; set; }
    }
}
