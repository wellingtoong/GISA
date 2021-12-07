using FluentValidation.Results;

namespace GISA.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public bool Sucesso { get; set; }

        public ResponseMessage(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}