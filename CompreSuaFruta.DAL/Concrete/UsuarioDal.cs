using CompreSuaFruta.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using CompreSuaFruta.Model.Models;
using System.Linq;
using Newtonsoft.Json;

namespace CompreSuaFruta.Dal.Concrete
{
    public class UsuarioDal : IUsuarioDal
    {
        private readonly DalHelper _dbContext = new DalHelper();

        public Usuario AtualizarUsuario(Usuario dadosUsuario)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Usuario set Nome = @Nome, Cpf = @Cpf, Senha = @Senha, UsuarioAtivo = @UsuarioAtivo WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Nome", dadosUsuario.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", dadosUsuario.Cpf);
                    cmd.Parameters.AddWithValue("@Senha", dadosUsuario.Senha);
                    cmd.Parameters.AddWithValue("@UsuarioAtivo", dadosUsuario.UsuarioAtivo);
                    cmd.Parameters.AddWithValue("@Id", dadosUsuario.Id);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Usuario Usuario = JsonConvert.DeserializeObject<Usuario>(JsonConvert.SerializeObject(dt));
                    return Usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioId(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario Where Id= " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Usuario Usuario = JsonConvert.DeserializeObject<Usuario>(JsonConvert.SerializeObject(dt));
                    return Usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> BuscarUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario";
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<Usuario> listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(JsonConvert.SerializeObject(dt));
                    return listaUsuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario InserirUsuario(Usuario dadosUsuario)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Usuario(Id, Nome, Cpf, Senha, UsuarioAtivo) values (@Id, @Nome, @Cpf, @Senha, @UsuarioAtivo)";
                    cmd.Parameters.AddWithValue("@Nome", dadosUsuario.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", dadosUsuario.Cpf);
                    cmd.Parameters.AddWithValue("@Senha", dadosUsuario.Senha);
                    cmd.Parameters.AddWithValue("@UsuarioAtivo", dadosUsuario.UsuarioAtivo);
                    cmd.Parameters.AddWithValue("@Id", dadosUsuario.Id);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Usuario Usuario = JsonConvert.DeserializeObject<Usuario>(JsonConvert.SerializeObject(dt));
                    return Usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarUsuario(Usuario dadosUsuario)
        {
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Usuario set UsuarioAtivo = 0 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosUsuario.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioCpfSenha(string cpf, string senha)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario Where Cpf = @Cpf AND Senha = @Senha ";
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        da.Fill(dt);
                        Usuario Usuario = JsonConvert.DeserializeObject<Usuario>(JsonConvert.SerializeObject(dt));
                        return Usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioCpf(string cpf)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario Where Cpf = @Cpf ";
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        da.Fill(dt);
                        Usuario Usuario = JsonConvert.DeserializeObject<Usuario>(JsonConvert.SerializeObject(dt));
                        return Usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
