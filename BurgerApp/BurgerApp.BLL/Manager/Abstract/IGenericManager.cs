using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Abstract
{
    public interface IGenericManager<TModel>
    {
        void Add(TModel obj);
        void Update(TModel obj);
        void Delete(TModel obj);
        void Remove(TModel obj);
        IList<TModel> GetAll();
        TModel GetById(int id);
    }
}
