using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class SauceRepo : GenericRepo<Sauce>, ISauceRepo
    {
        public SauceRepo()
        { }
        public SauceRepo(BurgerAppContext context) : base(context)
        { }
    }

}
