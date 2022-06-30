using UploadImage.DTOs;

namespace UploadImage.Data.Repositories
{
    public interface IProductRepo
    {
        public void Add(ProductWriteDTO productWriteDTO);
        public void FillProductImage(Guid productId, string savedFileName);
    }
}
