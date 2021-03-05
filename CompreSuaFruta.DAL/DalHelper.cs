using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace CompreSuaFruta.Dal
{
    class DalHelper
    {
        private static SQLiteConnection sqliteConnection;
        public DalHelper()
        { }
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\BdCompreSuaFruta.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\dados\BdCompreSuaFruta.sqlite");
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Fruta(Id int, Nome Varchar(50), Descricao VarChar(80), QuantidadeDisponivel int, Valor Double, ProdutoAtivo Boolean)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuario(Id int, Nome Varchar(50), Cpf VarChar(20), Senha Varchar(50))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Venda(Id int, Data Varchar(50), Valor Double, IdUsuario, Status int)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS StatusVenda(Id int, Nome VarChar(20))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StatusVenda";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO StatusVenda(id, Nome) values (1, Finalizada)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO StatusVenda(id, Nome) values (2, Em Andamento)";
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
