using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl.Types
{
	public class ProductType : ObjectType<Product>
	{
		protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
		{
			descriptor.Description("Reperesents available products in stock");

			descriptor.Field(p => p.Id)
				.Description("Product id");

			descriptor.Field(p => p.Name)
				.Description("Product name");

			descriptor.Field(p => p.Price)
				.Description("Product price");

			descriptor.Field(p => p.QuantityInStock)
				.Description("Available product quantity in stock");
		}
	}
}
