using Microsoft.AspNetCore.Mvc;
using MPA201AdminPanel.Contexts;

namespace MPA201AdminPanel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            ViewBag.Blogs = blogs;
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);
            blog.CreatedDate = DateTime.UtcNow.AddHours(4);
            blog.IsDeleted = false;
            _context.Add(blog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("blog/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null) return NotFound("Blog is not found");
            _context.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null) return NotFound("Blog is not found");
            return View(blog);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (!ModelState.IsValid) return View();
            var existBlog = _context.Blogs.FirstOrDefault(b => b.Id == blog.Id);
            if (existBlog == null) return NotFound("Error");

            existBlog.Title = blog.Title;
            existBlog.Text = blog.Text;
            existBlog.ImageName = blog.ImageName;
            existBlog.ImageURL = blog.ImageURL;
            _context.Blogs.Update(existBlog);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
