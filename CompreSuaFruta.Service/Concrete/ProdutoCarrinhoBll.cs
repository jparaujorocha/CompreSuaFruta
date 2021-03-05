using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Business.Concrete
{
    class ProdutoCarrinhoBll : IProdutoCarrinhoBll
    {
        private readonly IProdutoCarrinhoDal _produtoCarrinhoDal;

        public ProdutoCarrinhoBll(IProdutoCarrinhoDal produtoCarrinho)
        {
            this._produtoCarrinhoDal = produtoCarrinho;
        }
        public List<ProdutoCarrinho> AtualizarProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho)
        {
            try
            {
                return _produtoCarrinhoDal.AtualizarProdutoCarrinho(dadosProdutoCarrinho);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProdutoCarrinho BuscarProdutoCarrinhoId(int id)
        {
            try
            {
                return _produtoCarrinhoDal.BuscarProdutoCarrinhoId(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> BuscarProdutosCarrinho()
        {
            try
            {
                return _produtoCarrinhoDal.BuscarProdutosCarrinho();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> BuscarProdutosCarrinhoVenda(int idVenda)
        {
            try
            {
                return _produtoCarrinhoDal.BuscarProdutosCarrinhoVenda(idVenda);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> InserirProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho)
        {
            try
            {
                dadosProdutoCarrinho.Id = _produtoCarrinhoDal.BuscarProdutosCarrinho().Select(c => c.Id).Max() + 1;

                return _produtoCarrinhoDal.InserirProdutoCarrinho(dadosProdutoCarrinho);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> RemoverProdutoCarrinho(int idProdutoCarrinho)
        {
            try
            {
                ProdutoCarrinho dadosProduto = _produtoCarrinhoDal.BuscarProdutoCarrinhoId(idProdutoCarrinho);
               return _produtoCarrinhoDal.RemoverProdutoCarrinho(dadosProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
