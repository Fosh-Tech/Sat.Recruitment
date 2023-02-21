
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sat.Recruitment.Shared.Models.Exceptions
{
    public class ValidateModelException : ModelStateDictionary
    {

        public ValidateModelException()
        {
            Errors = new Dictionary<string, List<string>>();
        }


        public ValidateModelException(ModelStateDictionary modelState)
            : this()
        {
            foreach (string key in modelState.Keys)
            {
                var property = modelState.GetValueOrDefault(key);

                if (property != null)
                {
                    var errors = property.Errors.Select(error => error.ErrorMessage).ToList();

                    Errors.Add(key, errors);
                }
            }
        }

        public ValidateModelException(List<ValidationFailure> validationFailures)
            : this()
        {
            foreach (var validationFailure in validationFailures)
                Errors.Add(validationFailure.PropertyName, new List<string> { validationFailure.ErrorCode, validationFailure.ErrorMessage });
        }

        public IDictionary<string, List<string>> Errors { get; }
    }
}
