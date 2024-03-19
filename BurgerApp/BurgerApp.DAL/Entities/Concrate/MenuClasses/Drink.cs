
﻿using BurgerApp.DAL.Comman;
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
<<<<<<< HEAD
    public class Drink : BaseImage, IDrink
=======

    public class Drink : BaseImage
>>>>>>> c2f32e47f727f5a400a8faeafa35b234d5c90b48
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public ICollection<Menu> Menus { get; set; }
<<<<<<< HEAD
=======




>>>>>>> c2f32e47f727f5a400a8faeafa35b234d5c90b48
    }
}
