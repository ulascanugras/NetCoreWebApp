using System.ComponentModel.DataAnnotations;

namespace Moralabs_NetCoreWebApp.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } //Açılan sayfada kullanıcı bir şeyler ekleyecek yapacaksa model kullanıyoruz.
    }
}
