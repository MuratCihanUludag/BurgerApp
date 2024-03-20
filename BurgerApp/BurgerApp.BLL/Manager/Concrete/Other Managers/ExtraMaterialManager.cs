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
    public class ExtraMaterialManager : GenericManager<ExtraMaterialDTO, ExtraMaterial>
    {
        public ExtraMaterialManager(BurgerAppContext context)
        {
            _repo = new ExtraMaterialRepo(context);
        }
    }
}
