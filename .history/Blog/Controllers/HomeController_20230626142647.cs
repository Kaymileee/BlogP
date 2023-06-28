using AutoMapper;
using Blog.Data.Entities;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

      HashSet<string> setTag = new HashSet<string>();
      foreach (var post in listPost)
      {
        if (post.Tags != null && post.Tags.Any())
        {
          foreach (var tag in post.Tags)
          {
            setTag.Add(tag);
          }
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