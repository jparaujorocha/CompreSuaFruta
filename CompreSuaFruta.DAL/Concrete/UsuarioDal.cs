using CompreSuaFruta.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using CompreSuaFruta.Dal.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using CompreSuaFruta.Model.Models;

namespace CompreSuaFruta.Dal.Concrete
{
    public class UsuarioDal : IUsuarioDal
    {
        private readonly UsuarioDbContext _dbContext;
        private bool _disposed;

        public UsuarioDal(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Usuario AtualizarUsuario(Usuario dadosUsuario)
        {
            try
            {
                var localEntity = _dbContext.Set<Usuario>().Local.FirstOrDefault(f => f.Id == dadosUsuario.Id);
                if (localEntity != null)
                {
                    _dbContext.Entry(localEntity).State = EntityState.Detached;
                }
                _dbContext.Usuario.Attach(dadosUsuario);
                _dbContext.Entry(dadosUsuario).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return dadosUsuario;
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
                return (from dados in _dbContext.Usuario where dados.Id == id select dados).FirstOrDefault();
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
                return (from dados in _dbContext.Usuario select dados).ToList();
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

                _dbContext.Usuario.Add(dadosUsuario);
                _dbContext.SaveChanges();

                return dadosUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarUsuario(Usuario dadosUsuario)
        {
            try
            {
                dadosUsuario.UsuarioAtivo = false;
                _dbContext.Usuario.Attach(dadosUsuario);
                _dbContext.Entry(dadosUsuario).State = EntityState.Modified;
                _dbContext.SaveChanges();
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
                return (from dados in _dbContext.Usuario where dados.Cpf == cpf && dados.Senha == senha select dados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioCpf(string cpf)
        {
            try
            {
                return (from dados in _dbContext.Usuario where dados.Cpf == cpf select dados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
