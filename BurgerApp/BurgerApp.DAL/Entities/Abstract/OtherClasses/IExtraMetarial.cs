using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract.OtherClasses
{
    public interface IExtraMetarial
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
    }
}
