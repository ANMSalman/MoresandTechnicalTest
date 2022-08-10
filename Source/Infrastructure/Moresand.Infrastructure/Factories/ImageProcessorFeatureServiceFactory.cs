using Microsoft.Extensions.DependencyInjection;
using Moresand.Contracts.Enums;
using Moresand.Contracts.Factories;
using Moresand.Contracts.Services.ImageProcessor;
using System.Collections.Immutable;

namespace Moresand.Infrastructure.Factories;
internal class ImageProcessorFeatureServiceFactory : IImageProcessorFeatureServiceFactory
{
    private readonly IReadOnlyDictionary<ImageProcessingFeature, IImageFeatureService> _services;

    public ImageProcessorFeatureServiceFactory(IServiceProvider serviceProvider)
    {
        // Opted using Anti-pattern instead of manually providing dependencies

        _services = serviceProvider
            .GetServices<IImageFeatureService>()
            .ToImmutableDictionary(x => x.Feature, x => x);
    }

    public IImageFeatureService GetFeatureService(ImageProcessingFeature feature)
    {
        _services.TryGetValue(feature, out var service);

        if (service is null)
            throw new InvalidOperationException(
                $"A Feature service for {typeof(ImageProcessingFeature).GetEnumName(feature)} not found");

        return service;
    }
}
