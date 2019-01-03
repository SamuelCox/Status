using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Status.Business.Update;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Business
{
    public class UpdateService : IUpdateService
    {
        private IUpdateRepository _updateRepository;

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
            return _updateRepository.GetUpdates(pagedRequest);
        }

        public bool CreateUpdate(DomainModel.Models.Update update)
        {
            _updateRepository.AddUpdate(update);
            return true;
        }
    }
}
