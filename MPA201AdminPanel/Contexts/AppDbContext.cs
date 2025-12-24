using Microsoft.EntityFrameworkCore;
using MPA201AdminPanel.Models;

namespace MPA201AdminPanel.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Product> Products { get; set; }

    }
}
