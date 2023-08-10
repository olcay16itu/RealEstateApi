using RealEstateApi.Models.DTOs.CategoryDTOs;

namespace RealEstateApi.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<ResultCategoryDTO>> getAllResultsAsync();
        public void AddCategoryAsync(CreateCategoryDTO createCategoryDTO);
        public void DeleteCategory(int id);
        public void UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
        public Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
