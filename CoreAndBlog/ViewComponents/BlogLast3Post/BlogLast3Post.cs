using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.BlogLast3Post
{
    public class BlogLast3Post:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var deger = bm.GetLast3Blog();
            return View(deger);
        }
    }
}
