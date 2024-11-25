using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RemoteMultiSiteMobileBasedExpenseManager.Models.SetupModels;
using RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels;

namespace RemoteMultiSiteMobileBasedExpenseManager.SqlServer
{
    public class DbContextEntities : DbContext //IdentityDbContext
    {
        public DbContextEntities(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectUsers> ProjectUsers { get; set; }
    }
}
