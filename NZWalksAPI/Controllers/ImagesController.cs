using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload( [FromForm] ImageUploadRequestDto imageUploadRequest)
        {
            ValidateFileUpload(imageUploadRequest);
            if(ModelState.IsValid) 
            {
                var imageDomain = new Image
                {
                    File = imageUploadRequest.File,
                    FileName = imageUploadRequest.FileName,
                    FileDescription = imageUploadRequest.FileDescription,
                    FileExtension = Path.GetExtension(imageUploadRequest.File.FileName),
                    FileSizeInBytes = imageUploadRequest.File.Length
                };

                // Image repo to upload img
                imageDomain = await _imageRepository.Upload(imageDomain);
                var imageDto = new ImageDto
                {
                    Id = imageDomain.Id,
                    FileName = imageDomain.FileName,
                    FileDescription = imageDomain.FileDescription,
                    FilePath = imageDomain.FilePath,
                    FileExtension = imageDomain.FileExtension,
                    FileSizeInBytes = imageDomain.FileSizeInBytes
                };
                return Ok(imageDto);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequest) 
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            var g = Path.GetExtension(imageUploadRequest.File.FileName);
            if( allowedExtensions.Contains(Path.GetExtension(imageUploadRequest.File.FileName)) == false) 
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            long minFileLengthInMB = 10 * 1024 * 1024;
            if (imageUploadRequest.File.Length > minFileLengthInMB)
            {
                ModelState.AddModelError("file", "File size more than 10 MB, Please upload smaller size file.");
            }
        }
    }
}
