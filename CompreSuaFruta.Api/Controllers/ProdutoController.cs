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
            return View(_produtoBll.BuscarProdutos());
        }

        // GET: Produto/Details/5
        public IActionResult Detalhes(int? id)
        {
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
    }
}
