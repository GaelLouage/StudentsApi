using StudentPointsApi.Repository.Classes;
using StudentPointsApi.Repository.Interfaces;

namespace StudentPointsApi.Bootstrapper
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJsonService, JsonService>();
        }
    }
}
