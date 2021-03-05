using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace CompreSuaFruta.Dal
{
    public class DalHelper
    {
        private static SQLiteConnection sqliteConnection;
        public DalHelper()
        { }
        public SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\BdCompreSuaFruta.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(@"c:\dados\BdCompreSuaFruta.sqlite") == false)
                {
                    SQLiteConnection.CreateFile(@"c:\dados\BdCompreSuaFruta.sqlite");
                }
                CriarTabelaSQlite();
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Produto(Id int, Nome Varchar(50), Descricao VarChar(80), QuantidadeDisponivel int, Valor Double, ProdutoAtivo Boolean)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuario(Id int, Nome Varchar(50), Cpf VarChar(20), Senha Varchar(50), UsuarioAtivo Boolean)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Venda(Id int, Data DateTime, Valor Double, IdUsuario int, IdStatus int, VendaAtiva Boolean)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS ProdutoCarrinho(Id int, IdProduto int, IdVenda int)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS StatusVenda(Id int, Nome VarChar(20))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StatusVenda";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO StatusVenda(id, Nome) values (1, 'Finalizada')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO StatusVenda(id, Nome) values (2, 'Em Andamento')";
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
