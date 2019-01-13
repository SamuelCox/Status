using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateController(IUpdateService updateService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _updateService = updateService;
            _userManager = userManager;
            _mapper = mapper;
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
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            update.Creator = _mapper.Map<User>(currentUser);
            _updateService.CreateUpdate(update);
            return Json(true);
        }
    }
}