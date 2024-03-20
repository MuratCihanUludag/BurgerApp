using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Abstract.Base
{
    public interface IBaseImage : IBaseEntity
    {
        public byte[] Image { get; set; }
    }
}
