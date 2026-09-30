using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.DAL.Repositories;
using KFCMenuAPI.Model;

namespace KFCMenuAPI.BLL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IngredientDTO>> GetAllAsync()
        {
            var ingredients = await _repository.GetAllAsync();

            return ingredients.Select(i => new IngredientDTO
            {
                IngredientId = i.IngredientId,
                Name = i.Name
            }).ToList();
        }

        public async Task<IngredientDTO> GetByIdAsync(int id)
        {
            var ingredient = await _repository.GetByIdAsync(id);

            if (ingredient == null)
            {
                return null;
            }

            return new IngredientDTO
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name
            };
        }

        public async Task AddAsync(IngredientDTO ingredientDTO)
        {
            var ingredient = new Ingredient
            {
                Name = ingredientDTO.Name
            };

            await _repository.AddAsync(ingredient);
        }

        public async Task UpdateAsync(IngredientDTO ingredientDTO)
        {
            var ingredient = new Ingredient
            {
                IngredientId = ingredientDTO.IngredientId,
                Name = ingredientDTO.Name
            };

            await _repository.UpdateAsync(ingredient);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}