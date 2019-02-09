using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Status.Business.Blog;
using Status.DomainModel.Models;
using Status.DomainModel.Requests;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BlogPreviewController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogPreviewController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetPreviews(PagedRequest pagedRequest)
        {
            return Json(_blogService.GetBlogPreviews(pagedRequest));
        }
    }
}