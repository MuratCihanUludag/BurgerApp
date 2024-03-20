﻿using BurgerApp.BLL.Manager.Abstract;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Repo.Concrete;
using BurgerApp.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Concrete.Menu_Manager
{
    public class CipsManager : GenericManager<CipsDTO, Cips>
    {
        public CipsManager()
        {
            _repo = new CipsRepo();
        }
    }
}
