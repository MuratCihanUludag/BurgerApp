using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.PL.Areas.Identity.Data;

namespace BurgerApp.PL.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
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
