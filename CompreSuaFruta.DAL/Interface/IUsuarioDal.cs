using System;
using System.Collections.Generic;
using System.Text;
using CompreSuaFruta.Model.Models;

namespace CompreSuaFruta.Dal.Interface
{
    public interface IUsuarioDal
    {
        Usuario BuscarUsuarioId(int id);
        Usuario BuscarUsuarioCpfSenha(string cpf, string senha);
        List<Usuario> BuscarUsuarios();
        Usuario InserirUsuario(Usuario dadosUsuario);
        Usuario AtualizarUsuario(Usuario dadosUsuario);
        void DesativarUsuario(Usuario dadosUsuario);

    }
}
