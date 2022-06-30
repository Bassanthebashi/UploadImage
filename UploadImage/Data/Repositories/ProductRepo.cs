using UploadImage.Data.Context;
using UploadImage.Data.Modals;
using UploadImage.DTOs;

namespace UploadImage.Data.Repositories
{
    public class ProductRepo:IProductRepo
    {
        private readonly EcommerceContext _context;

        public ProductRepo(EcommerceContext context)
        {
            this._context = context;
        }
        public void Add(ProductWriteDTO productWriteDTO)
        {
            _context.Products.Add(new Product { Id = Guid.NewGuid(), Name = productWriteDTO.Name });
            _context.SaveChanges();
        }
        public void FillProductImage(Guid productId, string savedFileName)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            product.Image = savedFileName;
            _context.SaveChanges();
        }
    }
}
