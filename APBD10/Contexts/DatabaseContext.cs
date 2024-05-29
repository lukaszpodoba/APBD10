using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.AccountId, sc.ProductId });

        modelBuilder.Entity<ProductCategory>()
            .HasKey(sc => new {sc.ProductId, sc.CategoryId});
        
        modelBuilder.Entity<Product>()
            .Property(p => p.ProductId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                AccountId = 1,
                AccountFirstName = "John",
                AccountLastName = "Doe",
                AccountEmal = "johndoe@gmai.com",
                AccountPhone = "123456789",
                RoleId = 1
            }
        });
        
        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                RoleId = 1,
                RoleName = "User"
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Product 1",
                ProductWeight = 1.12m,
                ProductWidth = 2.453m,
                ProductHeight = 3.23m,
                ProductDepth = 4
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>
        {
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 1,
                ShoppingCartAmount = 2
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Category 1"
            }
        });

    }
}