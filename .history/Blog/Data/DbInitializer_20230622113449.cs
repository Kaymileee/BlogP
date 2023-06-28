using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.Models;
using Blog.Models.EF;
using Blog.Services;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class DbInitializer
{
  private readonly ApplicationDBContext _context;
  private readonly IPostService _postService;
  private readonly IWebHostEnvironment _webHostEnvironment;

  public DbInitializer(
  ApplicationDBContext context,
  IPostService postService,
  IWebHostEnvironment webHostEnvironment)
  {
    _context = context;
    _postService = postService;
    _webHostEnvironment = webHostEnvironment;
  }

  public string GetResourceDirectoryPath()
  {
    return _webHostEnvironment.WebRootPath;
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
      _context.Users.AddRange(new List<User>() { user1, user2 });
      await _context.SaveChangesAsync();

    }
    // if (!_context.Categories.Any())
    // {
    //     _context.Categories.AddRange(new List<Category>()
    //   {
    //     new Category
    //     {
    //     CategoryId = 1,
    //     CategoryName = "Technology",
    //     Slug = "technology",
    //     Description = "This is a category about technology",
    //     },
    //     new Category
    //     {
    //     CategoryId = 2,
    //     CategoryName = "Sports",
    //     Slug = "sports",
    //     Description = "This is a category about sports",
    //     }
    //     });
    //     await _context.SaveChangesAsync();

    // }

    if (!_context.Posts.Any())
    {
      List<PostFromCSV> listPost = _postService.GetData(GetResourceDirectoryPath() + "/resources/train.csv");
      List<PostCreateRequest> listPoste = _mapper.Map<List<PostsFromCSV>, List<PostCreateRequest>>(listPost);
      await _contentBasedService.SeedData(listPoste, "45c2a768-549e-4d57-95a7-ad19939403e0");

    }

    await _context.SaveChangesAsync();

  }

}
