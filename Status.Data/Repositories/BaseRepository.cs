using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Status.DomainModel.Repositories;

namespace Status.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IStatusContext _statusContext;

        public BaseRepository(IStatusContext statusContext)
        {
            _statusContext = statusContext;
        }

        public DbSet<T> GetAll()
        {
            return _statusContext.Set<T>();
        }

        public T GetById(params object[] ids)
        {
            return _statusContext.Set<T>().Find(ids);
        }

        public async Task<int> Update(T entity)
        {
            _statusContext.Set<T>().Update(entity);
            return await _statusContext.SaveChangesAsync();
        }

        public async Task<int> Remove(T entity)
        {
            _statusContext.Set<T>().Remove(entity);
            return await _statusContext.SaveChangesAsync();
        }
       
    }
}
