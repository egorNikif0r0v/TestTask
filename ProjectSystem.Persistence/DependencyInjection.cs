using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectSystem.Application.Interfaces;


namespace ProjectSystem.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CustomersDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICustomersDbContext>(provider =>
                provider.GetService<CustomersDbContext>());

            return services;
        }
    }
}
