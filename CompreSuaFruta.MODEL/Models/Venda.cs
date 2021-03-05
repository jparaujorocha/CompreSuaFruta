using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Model.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public int IdUsuario { get; set; }
        public int Status { get; set; }
        public bool VendaAtiva { get; set; }
    }
}
