using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract.Base
{
    public class BaseImage : BaseEntity, IBaseImage
    {
        public byte[] Image { get; set; }
    }
}
