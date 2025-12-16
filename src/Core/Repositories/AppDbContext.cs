using Microsoft.EntityFrameworkCore;
using EvalApi.Src.Core.Repositories.Entities;

namespace EvalApi.Src.Core.Repositories;

public class AppDbContext : DbContext
{
  public DbSet<PostEntity> Posts { get; set; } = null!;
  public DbSet<UserEntity> Users { get; set; } = null!;

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // If you have many-to-many or other configurations between Post and User,
    // configure them here; otherwise, leave default.
    base.OnModelCreating(modelBuilder);
  }
}