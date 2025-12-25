using Microsoft.EntityFrameworkCore;
using MPA201AdminPanel.Models;

namespace MPA201AdminPanel.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
