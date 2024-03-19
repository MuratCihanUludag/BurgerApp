using BurgerApp.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Entities.Concrate.OtherClasses
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public byte[] ImageArry { get; set; }
    }
}
