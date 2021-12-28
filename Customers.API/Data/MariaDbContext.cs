using Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Data
{
    public partial class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Customer>? Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(b =>
            {
                b.ToTable("customers");
            });
        }
    }
}
