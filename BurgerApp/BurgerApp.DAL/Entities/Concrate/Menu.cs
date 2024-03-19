using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int CipsId { get; set; }
        public Cips Cips { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public double MenuPrice()
        {
            return this.Burger.Price + this.Drink.Price + this.Cips.Price;
        }
    }
}
