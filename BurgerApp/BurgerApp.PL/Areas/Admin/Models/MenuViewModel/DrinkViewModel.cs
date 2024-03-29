using BurgerApp.DAL.Comman;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class DrinkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İçecek adı zorunludur.")]
        public string Name { get; set; }

        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Fiyat sifirdam buyuk olmalidir.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boyut seçimi zorunludur.")]
        public ProductSize Size { get; set; }

        [Required(ErrorMessage ="Resim zorunludur.")]
        public IFormFile Image { get; set; }

        public override string ToString()
        {
            return Name + " (" + Enum.GetName<ProductSize>(Size) + ") "+ Price.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
