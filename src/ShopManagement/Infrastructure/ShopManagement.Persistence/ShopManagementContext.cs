using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Persistence;

public class ShopManagementContext : DbContext
{

    public ShopManagementContext(DbContextOptions<ShopManagementContext> options) : base(options)
    {

    }

    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
} 