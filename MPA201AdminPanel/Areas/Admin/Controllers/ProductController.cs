
using Microsoft.AspNetCore.Mvc;
using MPA201AdminPanel.Contexts;
using MPA201AdminPanel.Models;

namespace MPA201AdminPanel.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create() 
    { 
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product) 
    { 
        if(!ModelState.IsValid) return View(product);
        product.CreatedDate = DateTime.UtcNow.AddHours(4);
        product.IsDeleted = false;
        _context.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("product/{id}")]
    public IActionResult Delete([FromRoute] int id) 
    { 
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Product is not found");
        _context.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id) 
    { 
        var product = _context.Products.Find(id);
        if (product == null) return NotFound("Product is not found");
        return View(product);
    }
    [HttpPost]
    public IActionResult Update(Product product) 
    {
        if (!ModelState.IsValid) return View();
        var existProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (existProduct == null) return NotFound("Error");

        existProduct.Name = product.Name;
        existProduct.Price = product.Price;
        existProduct.ImageName = product.ImageName;
        existProduct.ImageURL = product.ImageURL;
        _context.Products.Update(existProduct);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Toggle(int id) 
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound("Product is not found");
        product.IsDeleted = !product.IsDeleted;
        _context.Update(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
