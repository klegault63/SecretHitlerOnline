using Microsoft.AspNetCore.Mvc;
using SecretHitler.Models;

namespace SecretHitler.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        return RedirectToAction("Index", "Home");
    }
}