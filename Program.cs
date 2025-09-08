using Microsoft.AspNetCore.Http.HttpResults;

namespace OrderGraphQlApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/product", () =>
            {
                return Results.Ok("Product returned");
            });
            app.UseRouting();
            app.Run();
        }
    }
}
