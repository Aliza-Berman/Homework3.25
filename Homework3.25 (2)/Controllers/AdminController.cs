using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework3._25__2_.Models;

namespace Homework3._25__2_.Controllers
{
    public class AdminController : Controller
    {
        BlogPostDb db = new BlogPostDb(@"Data Source=.\sqlexpress;Initial Catalog=BlogPostsHomework;Integrated Security=True");
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitBlog(Post post)
        {
            post.DateSubmitted = DateTime.Now;
            db.AddPost(post);
            return Redirect($"/home/post?id={post.Id}");
        }
    }
}