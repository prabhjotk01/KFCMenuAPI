using KFCMenuAPI.Model;

namespace KFCMenuAPI.DAL.Repositories
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();

        Task<MenuItem> GetByIdAsync(int id);

        Task<MenuItem> GetWithIngredientsAsync(int id);

        Task AddAsync(MenuItem menuItem);

        Task UpdateAsync(MenuItem menuItem);

        Task DeleteAsync(int id);
    }
}