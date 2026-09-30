using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.DAL.Repositories;
using KFCMenuAPI.Model;

namespace KFCMenuAPI.BLL.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;
        private readonly IIngredientRepository _ingredientRepository;

        public MenuItemService(
            IMenuItemRepository repository,
            IIngredientRepository ingredientRepository)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<List<MenuItemDTO>> GetAllAsync()
        {
            var menuItems = await _repository.GetAllAsync();

            return menuItems.Select(m => new MenuItemDTO
            {
                MenuItemId = m.MenuItemId,
                Name = m.Name,
                Price = m.Price,
                Description = m.Description,
                CategoryId = m.CategoryId
            }).ToList();
        }

        public async Task<MenuItemDTO> GetByIdAsync(int id)
        {
            var menuItem = await _repository.GetByIdAsync(id);

            if (menuItem == null)
            {
                return null;
            }

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Description = menuItem.Description,
                CategoryId = menuItem.CategoryId
            };
        }

        public async Task<MenuItemDTO> GetWithIngredientsAsync(int id)
        {
            var menuItem = await _repository.GetWithIngredientsAsync(id);

            if (menuItem == null)
            {
                return null;
            }

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Description = menuItem.Description,
                CategoryId = menuItem.CategoryId,
                Ingredients = menuItem.Ingredients.Select(i => new IngredientDTO
                {
                    IngredientId = i.IngredientId,
                    Name = i.Name
                }).ToList()
            };
        }

        public async Task AddAsync(MenuItemDTO menuItemDTO)
        {
            var menuItem = new MenuItem
            {
                Name = menuItemDTO.Name,
                Price = menuItemDTO.Price,
                Description = menuItemDTO.Description,
                CategoryId = menuItemDTO.CategoryId
            };

            if (menuItemDTO.IngredientIds != null)
            {
                foreach (var ingredientId in menuItemDTO.IngredientIds)
                {
                    var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);

                    if (ingredient != null)
                    {
                        menuItem.Ingredients.Add(ingredient);
                    }
                }
            }

            await _repository.AddAsync(menuItem);
        }

        public async Task UpdateAsync(MenuItemDTO menuItemDTO)
        {
            var menuItem = new MenuItem
            {
                MenuItemId = menuItemDTO.MenuItemId,
                Name = menuItemDTO.Name,
                Price = menuItemDTO.Price,
                Description = menuItemDTO.Description,
                CategoryId = menuItemDTO.CategoryId
            };

            await _repository.UpdateAsync(menuItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}