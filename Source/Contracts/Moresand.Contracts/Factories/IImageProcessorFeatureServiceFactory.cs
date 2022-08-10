using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Contracts.Factories;
public interface IImageProcessorFeatureServiceFactory
{
    IImageFeatureService GetFeatureService(ImageProcessingFeature feature);
}
