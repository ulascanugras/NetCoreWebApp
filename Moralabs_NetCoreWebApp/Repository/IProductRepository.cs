using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;

namespace Moralabs_NetCoreWebApp.Repository
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetByID(int id);
        int InsertProduct(ProductDTO dto);
        int UpdateProduct(ProductDTO dto);
        int DeleteProduct(int id);
    }
}
