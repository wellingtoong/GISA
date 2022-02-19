using System;
using System.ComponentModel.DataAnnotations;

namespace GISA.WebApp.MVC.Models
{
    public class PlanoClienteViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid PlanoId { get; set; }

        public decimal? Desconto { get; set; }

        public decimal? ValorFinal { get; set; }
    }
}
