using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager mn = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page=1)
        {
            var deger = mn.GetList().ToPagedList(page,3);
            return View(deger);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category p)
        {
            p.CategoryStatus = true;
            mn.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var remove = mn.GetById(id);
            mn.TDelete(remove);
            return RedirectToAction("Index");
        }
    }
}
