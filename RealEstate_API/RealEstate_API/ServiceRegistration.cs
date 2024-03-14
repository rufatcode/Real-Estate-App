using System;
using RealEstate_API.DAL;
using RealEstate_API.Repositories.CategoryRepository;

namespace RealEstate_API
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services)
		{
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<DataContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
	}
}

