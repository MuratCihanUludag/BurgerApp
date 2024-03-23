using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate
{
    public class Menu : BaseImage, IMenu
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BurgerId { get; set; }
        public virtual Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public virtual Drink Drink { get; set; }
        public int CipsId { get; set; }
        public virtual Cips Cips { get; set; }
        public double MenuPrice()
        {
            if (this.Burger.Price != null && this.Drink.Price != null && this.Cips.Price != null)
                return this.Burger.Price + (this.Drink.Price % 75) + (this.Cips.Price % 85);
            return 0;
        }
    }
}
