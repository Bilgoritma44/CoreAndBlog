using CoreAndBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName="Teknoloji",
                categoryCount=10

            });  
            list.Add(new CategoryClass
            {
                categoryName="Spor",
                categoryCount=15

            });
             list.Add(new CategoryClass
            {
                categoryName="Bilim",
                categoryCount=20

            });



            return Json(new { JsonList = list });
        }
    }
}
