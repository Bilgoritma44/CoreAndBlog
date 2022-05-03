using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.ViewComponents.Writer
{
    public class WriterAboutDashboard:ViewComponent
    {
        WriterManager mn = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var deger = mn.GetWriterById(writerId);
            return View(deger);
        }
    }
}
