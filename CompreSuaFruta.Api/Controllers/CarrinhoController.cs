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
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Controllers
{
    [Authorize]
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
        public IActionResult Index()
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

            return View(itensCarrinho);
        }

        /// <summary>
        /// Confirma a compra, registrando dados de venda e dos produtos da venda.
        /// </summary>
        /// <returns></returns>
        public IActionResult ConfirmarCompra()
        {
            try
            {
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

                //Recupera dados do usuário logado
                var dadosUsuario = _usuarioBll.BuscarUsuarioCpf(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
                if (dadosUsuario != null)
                {
                    if (itensCarrinho != null && itensCarrinho.Count > 0)
                    {
                        //Registra a venda efetuada
                        Venda dadosVenda = new Venda();
                        dadosVenda.Data = DateTime.Now;
                        dadosVenda.IdUsuario = dadosUsuario.Id;
                        dadosVenda.Status = 1;
                        dadosVenda.VendaAtiva = true;
                        dadosVenda.Valor = itensCarrinho.Sum(a => a.ValorTotal);
                        Venda dadosVendaEfetuada = _vendaBll.InserirVenda(dadosVenda);

                        //Registra os produtos da venda efetuada
                        foreach (var item in itensCarrinho)
                        {
                            ProdutoVenda dadosProdutoVenda = new ProdutoVenda();
                            dadosProdutoVenda.ValorTotal = item.ValorTotal;
                            dadosProdutoVenda.ValorUnitario = item.ValorUnitario;
                            dadosProdutoVenda.IdProduto = item.IdProduto;
                            dadosProdutoVenda.IdVenda = dadosVendaEfetuada.Id;
                            dadosProdutoVenda.QuantidadeProduto = item.QuantidadeProduto;
                            _produtoVendaBll.InserirProdutoVenda(dadosProdutoVenda);
                        }
                    }
                    TempData["itensCarrinho"] = null;
                    TempData["numeroItens"] = 0;
                    TempData["Mensagem"] = "Compra realizada com sucesso.";
                    return RedirectToAction("Index", "Carrinho");
                }
                else
                {
                    TempData["itensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
                    TempData["numeroItens"] = itensCarrinho.Count();
                    ModelState.AddModelError("Message", "Necessário fazer cadastro e login.");
                    return RedirectToAction("Index", "Carrinho");
                }
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Carrinho");
            }
        }
        /// <summary>
        /// Adiciona item ao carrinho
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public IActionResult AdicionarItem(int idProduto)
        {
            try
            {
                var produto = _produtoBll.BuscarProdutoId(idProduto);
                if (produto != null)
                {
                    //Verifica se há estoque
                    if (produto.QuantidadeDisponivel > 0)
                    {
                        ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                        dadosItem.IdProduto = idProduto;
                        dadosItem.Nome = produto.Nome;
                        dadosItem.ValorUnitario = produto.Valor;

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

                        //Verifica se existem itens no carrinho
                        if (itensCarrinho != null)
                        {
                            int numeroItens = (int)TempData["numeroItens"];

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

                            TempData["Mensagem"] = "Item adicionado com sucesso.";
                            TempData["itensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
                            TempData["numeroItens"] = itensCarrinho.Count;
                            return RedirectToAction("Index", "Carrinho");

                        }
                        else
                        {
                            itensCarrinho = new List<ProdutoCarrinho>();

                            dadosItem.QuantidadeProduto = 1;
                            dadosItem.ValorTotal = dadosItem.ValorUnitario;

                            itensCarrinho.Add(dadosItem);

                            TempData["itensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
                            TempData["numeroItens"] = itensCarrinho.Count;

                            return RedirectToAction("Index", "Carrinho");
                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "Estoque do produto esgotado.";
                        TempData["itensCarrinho"] = ViewData["itensCarrinho"];
                        TempData["numeroItens"] = ViewData["numeroItens"];
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["Mensagem"] = "Estoque do produto esgotado.";
                    TempData["itensCarrinho"] = ViewData["itensCarrinho"];
                    TempData["numeroItens"] = ViewData["numeroItens"];
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Carrinho");
            }
        }

        /// <summary>
        /// Atualiza itens do carrinho
        /// </summary>
        /// <param name="idProduto">id do item</param>
        /// <param name="novaQuantidade">Nova quantidade do item</param>
        /// <returns></returns>
        public IActionResult AtualizarItem(int idProduto, int novaQuantidade)
        {
            try
            {
                var produto = _produtoBll.BuscarProdutoId(idProduto);
                if (produto != null)
                {
                    ///Verifica se há estoque disponível
                    if (produto.QuantidadeDisponivel > 0)
                    {
                        ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                        dadosItem.IdProduto = idProduto;
                        dadosItem.Nome = produto.Nome;
                        dadosItem.ValorUnitario = produto.Valor;

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

                        //Verifica se existem itens no carrinho
                        if (itensCarrinho != null && itensCarrinho.Count > 0)
                        {
                            int numeroItens = (int)TempData["numeroItens"];

                            //Verificar se o item já está no carrinho
                            var itemJaAdicionado = itensCarrinho.Find(c => c.IdProduto == idProduto);

                            if (itemJaAdicionado != null)
                            {
                                if (novaQuantidade <= 0)
                                {
                                    itensCarrinho.Remove(itemJaAdicionado);
                                }
                                else
                                {
                                    itensCarrinho.Remove(itemJaAdicionado);
                                    dadosItem.QuantidadeProduto = novaQuantidade;
                                    dadosItem.ValorTotal = dadosItem.ValorUnitario * dadosItem.QuantidadeProduto;
                                    itensCarrinho.Add(dadosItem);
                                }
                            }

                            //Atualiza quantidade do produto em estoque
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

                            TempData["Mensagem"] = "Item atualizado com sucesso.";
                            TempData["itensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
                            TempData["numeroItens"] = itensCarrinho.Count;
                            return RedirectToAction("Index", "Carrinho");

                        }

                        TempData["itensCarrinho"] = ViewData["itensCarrinho"];
                        TempData["numeroItens"] = ViewData["numeroItens"];

                        return RedirectToAction("Index", "Carrinho");

                    }
                    else
                    {
                        TempData["itensCarrinho"] = ViewData["itensCarrinho"];
                        TempData["numeroItens"] = ViewData["numeroItens"];
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["Mensagem"] = "Estoque do produto esgotado.";
                    TempData["itensCarrinho"] = ViewData["itensCarrinho"];
                    TempData["numeroItens"] = ViewData["numeroItens"];
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Carrinho");
            }
        }
        /// <summary>
        /// Remove item do carrinho
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public IActionResult RemoverItem(int idProduto)
        {
            try
            {
                var produto = _produtoBll.BuscarProdutoId(idProduto);
                if (produto != null)
                {
                    ProdutoCarrinho dadosItem = new ProdutoCarrinho();

                    dadosItem.IdProduto = idProduto;
                    dadosItem.Nome = produto.Nome;
                    dadosItem.ValorUnitario = produto.Valor;

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

                    //Verifica se existem itens no carrinho
                    if (itensCarrinho != null)
                    {
                        int numeroItens = (int)TempData["numeroItens"];

                        //Verificar se o item já está no carrinho
                        var itemJaAdicionado = itensCarrinho.Find(c => c.IdProduto == idProduto);

                        if (itemJaAdicionado != null)
                        {
                            itensCarrinho.Remove(itemJaAdicionado);
                        }

                        TempData["itensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
                        TempData["numeroItens"] = itensCarrinho.Count;

                        //Atualiza quantidade do produto em estoque
                        produto.QuantidadeDisponivel = itemJaAdicionado.QuantidadeProduto;
                        _produtoBll.AtualizarProduto(produto);

                        TempData["Mensagem"] = "Item removido com sucesso.";
                        return RedirectToAction("Index", "Carrinho");


                    }

                    TempData["itensCarrinho"] = TempData["itensCarrinho"];
                    TempData["numeroItens"] = TempData["numeroItens"];

                    return RedirectToAction("Index", "Carrinho");
                }

                TempData["itensCarrinho"] = TempData["itensCarrinho"];
                TempData["numeroItens"] = TempData["numeroItens"];
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro: " + ex.Message;
                return RedirectToAction("Index", "Carrinho");
            }
        }
    }
}
