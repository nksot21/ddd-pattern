using DDDParttern.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Helpers
{
    public class ResponseHelper
    {
        public static ResponseModel HandleSuccessResponse(string message, object data) {
            return new ResponseModel { Data = data , Message = message, StatusCode = 200};
        }
        public static ResponseModel HandleErrorResponse(int statusCode, string error)
        {
            return new ResponseModel { StatusCode = statusCode, Error = error };
        }
    }
}
