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
    public class VendaDal : IVendaDal
    {
        private readonly DalHelper _dbContext = new DalHelper();

        public Venda AtualizarVenda(Venda dadosVenda)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Venda set Data = @Data, Valor = @Valor, IdUsuario = @IdUsuario, Status = @Status, VendaAtiva = @VendaAtiva WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosVenda.Id);
                    cmd.Parameters.AddWithValue("@Data", dadosVenda.Data);
                    cmd.Parameters.AddWithValue("@Valor", dadosVenda.Valor);
                    cmd.Parameters.AddWithValue("@IdUsuario", dadosVenda.IdUsuario);
                    cmd.Parameters.AddWithValue("@Status", dadosVenda.Status);
                    cmd.Parameters.AddWithValue("@VendaAtiva", dadosVenda.VendaAtiva);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Venda venda = JsonConvert.DeserializeObject<Venda>(JsonConvert.SerializeObject(dt));
                    return venda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda BuscarVendaId(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Venda Where Id= " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Venda venda = JsonConvert.DeserializeObject<Venda>(JsonConvert.SerializeObject(dt));
                    return venda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendas()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Venda";
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<Venda> listaVendas = JsonConvert.DeserializeObject<List<Venda>>(JsonConvert.SerializeObject(dt));
                    return listaVendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendasUsuario(int idUsuario)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Venda where IdUsuario = @IdUsuario";
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<Venda> listaVendas = JsonConvert.DeserializeObject<List<Venda>>(JsonConvert.SerializeObject(dt));
                    return listaVendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venda> BuscarVendasPendenteUsuario(int idUsuario)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Venda where IdUsuario = @IdUsuario, IdStatus = 2";
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    List<Venda> listaVendas = JsonConvert.DeserializeObject<List<Venda>>(JsonConvert.SerializeObject(dt));
                    return listaVendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venda InserirVenda(Venda dadosVenda)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Venda(Id, Data, Valor, IdUsuario, Status, VendaAtiva) values (@Id, @Data, @Valor, @IdUsuario, @Status, @VendaAtiva)";
                    cmd.Parameters.AddWithValue("@Id", dadosVenda.Id);
                    cmd.Parameters.AddWithValue("@Data", dadosVenda.Data);
                    cmd.Parameters.AddWithValue("@Valor", dadosVenda.Valor);
                    cmd.Parameters.AddWithValue("@IdUsuario", dadosVenda.IdUsuario);
                    cmd.Parameters.AddWithValue("@Status", dadosVenda.Status);
                    cmd.Parameters.AddWithValue("@VendaAtiva", dadosVenda.VendaAtiva);
                    da = new SQLiteDataAdapter(cmd.CommandText, _dbContext.DbConnection());
                    da.Fill(dt);
                    Venda venda = JsonConvert.DeserializeObject<Venda>(JsonConvert.SerializeObject(dt));
                    return venda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesativarVenda(Venda dadosVenda)
        {
            try
            {
                var conexao = _dbContext.DbConnection();
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Venda set VendaAtiva = 0 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", dadosVenda.Id);
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
