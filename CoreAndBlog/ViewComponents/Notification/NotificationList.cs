using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Notification
{
    public class NotificationList:ViewComponent
    {
        NotificationManager mn = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var deger = mn.GetList();
            return View(deger);
        }
    }
}
