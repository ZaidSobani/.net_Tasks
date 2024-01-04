using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        { 
            
        }

        public DbSet<Item> Items { get; set; } = null!;
    }
}
