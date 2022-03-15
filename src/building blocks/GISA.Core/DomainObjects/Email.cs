using System.Text.RegularExpressions;

namespace GISA.Core.DomainObjects
{
    public class Email
    {
        private static readonly Regex EmailRegex
            = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$",
                RegexOptions.CultureInvariant | RegexOptions.Compiled);

        public const int EnderecoMaxLength = 150;
        public const int EnderecoMinLength = 5;

        protected Email()
        {
        }

        public Email(string endereco)
        {
            if (!Validar(endereco))
                throw new DomainException("E-mail inválido");

            Endereco = endereco;
        }

        public string Endereco { get; private set; }

        private static bool Validar(string email) => EmailRegex.IsMatch(email);
    }
}