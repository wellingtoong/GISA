using System;
using System.Collections.Generic;
using System.Text;

namespace GISA.Core.Messages
{
    public class ResponseMessageTeste
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int? Status { get; set; }
        public string TraceId { get; set; } = string.Empty;
        public object Errors { get; set; } = null;
        public bool Sucesso { get; set; } = false;
    }
}
