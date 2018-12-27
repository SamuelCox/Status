using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Status.DomainModel.Models;
using Status.DomainModel.Requests;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UpdateController : Controller
    {
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