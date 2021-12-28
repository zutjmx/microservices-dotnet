using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace Products.API.Data
{
    public partial class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(b =>
            {
                b.ToTable("products");
            });
        }
    }
}
