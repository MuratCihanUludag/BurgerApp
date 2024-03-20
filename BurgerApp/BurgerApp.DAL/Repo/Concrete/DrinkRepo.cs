using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class DrinkRepo : GenericRepo<Drink>, IDrinkRepo
    {
        public DrinkRepo()
        {

        }
        public DrinkRepo(BurgerAppContext context) : base(context)
        {

        }
    }

}
