
using BurgerApp.DAL.Comman;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Abstract.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.MenuClasses
{

    public class Drink : BaseImage, IDrink
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
