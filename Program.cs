using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.GraphQl;
using OrderGraphQlApi.GraphQl.Inputs;
using OrderGraphQlApi.GraphQl.Types;

namespace OrderGraphQlApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddPooledDbContextFactory<GraphQlDbContext>(options =>
			{
				options.UseNpgsql(builder.Configuration["ConnectionStrings:DbConnection"]);
			});

			builder.Services
				.AddGraphQLServer()
				.AddQueryType<Query>()
				.AddMutationType<Mutation>()
				.AddSubscriptionType<Subscription>()
				.AddType<ProductType>()
				.AddType<CustomerType>()
				.AddType<OrderType>()
				.AddType<OrderItemType>()
				.AddType<InputObjectType<CustomerInputDto>>()
				.AddType<InputObjectType<ProductInputDto>>()
				.AddType<InputObjectType<OrderItemInputDto>>()
				.RegisterDbContextFactory<GraphQlDbContext>()
				.AddProjections()
				.AddFiltering()
				.AddSorting()
				.AddInMemorySubscriptions();

			var app = builder.Build();

			app.MapGraphQL("/graphql");
			app.Map("/orders", () =>
			{
				return "Ok";
			});
			app.Run();
		}
	}
}
