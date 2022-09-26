using System.ComponentModel.DataAnnotations;

namespace DesafioSimpress.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(250)]
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Produto>? Produto { get; set; }

    }
}
