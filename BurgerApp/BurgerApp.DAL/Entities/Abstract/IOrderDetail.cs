using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IOrderDetail : IBaseEntity
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
        public double OrderDetailTotalPrice();
    }
}
