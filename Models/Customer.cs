﻿using System.ComponentModel.DataAnnotations;

namespace OrderGraphQlApi.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		public string? Address { get; set; }
		[Required]
		public string? Email { get; set; }

	}
}
