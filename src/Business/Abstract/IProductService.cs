using DataAccess.Dtos.Product;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ProductResponseDto?> Insert(ProductInsertDto product);  
        Task<ProductResponseDto?> Update(ProductUpdateDto product);
    }
}
