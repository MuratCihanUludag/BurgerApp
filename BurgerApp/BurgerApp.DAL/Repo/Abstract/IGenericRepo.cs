using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Repo.Abstract
{
    public interface IGenericRepo<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        IList<T> GetAll();
        T GetById(int id);
    }
    public interface IBurgerManager : IGenericRepo<Burger>
    { 
    }
    public interface ICipsManager : IGenericRepo<Cips>
    {
    }
    public interface IDrinkManager : IGenericRepo<Drink>
    {
    }
    public interface IExtraMaterialManager : IGenericRepo<ExtraMaterial>
    {
    }
    public interface ISauceManager : IGenericRepo<Sauce>
    {
    }
    public interface IMenuManager : IGenericRepo<Menu>
    {
    }
    public interface IOrderDetailManager : IGenericRepo<OrderDetail>
    {
    }
    public interface IOrderManager : IGenericRepo<Order>
    {
    }

}
