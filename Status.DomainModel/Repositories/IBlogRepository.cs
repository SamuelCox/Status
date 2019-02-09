using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Status.DomainModel.Models;

namespace Status.DomainModel.Repositories
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetBlogs();
        Task CreateBlog(Blog blog);
        Blog GetBlog(int id);
    }
}
