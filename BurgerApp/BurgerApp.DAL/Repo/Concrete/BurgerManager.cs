using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Repo.Concrete
{

    public class BurgerManager : GenericRepo<Burger>,IBurgerManager
    {
    }

}
