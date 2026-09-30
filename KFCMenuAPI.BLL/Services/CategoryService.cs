using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.DAL.Repositories;
using KFCMenuAPI.Model;

namespace KFCMenuAPI.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
            {
                return null;
            }

            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task AddAsync(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Name = categoryDTO.Name
            };

            await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                CategoryId = categoryDTO.CategoryId,
                Name = categoryDTO.Name
            };

            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}