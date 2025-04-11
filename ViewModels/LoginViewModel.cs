using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecretHitler.Models;

public class LoginViewModel {
    [Required]
    [MaxLength(64)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [DisplayName("Remember Me")]
    public bool RememberMe { get; set; }
}
