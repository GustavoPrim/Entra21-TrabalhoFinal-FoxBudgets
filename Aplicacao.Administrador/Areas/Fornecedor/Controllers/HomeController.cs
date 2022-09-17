﻿using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Areas.Fornecedor.Controllers
{
    [Area("Fornecedor")]
    [Route("fornecedor/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
