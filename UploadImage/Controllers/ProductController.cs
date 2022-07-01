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
        public ActionResult<ProductReadDTO> Add(ProductWriteDTO productWriteDTO)
        {
            var product = new Product { Id = Guid.NewGuid(), Name = productWriteDTO.Name };
            _productRepo.Add(product);
            var productReadDTO = new ProductReadDTO() { Id = product.Id, Name = product.Name };
            return productReadDTO;
        }
    }
}
