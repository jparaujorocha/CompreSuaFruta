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
        List<ProdutoVenda> InserirProdutoVenda(ProdutoVenda dadosProdutoVenda);
        List<ProdutoVenda> AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda);
        List<ProdutoVenda> RemoverProdutoVenda(int idProdutoVenda);
    }
}
