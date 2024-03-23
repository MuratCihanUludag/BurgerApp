using AutoMapper;
using BurgerApp.DAL.Entities.Abstract.Base;
using BurgerApp.DAL.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.BLL.Manager.Abstract
{
    public class GenericManager<TModel, TEntity> : IGenericManager<TModel> where TModel : class, new()
                                                                           where TEntity : BaseEntity, new()
    {
        private IMapper _mapper;
        protected IGenericRepo<TEntity> _repo;

        public GenericManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, TEntity>().ReverseMap();
            });
            _mapper = new Mapper(config);
        }

        public void Add(TModel obj)
        {
            TEntity entity = _mapper.Map<TEntity>(obj);
            _repo.Add(entity);
        }

        public void Delete(TModel obj)
        {
            TEntity entity = _mapper.Map<TEntity>(obj);
            _repo.Delete(entity);
        }
        public void Remove(TModel obj)
        {
            TEntity entity = _mapper.Map<TEntity>(obj);
            _repo.Remove(entity);

        }

        public void Update(TModel obj)
        {
            TEntity entity = _mapper.Map<TEntity>(obj);
            _repo.Update(entity);
        }
        public IList<TModel> GetAll()
        
        {
            ICollection<TEntity> entities = _repo.GetAll();
            List<TModel> models = new List<TModel>();
            foreach (var entity in entities)
            {
                TModel model = _mapper.Map<TModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public TModel GetById(int id)
        {
            TEntity entity = _repo.GetById(id);
            TModel model = _mapper.Map<TModel>(entity);
            return model;
        }

    }
}
