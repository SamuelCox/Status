using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Status.Data.Entities;

namespace Status.Data
{
    public interface IStatusContext
    {
        DbSet<Update> Updates { get; set; }

        DbSet<Blog> Blogs { get; set; }

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
