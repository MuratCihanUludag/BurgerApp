
﻿using BurgerApp.DAL.Comman;
using BurgerApp.DAL.Entities.Abstract;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.MenuClasses
{
    public class Cips : BaseImage
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public ICollection<Menu> Menus { get; set; }




    }
}
