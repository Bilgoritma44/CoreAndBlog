using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAndBlog.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            var deger = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            if(deger!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)

                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
    }
}
//HttpContext.Session.SetString("username", p.WriterMail);