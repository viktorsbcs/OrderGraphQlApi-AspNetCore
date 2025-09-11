using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl
{
	public class Query
	{
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Customer> GetCustomers(GraphQlDbContext dbContext)
		{
			return dbContext.Customers;
		}

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Product> GetProducts(GraphQlDbContext dbContext)
		{
			return dbContext.Products;
		}

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Order> GetOrders(GraphQlDbContext dbContext)
		{
			return dbContext.Orders;
		}

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<OrderItem> GetOrderItems(GraphQlDbContext dbContext)
		{
			return dbContext.OrderItems;
		}
	}
}
