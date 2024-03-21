using BurgerApp.BLL.ViewModels.General_Models;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
