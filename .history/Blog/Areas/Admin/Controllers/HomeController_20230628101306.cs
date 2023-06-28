using AutoMapper;
using Blog.Data.Entities;
using Blog.Helpers;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace Blog.Areas.Admin.Controllers
{
  [Area("Admin")]
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
      var tags = await _db.Tags.Take(10).ToListAsync();
      ViewBag.Tags = tags;
      return View();
    }
    public async Task<IActionResult> Part()
    {
      var model = new TagVMD { TagId = "100", TagName = "Teah" };
      return PartialView("~/Areas/Admin/Views/Shared/_TagSidebar.cshtml", model);
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

      List<UserBases> userBases = new List<UserBases>();
      for (int i = 0; i < listVectors.Count; i++)
      {
        double cosine = CosineSimilarity.Cosine(listVectors[i].Vector, vector_user);
        if (cosine > 0)
        {
          userBases.Add(new UserBases()
          {
            UserId = user1.UserId,
            PostId = listVectors[i].PostId,
            Tags = GetTagsById(listVectors[i].PostId, listPost),
            Cosine = cosine
          });
        }
      }

      userBases = userBases.OrderByDescending(x => x.Cosine).ToList();

      return Ok(userBases);
    }

    string[]? GetTagsById(int PostId, List<PostFromCSV> listPost)
    {
      foreach (var post in listPost)
      {
        if (post.Id == PostId)
        {
          return post.Tags;
        }
      }
      return null;
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