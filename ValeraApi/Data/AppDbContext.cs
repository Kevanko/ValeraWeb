// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ValeraApi.Models;


namespace ValeraApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Valera> Valeras { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
        modelBuilder.Entity<Valera>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId);
    }
}