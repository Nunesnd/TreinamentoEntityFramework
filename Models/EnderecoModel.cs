using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("Enderecos")]
    public class EnderecoModel
    {
        [Key]
        [Column("codigo")]
        public int Id { get; set; }

        [Column("cep")]
        [MaxLength(9)]
        [Required]
        public string? CEP { get; set; }
        
        [Column("logradouro")]
        [MaxLength(150)]
        [Required]
        public string? Logradouro { get; set; }

        [Column("numero")]
        [MaxLength(10)]
        [Required]
        public string? Numero { get; set; }

        [Column("complemento")]
        [MaxLength(255)]
        public string? Complemento { get; set; }

        [Column("bairro")]
        [MaxLength(90)]
        [Required]
        public string? Bairro { get; set; }

        [Column("cidade")]
        [MaxLength(30)]
        [Required]
        public string? Cidade { get; set; }

        [Column("uf")]
        [MaxLength(2)]
        [Required]
        public string? UF { get; set; }
    }
}