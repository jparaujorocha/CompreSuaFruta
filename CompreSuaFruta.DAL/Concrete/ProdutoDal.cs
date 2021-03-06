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
    public class ProdutoDal : IProdutoDal
    {
        private readonly ProdutoDbContext _dbContext;
        private bool _disposed;

        public ProdutoDal(ProdutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Produto AtualizarProduto(Produto dadosProduto)
        {
            try
            {
                var localEntity = _dbContext.Set<Produto>().Local.FirstOrDefault(f => f.Id == dadosProduto.Id);
                if (localEntity != null)
                {
                    _dbContext.Entry(localEntity).State = EntityState.Detached;
                }
                _dbContext.Produto.Attach(dadosProduto);
                _dbContext.Entry(dadosProduto).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return dadosProduto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto BuscarProdutoId(int id)
        {
            try
            {
                return (from dados in _dbContext.Produto where dados.Id == id select dados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> BuscarProdutos()
        {
            try
            {
                return (from dados in _dbContext.Produto select dados).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto InserirProduto(Produto dadosProduto)
        {
            try
            {

                _dbContext.Produto.Add(dadosProduto);
                _dbContext.SaveChanges();

                return dadosProduto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarProduto(Produto dadosProduto)
        {
            try
            {
                dadosProduto.ProdutoAtivo = false;
                _dbContext.Produto.Attach(dadosProduto);
                _dbContext.Entry(dadosProduto).State = EntityState.Modified;
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
    }
}
