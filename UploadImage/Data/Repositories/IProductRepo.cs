using UploadImage.Data.Modals;
using UploadImage.DTOs;

namespace UploadImage.Data.Repositories
{
    public interface IProductRepo
    {
        public void Add(Product product);
        public void FillProductImage(Guid productId, string savedFileName);
    }
}
