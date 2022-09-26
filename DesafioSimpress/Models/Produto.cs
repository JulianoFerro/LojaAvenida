using System.ComponentModel.DataAnnotations;

namespace DesafioSimpress.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(250)]
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Perecivel { get; set; }
        public int CategoriaId { get; set; }
        public  Categoria? Categoria { get; set; }
    }
}
