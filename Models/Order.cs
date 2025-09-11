using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
		[ForeignKey("CustomerId")]
		public Customer? Customer { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
