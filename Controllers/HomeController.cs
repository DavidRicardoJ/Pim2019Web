using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pim2019WEB.Models;

namespace Pim2019WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            Login l = new Login();
            if (l.ValidarLogin(login))
            {
                return RedirectToAction("Relatorio","Relatorio");
            }
            return View("LoginFail");
        }
    }
}