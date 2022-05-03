using BusinessLayer.Concrete;
using CoreAndBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager mn = new WriterManager(new EfWriterDal());
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var username = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = username;
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult WriterEditProfile()
        {
            var writermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == writermail).Select(y => y.WriterId).FirstOrDefault();
            var deger = mn.GetById(writerId);
            return View(deger);

        }
        [HttpPost]
        public ActionResult WriterEditProfile(Writer p)
        {
            mn.TUpdate(p);
            return RedirectToAction("Index","Dashboard");

        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(AddProfileImage p)
        {
            Writer w = new Writer();

            if(p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterProfileImages/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterAbout = p.WriterAbout;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;

            mn.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }


    }
}
