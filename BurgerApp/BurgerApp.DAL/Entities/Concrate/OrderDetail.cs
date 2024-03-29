using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.PL.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate
{
    public class OrderDetail : BaseEntity, IOrderDetail
    {

        public string UserId { get; set; }
        public virtual BurgerAppUser User { get; set; }
        public int BurgerId { get; set; }
        public virtual Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public virtual Drink Drink { get; set; }
        public int CipsId { get; set; }
        public virtual Cips Cips { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Sauce> Sauces { get; set; }
        public virtual ICollection<ExtraMaterial> ExtraMetarials { get; set; }
        public bool IsSell { get; set; }
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
