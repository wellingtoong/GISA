using System;

namespace GISA.WebApp.MVC.Models
{
    public class ResponseMessage
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }
        public bool Sucesso { get; set; }
    }
}
