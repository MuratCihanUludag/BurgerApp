using BurgerApp.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.OtherClasses
{
    public class ExtraMetarial : BaseImage
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<OrderDetail> Details { get; set; }

    }
}
