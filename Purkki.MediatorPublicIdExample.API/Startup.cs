using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Purkki.MediatorPublicIdExample.API.Filters;
using Purkki.MediatorPublicIdExample.Application.Cars;
using Purkki.MediatorPublicIdExample.Persistence;

namespace Purkki.MediatorPublicIdExample.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(CarDto).Assembly);
			services.AddMediatR(typeof(CarDto).Assembly);
			services.AddDbContext<ExampleContext>(o => o.UseInMemoryDatabase(nameof(ExampleContext)));

			services.AddControllers(o => o.Filters.Add(typeof(CustomExceptionFilter)));
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
