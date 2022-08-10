using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features.Effects;
internal class SunshineEffectApplier : IImageEffectApplierService
{
    public ImageApplyingEffect Effect => ImageApplyingEffect.SunShine;
    public async Task<string> Apply(string image)
    {
        return await Task.FromResult(image + "Sun Shine Effect added. ");
    }
}
