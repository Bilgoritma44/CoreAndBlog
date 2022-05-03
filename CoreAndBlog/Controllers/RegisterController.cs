using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class RegisterController : Controller
    {

        WriterManager mn = new WriterManager(new EfWriterDal());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidatior validatior = new WriterValidatior();
            ValidationResult result = validatior.Validate(p);
            if (result.IsValid)
            {
                p.WriterAbout = "Deneme Testi";
                p.WriterStatus = true;
                mn.TAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);

                }
            }
            return View();
        }
    }
}
