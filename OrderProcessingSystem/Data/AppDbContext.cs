using Microsoft.EntityFrameworkCore;

namespace OrderProcessingSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AutorModel> Order { get; set; }
        public DbSet<AutorModel> Payment { get; set; }
        public DbSet<AutorModel> Notification { get; set; }

    }
}
