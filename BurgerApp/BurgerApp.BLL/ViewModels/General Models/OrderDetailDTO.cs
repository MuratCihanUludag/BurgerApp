using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.BLL.ViewModels.Other_Models;

namespace BurgerApp.BLL.ViewModels.General_Models
{
    public class OrderDetailDTO:BaseDTO
    {
        public int MenuId { get; set; }
        public MenuDTO Menu { get; set; }
        public int Count { get; set; }
        public ICollection<SauceDTO> Sauces { get; set; }
        public ICollection<ExtraMaterialDTO> ExtraMetarials { get; set; }
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
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
