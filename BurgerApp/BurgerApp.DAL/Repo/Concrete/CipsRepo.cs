using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class CipsRepo : GenericRepo<Cips>, ICipsRepo
    {
        public CipsRepo()
        {

        }
        public CipsRepo(BurgerAppContext context) : base(context)
        {

        }
    }

}
