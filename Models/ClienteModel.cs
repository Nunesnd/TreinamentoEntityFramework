using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class ClienteModel
    {
        [Key]
        [Column("Código")]
        public int Id { get; set; }

        [MaxLength(150)]
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Observacoes", TypeName = "text")]
        public string Observacoes { get; set; }

        public ClienteModel(string nome, string observacoes)
        {
            Nome = nome;
            Observacoes = observacoes;
        }


    }
}