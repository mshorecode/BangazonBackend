using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5003")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// User routes
app.MapGet("/user", (BangazonDbContext db) =>
{
    return db.Users.ToList();
});

app.MapGet("/user/{id}", (BangazonDbContext db, int id) =>
{
    return db.Users.SingleOrDefault(user => user.Id == id);
});

app.MapPost("/checkuser", (BangazonDbContext db, UserAuthDto userAuthDto) =>
{
    var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

    if (userUid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(userUid);
    }
});

app.MapPost("/register", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

app.MapPatch("/user/{id}", (BangazonDbContext db, int id, UserDto user) =>
{
    var userToUpdate = db.Users.SingleOrDefault(user => user.Id == id);

    if (userToUpdate == null)
    {
        return Results.NotFound();
    }

    if (!string.IsNullOrEmpty(user.Username)) userToUpdate.Username = user.Username;
    if (!string.IsNullOrEmpty(user.FirstName)) userToUpdate.FirstName = user.FirstName;
    if (!string.IsNullOrEmpty(user.LastName)) userToUpdate.LastName = user.LastName;
    if (!string.IsNullOrEmpty(user.Email)) userToUpdate.Email = user.Email;
    if (user.Seller.HasValue) userToUpdate.Seller = user.Seller.Value;

    db.SaveChanges();
    return Results.NoContent();
});

// Product routes
app.MapGet("/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});

app.MapGet("/products/{productId}", (BangazonDbContext db, int productId) =>
{
    return db.Products.SingleOrDefault(c => c.ProductId == productId);
});

//Products by SellerId
app.MapGet("/products/seller/{sellerId}", (BangazonDbContext db, int sellerId) =>
{
    return db.Products.Where(p => p.SellerId == sellerId).ToList();
});

// Filter products by category
app.MapGet("/products/category/{categoryId}", (BangazonDbContext db, int categoryId) =>
{
    return db.Products.Where(p => p.CategoryId == categoryId).ToList();
});

// Order routes
app.MapGet("/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});

app.MapGet("/orders/{id}", (BangazonDbContext db, int id) =>
{
    return db.Orders.SingleOrDefault(c => c.OrderId == id);
});

// TODO: check into call auto adding the products to the order with post instead of using patch
app.MapPost("/orders", (BangazonDbContext db, Order order) =>
{
    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Created($"/orders/{order.OrderId}", order);
});

app.MapPost("/orders/addproduct", (BangazonDbContext db, OrderProductDto orderProductDto) =>
{
    var order = db.Orders.Include(order => order.Products).SingleOrDefault(order => order.OrderId == orderProductDto.OrderId);
    var product = db.Products.Find(orderProductDto.ProductId);

    if (order == null || product == null)
    {
        return Results.NotFound();
    }

    order.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/orders/{orderProductDto.OrderId}/products/{orderProductDto.ProductId}", product);
});

app.MapDelete("/orders/{id}", (BangazonDbContext db, int id) =>
{
    var order = db.Orders.SingleOrDefault(order => order.OrderId == id);

    if (order == null)
    {
        return Results.NotFound();
    }

    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/orders/{orderId}/products/{productId}", (BangazonDbContext db, int orderId, int productId) =>
{
    var order = db.Orders.SingleOrDefault(order => order.OrderId == orderId);
    var product = db.Products.SingleOrDefault(product => product.ProductId == productId);

    if (order == null || product == null)
    {
        return Results.NotFound();
    }

    order.Products.Remove(product);
    db.SaveChanges();
    return Results.NoContent();
});

// Category routes
app.MapGet("/categories", (BangazonDbContext db) =>
{
    return db.Categories.ToList();
});

app.MapGet("/categories/{id}", (BangazonDbContext db, int id) =>
{
    var category = db.Categories.SingleOrDefault(category => category.CategoryId == id);
    return category.CategoryType;
});

// Payment routes
app.MapGet("/payments", (BangazonDbContext db) =>
{
    return db.Payments.ToList();
});

app.Run();
