using Moralabs_NetCoreWebApp.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Moralabs_NetCoreWebApp.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
