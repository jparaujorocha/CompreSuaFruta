using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public IProdutoBll _produtoBll;

        public ProdutoController(IProdutoBll produtoBll)
        {
            this._produtoBll = produtoBll;
        }

        /// <summary>
        /// Busca o estoque atual de produtos
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        //[Route("produtos")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(List<Produto>), 200)]
        public IActionResult BuscaProdutos()
        {
            try
            {
                var listaProdutos = JsonConvert.SerializeObject(_produtoBll.BuscarProdutos());
                if (listaProdutos != null && listaProdutos.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(listaProdutos));

                }
                else
                {
                    return Ok("Nenhum dado encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }
        /// <summary>
        /// Busca o estoque atual de produtos
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Produto), 400)]
        public IActionResult BuscaProduto(int id)
        {
            try
            {
                var produto = JsonConvert.SerializeObject(_produtoBll.BuscarProdutoId(id));
                if (produto != null && produto.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(produto));

                }
                else
                {
                    return Ok("Nenhum dado encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove Produtos do estoque atual
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("desativar/{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult DesativarProduto(int id)
        {
            try
            {
                _produtoBll.DesativarProduto(id);

                return Ok("Produto Desativado com sucesso.");


            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Produtos ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        [Route("adicionarproduto")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Produto), 200)]
        public IActionResult AdicionaProduto([FromBody] Produto dadosProduto)
        {
            try
            {
                var estoqueProdutos = JsonConvert.SerializeObject(_produtoBll.InserirProduto(dadosProduto));
                if (estoqueProdutos != null && estoqueProdutos.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueProdutos));

                }
                else
                {
                    return Ok("Nenhum dado encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Produtos ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("atualizarproduto")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Produto), 200)]
        public IActionResult AtualizarProduto([FromBody] Produto dadosProduto)
        {
            try
            {
                var estoqueProdutos = JsonConvert.SerializeObject(_produtoBll.InserirProduto(dadosProduto));
                if (estoqueProdutos != null && estoqueProdutos.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueProdutos));

                }
                else
                {
                    return Ok("Nenhum dado encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

    }
}