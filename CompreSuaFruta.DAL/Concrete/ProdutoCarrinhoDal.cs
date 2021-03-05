using CompreSuaFruta.Dal.Interface;
using CompreSuaFruta.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace CompreSuaFruta.Dal.Concrete
{
    public class ProdutoCarrinhoDal : IProdutoCarrinhoDal
    {
        private readonly DalHelper _dbContext = new DalHelper();

        public List<ProdutoCarrinho> AtualizarProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ProdutoCarrinho set QuantidadeProduto = @QuantidadeProduto, IdProduto = @IdProduto, IdVenda = @IdVenda, ProdutoCarrinhoAtivo = @ProdutoCarrinhoAtivo WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosProdutoCarrinho.Id);
                    cmd.Parameters.AddWithValue("@IdIdProduto", dadosProdutoCarrinho.IdProduto);
                    cmd.Parameters.AddWithValue("@IdVenda", dadosProdutoCarrinho.QuantidadeProduto);
                    cmd.Parameters.AddWithValue("@Id", dadosProdutoCarrinho.IdVenda);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<ProdutoCarrinho> ProdutoCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>(JsonConvert.SerializeObject(dt));
                    return ProdutoCarrinho;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProdutoCarrinho BuscarProdutoCarrinhoId(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ProdutoCarrinho Where Id= " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    ProdutoCarrinho ProdutoCarrinho = JsonConvert.DeserializeObject<ProdutoCarrinho>(JsonConvert.SerializeObject(dt));
                    return ProdutoCarrinho;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> BuscarProdutosCarrinho()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ProdutoCarrinho";
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<ProdutoCarrinho> listaProdutoCarrinhos = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>(JsonConvert.SerializeObject(dt));
                    return listaProdutoCarrinhos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> BuscarProdutosCarrinhoVenda(int idVenda)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ProdutoCarrinho WHERE IdVenda = @IdVenda";
                    cmd.Parameters.AddWithValue("@IdVenda", idVenda);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<ProdutoCarrinho> listaProdutoCarrinhos = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>(JsonConvert.SerializeObject(dt));
                    return listaProdutoCarrinhos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> InserirProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ProdutoCarrinho(Id, IdProduto, IdVenda, QuantidadeProduto) values (@Id, @IdProduto, @IdVenda, @QuantidadeProduto)";
                    cmd.Parameters.AddWithValue("@Id", dadosProdutoCarrinho.Id);
                    cmd.Parameters.AddWithValue("@IdProduto", dadosProdutoCarrinho.IdProduto);
                    cmd.Parameters.AddWithValue("@IdVenda", dadosProdutoCarrinho.IdVenda);
                    cmd.Parameters.AddWithValue("@QuantidadeProduto", dadosProdutoCarrinho.QuantidadeProduto);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<ProdutoCarrinho> ProdutoCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>(JsonConvert.SerializeObject(dt));
                    return ProdutoCarrinho;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoCarrinho> RemoverProdutoCarrinho(ProdutoCarrinho dadosProdutoCarrinho)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ProdutoCarrinho WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosProdutoCarrinho.Id);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<ProdutoCarrinho> ProdutoCarrinho = JsonConvert.DeserializeObject<List<ProdutoCarrinho>>(JsonConvert.SerializeObject(dt));
                    return ProdutoCarrinho;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
