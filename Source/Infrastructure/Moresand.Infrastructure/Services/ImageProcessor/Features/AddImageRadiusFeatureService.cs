using Moresand.Contracts.Enums;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features;
internal class AddImageRadiusFeatureService : IImageFeatureService
{
    public string ExpectedValueInfo => "Should provide an integer value less than 100";
    public ImageProcessingFeature Feature => ImageProcessingFeature.AddRadius;
    public async Task<string> Apply(string image, string applyingValue)
    {
        if (!IsValid(applyingValue))
            throw new InvalidDataException(ExpectedValueInfo);

        return await Task.FromResult(image + "Radius applied. ");
    }

    public bool IsValid(string applyingValue)
    {
        // TODO: perform validation here
        return true;
    }
}
