using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Contracts.Factories;
public interface IImageEffectApplierServiceFactory
{
    IImageEffectApplierService GetApplyingEffectService(ImageApplyingEffect effect);
}
