using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.DAL.Entities.Abstract.OtherClasses;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Menu seçimi zorunludur.")]
        public int MenuId { get; set; }
        public MenuDTO Menu { get; set; }

        [Required(ErrorMessage = "Adet bilgisi zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Adet 1'den büyük olmalıdır.")]
        public int Count { get; set; }

        public ICollection<SauceDTO> Sauces { get; set; }
        public ICollection<ExtraMaterialDTO> ExtraMaterials { get; set; }

        [Required(ErrorMessage = "Sipariş ID'si zorunludur.")]
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
            foreach (var extraMetarial in ExtraMaterials)
            {
                totalExtraMetarialPrice += extraMetarial.Price;
            }

            return (this.Menu.MenuPrice() + totalSaucePrice + totalExtraMetarialPrice) * this.Count;
        }
    }
}
