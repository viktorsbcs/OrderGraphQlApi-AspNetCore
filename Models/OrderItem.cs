using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class OrderItem
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int ProductQuantity { get; set; }

		[ForeignKey("OrderId")]
		public Order? Order { get; set; }
		[ForeignKey("ProductId")]
		public Product? Product { get; set; }
	}
}
