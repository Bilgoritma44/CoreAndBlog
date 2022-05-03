using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    
    public class DashboardController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == writerId).Count();
            ViewBag.v3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
