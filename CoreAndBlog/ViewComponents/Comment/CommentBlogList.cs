using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Comment
{
    public class CommentBlogList:ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke()
        {
            var deger = cm.GetList(4);
            return View(deger);
        }
    }
}
