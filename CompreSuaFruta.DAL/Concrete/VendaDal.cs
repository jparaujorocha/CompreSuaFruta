using CompreSuaFruta.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using CompreSuaFruta.Model.Models;
using System.Linq;
using Newtonsoft.Json;
using CompreSuaFruta.Dal.Context.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CompreSuaFruta.Dal.Concrete
{
    public class VendaDal : IVendaDal
    {
        private readonly VendaDbContext _dbContext;
        private bool _disposed;

        public VendaDal(VendaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Venda AtualizarVenda(Venda dadosVenda)
        {
            try
            {
                var localEntity = _dbContext.Set<Venda>().Local.FirstOrDefault(f => f.Id == dadosVenda.Id);
                if (localEntity != null)
                {
                    _dbContext.Entry(localEntity).State = EntityState.Detached;
                }
                _dbContext.Venda.Attach(dadosVenda);
                _dbContext.Entry(dadosVenda).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return dadosVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda BuscarVendaId(int id)
        {
            try
            {
                return (from dados in _dbContext.Venda where dados.Id == id select dados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendas()
        {
            try
            {
                return (from dados in _dbContext.Venda select dados).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda InserirVenda(Venda dadosVenda)
        {
            try
            {

                _dbContext.Venda.Add(dadosVenda);
                _dbContext.SaveChanges();

                return dadosVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarVenda(Venda dadosVenda)
        {
            try
            {
                dadosVenda.VendaAtiva = false;
                _dbContext.Venda.Attach(dadosVenda);
                _dbContext.Entry(dadosVenda).State = EntityState.Modified;
                _dbContext.SaveChanges();
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

        public List<Venda> BuscarVendasUsuario(int idUsuario)
        {
            try
            {
                return (from dados in _dbContext.Venda where dados.IdUsuario == idUsuario select dados).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendasPendenteUsuario(int idUsuario)
        {
            try
            {
                return (from dados in _dbContext.Venda where dados.IdUsuario == idUsuario && dados.Status == 2 select dados).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
