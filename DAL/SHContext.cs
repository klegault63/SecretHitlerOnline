using System.Data.Common;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecretHitler.Configs;
using SecretHitler.Models;

namespace SecretHitler;

public class SHContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
    public SHContext(DbContextOptions<SHContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Call this manually for the identity models
        IdentityModelConfig.Configure(modelBuilder);

        // Apply additional configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
