using System;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using RealEstate_API.Configurations;
using RealEstate_API.DAL;
using RealEstate_API.Repositories.CategoryRepository;
using RealEstate_API.Repositories.ContactRepository;
using RealEstate_API.Repositories.EmployeRepository;
using RealEstate_API.Repositories.SettingRepository;
using RealEstate_API.Services;
using RealEstate_API.Services.Interfaces;
using RealEstate_API.Validators.CategoryValidators;

namespace RealEstate_API
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddControllers()
               .AddFluentValidation(d => d.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(orign => true);
                    policy.WithOrigins("http://localhost:8080", "https://on-trend.netlify.app", "https://localhost:7172");
                });
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<DataContext>();
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IEmployeRepository, EmployeRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<ISettingRepository, SettingRepository>();
        }
	}
}

