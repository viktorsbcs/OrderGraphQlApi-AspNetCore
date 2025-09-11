using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.GraphQl;
using OrderGraphQlApi.GraphQl.Types;
using System.Data.Common;

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
				.AddType<ProductType>()
				.AddType<CustomerType>()
				.AddType<OrderType>()
				.AddType<OrderItemType>()
				.RegisterDbContextFactory<GraphQlDbContext>()
				.AddProjections()
				.AddFiltering()
				.AddSorting();
				
			var app = builder.Build();

			app.MapGraphQL("/graphql");
			app.Run();
		}
	}
}
