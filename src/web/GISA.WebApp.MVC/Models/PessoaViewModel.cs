using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GISA.WebApp.MVC.Models
{
    public class PessoaViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string NomeCompleto { get; set; }

        [MaxLength(12, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Cpf { get; set; }

        [MaxLength(20, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Ativo { get; set; }

        [MaxLength(150, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [DisplayName("Tipo Pessoa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? TipoPessoaEnum { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }

        public PlanoClienteViewModel? PlanoClienteViewModel { get; set; }
    }
}
