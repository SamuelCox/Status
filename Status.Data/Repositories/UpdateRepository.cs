using System;
using System.Collections.Generic;
using System.Text;
using Status.Data.Entities;
using Status.DomainModel.Repositories;

namespace Status.Data.Repositories
{
    public class UpdateRepository : BaseRepository<Update>, IUpdateRepository
    {
        private IStatusContext _statusContext;

        public UpdateRepository(IStatusContext statusContext) : base(statusContext)
        {
            _statusContext = statusContext;
        }
    }
}
