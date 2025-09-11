using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.Context
{
	public class GraphQlDbContext : DbContext
	{
		public GraphQlDbContext(DbContextOptions<GraphQlDbContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderItem>(entity =>
			{
				entity.HasKey(e => new { e.OrderId, e.ProductId });
				entity.ToTable("OrderItems");

				entity.HasOne(oi => oi.Order)
					.WithMany(o => o.OrderItems)
					.HasForeignKey(oi => oi.OrderId);

				entity.HasOne(oi => oi.Product)
					.WithMany()
					.HasForeignKey(oi => oi.ProductId);
			});

			modelBuilder.Entity<Order>()
				.HasOne(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId);

			modelBuilder.Entity<Customer>()
				.HasMany(c => c.Orders)
				.WithOne(o => o.Customer);
		}
	}
}
