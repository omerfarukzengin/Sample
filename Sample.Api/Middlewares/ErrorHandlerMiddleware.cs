using Microsoft.AspNetCore.Http;
using Sample.Shared.Exceptions;
using Sample.Shared.Models.Wrappers;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sample.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = Result.Fail(exception.Message);

                if (exception is AppException appException)
                    response.StatusCode = (int)appException.StatusCode;
                else
                    response.StatusCode = StatusCodes.Status500InternalServerError;

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
