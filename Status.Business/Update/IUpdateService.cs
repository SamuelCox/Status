using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Status.DomainModel.Requests;
using Update = Status.DomainModel.Models.Update;

namespace Status.Business.Update
{
    public interface IUpdateService
    {
        List<DomainModel.Models.Update> GetUpdatesForUser(IdentityUser user,PagedRequest pagedRequest);
        List<DomainModel.Models.Update> GetUpdates(PagedRequest pagedRequest);
        bool CreateUpdate(DomainModel.Models.Update update);
    }
}
