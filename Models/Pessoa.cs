using System.ComponentModel.DataAnnotations;

namespace CadPessoas.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o Nome")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string? Nome { get; set; }

    }
}
