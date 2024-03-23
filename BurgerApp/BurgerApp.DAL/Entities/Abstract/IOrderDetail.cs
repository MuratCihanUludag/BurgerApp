using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.DAL.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.PL.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerApp.DAL.Entities.Abstract
{
    public interface IOrderDetail : IBaseEntity
    {
        string UserId { get; set; }
        BurgerAppUser User { get; set; }
        int BurgerId { get; set; }
        Burger Burger { get; set; }
        int DrinkId { get; set; }
        Drink Drink { get; set; }
        int CipsId { get; set; }
        Cips Cips { get; set; }
        int Count { get; set; }
        ICollection<Sauce> Sauces { get; set; }
        ICollection<ExtraMaterial> ExtraMetarials { get; set; }
        bool IsSell { get; set; }

        double OrderDetailTotalPrice();
    }
}
