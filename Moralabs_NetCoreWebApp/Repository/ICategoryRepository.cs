using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;

namespace Moralabs_NetCoreWebApp.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetByID(int id);
        int InsertCategory(CategoryDTO dto);
        int UpdateCategory(CategoryDTO dto);
        int DeleteCategory(int id);
    }
}
