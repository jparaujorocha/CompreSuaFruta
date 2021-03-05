using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Model.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public double Valor { get; set; }
        public bool ProdutoAtivo { get; set; }
    }
}
