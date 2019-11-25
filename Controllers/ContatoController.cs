using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pim2019WEB.Models;


namespace Pim2019WEB.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]     
        public IActionResult Index(Contato contato)
        {            
            if (contato.SalvarMensagemContato(contato))
            {
                return View("Obrigado");
            }
            else
            {
                return View("Falha");
            }
        }
        
      
        
    }
}