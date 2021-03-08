using Microsoft.EntityFrameworkCore.Migrations;

namespace CompreSuaFruta.Dal.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduto = table.Column<int>(nullable: false),
                    IdVenda = table.Column<int>(nullable: false),
                    QuantidadeProduto = table.Column<int>(nullable: false),
                    ValorUnitario = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVenda", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoVenda");
        }
    }
}
