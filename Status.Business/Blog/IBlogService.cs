using System.Collections.Generic;
using System.Threading.Tasks;
using Status.DomainModel.Models;
using Status.DomainModel.Requests;

namespace Status.Business.Blog
{
    public interface IBlogService
    {
        List<BlogPreview> GetBlogPreviews(PagedRequest pagedRequest);
        DomainModel.Models.Blog GetBlog(int id);
        Task CreateBlog(DomainModel.Models.Blog blog);
    }
}
