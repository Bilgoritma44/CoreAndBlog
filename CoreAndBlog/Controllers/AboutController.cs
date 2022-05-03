using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            var deger = ab.GetList();
            return View(deger);
        }
        public PartialViewResult SocialMedia()
        {
            return PartialView();
        }
    }
}
