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
        [Required(ErrorMessage ="Bos Birakilamaz")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        [Required]
        public double Price { get; set; }
        public override string ToString()
        {
            return Name +" " +Description + Price.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}
