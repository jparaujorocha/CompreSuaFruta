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
        private readonly string bancoDeDados = AppDomain.CurrentDomain.BaseDirectory + @"\BdCompreSuaFruta.sqlite";
        public DalHelper()
        { }
        public SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=" + bancoDeDados + "; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(bancoDeDados) == false)
                {
                    SQLiteConnection.CreateFile(bancoDeDados);
                }
                CriarTabelaSQlite();
            }

            catch (Exception ex)
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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Produto(Id int, Nome Varchar(50), Descricao VarChar(80), QuantidadeDisponivel int, Valor Double, ProdutoAtivo Boolean, CaminhoImagem Varchar(200))";
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
                    cmd.CommandText = "DELETE FROM Produto";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo, CaminhoImagem) values (1, 'Maçã', 'Maçã Gala 300g', 100, 23, true, '~/images/maca.jpg')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo, CaminhoImagem) values (2, 'Alface', 'Alface americana 100g', 100, 12, true, '~/images/alface.jpg')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo, CaminhoImagem) values (3, 'Laranja', 'Laranja Pera Rio 100g', 100, 11, true, '~/images/laranja.jpg')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo, CaminhoImagem) values (4, 'Uva', 'Pacote uva fechado 500g', 100, 8, true, '~/images/uva.jpg')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome, Descricao, QuantidadeDisponivel, Valor, ProdutoAtivo, CaminhoImagem) values (5, 'Tomate', 'Tomate 300g', 100, 7, true, '~/images/tomate.jpg')";
                    var teste = cmd.ExecuteNonQuery();

                    sqliteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
