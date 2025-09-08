using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.Context
{
	public class GraphQlDbContext : DbContext
	{
		public GraphQlDbContext() : base()
		{
				
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }	
		public DbSet<Product> Products { get; set; }	
	}
}
