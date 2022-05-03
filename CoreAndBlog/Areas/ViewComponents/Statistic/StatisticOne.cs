using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreAndBlog.Areas.ViewComponents.Statistic
{
    public class StatisticOne:ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();


            string api = "f17ac5bcdb34a47733e498368f5908ed";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document =XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
