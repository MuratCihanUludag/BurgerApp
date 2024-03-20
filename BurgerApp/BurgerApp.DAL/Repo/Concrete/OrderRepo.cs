using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo()
        { }
        public OrderRepo(BurgerAppContext context) : base(context)
        {

        }
    }

}
