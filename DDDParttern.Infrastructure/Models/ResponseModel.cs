using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Error { get; set; } = null;

        public object Data { get; set; }

        public ResponseModel() { }
        public ResponseModel(int statusCode, string message, string error, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Error = error;
            Data = data;
        }
    }
}
