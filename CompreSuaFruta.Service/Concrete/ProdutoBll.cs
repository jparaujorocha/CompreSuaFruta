using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Business.Concrete
{
    class ProdutoBll : IProdutoBll
    {
        private readonly IProdutoDal _produtoDal;

        public ProdutoBll(IProdutoDal produtoDal)
        {
            this._produtoDal = produtoDal;
        }
        
        public Produto AtualizarProduto(Produto dadosProduto)
        {
            try
            {
               return _produtoDal.AtualizarProduto(dadosProduto);
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
                return _produtoDal.BuscarProdutoId(id);
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
                return _produtoDal.BuscarProdutos();
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
                int idProduto = _produtoDal.BuscarProdutos().Select(c => c.Id).Max() + 1;
                return _produtoDal.InserirProduto(dadosProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarProduto(int id)
        {
            try
            {
                Produto dadosProduto = _produtoDal.BuscarProdutoId(id);
                _produtoDal.DesativarProduto(dadosProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
