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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CompreSuaFruta.Api.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoVendaBll _produtoVendaBll;
        private readonly IProdutoBll _produtoBll;
        private readonly IVendaBll _vendaBll;
        private readonly IUsuarioBll _usuarioBll;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarrinhoController(IProdutoVendaBll produtoVendaBll, IProdutoBll produtoBll, IVendaBll vendaBll,
            IUsuarioBll usuarioBll, IHttpContextAccessor httpContextAccessor)
        {
            _produtoVendaBll = produtoVendaBll;
            _produtoBll = produtoBll;
            _vendaBll = vendaBll;
            _usuarioBll = usuarioBll;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Carrinho
        public async Task<IActionResult> Index()
        {
            List<ProdutoCarrinho> itensCarrinho = (List<ProdutoCarrinho>)ViewBag["itensCarrinho"];
            return View(itensCarrinho);
        }

        [Authorize]
        public IActionResult ConfirmarCompra()
        {
            try
            {
                List<ProdutoCarrinho> itensCarrinho = (List<ProdutoCarrinho>)ViewBag["itensCarrinho"];
                var dadosUsuario = _usuarioBll.BuscarUsuarioCpf(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
                if (dadosUsuario != null)
                {
                    if (itensCarrinho != null && itensCarrinho.Count > 0)
                    {
                        Venda dadosVenda = new Venda();
                        dadosVenda.Data = DateTime.Now;
                        dadosVenda.IdUsuario = dadosUsuario.Id;
                        dadosVenda.Status = 1;
                        dadosVenda.VendaAtiva = true;
                        dadosVenda.Valor = itensCarrinho.Sum(a => a.ValorTotal);
                        Venda dadosVendaEfetuada = _vendaBll.InserirVenda(dadosVenda);

                        foreach (var item in itensCarrinho)
                        {
                            ProdutoVenda dadosProdutoVenda = new ProdutoVenda();
                            dadosProdutoVenda.ValorTotal = item.ValorTotal;
                            dadosProdutoVenda.ValorUnitario = item.ValorUnitario;
                            dadosProdutoVenda.IdProduto = item.IdProduto;
                            dadosProdutoVenda.QuantidadeProduto = item.QuantidadeProduto;
                            _produtoVendaBll.InserirProdutoVenda(dadosProdutoVenda);
                        }
                    }
                    return RedirectToAction("Index", "Carrinho");
                }
                else
                {
                    ModelState.AddModelError("Message", "Necessário fazer cadastro e login.");
                    return RedirectToAction("Index", "Carrinho");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Carrinho");
            }
        }
        public IActionResult AdicionarItem(int idProduto)
        {
            var produto = _produtoBll.BuscarProdutoId(idProduto);
            if (produto != null)
            {
                ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                dadosItem.IdProduto = idProduto;
                dadosItem.Nome = produto.Nome;
                dadosItem.ValorUnitario = produto.Valor;

                //Verifica se existem itens no carrinho
                if (ViewBag["itensCarrinho"] != null)
                {
                    List<ProdutoCarrinho> itensCarrinho = (List<ProdutoCarrinho>)ViewBag["itensCarrinho"];
                    int numeroItens = (int)ViewBag["numeroItens"];

                    //Verificar se o item já está no carrinho
                    var itemJaAdicionado = itensCarrinho.Find(c => c.IdProduto == idProduto);

                    if (itemJaAdicionado == null)
                    {
                        dadosItem.QuantidadeProduto = 1;
                        dadosItem.ValorTotal = dadosItem.ValorUnitario;
                        itensCarrinho.Add(dadosItem);
                    }
                    else
                    {
                        itensCarrinho.Remove(itemJaAdicionado);
                        itemJaAdicionado.QuantidadeProduto = itemJaAdicionado.QuantidadeProduto++;
                        itemJaAdicionado.ValorTotal = itemJaAdicionado.ValorUnitario * itemJaAdicionado.QuantidadeProduto;
                        itensCarrinho.Add(itemJaAdicionado);
                        dadosItem.QuantidadeProduto = itemJaAdicionado.QuantidadeProduto;
                    }

                    produto.QuantidadeDisponivel = produto.QuantidadeDisponivel - dadosItem.QuantidadeProduto;
                    _produtoBll.AtualizarProduto(produto);

                    ModelState.AddModelError("Message", "Item Adicionado com sucesso.");
                    ViewBag["itensCarrinho"] = itensCarrinho;
                    ViewBag["numeroItens"] = itensCarrinho.Count;
                    return RedirectToAction("Index", "Carrinho");

                }
                else
                {
                    List<ProdutoCarrinho> itensCarrinho = new List<ProdutoCarrinho>();

                    dadosItem.QuantidadeProduto = 1;
                    dadosItem.ValorTotal = dadosItem.ValorUnitario;

                    itensCarrinho.Add(dadosItem);

                    ViewBag["itensCarrinho"] = itensCarrinho;
                    ViewBag["numeroItens"] = itensCarrinho.Count;

                    return RedirectToAction("Index", "Carrinho");
                }
            }
            else
            {
                ViewBag["itensCarrinho"] = ViewBag["itensCarrinho"];
                ViewBag["numeroItens"] = ViewBag["numeroItens"];
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AtualizarItem(int idProduto, int novaQuantidade)
        {
            var produto = _produtoBll.BuscarProdutoId(idProduto);
            if (produto != null)
            {
                ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                dadosItem.IdProduto = idProduto;
                dadosItem.Nome = produto.Nome;
                dadosItem.ValorUnitario = produto.Valor;

                //Verifica se existem itens no carrinho
                if (ViewBag["itensCarrinho"] != null)
                {
                    List<ProdutoCarrinho> itensCarrinho = (List<ProdutoCarrinho>)ViewBag["itensCarrinho"];
                    int numeroItens = (int)ViewBag["numeroItens"];

                    //Verificar se o item já está no carrinho
                    var itemJaAdicionado = itensCarrinho.Find(c => c.IdProduto == idProduto);

                    if (itemJaAdicionado != null)
                    {
                        if (novaQuantidade == 0)
                        {
                            itensCarrinho.Remove(itemJaAdicionado);
                        }
                        else
                        {
                            dadosItem.QuantidadeProduto = novaQuantidade;
                            dadosItem.ValorTotal = dadosItem.ValorUnitario * dadosItem.QuantidadeProduto;
                            itensCarrinho.Add(dadosItem);
                        }
                    }

                    if (itemJaAdicionado.QuantidadeProduto > novaQuantidade)
                    {
                        int diferenca = itemJaAdicionado.QuantidadeProduto - novaQuantidade;
                        produto.QuantidadeDisponivel = produto.QuantidadeDisponivel + diferenca;
                    }
                    else if (itemJaAdicionado.QuantidadeProduto < novaQuantidade)
                    {
                        int diferenca = novaQuantidade - itemJaAdicionado.QuantidadeProduto;
                        produto.QuantidadeDisponivel = produto.QuantidadeDisponivel - diferenca;
                    }
                    _produtoBll.AtualizarProduto(produto);

                    ModelState.AddModelError("Message", "Item atualizado com sucesso.");
                    ViewBag["itensCarrinho"] = itensCarrinho;
                    ViewBag["numeroItens"] = itensCarrinho.Count;
                    return RedirectToAction("Index", "Carrinho");

                }

                ViewBag["itensCarrinho"] = ViewBag["itensCarrinho"];
                ViewBag["numeroItens"] = ViewBag["numeroItens"];

                return RedirectToAction("Index", "Carrinho");

            }
            else
            {
                ViewBag["itensCarrinho"] = ViewBag["itensCarrinho"];
                ViewBag["numeroItens"] = ViewBag["numeroItens"];
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult RemoverItem(int idProduto)
        {
            var produto = _produtoBll.BuscarProdutoId(idProduto);
            if (produto != null)
            {
                ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                dadosItem.IdProduto = idProduto;
                dadosItem.Nome = produto.Nome;
                dadosItem.ValorUnitario = produto.Valor;

                //Verifica se existem itens no carrinho
                if (ViewBag["itensCarrinho"] != null)
                {
                    List<ProdutoCarrinho> itensCarrinho = (List<ProdutoCarrinho>)ViewBag["itensCarrinho"];
                    int numeroItens = (int)ViewBag["numeroItens"];

                    //Verificar se o item já está no carrinho
                    var itemJaAdicionado = itensCarrinho.Find(c => c.IdProduto == idProduto);

                    if (itemJaAdicionado != null)
                    {
                        itensCarrinho.Remove(itemJaAdicionado);
                    }

                    ViewBag["itensCarrinho"] = itensCarrinho;
                    ViewBag["numeroItens"] = itensCarrinho.Count;
                    produto.QuantidadeDisponivel = itemJaAdicionado.QuantidadeProduto;

                    _produtoBll.AtualizarProduto(produto);
                    return RedirectToAction("Index", "Carrinho");


            }

                ModelState.AddModelError("Message", "Item removido com sucesso.");
                ViewBag["itensCarrinho"] = ViewBag["itensCarrinho"];
                ViewBag["numeroItens"] = ViewBag["numeroItens"];

                return RedirectToAction("Index", "Carrinho");
            }

            ViewBag["itensCarrinho"] = ViewBag["itensCarrinho"];
            ViewBag["numeroItens"] = ViewBag["numeroItens"];
            return RedirectToAction("Index", "Home");

        }
    }
}
