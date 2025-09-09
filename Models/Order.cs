using System.ComponentModel.DataAnnotations;

namespace OrderGraphQlApi.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public Customer? Customer { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
	}
}
