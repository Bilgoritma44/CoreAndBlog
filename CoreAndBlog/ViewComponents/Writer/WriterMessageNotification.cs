using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mn = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            int id;
            id = 2;

            var deger = mn.GetInboxByWriter(2);
            return View(deger);
        }
    }
}
