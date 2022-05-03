using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.ViewComponents.Statistic
{
    public class StatisticThree:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
