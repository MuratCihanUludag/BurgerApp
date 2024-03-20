using BurgerApp.BLL.Manager.Abstract;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Repo.Concrete;
using BurgerApp.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Concrete.Other_Managers
{
    public class SauceManager : GenericManager<SauceDTO, Sauce>
    {
        public SauceManager(BurgerAppContext context)
        {
            _repo = new SauceRepo(context);
        }
    }
}
