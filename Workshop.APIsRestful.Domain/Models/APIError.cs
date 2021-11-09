using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop.APIsRestful.Domain.Models
{
    public class APIError
    {
        public APIError(string message, string stacktrace)
        {
            Message = message;
            StackTrace = stacktrace;
        }

        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
