using CoreAndBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writers);
            return Json(jsonWriter);
        }
        public IActionResult GetWriterId(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Sadık"
            },new WriterClass
            {
                Id=2,
                Name="Gülüstan"
            },new WriterClass
            {
                Id=3,
                Name="Birsel"
            },new WriterClass
            {
                Id=4,
                Name="Nursel"
            },new WriterClass
            {
                Id=5,
                Name="Kadir"
            },new WriterClass
            {
                Id=6,
                Name="Erkan"
            }
            
        };
           
    }
}
