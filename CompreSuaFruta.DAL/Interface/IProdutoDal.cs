using System;
using System.Collections.Generic;
using System.Text;
using CompreSuaFruta.Model.Models;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IProdutoDal
    {
        Produto BuscarProdutoId(int id);
        List<Produto> BuscarProdutos();
        Produto InserirProduto(Produto dadosProduto);
        Produto AtualizarProduto(Produto dadosProduto);
        void DesativarProduto(Produto dadosProduto);
    }
}
