using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Items}/{action=Index}/{id?}");

app.Run();


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

        return View(items); 
}


public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
