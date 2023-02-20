using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        [Column("codigo")]
        public int Id { get; set; }

        [MaxLength(150)]
        [Column("nome")]
        public string? Nome { get; set; }

        [MaxLength(255)]
        [Column("url_imagem")]
        public string? UrlImagem { get; set; }

        [Column("valor")]
        public double? Valor { get; set; }

        [Column("descricao", TypeName = "text")]
        public string? Descricao { get; set; }
    }
}