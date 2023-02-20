using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Servicos.Database
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<ClienteModel> Clientes {get; set;}
        public DbSet<EnderecoModel> Enderecos {get; set;}
        public DbSet<PedidoModel> Pedidos { get; set; }     
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }
        public DbSet<ProdutoModel> Produtos {get; set;}   
    }
}