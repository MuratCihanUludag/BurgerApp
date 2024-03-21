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

}
