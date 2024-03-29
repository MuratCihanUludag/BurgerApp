using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.General_Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class SauceViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sos ismi zorunludur.")]
        public string Name { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Fiyat sifirdan buyuk olmalidir.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Resim zorunludur.")]
        public IFormFile Image { get; set; }
        public override string ToString()
        {
            return Name + " " + Price.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
