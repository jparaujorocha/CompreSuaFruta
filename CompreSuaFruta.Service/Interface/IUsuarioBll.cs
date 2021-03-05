using CompreSuaFruta.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Business.Interface
{
    public interface IUsuarioBll
    {
        Usuario BuscarUsuarioId(int id);
        Usuario BuscarUsuarioCpfSenha(string cpf, string senha);
        List<Usuario> BuscarUsuarios();
        Usuario InserirUsuario(Usuario dadosUsuario);
        Usuario AtualizarUsuario(Usuario dadosUsuario);
        void DesativarUsuario(int id);
    }
}
