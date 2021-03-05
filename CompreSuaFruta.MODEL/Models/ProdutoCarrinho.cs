using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Model.Models
{
    public class ProdutoCarrinho
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdVenda { get; set; }
    }
}
