using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Models.DTOs.CategoryDTOs;
using RealEstateApi.Repositories.CategoryRepository;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.getAllResultsAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO categoryDTO) 
        {
            _categoryRepository.AddCategoryAsync(categoryDTO);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            _categoryRepository.UpdateCategoryAsync(updateCategoryDTO);
            return Ok("Kategori güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCategory(int id)
        {
            var value =  await _categoryRepository.GetCategory(id);
            return Ok(value);
        }
    }
}
