using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Senha { get; set; }

        public bool UsuarioAtivo { get; set; }
    }
}
