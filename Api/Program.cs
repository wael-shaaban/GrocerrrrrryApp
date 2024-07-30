
using Api.Constants;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services
                     .AddDbContext<DataContext>(
                    server => server.UseSqlServer
                    (builder.Configuration.GetConnectionString(DatabaseConstants.GerogercyDBStringKey)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            var mastersGroup = app.MapGroup("/masters")
                         .AllowAnonymous();

            mastersGroup.MapGet("/categories", async (DataContext context) =>
                TypedResults.Ok(await context.Categories
                .AsNoTracking()
                .ToArrayAsync()
                )
            );
            mastersGroup.MapGet("/offers", async (DataContext context) =>
                TypedResults.Ok(await context.Offers
                .AsNoTracking()
                .ToArrayAsync()
                )
            );

            app.Run("https://localhost:54321");
           // app.Run();
        }
    }
}
