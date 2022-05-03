using ClosedXML.Excel;
using CoreAndBlog.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            using(var workBook=new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRow = 2;

                foreach (var x in GetBlogList())
                {
                    worksheet.Cell(BlogRow,1).Value = x.Id;
                    worksheet.Cell(BlogRow,2).Value = x.BlogName;
                    BlogRow++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xlsx");
                }

            }
            
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="C# Proglamlama Temelleri"},
                new BlogModel{Id=2,BlogName="Sql Server ile Veritabanı Dersi"},
                new BlogModel{Id=3,BlogName="Alışveriş Sepeti Mobil Uygulama"}
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult BlogListDynamicExcel()
        {
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRow = 2;

                foreach (var x in BlogTitleList())
                {
                    worksheet.Cell(BlogRow, 1).Value = x.Id;
                    worksheet.Cell(BlogRow, 2).Value = x.BlogName;
                    BlogRow++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xlsx");
                }

            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    Id=x.BlogId,
                    BlogName=x.BlogTitle
                }).ToList();
  
            }
            return bm;
        }
        public IActionResult DynamicExcel()
        {
            return View();
        }
    }
}
