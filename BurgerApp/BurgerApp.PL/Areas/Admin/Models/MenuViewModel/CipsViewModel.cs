using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Comman;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class CipsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ProductSize Size { get; set; }
        public IFormFile? Image { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
