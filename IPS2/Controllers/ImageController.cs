using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessingServer.Classes;
using ImageProcessingServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessingServer.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost("image/watermark")]
        public async Task<ImageModel> CreateWaterMarkAsync([FromBody] ImageModel image)
        {
            ImageProcessor processor = new ImageProcessor();
            ImageModel imageModel = new ImageModel();
            imageModel = await processor.CreateWatermarkAsync(image);
            return imageModel;
        }
    }
}