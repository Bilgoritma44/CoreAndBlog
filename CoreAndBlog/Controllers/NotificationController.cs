using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        NotificationManager mn = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification()
        {
            var deger = mn.GetList();
            return View(deger);
        }
    }
}
