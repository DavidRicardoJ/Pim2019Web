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
      

        public IActionResult Relatorio()
        {
            return View();
        }
        public IActionResult SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now.Date;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            Abastecimento a = new Abastecimento();

            return View(a.ListaAbastecimento(minDate, maxDate));
        }
    }
}