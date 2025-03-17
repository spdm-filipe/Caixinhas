
using Caixinhas.IoC;
using Microsoft.AspNetCore.Builder;

namespace Caixinhas.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi();
        //builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddInfrastructureAPI(builder.Configuration);
        builder.Services.AddInfrastructureSwagger();
        builder.Services.AddInfrastructureJWT(builder.Configuration);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchMVC API v1");
                c.RoutePrefix = string.Empty; // Acessar diretamente em http://localhost:5000
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
