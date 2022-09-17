using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyMovies.Api.Extensions;
using MyMovies.Api.Token;
using MyMovies.Entities;
using MyMovies.Repositories.Database.Context;
using MyMovies.Repositories.Database.Extensions;
using System.Text;

namespace MyMovies.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(cors => cors.AddPolicy("AllowOriginAndMethod", options => options
            .WithOrigins(new[] { "localhost" })
            .AllowAnyMethod()
            ));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //configura a autenticação do swagger
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Informe o token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Authorization"
                            }
                        },
                        new string[]{}
                    }

                });
            });
            builder.Services.AddDbContext<SQLiteContext>(); //*registre contexto
            builder.Services.AddDatabaseRepository();
            builder.Services.AddEventLogger();

            #region Injeção de dependência do JWT Token
            var tokenConfiguration = new TokenConfiguration();
            var authenticate = new Authenticate();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
            new ConfigureFromConfigurationOptions<Authenticate>(builder.Configuration.GetSection("MyMoviesAuthenticate")).Configure(authenticate);
            builder.Services.AddSingleton(tokenConfiguration);
            builder.Services.AddSingleton(authenticate);
            builder.Services.AddScoped(typeof(GenerateToken));
            #endregion

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = tokenConfiguration.Audience,
                    ValidIssuer = tokenConfiguration.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
                };
            });


            var app = builder.Build();

            //executa as migrações
            using (var scope = app.Services.CreateScope())
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

            app.UseCors("AllowOriginAndMethod");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}