using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Repo.Abstract;
using BurgerApp.PL.Data;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class OrderDetailRepo : GenericRepo<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo()
        { }
        public OrderDetailRepo(BurgerAppContext context) : base(context)
        {

        }

    }

}
