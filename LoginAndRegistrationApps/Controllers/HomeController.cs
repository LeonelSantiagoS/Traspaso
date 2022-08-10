using LoginAndRegistrationApp.Models;
using LoginAndRegistrationApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegistrationApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IdentityModel db;
        public HomeController(ILogger<HomeController> logger, IdentityModel context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login obj)
        {
            try
            {
                if (db.login.Any(a => a.Rfc == obj.Rfc && a.Clave == obj.Clave))
                {
                    TempData["user"] = obj.Rfc;
                    return RedirectToAction("Index");
                }

                else {
                    ViewBag.error = "!!Please Enter valid login credentials.";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = "!!There is some error.";
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Login obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.login.Add(obj);
                    db.SaveChanges();
                    ViewBag.success = "Sign Up successfully.";
                    return View();
                }
                else
                {
                    ViewBag.error = "!!There is some error.";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = "!!There is some error.";
            }
            return View();
        }      
    }
}
