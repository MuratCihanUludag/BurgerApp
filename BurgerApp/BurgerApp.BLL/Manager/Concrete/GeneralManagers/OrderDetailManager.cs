using BurgerApp.BLL.Manager.Abstract;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Repo.Concrete;
using BurgerApp.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Concrete.GeneralManager
{
    public class OrderDetailManager : GenericManager<OrderDetailDTO, OrderDetail>
    {
        public OrderDetailManager(BurgerAppContext context)
        {
            _repo = new OrderDetailRepo(context);
        }
    }
}
