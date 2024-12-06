using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiPruebas.Data;
namespace ApiPruebas
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<ApiPruebasContext>(options =>
			    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiPruebasContext") ?? throw new InvalidOperationException("Connection string 'ApiPruebasContext' not found.")));

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var origenesPermitidos = builder.Configuration.GetValue<string>("AllowedHosts")!.Split(",");
			builder.Services.AddCors(opciones =>
			{
				opciones.AddDefaultPolicy(politica =>
				{
					politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
				});
			});

			var app = builder.Build();

			//using (var scope = app.Services.CreateScope())
			//{
			//	var context = scope.ServiceProvider.GetService<ApiPruebasContext>();
			//	context.Database.Migrate();
			//}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseCors();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}