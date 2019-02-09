using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Status.Data.Entities;
using Status.DomainModel.Repositories;

namespace Status.Data.Repositories
{
    public class UpdateRepository : BaseRepository<Update>, IUpdateRepository
    {        
        private readonly IMapper _mapper;

        public UpdateRepository(IStatusContext statusContext, IMapper mapper) : base(statusContext)
        {
            _mapper = mapper;
        }

        public IQueryable<DomainModel.Models.Update> GetUpdates()
        {            
            var models = GetAll().Include(x => x.AspNetUser)
                .ProjectTo<DomainModel.Models.Update>(_mapper.ConfigurationProvider);
            return models;
        }

        public async Task AddUpdate(DomainModel.Models.Update update)
        {
            var entity = _mapper.Map<Update>(update);
            await Add(entity);
        }
    }
}
