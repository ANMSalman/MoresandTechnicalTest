using Moresand.Contracts.Enums;

namespace Moresand.Contracts.RequestModels.ImageProcessor;
public class ProcessImageRequestModel
{
    public string Base64Image { get; init; }        // Use Binary if memory is a concern
    public List<ApplyingFeature> ApplyingFeatures { get; init; }

    public class ApplyingFeature
    {
        public ImageProcessingFeature Feature { get; init; }
        public string Value { get; init; }
    }
}
