using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecretHitler.Models;

namespace SecretHitler.Controllers;

public class PlayController : Controller
{
    private readonly ILogger<PlayController> _logger;

    public PlayController(ILogger<PlayController> logger)
    {
        _logger = logger;
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
