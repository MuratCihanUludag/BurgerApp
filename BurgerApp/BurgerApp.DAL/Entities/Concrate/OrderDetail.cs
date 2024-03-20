using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate
{
    public class OrderDetail : BaseEntity, IOrderDetail
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int Count { get; set; }
        public ICollection<Sauce> Sauces { get; set; }
        public ICollection<ExtraMaterial> ExtraMetarials { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double OrderDetailTotalPrice()
        {
            double totalSaucePrice = 0;
            double totalExtraMetarialPrice = 0;
            foreach (var sauce in Sauces)
            {
                totalSaucePrice += sauce.Price;
            }
            foreach (var extraMetarial in ExtraMetarials)
            {
                totalExtraMetarialPrice += extraMetarial.Price;
            }

            return (this.Menu.MenuPrice() + totalSaucePrice + totalExtraMetarialPrice) * this.Count;
        }

    }
}
