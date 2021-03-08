using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IProdutoVendaDal : IDisposable
    {
        ProdutoVenda BuscarProdutoVendaId(int id);
        List<ProdutoVenda> BuscarProdutosVenda(int idVenda);
        List<ProdutoVenda> BuscarProdutosVenda();
        ProdutoVenda InserirProdutoVenda(ProdutoVenda dadosProdutoVenda);
        ProdutoVenda AtualizarProdutoVenda(ProdutoVenda dadosProdutoVenda);
        void RemoverProdutoVenda(ProdutoVenda dadosProdutoVenda);
    }
}
