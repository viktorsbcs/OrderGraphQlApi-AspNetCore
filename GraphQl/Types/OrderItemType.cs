using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl.Types
{
	public class OrderItemType : ObjectType<OrderItem>
	{
		protected override void Configure(IObjectTypeDescriptor<OrderItem> descriptor)
		{
			descriptor.Description("Items that are included in order");

			descriptor.Field(oi => oi.OrderId)
				.Description("Foreign key to related order id");

			descriptor.Field(oi => oi.ProductId)
				.Description("Foreign key to related product id");

			descriptor.Field(oi => oi.ProductQuantity)
				.Description("Amount of specific product ordered");

			descriptor.Field(oi => oi.Order)
				.Description("Reference to order");

			descriptor.Field(oi => oi.Product)
				.Description("Reference to product");
		}
	}
}
