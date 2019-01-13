using System.Linq;
using System.Threading.Tasks;
using Status.DomainModel.Requests;

namespace Status.DomainModel.Repositories
{
    public interface IUpdateRepository
    {
        IQueryable<DomainModel.Models.Update> GetUpdates();
        Task AddUpdate(DomainModel.Models.Update update);
    }
}
