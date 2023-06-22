namespace Blog.Models.Entities
{
    public class Category
    {
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
       //public virtual List<Post> Posts { get; set; }
    }
}
