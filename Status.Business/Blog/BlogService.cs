using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Status.DomainModel.Models;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Business.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public List<BlogPreview> GetBlogPreviews(PagedRequest pagedRequest)
        {
            var blogs = GetAllBlogs(pagedRequest);
            var blogPreviews = blogs.Select(x =>
                new BlogPreview
                {
                    Id = x.Id,
                    PreviewText = x.Text.Substring(0, 100) + "...",
                    Title = "Test",
                    CreatedDate = x.CreatedDate,
                    Creator = x.Creator
                }
            );
            return blogPreviews.ToList();
        }

        public DomainModel.Models.Blog GetBlog(int id)
        {
            return _blogRepository.GetBlog(id);
        }

        public async Task CreateBlog(DomainModel.Models.Blog blog)
        {
            await _blogRepository.CreateBlog(blog);
        }

        private IQueryable<DomainModel.Models.Blog> GetAllBlogs(PagedRequest pagedRequest)
        {
            return _blogRepository.GetBlogs().Skip(pagedRequest.PageNumber * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize);
        }
    }
}
