using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.DAL.Comman;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using System.Drawing;
using System.Globalization;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int BurgerId { get; set; }
        public Burger? Burger { get; set; }
        public int DrinkId { get; set; }
        public Drink? Drink { get; set; }
        public int CipsId { get; set; }
        public Cips? Cips { get; set; }

        public double MenuPrice()
        {
            if (this.Burger.Price != null && this.Drink.Price != null && this.Cips.Price != null)
                return this.Burger.Price + (this.Drink.Price - 10) + (this.Cips.Price - 15);
            return 0;

        }
    }


}
