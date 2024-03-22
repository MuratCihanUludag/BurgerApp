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
        public int Id { get; set; } 
        public int BurgerId { get; set; } 
        public BurgerDTO Burger { get; set; }
        public int DrinkId { get; set; }
        public DrinkDTO Drink { get; set; }
        public int CipsId { get; set; }
        public CipsDTO Cips { get; set; }
        public int Count { get; set; } 
        public ICollection<SauceDTO> Sauces { get; set; }
        public ICollection<ExtraMaterialDTO> ExtraMaterials { get; set; }
        public int OrderId { get; set; } 
        public double OrderDetailTotalPrice()
        {
            double totalSaucePrice = Sauces?.Sum(sauce => sauce.Price) ?? 0;
            double totalExtraMaterialPrice = ExtraMaterials?.Sum(extra => extra.Price) ?? 0;
            double menuPrice = (Burger?.Price ?? 0) + (Drink?.Price ?? 0) + (Cips?.Price ?? 0);
            return (menuPrice + totalSaucePrice + totalExtraMaterialPrice) * Count;
        }

    }
}
