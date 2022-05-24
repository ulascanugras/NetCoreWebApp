using Moralabs_NetCoreWebApp.Data;
using Moralabs_NetCoreWebApp.Data.Entities;
using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Moralabs_NetCoreWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        NorthwindDBContext _dBContext;

        public ProductRepository(NorthwindDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int DeleteProduct(int id)
        {
            Product product = _dBContext.Products.FirstOrDefault(x => x.ProductID == id);

            _dBContext.Products.Remove(product);
            return _dBContext.SaveChanges();
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _dBContext.Products.Select(x => new ProductDTO()
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryID = x.CategoryID,
                SupplierID = x.SupplierID,
                CategoryName = x.Category.CategoryName,
                SupplierName = x.Supplier.CompanyName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock

            }).ToList();

            return products;
        }

        public ProductDTO GetByID(int id)
        {
            Product product = _dBContext.Products.FirstOrDefault(x => x.ProductID == id);

            ProductDTO dto1 = new()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                SupplierID = product.SupplierID,
                CategoryName = product.Category?.CategoryName,
                SupplierName = product.Supplier?.CompanyName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock

            };

            return dto1;
        }

        public int InsertProduct(ProductDTO dto)
        {
            Product product = new Product()
            {
                ProductName = dto.ProductName,
                CategoryID = dto.CategoryID,
                SupplierID = dto.SupplierID,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock
            };

            _dBContext.Products.Add(product);

            return _dBContext.SaveChanges();
        }

        public int UpdateProduct(ProductDTO dto)
        {
            Product product = _dBContext.Products.FirstOrDefault(x => x.ProductID == dto.ProductID);

            product.ProductName = dto.ProductName;
            product.CategoryID = dto.CategoryID;
            product.SupplierID = dto.SupplierID;
            product.UnitPrice = dto.UnitPrice;
            product.UnitsInStock = dto.UnitsInStock;

            return _dBContext.SaveChanges();
        }
    }
}
