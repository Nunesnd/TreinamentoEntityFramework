using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class BaseDadosProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_imagem = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<double>(type: "double", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observacoes = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enderecoIdFk = table.Column<int>(type: "int", nullable: false),
                    EnderecoIdNome = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoIdNome",
                        column: x => x.EnderecoIdNome,
                        principalTable: "Enderecos",
                        principalColumn: "codigo");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clienteIdFk = table.Column<int>(type: "int", nullable: false),
                    ClienteIdNome = table.Column<int>(type: "int", nullable: true),
                    enderecoIdFk = table.Column<int>(type: "int", nullable: false),
                    EnderecoIdNome = table.Column<int>(type: "int", nullable: true),
                    valorTotal = table.Column<double>(type: "double", nullable: false),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Pedido_Clientes_ClienteIdNome",
                        column: x => x.ClienteIdNome,
                        principalTable: "Clientes",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_Pedido_Enderecos_EnderecoIdNome",
                        column: x => x.EnderecoIdNome,
                        principalTable: "Enderecos",
                        principalColumn: "codigo");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoIdFk = table.Column<int>(type: "int", nullable: false),
                    PedidoIdNome = table.Column<int>(type: "int", nullable: true),
                    produtoIdFk = table.Column<int>(type: "int", nullable: false),
                    ProdutoIdNome = table.Column<int>(type: "int", nullable: true),
                    valorPedidoProd = table.Column<double>(type: "double", nullable: false),
                    QuantidadePedidoProd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Pedido_PedidoIdNome",
                        column: x => x.PedidoIdNome,
                        principalTable: "Pedido",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Produtos_ProdutoIdNome",
                        column: x => x.ProdutoIdNome,
                        principalTable: "Produtos",
                        principalColumn: "codigo");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoIdNome",
                table: "Clientes",
                column: "EnderecoIdNome");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteIdNome",
                table: "Pedido",
                column: "ClienteIdNome");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EnderecoIdNome",
                table: "Pedido",
                column: "EnderecoIdNome");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_PedidoIdNome",
                table: "PedidosProdutos",
                column: "PedidoIdNome");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_ProdutoIdNome",
                table: "PedidosProdutos",
                column: "ProdutoIdNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProdutos");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
