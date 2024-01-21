using CreateMyApp.Services;

namespace CreateMyApp
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatusRequestService, StatusRequestService>(); 

            return services;
        }
    }
}
