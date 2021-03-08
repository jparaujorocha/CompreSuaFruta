using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompreSuaFruta.Business.Concrete
{
    public class VendaBll : IVendaBll
    {
        private readonly IVendaDal _vendaDal;
        private readonly IUsuarioDal _usuarioDal;

        public VendaBll(IVendaDal vendaDal, IUsuarioDal usuarioaDal)
        {
            this._vendaDal = vendaDal;
            this._usuarioDal = usuarioaDal;
        }
        public Venda AtualizarVenda(Venda dadosVenda)
        {
            try
            {
                return _vendaDal.AtualizarVenda(dadosVenda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda BuscarVendaId(int id)
        {
            try
            {
                return _vendaDal.BuscarVendaId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendas()
        {
            try
            {
                return _vendaDal.BuscarVendas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda InserirVenda(Venda dadosVenda)
        {
            try
            {
                return _vendaDal.InserirVenda(dadosVenda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarVenda(int id)
        {
            try
            {
                Venda dadosVenda = _vendaDal.BuscarVendaId(id);
                _vendaDal.DesativarVenda(dadosVenda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda VerificaVendaPendenteUsuario(string cpfUsuario)
        {
            try
            {
                Usuario dadosUsuario = _usuarioDal.BuscarUsuarioCpf(cpfUsuario);
                if (dadosUsuario != null && string.IsNullOrWhiteSpace(dadosUsuario.Cpf) == false)
                {
                    int idVendaPendente = _vendaDal.BuscarVendasPendenteUsuario(dadosUsuario.Id).Select(c => c.Id).Max();
                    Venda dadosVendaPendente = _vendaDal.BuscarVendaId(idVendaPendente);

                    return dadosVendaPendente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
