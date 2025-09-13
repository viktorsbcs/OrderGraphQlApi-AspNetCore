using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		[Required]
		public int CustomerId { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0")]
		public decimal TotalPrice { get; set; }
		
		[ForeignKey("CustomerId")]
		public Customer? Customer { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
