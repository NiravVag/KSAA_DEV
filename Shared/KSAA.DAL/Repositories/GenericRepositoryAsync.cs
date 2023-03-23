using KSAA.Domain.Common;
using KSAA.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.DAL.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly ApplicationDBContext _contex;
        public GenericRepositoryAsync(ApplicationDBContext context)
        {
            _contex = context;
        }
        public IQueryable<T> GetAllQueryable()
        {
            return _contex.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _contex.AddAsync(entity).ConfigureAwait(false);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _contex.Remove(entity);
            await _contex.SaveChangesAsync();
        }


        public async Task DeleteManyAsync(List<T> entity)
        {
            _contex.RemoveRange(entity);
            await _contex.SaveChangesAsync();
        }

        public virtual async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return (await (_contex.Set<T>()
                .Where(expression).ToListAsync().ConfigureAwait(false))).AsQueryable();
        }

        public virtual async Task<T> FindById(long id)
        {
            return await _contex.Set<T>().FindAsync(id);

        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entity = await _contex.Set<T>().ToListAsync();
            return entity;
        }

        //public virtual async Task<List<T>> GetAllListAsync(string month, string year)
        //{
        //    var entity = await _contex.Set<T>().ToListAsync();
        //    return entity;
        //}

        public virtual async Task<IQueryable<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return (await _contex.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false)).AsQueryable();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _contex.Entry(entity).State = EntityState.Modified;
                await _contex.SaveChangesAsync();
            }
            return entity;
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression)
        {
            return _contex.Set<T>()
                           .Where(expression);
        }
    }
}
