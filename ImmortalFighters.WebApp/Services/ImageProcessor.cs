using ImmortalFighters.WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Services
{
    public interface IImageProcessor
    {
        Task<string> ConvertToBase64Async(IFormFile file);
    }

    public class ImageProcessor : IImageProcessor
    {
        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { "jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                }
            },
            { "jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }
                }
            }
        };

        public async Task<string> ConvertToBase64Async(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            var fileExtension = file.FileName.Split('.').Last();
            var signatures = _fileSignature[fileExtension];
            var headerBytes = bytes.Take(signatures.Max(m => m.Length));

            var isKnownSignature = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));

            if (!isKnownSignature) throw new ApiResponseException();

            var base64File = Convert.ToBase64String(memoryStream.ToArray());
            return $"data:image/{fileExtension};base64,{base64File}";
        }
    }
}
