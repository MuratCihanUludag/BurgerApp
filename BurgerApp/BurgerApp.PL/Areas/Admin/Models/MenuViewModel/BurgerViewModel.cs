using BurgerApp.BLL.ViewModels.General_Models;
using System.ComponentModel.DataAnnotations;

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

    }
}
