using System.ComponentModel.DataAnnotations;

namespace Moralabs_NetCoreWebApp.Data.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
