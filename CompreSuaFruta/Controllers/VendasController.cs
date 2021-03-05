using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompreSuaFruta.Api.Controllers
{
    [Route("api/vendas")]
    [ApiController]
    public class VendasController : ControllerBase
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
        public IActionResult CriarVenda()
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
        /// Busca o estoque atual de fruttas
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("estoque")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AtualizarVenda()
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