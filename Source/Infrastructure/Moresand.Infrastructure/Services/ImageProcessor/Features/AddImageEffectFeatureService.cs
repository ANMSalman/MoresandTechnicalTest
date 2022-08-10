using Moresand.Contracts.Enums;
using Moresand.Contracts.Factories;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Infrastructure.Services.ImageProcessor.Features;
internal class AddImageEffectFeatureService : IImageFeatureService
{
    private readonly IImageEffectApplierServiceFactory _effectsApplierFactory;

    public AddImageEffectFeatureService(IImageEffectApplierServiceFactory effectsApplierFactory)
    {
        _effectsApplierFactory = effectsApplierFactory;
    }

    public string ExpectedValueInfo => "Should provide valid effect types in a comma separated string. Ex: 1,2,3";
    public ImageProcessingFeature Feature => ImageProcessingFeature.AddEffects;
    public async Task<string> Apply(string image, string applyingValue)
    {
        if (!IsValid(applyingValue))
            throw new InvalidDataException(ExpectedValueInfo);

        var effectKeys = applyingValue.Split(",").Select(x => (ImageApplyingEffect)int.Parse(x.Trim())).ToList();

        foreach (var effectKey in effectKeys)
        {
            var effect = _effectsApplierFactory.GetApplyingEffectService(effectKey);

            image = await effect.Apply(image);
        }

        return await Task.FromResult(image + "Effects added. ");
    }

    public bool IsValid(string applyingValue)
    {
        // TODO: perform validation here
        return true;
    }
}
