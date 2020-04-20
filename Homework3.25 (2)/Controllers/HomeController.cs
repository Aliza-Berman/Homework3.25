using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework3._25__2_.Models;

namespace Homework3._25__2_.Controllers
{
    public class HomeController : Controller
    {
        BlogPostDb db = new BlogPostDb(@"Data Source=.\sqlexpress;Initial Catalog=BlogPostsHomework;Integrated Security=True");
        public IActionResult Index(int page)
        {
            return View();
        }
        public IActionResult Post(int id)
        {
            if (id == 0)
            {
                return Redirect("/"); //if no id was sent in, redirect to home page
            }
            PostViewModel vm = new PostViewModel();
            vm.Post = db.GetPost(id);
            vm.Comments = db.GetComments(id);
            if (Request.Cookies["commenter-name"] != null)
            {
                vm.CommenterName = Request.Cookies["commenter-name"];
            }

            return View(vm);
        }

    }
}
