using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogvs.Models;
using blogvs.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_vs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("NikoPolicy")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogManager _blogManager;
        public BlogController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        [HttpGet("getposts")]
        public IActionResult GetPosts()
        {
            var data = _blogManager.GetPosts();
            return Ok(data);
        }

        [HttpPost("savepost")]
        public IActionResult SavePost(Post newPost)
        {
            var data = _blogManager.SavePost(newPost);
            return Ok(data);
        }

        [HttpGet("getlatestposts")]
        public IActionResult GetLatestPosts()
        {
            var data = _blogManager.GetLatestPosts();
            return Ok(data);
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var data = _blogManager.GetCategories();
            return Ok(data);
        }


    }
}