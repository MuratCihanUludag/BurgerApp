using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Repo.Concrete
{

    public class BurgerRepo : GenericRepo<Burger>, IBurgerRepo
    {
        public BurgerRepo()
        { }
        public BurgerRepo(BurgerAppContext dbContext) : base(dbContext)
        {

        }
    }

}
