﻿namespace OrderGraphQlApi.GraphQl.Inputs
{
	public class ProductInputDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
	}
}
