using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class BangazonDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(order => order.Products)
            .WithMany(products => products.Orders)
            .UsingEntity(x => x.ToTable("OrderProduct"));

        modelBuilder.Entity<User>().HasData(new User[]
        {
            
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category {CategoryId = 1, CategoryType = "Men's Apparel"},
            new Category {CategoryId = 2, CategoryType = "Women's Apparel"},
            new Category {CategoryId = 3, CategoryType = "Children's Apparel"},
            new Category {CategoryId = 4, CategoryType = "Electronics"}
        });

        modelBuilder.Entity<Payment>().HasData(new Payment[]
        {
            new Payment {PaymentId = 1, PaymentType = "Cash"},
            new Payment {PaymentId = 2, PaymentType = "Card"}
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {OrderId = 1, CustomerId = 1, PaymentId = 1, Status = true}, 
            new Order {OrderId = 2, CustomerId = 2, PaymentId = 2, Status = true}
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product {ProductId = 1, SellerId = 1, CategoryId = 1, ProductName = "Polo Shirt", ProductDescription = "A nice polo shirt", ProductPrice = 20.00m, ProductImageUrl = "https://via.placeholder.com/150"},
            new Product {ProductId = 2, SellerId = 1, CategoryId = 2, ProductName = "Dress", ProductDescription = "A nice dress", ProductPrice = 40.00m, ProductImageUrl = "https://via.placeholder.com/150"},
            new Product {ProductId = 3, SellerId = 1, CategoryId = 3, ProductName = "T-Shirt", ProductDescription = "A nice t-shirt", ProductPrice = 15.00m, ProductImageUrl = "https://via.placeholder.com/150"},
            new Product {ProductId = 4, SellerId = 1, CategoryId = 4, ProductName = "Laptop", ProductDescription = "A nice laptop", ProductPrice = 800.00m, ProductImageUrl = "https://via.placeholder.com/150"}
        });
    }
}