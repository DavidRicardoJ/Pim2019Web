using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pim2019WEB.Models;

namespace Pim2019WEB.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            Abastecimento a = new Abastecimento();               
            return View(a.ListaAbastecimento());
        }
    }
}