using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Status.DomainModel.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> GetAll();

        T GetById(params object[] ids);

        Task<int> Update(T entity);

        Task<int> Remove(T entity);
        
    }
}
