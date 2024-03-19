using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.PL.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.ViewModels.General_Models
{
    public class OrderDTO:BaseDTO
    {
        public string UserId { get; set; }
        public BurgerAppUser User { get; set; }
        public ICollection<OrderDetailDTO> Details { get; set; }
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
