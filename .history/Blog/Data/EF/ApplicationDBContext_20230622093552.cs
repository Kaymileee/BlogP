using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.EF
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PostCategory>().HasKey(x => new { x.PostId, x.CategoryId });
    }



    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<Comment> Comments { get; set; }



  }
}
