using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("Pedido")]
    public class PedidoModel
    {
        [Key]
        [Column("codigo")]
        public int Id { get; set; }

        [Column("clienteIdFk")]//Nome da coluna
        public int ClienteId { get; set; }
        [ForeignKey("ClienteIdNome")]//nome da propriedade, não da coluna
        public ClienteModel? Cliente { get; set; }

        [Column("enderecoIdFk")]//Nome da coluna
        public int EnderecoId { get; set; }
        [ForeignKey("EnderecoIdNome")]//nome da propriedade, não da coluna
        public EnderecoModel? Endereco { get; set; }

        [Column("valorTotal")]
        [Required]
        public double? ValorTotal { get; set; }

        [Column("data")]
        [Required]
        public DateTime Date { get; set; }

    }
}