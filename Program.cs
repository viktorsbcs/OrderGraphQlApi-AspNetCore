using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderGraphQlApi.Context;
using OrderGraphQlApi.GraphQl;
using System.Data.Common;

namespace OrderGraphQlApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<GraphQlDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:DbConnection"]);
            });

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            var app = builder.Build();



            app.MapGet("/products", (IServiceProvider service) =>
            {
                var products = service.GetService<GraphQlDbContext>().Products.ToList();
                return Results.Ok(products);
            });

            app.MapGraphQL("/graphql");
            app.Run();
        }
    }
}
