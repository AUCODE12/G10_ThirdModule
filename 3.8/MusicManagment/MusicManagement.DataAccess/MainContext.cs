using Microsoft.EntityFrameworkCore;
using MusicManagement.DataAccess.Entities;

namespace MusicManagement.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Music> Music { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusicManagement;User Id=sa;Password=1;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
