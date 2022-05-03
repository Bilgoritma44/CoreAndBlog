using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.ViewComponents.Statistic
{
    public class StatisticFour:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminId == 1).Select(y => y.Description).FirstOrDefault();
            return View();
        }
    }
}
