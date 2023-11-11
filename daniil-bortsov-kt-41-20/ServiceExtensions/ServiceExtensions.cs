using daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces;

namespace daniil_bortsov_kt_41_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
