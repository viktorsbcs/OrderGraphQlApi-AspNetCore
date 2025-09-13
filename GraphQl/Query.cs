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
		public IQueryable<Customer> GetCustomers(GraphQlDbContext dbContext) => dbContext.Customers;

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Product> GetProducts(GraphQlDbContext dbContext) => dbContext.Products;

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Order> GetOrders(GraphQlDbContext dbContext) => dbContext.Orders;

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<OrderItem> GetOrderItems(GraphQlDbContext dbContext) => dbContext.OrderItems;
	}
}
