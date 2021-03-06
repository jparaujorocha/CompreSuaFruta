using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompreSuaFruta.Api.Models;
using CompreSuaFruta.Business.Interface;

namespace CompreSuaFruta.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoBll _produtoBll;
        public HomeController(IProdutoBll produtoBll)
        {
            this._produtoBll = produtoBll;
        }
        public IActionResult Index()
        {
            try
            {
                return View(_produtoBll.BuscarProdutos());
            }
            catch (Exception ex)
            {
                return View("Erro: " + ex.Message);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
