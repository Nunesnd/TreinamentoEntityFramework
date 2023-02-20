using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        [Column("codigo")]
        public int Id { get; set; }

        [MaxLength(150)]
        [Column("nome")]
        public string? Nome { get; set; }

        [Column("observacoes", TypeName = "text")]
        public string? Observacoes { get; set; }

        [Column("enderecoIdFk")]//Nome da coluna
        public int EnderecoId { get; set; }
        [ForeignKey("EnderecoIdNome")]//nome da propriedade, não da coluna
        public EnderecoModel? Endereco { get; set; }
    }
}