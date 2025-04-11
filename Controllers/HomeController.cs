using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecretHitler.Models;
using SecretHitler.Services;

namespace SecretHitler.Controllers;

public class HomeController : Controller
{

  private readonly UserService _userService;
  public HomeController(UserService userService)
  {
    _userService = userService;
  }

  public IActionResult Index()
  {
    return View();
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
