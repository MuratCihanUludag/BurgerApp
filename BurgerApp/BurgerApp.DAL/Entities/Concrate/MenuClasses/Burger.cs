using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.MenuClasses
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<Menu> Menus { get; set; }   

    }
}
