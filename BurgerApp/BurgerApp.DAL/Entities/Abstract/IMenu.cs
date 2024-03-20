using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IMenu : IBaseImage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int CipsId { get; set; }
        public Cips Cips { get; set; }
        public double MenuPrice();
    }
}
