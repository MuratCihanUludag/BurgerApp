using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.BLL.ViewModels.Menu_Models;

namespace BurgerApp.BLL.ViewModels.General_Models
{
    public class OrderDetailDTO:BaseDTO
    {
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int CipsId { get; set; }
        public Cips Cips { get; set; }
        public int Count { get; set; }
        public ICollection<Sauce> Sauces { get; set; }
        public ICollection<ExtraMaterial> ExtraMetarials { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double OrderDetailTotalPrice()
        {
            double totalSaucePrice = Sauces.Sum(sauce => sauce.Price);
            double totalExtraMaterialPrice = ExtraMetarials.Sum(extra => extra.Price);
            double menuPrice = this.Burger.Price + (this.Drink.Price - 10) + (this.Cips.Price - 15);
            double totalPrice = (menuPrice + totalSaucePrice + totalExtraMaterialPrice) * Count;

            return totalPrice;
        }

    }
}
