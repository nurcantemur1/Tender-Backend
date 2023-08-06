using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Business.Abstract;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private IProductService _productService;
        private IImageService _imageService;
        private IOptions<CloudinarySettings> _options;
        private Cloudinary _cloudinary;

        public PhotoController(IImageService imageService, IProductService productService, IOptions<CloudinarySettings> options)
        {
            
            _imageService = imageService;
            _productService = productService;
            _options = options;
            _cloudinary = new Cloudinary(new Account(_options.Value.CloudName, _options.Value.ApiKey, _options.Value.ApiSecret));
        }

        [HttpPost("addphoto")]
        public  IActionResult AddPhotoForProductt(int productId,IFormFile file)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {
                
                var upload = new ImageUploadResult();
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams { File = new FileDescription(file.Name, stream) };
                        upload = _cloudinary.Upload(uploadParams);
                    }
                }

                Image image = new Image();
                image.productId = productId;
                image.url = upload.Uri.ToString();
                image.publicId = upload.PublicId;
                image.isMain = true;
           
                var result =  _imageService.Add(image);
                if (result.Success)
                {
                    return Ok(result);
                }
                
            }

            return BadRequest("bulunamadı");
        }

        [HttpGet("getphoto")]
        public ActionResult photo(int productId)
        {
           return Ok(_imageService.GetAllbyProduct(productId));
        }
        
        [HttpPost("addphotos")]
        public IActionResult AddPhotoForProduct(int productId, [FromForm] PhotoForCreationDto photoForCreationDto)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {
                var file = photoForCreationDto.File;

                var uploadResult = new ImageUploadResult();
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name, stream)
                        };

                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }
                photoForCreationDto.Url = uploadResult.Uri.ToString();
                photoForCreationDto.PublicId = uploadResult.PublicId; 
                
                Image image = new Image();
                image.productId = productId;
                image.url = uploadResult.Uri.ToString();
                image.publicId = uploadResult.PublicId;
                image.isMain = true;

                var result = _imageService.Add(image);
                if (result.Success)
                {
                    return Ok(result);
                }

            }

            return BadRequest("bulunamadı");
        }


        [HttpPost("addphotoadd")]
        public IActionResult AddPhotoForProducttt([FromForm] PhotoModel model)
        {
            var product = _productService.GetById(model.productId);
            if (product != null)
            {

                var upload = new ImageUploadResult();
                if (model.file.Length > 0)
                {
                    using (var stream = model.file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams { File = new FileDescription(model.file.Name, stream) };
                        upload = _cloudinary.Upload(uploadParams);
                    }
                }

                Image image = new Image();
                image.productId = model.productId;
                image.url = upload.Uri.ToString();
                image.publicId = upload.PublicId;
                image.isMain = true;

                var result = _imageService.Add(image);
                if (result.Success)
                {
                    return Ok(result);
                }

            }

            return BadRequest("bulunamadı");
        }

        [HttpPost("addphototo")]
        public IActionResult AddPhotoForProduc(int productId)
        {
            var file = HttpContext.Request.Form.Files[0];
            var product = _productService.GetById(productId);
            if (product != null && file != null)
            {

                var upload = new ImageUploadResult();
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams { File = new FileDescription(file.Name, stream) };
                        upload = _cloudinary.Upload(uploadParams);
                    }
                }

                Image image = new Image();
                image.productId = productId;
                image.url = upload.Uri.ToString();
                image.publicId = upload.PublicId;
                image.isMain = true;

                var result = _imageService.Add(image);
                if (result.Success)
                {
                    return Ok(result);
                }

            }

            return BadRequest("bulunamadı");
        }
    }
}
