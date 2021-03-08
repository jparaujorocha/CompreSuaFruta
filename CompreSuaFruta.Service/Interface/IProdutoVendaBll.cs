using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Business.Interface
{
    public interface IProdutoVendaBll
    {
        ProdutoVenda BuscarProdutoVendaId(int id);
        List<ProdutoVenda> BuscarProdutosCarrinhoVenda(int idVenda);
        List<ProdutoVenda> BuscarProdutosCarrinho();
        ProdutoVenda InserirProdutoVenda(ProdutoVenda dadosProdutoVenda);
        ProdutoVenda AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda);
        void RemoverProdutoVenda(int idProdutoVenda);
    }
}
