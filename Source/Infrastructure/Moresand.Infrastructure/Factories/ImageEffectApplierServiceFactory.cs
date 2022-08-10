using Microsoft.Extensions.DependencyInjection;
using Moresand.Contracts.Enums;
using Moresand.Contracts.Factories;
using Moresand.Contracts.Services.ImageProcessor;
using System.Collections.Immutable;

namespace Moresand.Infrastructure.Factories;
internal class ImageEffectApplierServiceFactory : IImageEffectApplierServiceFactory
{
    private readonly IReadOnlyDictionary<ImageApplyingEffect, IImageEffectApplierService> _services;

    public ImageEffectApplierServiceFactory(IServiceProvider serviceProvider)
    {
        // Opted using Anti-pattern instead of manually providing dependencies

        _services = serviceProvider
            .GetServices<IImageEffectApplierService>()
            .ToImmutableDictionary(x => x.Effect, x => x);
    }

    public IImageEffectApplierService GetApplyingEffectService(ImageApplyingEffect effect)
    {
        _services.TryGetValue(effect, out var service);

        if (service is null)
            throw new InvalidOperationException(
                $"An Effect applier for {typeof(ImageApplyingEffect).GetEnumName(effect)} not found");

        return service;
    }
}
