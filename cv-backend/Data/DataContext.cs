using cv_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cv_backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Skill> Skill { get; set; }
    public DbSet<Experience> Experience { get; set; }
    public DbSet<Education> Education { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
       .HasMany(c => c.Skills)
       .WithOne(e => e.User);

        modelBuilder.Entity<User>()
            .HasMany(c => c.Experience)
            .WithOne(e => e.User);

        modelBuilder.Entity<User>()
            .HasMany(c => c.Education)
            .WithOne(e => e.User);
    }
}