using CompreSuaFruta.Dal.Context.Contexts;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Dal.Concrete
{
    public class ProdutoVendaDal : IProdutoVendaDal
    {
        private readonly ProdutoVendaDbContext _dbContext;
        private bool _disposed;

        public ProdutoVendaDal(ProdutoVendaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProdutoVenda AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            try
            {
                var localEntity = _dbContext.Set<ProdutoVenda>().Local.FirstOrDefault(f => f.Id == dadosProdutoVenda.Id);
                if (localEntity != null)
                {
                    _dbContext.Entry(localEntity).State = EntityState.Detached;
                }
                _dbContext.ProdutoVenda.Attach(dadosProdutoVenda);
                _dbContext.Entry(dadosProdutoVenda).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return dadosProdutoVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProdutoVenda BuscarProdutoVendaId(int id)
        {
            try
            {
                return (from dados in _dbContext.ProdutoVenda where dados.Id == id select dados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoVenda> BuscarProdutoVendas()
        {
            try
            {
                return (from dados in _dbContext.ProdutoVenda select dados).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProdutoVenda InserirProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            try
            {

                _dbContext.ProdutoVenda.Add(dadosProdutoVenda);
                _dbContext.SaveChanges();

                return dadosProdutoVenda;
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

        public List<ProdutoVenda> BuscarProdutosCarrinhoVenda(int idVenda)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoVenda> BuscarProdutosCarrinho()
        {
            throw new NotImplementedException();
        }

        List<ProdutoVenda> IProdutoVendaDal.InserirProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            throw new NotImplementedException();
        }

        List<ProdutoVenda> IProdutoVendaDal.AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoVenda> RemoverProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            throw new NotImplementedException();
        }
    }
}
