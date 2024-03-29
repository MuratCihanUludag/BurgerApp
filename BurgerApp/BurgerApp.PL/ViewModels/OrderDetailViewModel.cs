using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.PL.Areas.Identity.Data;

namespace BurgerApp.PL.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; } 
        public string? UserId { get; set; }
        public BurgerAppUser? User { get; set; }
        public int BurgerId { get; set; }
        public Burger? Burger { get; set; }
        public int DrinkId { get; set; }
        public Drink? Drink { get; set; }
        public int CipsId { get; set; }
        public Cips? Cips { get; set; }
        public int Count { get; set; }
        public ICollection<Sauce>? Sauces { get; set; }
        public ICollection<ExtraMaterial>? ExtraMetarials { get; set; }
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
