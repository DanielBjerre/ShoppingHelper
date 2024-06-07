using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions.IServiceCollectionExtensions;
public static class RegisterValidatedOptionsExtension
{
    public static IServiceCollection RegisterValidatedOptions<T>(this IServiceCollection services, string section) where T : class
    {
        services
            .AddOptions<T>()
            .BindConfiguration(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}