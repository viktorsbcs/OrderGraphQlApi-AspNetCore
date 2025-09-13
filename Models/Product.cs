using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		public string? Description { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
		public decimal Price { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Quantity in stock cannot be negative")]
		public int QuantityInStock {  get; set; }
	}
}
