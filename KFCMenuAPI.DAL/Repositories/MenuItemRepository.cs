using KFCMenuAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace KFCMenuAPI.DAL.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly KFCMenuDbContext _context;

        public MenuItemRepository(KFCMenuDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<MenuItem> GetWithIngredientsAsync(int id)
        {
            return await _context.MenuItems
                .Include(m => m.Ingredients)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}