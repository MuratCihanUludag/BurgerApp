using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.DAL.Entities.Abstract.Base;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IOrderDetail : IBaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int Count { get; set; }
        public ICollection<Sauce> Sauces { get; set; }
        public ICollection<ExtraMetarial> ExtraMetarials { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double OrderDetailTotalPrice();
    }
}
