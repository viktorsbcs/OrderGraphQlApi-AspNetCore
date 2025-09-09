﻿using System.ComponentModel.DataAnnotations;

namespace OrderGraphQlApi.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int QuantityInStock {  get; set; }
	}
}
