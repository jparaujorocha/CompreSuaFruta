using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompreSuaFruta.Dal.Context.Contexts;
using CompreSuaFruta.Model.Models;
using CompreSuaFruta.Business.Interface;
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoBll _produtoBll;

        public ProdutoController(IProdutoBll produtoBll)
        {
            this._produtoBll = produtoBll;
        }


        // GET: Produto
        public IActionResult Index()
        {
            try
            {
                ViewData["Mensagem"] = TempData["Mensagem"];
                return View(_produtoBll.BuscarProdutos());
            }

            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Produto/Details/5
        public IActionResult Detalhes(int? id)
        {
            try
            {
                ViewData["Mensagem"] = TempData["Mensagem"];

                List<ProdutoCarrinho> itensCarrinho = new List<ProdutoCarrinho>();
                if (TempData["itensCarrinho"] != null)
                {
                    itensCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>((string)TempData["itensCarrinho"]);
                    if (itensCarrinho != null && itensCarrinho.Count > 0)
                    {
                        ViewData["itensCarrinho"] = itensCarrinho;
                        ViewData["numeroItens"] = itensCarrinho.Count();
                    }
                    else
                    {
                        ViewData["itensCarrinho"] = null;
                        ViewData["numeroItens"] = 0;
                    }
                }
                else
                {
                    ViewData["itensCarrinho"] = null;
                    ViewData["numeroItens"] = 0;
                }

                if (id == null)
                {
                    return NotFound();
                }

                var produto = _produtoBll.BuscarProdutoId((int)id);
                if (produto == null)
                {
                    return NotFound();
                }

                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
