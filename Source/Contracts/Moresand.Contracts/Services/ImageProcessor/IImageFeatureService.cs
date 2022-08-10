using Moresand.Contracts.Enums;

namespace Moresand.Contracts.Services.ImageProcessor;
public interface IImageFeatureService
{
    string ExpectedValueInfo { get; }
    ImageProcessingFeature Feature { get; }

    // Return type and image parameter should be of type System.Drawing.Image. String was chosen just for demonstration
    Task<string> Apply(string image, string applyingValue);
    bool IsValid(string applyingValue);
}
