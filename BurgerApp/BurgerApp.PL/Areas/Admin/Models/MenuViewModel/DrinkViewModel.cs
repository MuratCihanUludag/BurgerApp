using BurgerApp.DAL.Comman;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class DrinkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İçecek adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boyut seçimi zorunludur.")]
        public ProductSize Size { get; set; }

        public IFormFile? Image { get; set; }
    }
}
