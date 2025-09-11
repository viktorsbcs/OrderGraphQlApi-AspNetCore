using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.Models;
using HotChocolate.Data;

namespace OrderGraphQlApi.GraphQl.Types
{
	public class OrderType : ObjectType<Order>
	{
		protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
		{
			descriptor.Description("Represents order, each order can have single customer and one or many orderItems");

			descriptor.Field(o => o.Id)
				.Description("Unique identifier of the order");

			descriptor.Field(o => o.CreatedAt)
				.Description("Date and time when order was created");

			descriptor.Field(o => o.TotalPrice)
				.Description("Total price of order");

			descriptor.Field(o => o.Customer)
				.Description("Customer who placed an order");

			descriptor.Field(o => o.OrderItems)
				.Description("Collection of products included in order");

		}
	}
}
