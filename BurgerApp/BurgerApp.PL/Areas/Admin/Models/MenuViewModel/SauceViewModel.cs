using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.General_Models;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class SauceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
    }
}
WebHostBuilderNamedPipeExtensions göre oluştur IFormFile? propunu ekle