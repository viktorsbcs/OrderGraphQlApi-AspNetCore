using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.GraphQl.Inputs;
using OrderGraphQlApi.Models;
using HotChocolate.Subscriptions;

namespace OrderGraphQlApi.GraphQl
{
	public class Mutation
	{
		public async Task<Customer> AddCustomer(CustomerInputDto customerDto, GraphQlDbContext dbContext, ITopicEventSender eventSender, CancellationToken cancellationToken)
		{
			var customer = new Customer()
			{
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				Address = customerDto.Address,
				Email = customerDto.Email
			};

			await dbContext.Customers.AddAsync(customer);
			await dbContext.SaveChangesAsync();

			await eventSender.SendAsync(nameof(Subscription.OnCustomerAdded), customer, cancellationToken);

			return customer;
		}

		public async Task<Product> AddProduct(ProductInputDto productDto, GraphQlDbContext dbContext, ITopicEventSender eventSender, CancellationToken cancellationToken)
		{
			var product = new Product()
			{
				Name = productDto.Name,
				Description = productDto.Description,
				Price = productDto.Price,
				QuantityInStock = productDto.QuantityInStock
			};

			await dbContext.AddAsync(product);
			await dbContext.SaveChangesAsync();

			await eventSender.SendAsync(nameof(Subscription.OnProductAdded), product, cancellationToken);

			return product;

		}

		public async Task<Order> AddOrder(int customerId, List<OrderItemInputDto> orderItemsDto, GraphQlDbContext dbContext, ITopicEventSender eventSender, CancellationToken cancellationToken)
		{
			await using var transaction = await dbContext.Database.BeginTransactionAsync();
			try
			{
				var customer = await dbContext.Customers.Where(c => c.Id == customerId).FirstOrDefaultAsync();
				if (customer is null) throw new ArgumentException($"{nameof(customerId)}={customerId} not found");

				var order = new Order()
				{
					CustomerId = customerId,
					Customer = customer,
					CreatedAt = DateTime.UtcNow,
					OrderItems = new List<OrderItem>()
				};

				decimal orderTotalPrice = 0;

				foreach (var input in orderItemsDto)
				{
					var product = await dbContext.Products
						.Where(p => p.Id == input.ProductId)
						.SingleOrDefaultAsync();

					if (product is null) throw new ArgumentException($"{nameof(input.ProductId)} not found");

					if (product.QuantityInStock < input.ProductQuantity)
						throw new ArgumentOutOfRangeException($"Product {input.ProductId}:{product.Name} stock insufficient. Requested quantity: {input.ProductQuantity}, available in stock {product.QuantityInStock}");

					product.QuantityInStock -= input.ProductQuantity;
					dbContext.Products.Update(product);

					var orderItem = new OrderItem()
					{
						ProductId = product.Id,
						ProductQuantity = input.ProductQuantity
					};
					order.OrderItems.Add(orderItem);
					orderTotalPrice += input.ProductQuantity * product.Price;
				}

				order.TotalPrice = orderTotalPrice;
				await dbContext.Orders.AddAsync(order);
				await dbContext.SaveChangesAsync();
				await transaction.CommitAsync();

				await eventSender.SendAsync(nameof(Subscription.OnOrderCreated), order, cancellationToken);

				return order;
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}

		}
	}
}
