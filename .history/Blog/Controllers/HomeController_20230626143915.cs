using AutoMapper;
using Blog.Data.Entities;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace Blog.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDBContext _db;
    private readonly IMapper _mapper;

    public HomeController(ApplicationDBContext db, IMapper mapper)
    {
      _db = db;
      _mapper = mapper;
    }


    public async Task<IActionResult> Index()
    {
      var categories = await _db.Categories.ToListAsync();
      return Ok(categories);
    }

    public async Task<IActionResult> GetSuggestedPosts()
    {
      var posts = await _db.Posts.ToListAsync();
      List<PostFromCSV> listPost = _mapper.Map<List<Post>, List<PostFromCSV>>(posts);

      var tags = await _db.Tags.ToListAsync();
      HashSet<string> setTag = new HashSet<string>();
      foreach (var tag in tags)
      {
        if (tag.TagName != null && tag.TagName.Any())
        {
          setTag.Add(tag.TagName);
        }
      }

      List<string> listTag = setTag.ToList();

      UserBases user1 = new UserBases()
      {
        UserId = "3375b35a-9bcc-4b49-a1ed-611a38a607d2",
        Tags = new string[]{
            "java",
            ".Net",
            "C#",
            "optional",
            "haskell"
            }
      };

      BitArray vector_user = new BitArray(listTag.Count);
      for (int i = 0; i < listTag.Count; i++)
      {
        if (user1.Tags != null && user1.Tags.Contains(listTag[i]))
        {
          vector_user[i] = true;
        }
      }

      List<PostVector> listVectors = new List<PostVector>();
      foreach (var post in listPost)
      {
        if (post.Tags != null && post.Tags.Any())
        {
          BitArray vector_post = new BitArray(listTag.Count);
          for (int i = 0; i < listTag.Count; i++)
          {
            if (post.Tags.Contains(listTag[i]))
            {
              vector_post[i] = true;
            }
          }
          listVectors.Add(new PostVector()
          {
            PostId = post.Id,
            Vector = vector_post
          });
        }
      }

      return Ok(setTag);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}