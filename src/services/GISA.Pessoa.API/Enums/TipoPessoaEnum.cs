using System.ComponentModel;

namespace GISA.Pessoa.API.Enums
{
    public enum TipoPessoaEnum
    {
        [Description("Cliente externo")]
        Associado,
        [Description("Cliente interno")]
        Colaborador
    }
}
