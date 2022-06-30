using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Data.Context;
using UploadImage.Data.Modals;
using UploadImage.Data.Repositories;
using UploadImage.DTOs;

namespace UploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }
        [HttpPost]
        public ActionResult Add(ProductWriteDTO productWriteDTO)
        {
            _productRepo.Add(productWriteDTO);
            return Ok();
        }
    }
}
