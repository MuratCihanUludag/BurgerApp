using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class MenuRepo : GenericRepo<Menu>, IMenuRepo
    {
        public MenuRepo()
        {

        }
        public MenuRepo(BurgerAppContext context) : base(context)
        {

        }
    }

}
