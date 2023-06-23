using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Models
{
    public class RequestException : Exception
    {
        public string Error { get; set; }
        public RequestException() { }

        public RequestException(string error) { 
            Error = error;
        }
    }
}
