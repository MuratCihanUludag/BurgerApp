using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Abstract.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.OtherClasses
{
    public class ExtraMaterial : BaseImage, IExtraMetarial

    {
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; }

    }
}
