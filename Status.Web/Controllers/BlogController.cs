﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Status.Business.Blog;
using Status.DomainModel.Models;
using Status.DomainModel.Requests;

namespace Status.Web.Controllers
{
    [Route("api/[controller]")]    
    [Authorize] 
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetBlog(int id)
        {
            return Json(_blogService.GetBlog(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody]Blog blog)
        {
            await _blogService.CreateBlog(blog);
            return Json(true);
        }
    }
}