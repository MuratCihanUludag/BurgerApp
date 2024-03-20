using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class ExtraMaterialRepo : GenericRepo<ExtraMaterial>, IExtraMaterialRepo
    {
        public ExtraMaterialRepo()
        { }
        public ExtraMaterialRepo(BurgerAppContext context) : base(context)
        {

        }
    }

}
