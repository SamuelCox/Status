using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Status.Business.Auth;
using Status.Business.Update;
using Status.DomainModel.Models;
using Status.DomainModel.Requests;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        private readonly IAuthService _authService;

        public UpdateController(IUpdateService updateService, IAuthService authService)
        {
            _updateService = updateService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Get(PagedRequest request)
        {
            var updates = _updateService.GetUpdates(request);
            return Json(updates);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            update.Creator = await _authService.GetCurrentUser(HttpContext.User);
            _updateService.CreateUpdate(update);
            return Json(true);
        }
    }
}