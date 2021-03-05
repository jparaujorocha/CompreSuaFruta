using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompreSuaFruta.Api.Controllers
{
    [Route("api/frutas")]
    [ApiController]
    public class FrutasController : ControllerBase
    {
        /*
        public IFrutasService _FrutasService;

        public FrutasController(IFrutasService frutasService)
        {
            this._FrutasService = frutasService;
        }

        /// <summary>
        /// Busca o estoque atual de fruttas
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult BuscaEstoqueFrutas()
        {
            try
            {
                var estoqueFrutas = JsonConvert.SerializeObject(_FrutasService.BuscarDadosMensais());
                if (estoqueFrutas != null && estoqueFrutas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueFrutas));

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
        /// Remove frutas do estoque atual
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult RemoveFrutasEstoque()
        {
            try
            {
                var estoqueFrutas = JsonConvert.SerializeObject(_FrutasService.BuscarDadosMensais());
                if (estoqueFrutas != null && estoqueFrutas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueFrutas));

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
        /// Adiciona frutas ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AdicionaFrutasEstoque()
        {
            try
            {
                var estoqueFrutas = JsonConvert.SerializeObject(_FrutasService.BuscarDadosMensais());
                if (estoqueFrutas != null && estoqueFrutas.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueFrutas));

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