using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Repo.Abstract;

namespace BurgerApp.DAL.Repo.Concrete
{
    public class OrderManager : GenericRepo<Order>,IOrderManager 
    {
    }

}
