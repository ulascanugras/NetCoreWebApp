using Moralabs_NetCoreWebApp.Data;
using Moralabs_NetCoreWebApp.Data.Entities;
using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Moralabs_NetCoreWebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        NorthwindDBContext _dBContext;

        public CategoryRepository(NorthwindDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int DeleteCategory(int id)
        {
            Category category = _dBContext.Categories.FirstOrDefault(x => x.CategoryID == id);

            _dBContext.Categories.Remove(category);
            return _dBContext.SaveChanges();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var categories = _dBContext.Categories.Select(x => new CategoryDTO()
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();

            return categories;
        }

        public CategoryDTO GetByID(int id)
        {
            Category category = _dBContext.Categories.FirstOrDefault(x => x.CategoryID == id);

            CategoryDTO dto1 = new()
            {
                ID = category.CategoryID,
                Name = category.CategoryName,
                Description = category.Description
            };

            return dto1;
        }

        public int InsertCategory(CategoryDTO dto)
        {
            Category category = new()
            {
                CategoryName = dto.Name,
                Description = dto.Description
            };

            _dBContext.Categories.Add(category);

            return _dBContext.SaveChanges();
        }

        public int UpdateCategory(CategoryDTO dto)
        {
            Category category = _dBContext.Categories.FirstOrDefault(x => x.CategoryID == dto.ID);

            category.CategoryName = dto.Name;
            category.Description = dto.Description;

            return _dBContext.SaveChanges();
        }
    }
}
