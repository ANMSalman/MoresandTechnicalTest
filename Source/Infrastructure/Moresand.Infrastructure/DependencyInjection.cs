using Microsoft.Extensions.DependencyInjection;
using Moresand.Contracts.Factories;
using Moresand.Contracts.Services.ImageProcessor;
using Moresand.Infrastructure.Factories;
using Moresand.Infrastructure.Services.ImageProcessor;

namespace Moresand.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddFactories()
            .AddImageProcessorFeatures()
            .AddImageEffectAppliers();

        return services;
    }
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IImageProcessorService, ImageProcessorService>();

        return services;
    }
    private static IServiceCollection AddFactories(this IServiceCollection services)
    {
        services.AddScoped<IImageProcessorFeatureServiceFactory, ImageProcessorFeatureServiceFactory>();
        services.AddScoped<IImageEffectApplierServiceFactory, ImageEffectApplierServiceFactory>();

        return services;
    }
    private static IServiceCollection AddImageProcessorFeatures(this IServiceCollection collection)
    {
        var services = typeof(ImageProcessorService).Assembly.GetTypes()
            .Where(x => typeof(IImageFeatureService).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
            .Select(x => x)
            .ToList();

        foreach (var service in services)
        {
            collection.AddScoped(typeof(IImageFeatureService), service);
        }

        return collection;
    }
    private static IServiceCollection AddImageEffectAppliers(this IServiceCollection collection)
    {
        var services = typeof(ImageProcessorService).Assembly.GetTypes()
            .Where(x => typeof(IImageEffectApplierService).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
            .Select(x => x)
            .ToList();

        foreach (var service in services)
        {
            collection.AddScoped(typeof(IImageEffectApplierService), service);
        }

        return collection;
    }

}
