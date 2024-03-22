using BurgerApp.BLL.ViewModels.Base;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.ViewModels.Other_Models
{
    public class SauceDTO:BaseDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public ICollection<OrderDetailDTO> Details { get; set; }
    }
}
