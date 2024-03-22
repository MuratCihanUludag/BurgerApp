using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Comman;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Isim zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Aciklama zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Resim Zorunludur.")]
        public IFormFile Image { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Fiyat sifirdan buyuk olmalidir.")]
        public double Price { get; set; }
        public override string ToString()
        {
            return Name +" " +Description + Price.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}
