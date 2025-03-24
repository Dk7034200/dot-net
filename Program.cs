using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable static file serving (for images, CSS, JS, etc.)
app.UseStaticFiles();  // This enables static files from wwwroot

// Define a simple model
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// Define a simple controller that handles requests
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Items}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "items",
    pattern: "items",
    defaults: new { controller = "Items", action = "Index" });

// Create the ItemsController with Index action
app.MapGet("/Items/Index", async context =>
{
    var items = new List<Item>
    {
        new Item { Id = 1, Name = "Item 1", Price = 10.99M },
        new Item { Id = 2, Name = "Item 2", Price = 15.99M },
        new Item { Id = 3, Name = "Item 3", Price = 20.99M }
    };

    // Build a simple HTML response including the image
    var html = "<html><body><h1>Items List</h1>";
    html += "<img src='/image.jpg' alt='Image' style='width:300px;' />";
    html += "<table border='1'>";
    html += "<tr><th>Id</th><th>Name</th><th>Price</th></tr>";
    foreach (var item in items)
    {
        html += $"<tr><td>{item.Id}</td><td>{item.Name}</td><td>{item.Price}</td></tr>";
    }
    html += "</table></body></html>";

    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(html);
});

// Run the app
app.Run();
