using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SIENN.DbAccess;
using SIENN.DbAccess.Models;
using SIENN.Dto;

namespace SIENN.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : CodeEntity
    {
        protected readonly IUnitOfWork _uof;

        public Service(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public virtual TDto Get(Guid id)
        {
            return Mapper.Map<TDto>(_uof.GetRepository<TEntity>().Get(id));
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            return Mapper.Map<IEnumerable<TDto>>(_uof.GetRepository<TEntity>().GetAll().ToList());
        }

        public virtual IEnumerable<TDto> GetFiltred(Filter filter)
        {
            return Mapper.Map<IEnumerable<TDto>>(_uof.GetRepository<TEntity>().GetFiltered(filter).ToList());
        }

        public virtual IEnumerable<TDto> GetRange(int start, int count)
        {
            return Mapper.Map<IEnumerable<TDto>>(_uof.GetRepository<TEntity>().GetAll().Skip(start).Take(count));
        }

        public virtual TDto Add(TDto entity)
        {
            var newEntity = Mapper.Map<TDto>(_uof.GetRepository<TEntity>().Add(Mapper.Map<TEntity>(entity)));
            _uof.SaveChanges();
            return newEntity;
        }

        public virtual TDto Update(TDto entity)
        {
            var newEntity = Mapper.Map<TDto>(_uof.GetRepository<TEntity>().Update(Mapper.Map<TEntity>(entity)));
            _uof.SaveChanges();
            return newEntity;
        }

        public virtual void Remove(Guid id)
        {
            _uof.GetRepository<TEntity>().Remove(Mapper.Map<TEntity>(Get(id)));
            _uof.SaveChanges();
        }
    }
}
