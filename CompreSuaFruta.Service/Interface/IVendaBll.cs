using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Business.Interface
{
    public interface IVendaBll
    {
        Venda BuscarVendaId(int id);
        List<Venda> BuscarVendas();
        Venda InserirVenda(Venda dadosVenda);
        Venda AtualizarVenda(Venda dadosVenda);
        void DesativarVenda(int id);
    }
}
