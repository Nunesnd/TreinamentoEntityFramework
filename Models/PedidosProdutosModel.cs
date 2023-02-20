using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("PedidosProdutos")]
    public class PedidosProdutosModel
    {
        [Key]
        [Column("codigo")]
        public int Id { get; set; }

        [Column("PedidoIdFk")]//Nome da coluna
        public int PedidoId { get; set; }
        [ForeignKey("PedidoIdNome")]//nome da propriedade, não da coluna
        public PedidoModel? Pedido { get; set; }

        [Column("produtoIdFk")]//Nome da coluna
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoIdNome")]//nome da propriedade, não da coluna
        public ProdutoModel? Produto { get; set; }

        [Column("valorPedidoProd")]
        [Required]
        public double? ValorPEdidoProd { get; set; }
        
        [Column("QuantidadePedidoProd")]
        [Required]
        public int? QuantidadePEdidoProd { get; set; }
    }
}