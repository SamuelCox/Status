using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPut]
        public IActionResult Register()
        {
            return null;
        }

        [HttpPost]
        public IActionResult Login()
        {
            return null;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return null;
        }
    }
}