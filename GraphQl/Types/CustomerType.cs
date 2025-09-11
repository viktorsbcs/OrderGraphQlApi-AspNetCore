using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl.Types
{
	public class CustomerType : ObjectType<Customer>
	{
		protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
		{
			descriptor.Description("Customer who can place order");

			descriptor.Field(c => c.Id)
				.Description("Customer id");

			descriptor.Field(c => c.FirstName)
				.Description("Customer first name");

			descriptor.Field(c => c.LastName)
				.Description("Customer last name");

			descriptor.Field(c => c.Address)
				.Description("Customer address");

			descriptor.Field(c => c.Email)
				.Description("Customer email");

			descriptor.Field(c => c.Orders)
				.Description("List of orders that specific customer has placed");
		}
	}
}
