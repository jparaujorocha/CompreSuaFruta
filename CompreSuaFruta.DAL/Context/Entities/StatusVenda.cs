using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Entities
{
    public class StatusVenda
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
