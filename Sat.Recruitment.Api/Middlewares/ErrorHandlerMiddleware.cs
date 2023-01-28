using Microsoft.AspNetCore.Http;
using Sat.Recruitment.Api.Exceptions;
using Sat.Recruitment.Business.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;
        //TODO: Serilog?
        public ErrorHandlerMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var customErrorCode = GetCustomPropertyCode(e);

            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = e switch
            {
                MaxLenghtException or
                EmailFormatException or
                FieldMandatoryException or
                BadHttpRequestException or 
                ArgumentNullException
                => (int)HttpStatusCode.BadRequest,
                EntityNotFoundException => (int)HttpStatusCode.NotFound,
                DuplicateEntityException => (int)HttpStatusCode.Conflict,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var result = JsonSerializer.Serialize(new { message = e?.Message, code = customErrorCode });

            return response.WriteAsync(result);
        }

        /// <summary>
        /// Get "Code" custom property with Reflection
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string GetCustomPropertyCode(Exception error)
        {
            var prop = error.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name == "Code")
                .FirstOrDefault();

            string code = "GENERAL_ERROR";
            if (prop != null)
                code = prop.GetValue(error, null).ToString();

            return code;

        }
    }
}
