using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Comman;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class CipsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Isim zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boyut zorunludur.")]
        public ProductSize Size { get; set; }
        [Required(ErrorMessage = "Resim zorunludur.")]
        public IFormFile Image { get; set; }

        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Fiyat sifirdam buyuk olmalidir.")]
        public double Price { get; set; }
        public override string ToString()
        {
            return Name + " (" + Enum.GetName<ProductSize>(Size) + ") "+ Price.ToString("C", CultureInfo.CurrentCulture);
        }
    }

}
