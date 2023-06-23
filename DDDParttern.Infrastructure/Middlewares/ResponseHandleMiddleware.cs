using DDDParttern.Infrastructure.Helpers;
using DDDParttern.Infrastructure.Models;
using Microsoft.AspNetCore.Http;


namespace DDDParttern.Infrastructure.Middlewares
{
    public class ResponseHandleMiddleware
    {
        private readonly RequestDelegate Next;

        public ResponseHandleMiddleware(RequestDelegate next) {  Next = next; }

        public async Task InvokeAsync(HttpContext context)
        {
            try {
                await Next(context);
            }catch(RequestException ex)
            {
                await HandleRequestExceptionAsync(context, ex);
            }catch(Exception) 
            {
                await HandleSystemExceptionAsync(context);
            }
        }

        private static Task HandleRequestExceptionAsync(HttpContext context, RequestException ex)
        {
            ResponseModel badRequest = ResponseHelper.HandleErrorResponse(400, ex.Error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = badRequest.StatusCode;
            return context.Response.WriteAsJsonAsync(badRequest);
        }

        private static Task HandleSystemExceptionAsync(HttpContext context)
        {
            var error = ResponseHelper.HandleErrorResponse(500, "System Error");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.StatusCode;
            return context.Response.WriteAsJsonAsync(error);
        }

    }
}
