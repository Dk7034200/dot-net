using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// Define the entry point of the application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable static file serving (for images, CSS, JS, etc.)
app.UseStaticFiles(); // This enables static files from wwwroot

// Define routes for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Items}/{action=Index}/{id?}");

app.Run();

// Define the ItemsController with Index action
public class ItemsController : Controller
{
    public IActionResult Index()
    {
        var items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1", Price = 10.99M },
            new Item { Id = 2, Name = "Item 2", Price = 15.99M },
            new Item { Id = 3, Name = "Item 3", Price = 20.99M }
        };

        return View(items); // Return a view that will be rendered to the client
    }
}

// Define the simple model
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
