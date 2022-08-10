using Microsoft.AspNetCore.Mvc;
using Moresand.Contracts.RequestModels.ImageProcessor;
using Moresand.Contracts.Services.ImageProcessor;

namespace Moresand.Api.Controllers;

[Route("api/image-processor")]
[ApiController]
public class ImageProcessorController : ControllerBase
{
    private readonly IImageProcessorService _imageProcessorService;

    public ImageProcessorController(IImageProcessorService imageProcessorService)
    {
        this._imageProcessorService = imageProcessorService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProcessImageRequestModel model)
    {
        //TODO: add centralized Exception management to pipeline
        try
        {
            var result = await _imageProcessorService.ProcessImage(model);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
