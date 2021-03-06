using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Business.Concrete
{
    public class ProdutoVendaBll : IProdutoVendaBll
    {
        private readonly IProdutoVendaDal _produtoCarrinhoDal;

        public ProdutoVendaBll(IProdutoVendaDal produtoCarrinho)
        {
            this._produtoCarrinhoDal = produtoCarrinho;
        }
        public List<ProdutoVenda> AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            try
            {
                return _produtoCarrinhoDal.AtualizarProdutoVenda(dadosProdutoVenda);

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
                return _produtoCarrinhoDal.BuscarProdutoVendaId(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoVenda> BuscarProdutosCarrinho()
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

        public List<ProdutoVenda> BuscarProdutosCarrinhoVenda(int idVenda)
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

        public List<ProdutoVenda> InserirProdutoVenda(ProdutoVenda dadosProdutoVenda)
        {
            try
            {
                dadosProdutoVenda.Id = _produtoCarrinhoDal.BuscarProdutosCarrinho().Select(c => c.Id).Max() + 1;

                return _produtoCarrinhoDal.InserirProdutoVenda(dadosProdutoVenda);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoVenda> RemoverProdutoVenda(int idProdutoVenda)
        {
            try
            {
                ProdutoVenda dadosProduto = _produtoCarrinhoDal.BuscarProdutoVendaId(idProdutoVenda);
               return _produtoCarrinhoDal.RemoverProdutoVenda(dadosProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
