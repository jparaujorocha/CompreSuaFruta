using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IProdutoVendaDal : IDisposable
    {
        ProdutoVenda BuscarProdutoVendaId(int id);
        List<ProdutoVenda> BuscarProdutosCarrinhoVenda(int idVenda);
        List<ProdutoVenda> BuscarProdutosCarrinho();
        List<ProdutoVenda> InserirProdutoVenda(ProdutoVenda dadosProdutoVenda);
        List<ProdutoVenda> AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda);
        List<ProdutoVenda> RemoverProdutoVenda(ProdutoVenda dadosProdutoVenda);
    }
}
