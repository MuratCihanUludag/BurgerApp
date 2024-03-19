using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract
{
    public class BaseImage : BaseEntity
    {
        public byte[] Image { get; set; }
    }
}
