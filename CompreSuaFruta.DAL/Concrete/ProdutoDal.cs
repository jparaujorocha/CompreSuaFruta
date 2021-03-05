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
    public class ProdutoDal : IProdutoDal
    {
        private readonly DalHelper _dbContext = new DalHelper();

        public Produto AtualizarProduto(Produto dadosProduto)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Produto set Nome = @Nome, Descricao = @Descricao, QuantidadeDisponivel = @QuantidadeDisponivel, Valor = @Valor, ProdutoAtivo = @ProdutoAtivo WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Nome", dadosProduto.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", dadosProduto.Descricao);
                    cmd.Parameters.AddWithValue("@QuantidadeDisponivel", dadosProduto.QuantidadeDisponivel);
                    cmd.Parameters.AddWithValue("@Valor", dadosProduto.Valor);
                    cmd.Parameters.AddWithValue("@ProdutoAtivo", dadosProduto.ProdutoAtivo);
                    cmd.Parameters.AddWithValue("@Id", dadosProduto.Id);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Produto Produto = JsonConvert.DeserializeObject<Produto>(JsonConvert.SerializeObject(dt));
                    return Produto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto BuscarProdutoId(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Produto Where Id= " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Produto Produto = JsonConvert.DeserializeObject<Produto>(JsonConvert.SerializeObject(dt));
                    return Produto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> BuscarProdutos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Produto";
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<Produto> listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(JsonConvert.SerializeObject(dt));
                    return listaProdutos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto InserirProduto(Produto dadosProduto)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Produto(Id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo) values (@Id, @Nome, @Descricao, @QuantidadeDisponivel, @Valor, @ProdutoAtivo)";
                    cmd.Parameters.AddWithValue("@Nome", dadosProduto.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", dadosProduto.Descricao);
                    cmd.Parameters.AddWithValue("@QuantidadeDisponivel", dadosProduto.QuantidadeDisponivel);
                    cmd.Parameters.AddWithValue("@Valor", dadosProduto.Valor);
                    cmd.Parameters.AddWithValue("@ProdutoAtivo", dadosProduto.ProdutoAtivo);
                    cmd.Parameters.AddWithValue("@Id", dadosProduto.Id);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Produto Produto = JsonConvert.DeserializeObject<Produto>(JsonConvert.SerializeObject(dt));
                    return Produto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarProduto(Produto dadosProduto)
        {
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Produto set ProdutoAtivo = 0 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosProduto.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
