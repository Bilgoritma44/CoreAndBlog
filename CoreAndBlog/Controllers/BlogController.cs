using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());


        public IActionResult Index()
        {
            var deger = bm.GetListCategory();
            return View(deger);
        }
        public ActionResult Detail(int id)
        {
            var deger = bm.GetListBlogId(id);
            return View(deger);
        }
        public IActionResult BlogListWriter()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var deger = bm.GetListCategoryWriter(writerId);
            return View(deger);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> category = (from x in cm.GetList()

                                             select new SelectListItem
                                             {
                                                 Text=x.CategoryName,
                                                 Value=x.CategoryId.ToString()

                                             }
            ).ToList();

            ViewBag.cate = category;

            return View();
        }
        [HttpPost]
        public ActionResult Add(Blog p)
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.BlogCreateDate = DateTime.Now;
            p.WriterId = writerId;
            bm.TAdd(p);
            return RedirectToAction("BlogListWriter");
        }
        public ActionResult Delete(int id)
        {
            var deger = bm.GetById(id);
            bm.TDelete(deger);
            return RedirectToAction("BlogListWriter");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text=x.CategoryName,
                                                 Value=x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.cate = category;
            var deger = bm.GetById(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Blog p)
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = writerId;
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Now;
            bm.TUpdate(p);
            return RedirectToAction("BlogListWriter");
        }
    }
}
