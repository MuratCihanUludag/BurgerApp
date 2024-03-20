using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.PL.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate
{
    public class Order : BaseEntity, IOrder
    {
        public string UserId { get; set; }
        public BurgerAppUser User { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
        public double OrderPrice()
        {
            double price = 0;
            foreach (var item in Details)
            {
                price += item.OrderDetailTotalPrice();
            }
            return price;
        }

    }
}
