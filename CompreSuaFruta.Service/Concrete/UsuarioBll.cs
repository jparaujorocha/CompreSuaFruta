using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Business.Concrete
{
    public class UsuarioBll : IUsuarioBll
    {
        private readonly IUsuarioDal _usuarioDal;

        public UsuarioBll(IUsuarioDal usuarioDal)
        {
            this._usuarioDal = usuarioDal;
        }

        public Usuario AtualizarUsuario(Usuario dadosUsuario)
        {
            try
            {
                return _usuarioDal.AtualizarUsuario(dadosUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioId(int id)
        {
            try
            {
                return _usuarioDal.BuscarUsuarioId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> BuscarUsuarios()
        {
            try
            {
                return _usuarioDal.BuscarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario InserirUsuario(Usuario dadosUsuario)
        {
            try
            {
                if (_usuarioDal.BuscarUsuarios().Count > 0)
                {
                    dadosUsuario.Id = _usuarioDal.BuscarUsuarios().Select(c => c.Id).Max() + 1;
                }
                else
                {
                    dadosUsuario.Id = 1;
                }
                dadosUsuario.UsuarioAtivo = true;
                return _usuarioDal.InserirUsuario(dadosUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarUsuario(int id)
        {
            try
            {
                Usuario dadosUsuario = _usuarioDal.BuscarUsuarioId(id);
                _usuarioDal.DesativarUsuario(dadosUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioCpfSenha(string cpf, string senha)
        {
            try
            {
                return _usuarioDal.BuscarUsuarioCpfSenha(cpf, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
