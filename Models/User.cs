using System.ComponentModel.DataAnnotations;

namespace SecretHitler.Models;

public class User
{
    public int UserID { get; set; }
    [Required]
    [MaxLength(128)]
    public string Username { get; set; }
    [Required]
    [MaxLength(128)]
    public string Password { get; set; }
}