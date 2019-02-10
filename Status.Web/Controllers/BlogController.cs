using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Status.Business.Auth;
using Status.Business.Blog;
using Status.DomainModel.Models;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]    
    [Authorize] 
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAuthService _authService;

        public BlogController(IBlogService blogService, IAuthService authService)
        {
            _blogService = blogService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetBlog(int id)
        {
            return Json(_blogService.GetBlog(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody]Blog blog)
        {
            blog.Creator = await _authService.GetCurrentUser(HttpContext.User);
            await _blogService.CreateBlog(blog);
            return Json(true);
        }
    }
}