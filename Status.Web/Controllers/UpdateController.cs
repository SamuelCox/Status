using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        [HttpGet]
        public IActionResult Updates()
        {
            return Json(null);
        }

        [HttpPost]
        public IActionResult PostUpdate()
        {
            return Json(true);
        }
    }
}