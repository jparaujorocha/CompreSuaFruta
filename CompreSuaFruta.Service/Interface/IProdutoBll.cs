using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Business.Interface
{
    public interface IProdutoBll
    {
        Produto BuscarProdutoId(int id);
        List<Produto> BuscarProdutos();
        Produto InserirProduto(Produto dadosProduto);
        Produto AtualizarProduto(Produto dadosProduto);
        void DesativarProduto(int id);
    }
}
