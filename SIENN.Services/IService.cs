using SIENN.DbAccess.Models;
using SIENN.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services
{
    public interface IService<TEntity, TDto> where TEntity : CodeEntity
    {
        TDto Get(Guid id);
        IEnumerable<TDto> GetAll();
        IEnumerable<TDto> GetFiltred(Filter filter);
        IEnumerable<TDto> GetRange(int start, int count);

        TDto Add(TDto entity);
        TDto Update(TDto entity);
        void Remove(Guid id);
    }
}
