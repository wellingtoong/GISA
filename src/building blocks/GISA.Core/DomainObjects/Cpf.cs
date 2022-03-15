using GISA.Core.Utils;

namespace GISA.Core.DomainObjects
{
    public class Cpf
    {
        private const int CpfMaxLength = 11;

        protected Cpf()
        {
        }

        public Cpf(string numero)
        {
            if (!Validar(numero))
                throw new DomainException("CPF inválido");

            Numero = numero;
        }

        public string Numero { get; private set; }

        private static bool Validar(string cpf)
        {
            cpf = cpf.ApenasNumeros();

            if (cpf.Length > CpfMaxLength)
            {
                return false;
            }

            while (cpf.Length != CpfMaxLength)
            {
                cpf = '0' + cpf;
            }

            var igual = true;
            for (var i = 1; i < CpfMaxLength && igual; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    igual = false;
                }
            }

            if (igual || cpf == "12345678909")
            {
                return false;
            }

            var numeros = new int[11];

            for (var i = 0; i < CpfMaxLength; i++)
            {
                numeros[i] = int.Parse(cpf[i].ToString());
            }

            var soma = 0;
            for (var i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            var resultado = soma % CpfMaxLength;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != CpfMaxLength - resultado)
            {
                return false;
            }

            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += (CpfMaxLength - i) * numeros[i];
            }

            resultado = soma % CpfMaxLength;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else if (numeros[10] != CpfMaxLength - resultado)
            {
                return false;
            }

            return true;
        }
    }
}