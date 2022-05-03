using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Admin
{
    public class AdminNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
