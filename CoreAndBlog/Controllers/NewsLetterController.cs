using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager mn = new NewsLetterManager(new EfNewsLetterDal());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            mn.MailAdd(p);
            return PartialView();
        }
    }
}
