using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecretHitler.Models;

public class RegisterViewModel {
    [Required(ErrorMessage = "Username is required")]
    [DisplayName("Username")]
    [MaxLength(64)]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [DisplayName("Email")]
    [MaxLength(64)]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DisplayName("Password")]
    [MaxLength(64)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirmation of password is required.")]
    [DisplayName("Confirm Password")]
    [MaxLength(64)]
    public string ConfirmPassword { get; set; }
}
