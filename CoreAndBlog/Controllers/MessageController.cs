using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
    public class MessageController : Controller
    {
        Message2Manager mn = new Message2Manager(new EfMessage2Dal());
        public IActionResult Inbox()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var deger = mn.GetInboxByWriter(writerId);
            return View(deger);
        }
        public IActionResult Detail(int id)
        {
            var deger = mn.GetById(id);
            return View(deger);
        }
    }
}
