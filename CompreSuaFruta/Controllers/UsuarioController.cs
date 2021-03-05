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
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBll _usuarioBll;

        public UsuarioController(IUsuarioBll usuarioBll)
        {
            this._usuarioBll = usuarioBll;
        }

        /// <summary>
        /// Busca o estoque atual de Usuarios
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(List<Usuario>), 200)]
        public IActionResult BuscaUsuarios()
        {
            try
            {
                var listaUsuarios = JsonConvert.SerializeObject(_usuarioBll.BuscarUsuarios());
                if (listaUsuarios != null && listaUsuarios.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(listaUsuarios));

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
        /// Busca o estoque atual de Usuarios
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Usuario), 400)]
        public IActionResult BuscaUsuario(int id)
        {
            try
            {
                var Usuario = JsonConvert.SerializeObject(_usuarioBll.BuscarUsuarioId(id));
                if (Usuario != null && Usuario.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(Usuario));

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
        /// Busca o estoque atual de Usuarios
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("validausuario")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Usuario), 400)]
        public IActionResult ValidaUsuario([FromBody] Usuario dadosUsuario)
        {
            try
            {
                var Usuario = JsonConvert.SerializeObject(_usuarioBll.BuscarUsuarioCpfSenha(dadosUsuario.Cpf, dadosUsuario.Senha));
                if (Usuario != null && Usuario.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(Usuario));

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
        /// Remove Usuarios do estoque atual
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("desativar/{id}")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult DesativarUsuario(int id)
        {
            try
            {
                _usuarioBll.DesativarUsuario(id);

                return Ok("Usuario Desativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Usuarios ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpPost]
        [Route("adicionarUsuario")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Usuario), 200)]
        public IActionResult AdicionaUsuario([FromBody] Usuario dadosUsuario)
        {
            try
            {
                var estoqueUsuarios = JsonConvert.SerializeObject(_usuarioBll.InserirUsuario(dadosUsuario));
                if (estoqueUsuarios != null && estoqueUsuarios.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueUsuarios));

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
        /// Adiciona Usuarios ao estoque atual.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Route("atualizarUsuario")]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(Usuario), 200)]
        public IActionResult AtualizarUsuario([FromBody] Usuario dadosUsuario)
        {
            try
            {
                var estoqueUsuarios = JsonConvert.SerializeObject(_usuarioBll.InserirUsuario(dadosUsuario));
                if (estoqueUsuarios != null && estoqueUsuarios.Length > 0)
                {
                    return Ok(JsonConvert.SerializeObject(estoqueUsuarios));

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