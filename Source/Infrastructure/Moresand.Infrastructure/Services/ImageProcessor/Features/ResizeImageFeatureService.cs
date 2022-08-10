using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features;
internal class ResizeImageFeatureService : IImageFeatureService
{
    public string ExpectedValueInfo => "Should provide an integer value greater than 100";
    public ImageProcessingFeature Feature => ImageProcessingFeature.Resize;
    public async Task<string> Apply(string image, string applyingValue)
    {
        if (!IsValid(applyingValue))
            throw new InvalidDataException(ExpectedValueInfo);

        return await Task.FromResult(image + "Image Resized. ");
    }

    public bool IsValid(string applyingValue)
    {
        // TODO: perform validation here
        return true;
    }
}
