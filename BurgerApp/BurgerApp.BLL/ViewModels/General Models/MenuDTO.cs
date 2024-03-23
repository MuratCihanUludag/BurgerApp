using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.ViewModels.General_Models
{
    public class MenuDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int BurgerId { get; set; }
        public virtual Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public virtual Drink Drink { get; set; }
        public int CipsId { get; set; }
        public virtual Cips Cips { get; set; }
        public double MenuPrice()
        {
            if (this.Burger.Price != null && this.Drink.Price != null && this.Cips.Price != null)
                return this.Burger.Price + (this.Drink.Price - 10) + (this.Cips.Price - 15);
            return 0;
        }
    }
}
