using ProductManagement.Api.Common;
using System.Net;
using System.Text.Json;

namespace ProductManagement.Api.MIddleware
{
    public class ExceptionMiddleware
    {


        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger; 
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);


            } 
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Unhandled exception occured "); 

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ApiResponse<object>
                {
                    Success = false,
                    Message= "An Unexpected Errror occured",
                    Errors = new List<string> { ex.Message }
                    

                };

                var json = JsonSerializer.Serialize(response); 
                await context.Response.WriteAsync(json);




            }

        }
    }
}
