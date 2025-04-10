using System.Data.Common;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SecretHitler.Models;

namespace SecretHitler;

public class SHContext : DbContext
{
    public DbSet<User> Users { get; set;  }
    
    public SHContext(DbContextOptions<SHContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}