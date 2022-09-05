using Microsoft.EntityFrameworkCore;
using MyMovies.Api.Extensions;
using MyMovies.Repositories.Database.Context;
using MyMovies.Repositories.Database.Extensions;

namespace MyMovies.Api
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
            builder.Services.AddDbContext<SQLiteContext>(); //*registre contexto
            builder.Services.AddDatabaseRepository();
            builder.Services.AddEventLogger();

            var app = builder.Build();

            //executa as migrações
            using(var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<SQLiteContext>();
                dbContext?.Database.Migrate();
            }
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}