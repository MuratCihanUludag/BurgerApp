﻿using BurgerApp.DAL.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
