using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using UploadImage.Data.Context;
using UploadImage.Data.Modals;
using UploadImage.Data.Repositories;
using UploadImage.helpers;

namespace UploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IProductRepo _productRepo;

        public ImageController(IConfiguration config, IProductRepo productRepo)
        {
            this._config = config;
            this._productRepo = productRepo;
        }
        [HttpPost("{id:Guid}")]
        public ActionResult UploadProductImage(Guid id)
        {
            //validate the image file in request
            if (!Request.ContentType?.Contains("multipart/form-data") ?? true)
            {
                return BadRequest(UploadImagesErrors.NoMultiPartContent);
            }
            var filesInRequest = Request.Form.Files;
            if(!filesInRequest.Any())
            {
                return BadRequest(UploadImagesErrors.NoFilesExist);
            }
            var file=filesInRequest[0];
            var allowedExtensions = _config.GetSection("allowedExtensions").Get<string[]>();

            if (!allowedExtensions.Any(ext => file.FileName.EndsWith(ext, StringComparison.InvariantCultureIgnoreCase))){
                return BadRequest(UploadImagesErrors.NoAllowedExtensions);
            }
            if (file.Length > 3_000_000)
            {
                return BadRequest(UploadImagesErrors.LargeFileSize);
            }
            //get full path of file that will be saved in the project 
            string savedFileName;
            var fullFileToSavePath =Helper.GetFullFilePath(file, out savedFileName);
            //save the file in the full path
            Helper.SaveFileToDirectory(file, fullFileToSavePath);
            //save image file name as string in DB 
            _productRepo.FillProductImage(id, savedFileName);
            return Ok();
        }

    }
}
