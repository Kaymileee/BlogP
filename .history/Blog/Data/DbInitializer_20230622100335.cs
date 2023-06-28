using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
  public class DbInitializer
  {
    private readonly ApplicationDBContext _context;

    public DbInitializer(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task Seed()
    {
      var user1 = new User
      {
        UserId = Guid.NewGuid(),
        UserName = "johndoe",
        PasswordHash = Helpers.MD5Encrypt.Encrypt("password123"),
        Email = "johndoe@example.com",
        IsEmailConfirmed = true,
        Role = Role.Admin,
        Code = "12345",
        Avatar = "https://example.com/avatar.jpg",
        CreatedDate = DateTime.Now
      };

      var user2 = new User
      {
        UserId = Guid.NewGuid(),
        UserName = "datyeah",
        PasswordHash = Helpers.MD5Encrypt.Encrypt("password123"),
        Email = "johndoe@example.com",
        IsEmailConfirmed = true,
        Role = Role.User,
        Code = "12345",
        Avatar = "https://example.com/avatar.jpg",
        CreatedDate = DateTime.Now
      };


      if (!_context.Users.Any())
      {
        _context.Users.AddRange(new List<User>()
                  {
                  ,
                  });

        await _context.SaveChangesAsync();

      }
      if (!_context.Categories.Any())
      {
        _context.Categories.AddRange(new List<Category>()
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Technology",
                Slug = "technology",
                Description = "This is a category about technology",
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Sports",
                Slug = "sports",
                Description = "This is a category about sports",
            }
        });
        await _context.SaveChangesAsync();

      }
      if (!_context.Tags.Any())
      {
        _context.Tags.AddRange(new List<Tag>()
                  {

                       new Tag
                  {
                      TagId = 1,
                      TagName = "Technology",
                      TagId = "technology",

                  },
                  new Tag
                  {
                      TagId = 2,
                      TagName = "Sports",
                      TagId = "sports",

                  }
                   });
        await _context.SaveChangesAsync();

      }
      if (!_context.Posts.Any())
      {
        _context.Posts.AddRange(new List<Post>()
                  {

                       new Post
                {
    Title = "Title of the post",
    Slug = "slug-of-the-post",
    CreatedDate = DateTime.Now,
    Content = "Content of the post",
    //UserId=


    ListTag = "Tag 1, Tag 2",

    Status =PostStatus.Approved
},

                   });
        await _context.SaveChangesAsync();

      }

      //   // await _context.SaveChangesAsync();

    }

  }
}
