using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompreSuaFruta.Model.Models
{
    public class ProdutoVenda
    {
        [Key]
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
    }
}
