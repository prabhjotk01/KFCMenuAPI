using KFCMenuAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.DAL.Repositories
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllAsync();

        Task<Ingredient> GetByIdAsync(int id);

        Task AddAsync(Ingredient ingredient);

        Task UpdateAsync(Ingredient ingredient);

        Task DeleteAsync(int id);
    }
}
