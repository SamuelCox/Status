using System.Threading.Tasks;
using Status.DomainModel.Requests;
using Status.DomainModel.Response;

namespace Status.Business.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Register(RegisterRequest registerReq);

        Task<LoginResult> Login(LoginRequest loginReq);
    }
}
