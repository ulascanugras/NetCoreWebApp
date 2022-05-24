using Microsoft.EntityFrameworkCore;
using Moralabs_NetCoreWebApp.Data.Entities;

namespace Moralabs_NetCoreWebApp.Data
{
    public class NorthwindDBContext : DbContext
    {
        public NorthwindDBContext(DbContextOptions<NorthwindDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}

