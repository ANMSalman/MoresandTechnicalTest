using Moresand.Contracts.Factories;
using Moresand.Contracts.RequestModels.ImageProcessor;
using Moresand.Contracts.ResponseModels.ImageProcessor;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor;
internal class ImageProcessorService : IImageProcessorService
{
    private readonly IImageProcessorFeatureServiceFactory _featureServiceFactory;

    public ImageProcessorService(IImageProcessorFeatureServiceFactory featureServiceFactory)
    {
        _featureServiceFactory = featureServiceFactory;
    }

    public async Task<ProcessImageResponseModel> ProcessImage(ProcessImageRequestModel model)
    {
        // TODO: perform model validations here or using FluentValidations

        var applyingFeatures = new List<IImageFeatureService>();

        model.ApplyingFeatures.ForEach(x =>
        {
            var service = _featureServiceFactory.GetFeatureService(x.Feature);

            if (!service.IsValid(x.Value))
                throw new InvalidDataException(service.ExpectedValueInfo);

            applyingFeatures.Add(service);
        });

        var image = "This is an Image. ";      // TODO: Should be of type System.Drawing.Image. String was chosen just for demonstration

        foreach (var feature in applyingFeatures)
        {
            image = await feature.Apply(image, model.ApplyingFeatures.First(x => x.Feature == feature.Feature).Value);
        }

        return new ProcessImageResponseModel()
        {
            Base64ProcessedImage = image
        };
    }
}
