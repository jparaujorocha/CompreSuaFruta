using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompreSuaProduto.Api.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        /*
        public IProdutosService _ProdutosService;

        public ProdutosController(IProdutosService ProdutosService)
        {
            this._ProdutosService = ProdutosService;
        }

        /// <summary>
        /// Busca o estoque atual de fruttas
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult BuscaEstoqueProdutos()
        {
            try
            {
                var estoqueProdutos = JsonConvert.SerializeObject(_ProdutosService.BuscarDadosMensais());
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
        /// Remove Produtos do estoque atual
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult RemoveProdutosEstoque()
        {
            try
            {
                var estoqueProdutos = JsonConvert.SerializeObject(_ProdutosService.BuscarDadosMensais());
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
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AdicionaProdutosEstoque()
        {
            try
            {
                var estoqueProdutos = JsonConvert.SerializeObject(_ProdutosService.BuscarDadosMensais());
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
        */
    }
}