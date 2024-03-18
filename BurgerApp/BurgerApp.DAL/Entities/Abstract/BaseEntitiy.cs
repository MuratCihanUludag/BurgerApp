﻿using BurgerApp.DAL.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract
{
    public abstract class BaseEntitiy : IBaseEntitiy
    {
        public int ID { get; set; }
        public DataStatus DataStatu { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
