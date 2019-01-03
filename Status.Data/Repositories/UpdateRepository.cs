using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Status.Data.Entities;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Data.Repositories
{
    public class UpdateRepository : BaseRepository<Update>, IUpdateRepository
    {
        private IStatusContext _statusContext;
        private readonly IMapper _mapper;

        public UpdateRepository(IStatusContext statusContext, IMapper mapper) : base(statusContext)
        {
            _statusContext = statusContext;
            _mapper = mapper;
        }

        public List<DomainModel.Models.Update> GetUpdates(PagedRequest pagedRequest)
        {
            var entities = GetAll().Skip(pagedRequest.PageNumber * pagedRequest.PageSize).Take(pagedRequest.PageSize).ToList();
            return _mapper.Map<List<DomainModel.Models.Update>>(entities);
        }

        public async Task AddUpdate(DomainModel.Models.Update update)
        {
            var entity = _mapper.Map<Update>(update);
            await Add(entity);
        }
    }
}
