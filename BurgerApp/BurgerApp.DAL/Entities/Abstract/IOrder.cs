using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.PL.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IOrder : IBaseEntity
    {
        public string UserId { get; set; }
        public BurgerAppUser User { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
        public double OrderPrice();
    }
}
