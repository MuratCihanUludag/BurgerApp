using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class ExtraMaterialViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ekstra Malzeme ismi zorunludur.")]
        public string Name { get; set; }
        [Range(0.01, Double.PositiveInfinity, ErrorMessage = "Fiyat sıfır'dan buyuk olmalıdır.")]
        public double Price { get; set; }
        [Required (ErrorMessage ="Resim zorunludur.") ] 
        public IFormFile Image { get; set; }
    }
}
