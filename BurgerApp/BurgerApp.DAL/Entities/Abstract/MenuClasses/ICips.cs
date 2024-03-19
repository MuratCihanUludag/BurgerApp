using BurgerApp.DAL.Comman;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract.MenuClasses
{
    public interface ICips: IBaseImage
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
