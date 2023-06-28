using Blog.Data.Entities;
using Blog.Data.Enums;
using Blog.Models;
using Blog.Models.EF;
using Blog.Services;
using AutoMapper;

namespace Blog.Data;

public class DbInitializer
{
  private readonly ApplicationDBContext _context;
  private readonly IPostService _postService;
  private readonly IWebHostEnvironment _webHostEnvironment;
  private readonly IMapper _mapper;

  public DbInitializer(
  ApplicationDBContext context,
  IPostService postService,
  IWebHostEnvironment webHostEnvironment,
  IMapper mapper)
  {
    _context = context;
    _postService = postService;
    _webHostEnvironment = webHostEnvironment;
    _mapper = mapper;
  }

  public string GetResourceDirectoryPath()
  {
    return _webHostEnvironment.WebRootPath;
  }
  public async Task Seed()
  {
    var user1 = new User
    {
      UserId = new Guid("3375b35a-9bcc-4b49-a1ed-611a38a607d2"),
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
      UserId = new Guid("1aa17f30-8027-442d-ae05-7c539979b6a0"),
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
    if (!_context.Categories.Any())
    {
      _context.Categories.AddRange(new List<Category>()
      {
        new Category
        {

        CategoryName = "Technology",
        Slug = "technology",
        Description = "This is a category about technology",
        },
        new Category
        {

        CategoryName = "Sports",
        Slug = "sports",
        Description = "This is a category about sports",
        }
        });
      await _context.SaveChangesAsync();

    }

    if (!_context.Posts.Any())
    {
      List<PostFromCSV> listPost = _postService.GetData(GetResourceDirectoryPath() + "/resources/train.csv");
      List<PostCreateRequest> listPostEntity = _mapper.Map<List<PostFromCSV>, List<PostCreateRequest>>(listPost);
      await _postService.SeedData(listPostEntity, user1.UserId);

    }

    await _context.SaveChangesAsync();

  }

}
