using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Controllers
{
    [Route("api/vendas")]
    [ApiController]
    public class ApiVendaController : ControllerBase
    {
        private readonly IVendaBll _vendaBll;

        public ApiVendaController(IVendaBll vendaBll)
        {
            this._vendaBll = vendaBll;
        }

        /// <summary>
        /// Busca o estoque atual de Vendas
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(List<Venda>), 200)]
        public IActionResult BuscaVendas()
        {
            try
            {
                var listaVendas = JsonConvert.SerializeObject(_vendaBll.BuscarVendas());
                if (listaVendas != null && listaVendas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(listaVendas));

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
        /// Busca o estoque atual de Vendas
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Venda), 400)]
        public IActionResult BuscaVenda(int id)
        {
            try
            {
                var Venda = JsonConvert.SerializeObject(_vendaBll.BuscarVendaId(id));
                if (Venda != null && Venda.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(Venda));

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
        /// Remove Vendas do estoque atual
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("desativar/{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult DesativarVenda(int id)
        {
            try
            {
                _vendaBll.DesativarVenda(id);

                return Ok("Venda Desativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Vendas ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        [Route("adicionarvenda")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Venda), 200)]
        public IActionResult AdicionaVenda([FromBody] Venda dadosVenda)
        {
            try
            {
                var estoqueVendas = JsonConvert.SerializeObject(_vendaBll.InserirVenda(dadosVenda));
                if (estoqueVendas != null && estoqueVendas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueVendas));

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
        /// Adiciona Vendas ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("atualizarvenda")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Venda), 200)]
        public IActionResult AtualizarVenda([FromBody] Venda dadosVenda)
        {
            try
            {
                var estoqueVendas = JsonConvert.SerializeObject(_vendaBll.InserirVenda(dadosVenda));
                if (estoqueVendas != null && estoqueVendas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueVendas));

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