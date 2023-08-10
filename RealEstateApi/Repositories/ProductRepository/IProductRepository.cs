using RealEstateApi.Models.DTOs.ProductDTOs;

namespace RealEstateApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        public Task<List<ResultProductDTO>> GetAllAsync();
        public Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategory();
    }
}
