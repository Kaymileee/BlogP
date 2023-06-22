using Blog.Data.Entities;
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
      //   if (!_context.Users.Any())
      //   {
      //     _context.Users.AddRange(new List<User>()
      //             {
      //             new User
      //             {
      //                 UserId = Guid.NewGuid(),
      //                 UserName = "johndoe",
      //                 Password = "password123",
      //                 Email = "johndoe@example.com",
      //                 Avatar = "https://example.com/avatar.jpg",
      //                 CreatedAt = DateTime.Now.AddDays(-10),
      //                 LastLogin = DateTime.Now.AddDays(-1),

      //             },
      //             new User
      //             {
      //                 UserId = Guid.NewGuid(),
      //                 UserName = "janedoe",
      //                 Password = "password456",
      //                 Email = "janedoe@example.com",
      //                 Avatar = "https://example.com/avatar.jpg",
      //                 CreatedAt = DateTime.Now.AddDays(-5),
      //                 LastLogin = DateTime.Now.AddDays(-1),

      //             }});

      //     await _context.SaveChangesAsync();

      //   }
      //   //if (!_context.Categories.Any())
      //   //{
      //   //    _context.Categories.AddRange(new List<Category>()
      //   //    {
      //   //        new Category
      //   //     {
      //   //        CategoryId = 1,
      //   //        CategoryName = "Technology",
      //   //        slug = "technology",
      //   //        Content = "This is a category about technology",

      //   //    },
      //   //    new Category
      //   //    {
      //   //        CategoryId = 2,
      //   //        CategoryName = "Sports",
      //   //        slug = "sports",
      //   //        Content = "This is a category about sports",

      //   //    }
      //   //    });
      //   //    await _context.SaveChangesAsync();


      //   //}
      //   if (!_context.Tags.Any())
      //   {
      //     _context.Tags.AddRange(new List<Tag>()
      //             {

      //                  new Tag
      //             {
      //                 TagId = 1,
      //                 TagName = "Technology",
      //                 TagSlug = "technology",
      //                 TagContent = "This tag is related to technology",

      //             },
      //             new Tag
      //             {
      //                 TagId = 2,
      //                 TagName = "Sports",
      //                 TagSlug = "sports",
      //                 TagContent = "This tag is related to sports",

      //             }
      //              });
      //     await _context.SaveChangesAsync();

      //   }

      //   // await _context.SaveChangesAsync();

    }

  }
}
