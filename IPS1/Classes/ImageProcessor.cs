using ImageProcessingServer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingServer.Classes
{
    public class ImageProcessor
    {
        public async Task<ImageModel> CreateWatermarkAsync(ImageModel image)
        {
            var image64base = image.Image;
            byte[] bytes = Convert.FromBase64String(image64base);
            var stream = new MemoryStream(bytes);
            var watermarkedStream = new MemoryStream();
            var imageModel = new ImageModel();

            using (var img = Image.FromStream(stream))
            {
                using (var graphics = Graphics.FromImage(img))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold, GraphicsUnit.Point);
                    var color = Color.FromArgb(175, 255, 255, 255);
                    var brush = new SolidBrush(color);
                    var point = new Point(img.Width - ((img.Width / 2) + (img.Width / 3)), img.Height - (img.Height / 2));

                    graphics.DrawString("Classified Ads", font, brush, point);
                    img.Save(watermarkedStream, ImageFormat.Png);
                }
            }

            var imgByte = watermarkedStream.ToArray();
            imageModel.Image = Convert.ToBase64String(imgByte);
            
            return imageModel;
        }
    }
}
