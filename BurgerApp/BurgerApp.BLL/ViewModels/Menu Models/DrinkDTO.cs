using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Comman;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BurgerApp.BLL.ViewModels.Menu_Models
{
    public class DrinkDTO:BaseDTO
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public byte[] Image { get; set; }
    }
}
