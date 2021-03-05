using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IProdutoCarrinhoDal
    {
        ProdutoCarrinho BuscarProdutoCarrinhoId(int id);
        List<ProdutoCarrinho> BuscarProdutosCarrinhoVenda(int idVenda);
        List<ProdutoCarrinho> BuscarProdutosCarrinho();
        List<ProdutoCarrinho> InserirProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho);
        List<ProdutoCarrinho> AtualizarProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho);
        List<ProdutoCarrinho> RemoverProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho);
    }
}
