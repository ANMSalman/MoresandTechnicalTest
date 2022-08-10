using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features.Effects;
internal class MoonLightEffectApplier : IImageEffectApplierService
{
    public ImageApplyingEffect Effect => ImageApplyingEffect.MoonLight;
    public async Task<string> Apply(string image)
    {
        return await Task.FromResult(image + "Moon Light Effect added. ");
    }
}
