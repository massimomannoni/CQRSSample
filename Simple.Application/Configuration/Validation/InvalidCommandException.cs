using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Application.Configuration.Validation
{
    public class InvalidCommandException : Exception
    {
        public string Details { get; }
        public InvalidCommandException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}
