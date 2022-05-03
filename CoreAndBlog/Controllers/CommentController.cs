using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult BlogAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult BlogAddComment(Comment p)
        {
            p.CommentStatus = true;
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.BlogId = writerId;
            cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult BlogCommentList(int id)
        {
            var deger = cm.GetList(id);
            return PartialView(deger);
        }
    }
}
