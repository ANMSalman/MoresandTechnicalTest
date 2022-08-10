using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features.Effects;
internal class BlackAndWhiteEffectApplierService : IImageEffectApplierService
{
    public ImageApplyingEffect Effect => ImageApplyingEffect.BlackAndWhite;
    public async Task<string> Apply(string image)
    {
        return await Task.FromResult(image + "Black and White Effect added. ");
    }
}
