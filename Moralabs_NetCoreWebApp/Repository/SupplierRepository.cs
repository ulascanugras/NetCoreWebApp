using Moralabs_NetCoreWebApp.Data;
using Moralabs_NetCoreWebApp.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Moralabs_NetCoreWebApp.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        NorthwindDBContext _dBContext;

        public SupplierRepository(NorthwindDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int DeleteSupplier(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            var suppliers = _dBContext.Suppliers.Select(x => new SupplierDTO()
            {
                SupplierID = x.SupplierID,
                CompanyName = x.CompanyName

            }).ToList();

            return suppliers;
        }

        public SupplierDTO GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public int InsertSupplier(SupplierDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateSupplier(SupplierDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
