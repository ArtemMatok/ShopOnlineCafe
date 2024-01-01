using Microsoft.EntityFrameworkCore;
using ShopOnlineCafe.Server.Authentication;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
