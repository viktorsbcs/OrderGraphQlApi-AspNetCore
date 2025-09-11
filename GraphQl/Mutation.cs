using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl
{
	public class Mutation
	{
		public Customer AddCustomer(string firstName, string lastName, string address, string email, GraphQlDbContext dbContext)
		{
			var customer = new Customer() { FirstName = firstName, LastName = lastName, Address = address, Email = email };
			dbContext.Customers.Add(customer);
			dbContext.SaveChanges();
			return customer;
		}
	}
}
