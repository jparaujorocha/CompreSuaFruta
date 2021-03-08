using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompreSuaFruta.Api.Models;
using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Model.Models;
using Newtonsoft.Json;

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
                ViewData["Mensagem"] = TempData["Mensagem"];
                List<ProdutoCarrinho> itensCarrinho = new List<ProdutoCarrinho>();

                if (TempData["itensCarrinho"] != null)
                {
                    itensCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>((string)TempData["itensCarrinho"]);
                }

                if (itensCarrinho != null && itensCarrinho.Count > 0)
                {
                    ViewData["itensCarrinho"] = itensCarrinho;
                    ViewData["numeroItens"] = itensCarrinho.Count();
                }
                else
                {
                    ViewData["itensCarrinho"] = new List<ProdutoCarrinho>();
                    ViewData["numeroItens"] = 0;
                }

                return View(_produtoBll.BuscarProdutos());

            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Carrinho");
            }
        }
    }
}
