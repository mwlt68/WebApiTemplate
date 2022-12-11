using Core.Utilities.Responses;
using Serilog;
using System.Text.Json;

namespace Template.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError,
                };
                var responseModel = new BaseResponseModel<object>(ex.Message);
                Log.Error(ex,ex.Message);
                Console.WriteLine(ex);
                await context.Response.WriteAsync(JsonSerializer.Serialize(responseModel));
            }
        }
    }
}
