using System.Collections.Generic;

namespace GISA.Core.Messages.Integration
{
    public class ResponseMessageDefault
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string TraceId { get; set; }
        public bool Sucess { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }
}