using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Status.DomainModel.Requests;

namespace Status.DomainModel.Repositories
{
    public interface IUpdateRepository
    {
        List<DomainModel.Models.Update> GetUpdates(PagedRequest pagedRequest);
        Task AddUpdate(DomainModel.Models.Update update);
    }
}
