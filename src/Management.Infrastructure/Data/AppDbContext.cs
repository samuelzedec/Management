using Managment.Domain.Entities;
using Managment.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Managment.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        modelBuilder.SeedCategoryData();
    }
}