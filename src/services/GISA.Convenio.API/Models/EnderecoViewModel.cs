using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GISA.Convenio.API.Models
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(9, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Numero { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(2, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Municipio { get; set; }
    }
}
