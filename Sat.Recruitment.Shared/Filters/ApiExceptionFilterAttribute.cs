using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sat.Recruitment.Shared.Models.Exceptions;
using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Shared.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(FluentValidation.ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext> value))
            {
                value.Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = ServiceResult.Failed(ServiceError.DefaultError);

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            if (context.Exception is FluentValidation.ValidationException exception)
            {
                var details = ServiceResult.Failed(exception.Errors, ServiceError.Validation);

                context.Result = new BadRequestObjectResult(details);
            }

            context.ExceptionHandled = true;
        }

        private static void HandleInvalidModelStateException(ExceptionContext context)
        {
            var exception = new ValidateModelException(context.ModelState);

            context.Result = new BadRequestObjectResult(ServiceResult.Failed(exception.Errors, ServiceError.ValidationFormat));

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var details = ServiceResult.Failed(ServiceError.CustomMessage(context.Exception is NotFoundException exception ? exception.Message : ServiceError.NotFound.ToString(), StatusCodes.Status404NotFound));

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var details = ServiceResult.Failed(ServiceError.ForbiddenError);

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var details = ServiceResult.Failed(ServiceError.ForbiddenError);

            context.Result = new UnauthorizedObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
