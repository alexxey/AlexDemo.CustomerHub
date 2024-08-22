
using AlexDemo.CustomerHub.Core.Application;
using AlexDemo.CustomerHub.DataAccess.EF;
using AlexDemo.CustomerHub.Infrastructure;
using Microsoft.OpenApi.Models;

namespace AlexDemo.CustomerHub.Presentation.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigureDataAccessServices(builder.Configuration);

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Customer hub and customer portfolio demo API", Version = "v1"});
            });

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlexDemo.CustomerHub.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            // app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.MapControllers();

            app.Run();
        }
    }
}
