using Blog.Models;
using Blog.Models.EF;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDBContext _db;
    public HomeController(ApplicationDBContext db)
    {
      _db = db;
    }


    public IActionResult Index()
    {
      var categories = _db.Posts.ToList();
      return Ok(categories);
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