﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Models
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
