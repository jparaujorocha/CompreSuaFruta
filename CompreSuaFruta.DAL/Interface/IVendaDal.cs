using System;
using System.Collections.Generic;
using System.Text;
using CompreSuaFruta.Model.Models;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IVendaDal
    {
        Venda BuscarVendaId(int id);
        List<Venda> BuscarVendas();
        Venda InserirVenda(Venda dadosVenda);
        Venda AtualizarVenda(Venda dadosVenda);
        void DesativarVenda(Venda dadosVenda);
    }
}
