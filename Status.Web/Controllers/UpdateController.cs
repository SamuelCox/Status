using Microsoft.AspNetCore.Authorization;
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
        private IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpGet]
        public IActionResult Get(PagedRequest request)
        {
            return Json(null);
        }

        [HttpPost]
        public IActionResult Post(Update update)
        {
            return Json(true);
        }
    }
}