using Microsoft.AspNetCore.Mvc;
using Moralabs_NetCoreWebApp.Data;
using Moralabs_NetCoreWebApp.Data.Entities;
using Moralabs_NetCoreWebApp.DTO;
using Moralabs_NetCoreWebApp.Models;
using Moralabs_NetCoreWebApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Moralabs_NetCoreWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryRepository _categoryRepository; //Constructor injection
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<CategoryViewModel> vmList = _categoryRepository.GetAllCategories().Select(c => new CategoryViewModel()
            {
                ID = c.ID,
                Name = c.Name,
                Description = c.Description
            }).ToList();

            ViewBag.Categories = vmList;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);

            TempData["mesaj"] = "Başarıyla Silindi.";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var dto = _categoryRepository.GetByID(id);

            CategoryViewModel vm = new()
            {
                Name = dto.Name,
                ID = dto.ID,
                Description = dto.Description
            };

            return View(vm);
        }

        public IActionResult Save(CategoryViewModel model)
        {
            if (model.ID == 0)
            {
                CategoryDTO dto = new()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _categoryRepository.InsertCategory(dto);
            }
            else
            {
                CategoryDTO dto = new()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Description = model.Description
                };

                _categoryRepository.UpdateCategory(dto);
            }

            TempData["mesaj"] = "Başarıyla Kaydedildi.";
            return RedirectToAction("Index");
        }
    }
}
