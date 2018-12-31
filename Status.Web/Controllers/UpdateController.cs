using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Status.DomainModel.Models;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UpdateController : Controller
    {
        private IUpdateRepository _updateRepository;

        public UpdateController(IUpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;
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