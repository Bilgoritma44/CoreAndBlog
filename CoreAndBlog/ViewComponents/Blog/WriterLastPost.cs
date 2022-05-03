using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Blog
{
    public class WriterLastPost:ViewComponent
    {
        BlogManager mn = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var deger = mn.GetListWriter(1);
            return View(deger);
        }
    }
}
