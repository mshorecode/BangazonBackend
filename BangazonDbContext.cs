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
            new Product {ProductId = 1, SellerId = 1, CategoryId = 1, ProductName = "Assortment of Polo Shirts", ProductDescription = "A three pack of polo shirts", ProductPrice = 30.00m, ProductImageUrl = "https://www.trueclassictees.com/cdn/shop/products/StaplePolo3pack.jpg?v=1680043192&%3Bwidth=500&em-format=avif&em-width=500"},
            new Product {ProductId = 2, SellerId = 1, CategoryId = 2, ProductName = "Dress", ProductDescription = "A nice dress", ProductPrice = 40.00m, ProductImageUrl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSqvN814z6D8TvpO5h1fMllSOg3-hY9hCOb3qCdbUw-3e5tQi5J1oNvBwt2atWcE6gsEudtrrIZ9vCkoN_96PXTZKP-J3XC2rmyxcuDEHfHFIgwbEIW2Km5&usqp=CAE"},
            new Product {ProductId = 3, SellerId = 1, CategoryId = 3, ProductName = "Sonic T-Shirt", ProductDescription = "A nice Sonic t-shirt", ProductPrice = 15.00m, ProductImageUrl = "https://m.media-amazon.com/images/I/812lr5yYl2S._AC_SX679_.jpg"},
            new Product {ProductId = 4, SellerId = 1, CategoryId = 4, ProductName = "ASUS ROG STRIX Laptop", ProductDescription = "A nice gaming laptop", ProductPrice = 1700.00m, ProductImageUrl = "https://c1.neweggimages.com/ProductImageCompressAll1280/34-236-449-01.jpg"}
        });
    }
}