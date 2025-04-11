using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SecretHitler.Models;

public class ApplicationUser : IdentityUser
{

    [Required]
    [MaxLength(64)]
    public string Playername { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
}