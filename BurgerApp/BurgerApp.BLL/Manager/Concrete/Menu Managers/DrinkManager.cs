using BurgerApp.BLL.Manager.Abstract;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Concrete.Menu_Manager
{
    public class DrinkManager:GenericManager<DrinkDTO,Drink>
    {
        public DrinkManager()
        {
            _repository = new DrinkRepository(new BurgerAppContext());
        }
    }
}
