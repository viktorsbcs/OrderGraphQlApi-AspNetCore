using OrderGraphQlApi.Models;

namespace OrderGraphQlApi.GraphQl
{
	public class Subscription
	{
		[Subscribe]
		[Topic]
		public Customer OnCustomerAdded([EventMessage] Customer customer) => customer;

		[Subscribe]
		[Topic]
		public Product OnProductAdded([EventMessage] Product product) => product;

		[Subscribe]
		[Topic]
		public Order OnOrderCreated([EventMessage] Order order) => order;
	}
}
