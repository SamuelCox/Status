using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Business.Update
{
    public class UpdateService : IUpdateService
    {
        private readonly IUpdateRepository _updateRepository;

        public UpdateService(IUpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public List<DomainModel.Models.Update> GetUpdatesForUser(IdentityUser user, PagedRequest pagedRequest)
        {
            throw new NotImplementedException();
        }

        public List<DomainModel.Models.Update> GetUpdates(PagedRequest pagedRequest)
        {
            var updates = _updateRepository.GetUpdates()
                .OrderByDescending(x => x.CreatedDate)
                .Skip(pagedRequest.PageNumber * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize).ToList();
            return updates;
        }

        public bool CreateUpdate(DomainModel.Models.Update update)
        {
            _updateRepository.AddUpdate(update);
            return true;
        }
    }
}
