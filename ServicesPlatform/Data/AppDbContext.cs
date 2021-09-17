using Microsoft.EntityFrameworkCore;
using ServicesPlatform.Models;

namespace ServicesPlatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
            
        }

        public DbSet<Platform> Platforms {get;set;}
    }
}