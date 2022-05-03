using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager mn = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var deger=mn.GetList();
            return View(deger);
        }
    }
}
