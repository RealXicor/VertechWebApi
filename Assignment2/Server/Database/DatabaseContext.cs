using Assignment2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=VertechWebApiDB;Trusted_Connection=True;");
            }
        }
    }
}
