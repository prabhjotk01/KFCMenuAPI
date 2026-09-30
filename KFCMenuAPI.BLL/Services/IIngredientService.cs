using KFCMenuAPI.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.BLL.Services
{
    public interface IIngredientService
    {
        Task<List<IngredientDTO>> GetAllAsync();
        Task<IngredientDTO> GetByIdAsync(int id);
        Task AddAsync(IngredientDTO ingredientDTO);
        Task UpdateAsync(IngredientDTO ingredientDTO);
        Task DeleteAsync(int id);
    }
}
