using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// User routes
app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.Users.ToList();
});

app.MapGet("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    return db.Users.SingleOrDefault(user => user.Id == id);
});

app.MapPost("/api/users", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/api/users/{user.Id}", user);
});

app.MapPut("/api/users/{id}", (BangazonDbContext db, int id, UserDto user) =>
{
    var userUpdate = db.Users.SingleOrDefault(user => user.Id == id);

    if (userUpdate == null)
    {
        return Results.NotFound();
    }

    userUpdate.Username = String.IsNullOrEmpty(user.Username) ? userUpdate.Username : user.Username;
    userUpdate.FirstName = String.IsNullOrEmpty(user.FirstName) ? userUpdate.FirstName : user.FirstName;
    userUpdate.LastName = String.IsNullOrEmpty(user.LastName) ? userUpdate.LastName : user.LastName;
    userUpdate.Email = String.IsNullOrEmpty(user.Email) ? userUpdate.Email : user.Email;
    userUpdate.Seller = user.Seller ?? userUpdate.Seller;

    db.SaveChanges();
    return Results.NoContent();
});

// Product routes
app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.ToList();
});

app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    return db.Products.SingleOrDefault(c => c.ProductId == id);
});

// Order routes
app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders.ToList();
});

app.MapGet("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    return db.Orders.SingleOrDefault(c => c.OrderId == id);
});

// TODO: check into call auto adding the products to the order and failing if the product doesn't exist
app.MapPost("/api/orders", (BangazonDbContext db, Order order) =>
{
    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Created($"/api/orders/{order.OrderId}", order);
});

app.MapDelete("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    var order = db.Orders.SingleOrDefault(c => c.OrderId == id);

    if (order == null)
    {
        return Results.NotFound();
    }

    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();
