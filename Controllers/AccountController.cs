using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecretHitler.Models;
using SecretHitler.Services;


namespace SecretHitler.Controllers;

public class AccountController : Controller {
    // private readonly UserService _userService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        #region Validation
        if (!ModelState.IsValid){
            return View(model);
        }
        else if (!model.Password.Equals(model.ConfirmPassword)){
            ModelState.AddModelError("", "Passwords do not match.");
        }
        
        // Check if the user exists
        var existingUser = await _userManager.FindByNameAsync(model.Email);
        if (existingUser != null){
            ModelState.AddModelError("", "Email is already in use.");
        }
        #endregion
        
        #region Create User
        var user = new ApplicationUser
        {
            Playername = model.Username,
            DateCreated = DateTime.Now,
            UserName = model.Email, 
            Email = model.Email
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        #endregion

        #region Creation Validation
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction(nameof(Login));
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
        
        return View(model);
        #endregion
    }
}
