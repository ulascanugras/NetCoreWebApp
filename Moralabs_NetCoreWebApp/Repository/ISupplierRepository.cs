using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;

namespace Moralabs_NetCoreWebApp.Repository
{
    public interface ISupplierRepository
    {
        List<SupplierDTO> GetAllSuppliers();
        SupplierDTO GetByID(int id);
        int InsertSupplier(SupplierDTO dto);
        int UpdateSupplier(SupplierDTO dto);
        int DeleteSupplier(int id);
    }
}
