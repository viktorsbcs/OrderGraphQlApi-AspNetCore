using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGraphQlApi.Models
{
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string? FirstName { get; set; }

		[Required]
		public string? LastName { get; set; }

		[Required]
		public string? Address { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string? Email { get; set; }

		public ICollection<Order> Orders { get; set; } = new List<Order>();

	}
}
