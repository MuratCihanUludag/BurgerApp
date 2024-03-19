﻿using BurgerApp.BLL.Manager.Abstract;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Concrete.GeneralManager
{
    public class OrderManager : GenericManager<OrderDTO, Order>
    {
        public OrderManager()
        {
            _repository = new OrderRepository(new BurgerAppContext());
        }
    }
}
