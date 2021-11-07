using System.ComponentModel;

namespace GISA.Pessoa.API.Enums
{
    public enum StatusPlanoEnum
    {
        [Description("Plano em dia")]
        Ativo,
        [Description("Plano em análise")]
        Suspenso,
        [Description("Ex-cliente")]
        Inativos
    }
}
