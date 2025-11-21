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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
    }
}