using System;
namespace RealEstate_UI
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddRazorPages();
		}
	}
}

