using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GISA.WebApp.MVC.Models
{
    public class PlanoViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Participação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int TipoPlanoEnum { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
