using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class OrderItem
	{
		public int OrderId { get; set; }

		public int ProductId { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Product quantity must be 1 or more")]
		public int ProductQuantity { get; set; }

		[ForeignKey("OrderId")]
		public Order? Order { get; set; }

		[ForeignKey("ProductId")]
		public Product? Product { get; set; }
	}
}
