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
    public class ProductController : Controller
    {
        public IProductRepository _productRepository; //Constructor injection
        public ICategoryRepository _categoryRepository; //Constructor injection
        public ISupplierRepository _supplierRepository; //Constructor injection

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> vmList = _productRepository.GetAllProducts().Select(p => new ProductViewModel()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                CategoryID = p.CategoryID,
                CategoryName = p.CategoryName,
                SupplierName = p.SupplierName,
                SupplierID = p.SupplierID,
                UnitsInStock = p.UnitsInStock

            }).ToList();

            ViewBag.Products = vmList;

            return View();
        }

        void CheckBoxDoldur()
        {
            List<CategoryViewModel> vmList = _categoryRepository.GetAllCategories().Select(c => new CategoryViewModel()
            {
                ID = c.ID,
                Name = c.Name,
                Description = c.Description

            }).ToList();

            ViewBag.Categories = vmList;

            List<SupplierViewModel> vmList1 = _supplierRepository.GetAllSuppliers().Select(s => new SupplierViewModel()
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName

            }).ToList();

            ViewBag.Suppliers = vmList1;
        }

        public IActionResult Create()
        {
            CheckBoxDoldur();

            return View();
        }

        public IActionResult Update(int id)
        {
            CheckBoxDoldur();

            var dto = _productRepository.GetByID(id);

            ProductViewModel vm = new()
            {
                ProductName = dto.ProductName,
                ProductID = dto.ProductID,
                CategoryID = dto.CategoryID,
                SupplierID = dto.SupplierID,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock
            };

            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);

            TempData["mesaj"] = "Başarıyla Silindi.";
            return RedirectToAction("Index");
        }

        public IActionResult Save(ProductViewModel model)
        {
            if (model.ProductID == 0)
            {
                ProductDTO dto = new()
                {
                    ProductName = model.ProductName,
                    CategoryID = model.CategoryID,
                    SupplierID = model.SupplierID,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock
                };
                
                _productRepository.InsertProduct(dto);
            }
            else
            {
                ProductDTO dto = new()
                {
                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    CategoryID = model.CategoryID,
                    SupplierID = model.SupplierID,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock
                };

                _productRepository.UpdateProduct(dto);
            }

            TempData["mesaj"] = "Başarıyla Kaydedildi.";
            return RedirectToAction("Index");
        }
    }
}
