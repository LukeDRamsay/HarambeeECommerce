using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

using LukeRamsayWebAPI.Models;

namespace LukeRamsayWebAPI.Data
{
    public class ECommerceContextFactory : IDesignTimeDbContextFactory<ECommerceContext>
    {
        public ECommerceContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ECommerceContext>();
            var connectionString = configuration.GetConnectionString("ECommerceDatabase");
            builder.UseSqlServer(connectionString);

            return new ECommerceContext(builder.Options);
        }
    }
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}