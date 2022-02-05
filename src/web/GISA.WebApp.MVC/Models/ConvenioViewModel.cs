using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GISA.WebApp.MVC.Models
{
    public class ConvenioViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string NomeFantasia { get; set; }

        [DisplayName("Razão Social")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string RazaoSocial { get; set; }

        [DisplayName("Inscrição Municipal")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string InscricaoMunicipal { get; set; }

        [DisplayName("Inscrição Estadual")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(18, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Cnpj { get; set; }

        [MaxLength(20, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Telefone { get; set; }

        [MaxLength(150, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Ativo { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}
