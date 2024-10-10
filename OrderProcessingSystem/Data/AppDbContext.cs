using Microsoft.EntityFrameworkCore;

namespace OrderProcessingSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
