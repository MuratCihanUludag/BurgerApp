using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.PL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Repo.Abstract
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private BurgerAppContext _dbContext;
        private DbSet<T> _dbSet;
        public GenericRepo(BurgerAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            entity.DataStatu = Comman.DataStatus.Insert;
            entity.Created = DateTime.Now;
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.DataStatu = Comman.DataStatus.Delete;
            entity.Deleted = DateTime.Now;
            this.Update(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.DataStatu = entity.DataStatu != Comman.DataStatus.Delete ? Comman.DataStatus.Update : Comman.DataStatus.Delete;

            if (entity.DataStatu == Comman.DataStatus.Update)
                entity.Updated = DateTime.Now;

            _dbSet.Update(entity);
            _dbContext.SaveChanges();

        }
        public T GetById(int id)
        {
            return _dbSet.AsNoTracking().Single(e => e.Id == id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.AsNoTracking().Where(c => c.DataStatu != Comman.DataStatus.Delete).ToList();
        }

    }
}
