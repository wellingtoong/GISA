using System;
using System.ComponentModel.DataAnnotations;

namespace GISA.Pessoa.API.Models
{
    public class AgendaViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Key]
        public Guid? IdPessoa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Hora { get; set; }

        public string? Observacao { get; set; }
    }
}
