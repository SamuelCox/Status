using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Status.Data.Entities;
using Status.DomainModel.Repositories;

namespace Status.Data.Repositories
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly IMapper _mapper;

        public BlogRepository(IStatusContext statusContext, IMapper mapper) : base(statusContext)
        {
            _mapper = mapper;
        }

        public IQueryable<DomainModel.Models.Blog> GetBlogs()
        {
            var models = GetAll().Include(x => x.AspNetUser).ProjectTo<DomainModel.Models.Blog>(_mapper.ConfigurationProvider);
            return models;
        }

        public async Task CreateBlog(DomainModel.Models.Blog blog)
        {
            var entity = _mapper.Map<Blog>(blog);
            await Add(entity);
        }

        public DomainModel.Models.Blog GetBlog(int id)
        {
            var blog = GetById(id);
            return _mapper.Map<DomainModel.Models.Blog>(blog);
        }
    }
}
