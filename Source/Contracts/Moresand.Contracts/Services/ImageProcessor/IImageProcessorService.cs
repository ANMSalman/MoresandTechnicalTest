using Moresand.Contracts.RequestModels.ImageProcessor;
using Moresand.Contracts.ResponseModels.ImageProcessor;

namespace Moresand.Contracts.Services.ImageProcessor;
public interface IImageProcessorService
{
    Task<ProcessImageResponseModel> ProcessImage(ProcessImageRequestModel model);
}
